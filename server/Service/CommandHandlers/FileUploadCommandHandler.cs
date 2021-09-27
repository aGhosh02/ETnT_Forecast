using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Common.Commands;
using Common.Models;
using DataAccess.Abstractions;
using DataAccess.DbSets;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace Service.CommandHandlers
{
    public class FileUploadCommandHandler : INotificationHandler<FileUploadCommand>
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IRequestHandler<AddUpdateForecastCommand, object> _forecastRequestHandler;
        private readonly ILookupRepository _repository;

        public FileUploadCommandHandler(
            IRequestHandler<AddUpdateForecastCommand, object> forecastRequestHandler,
            ILookupRepository repository,
            IWebHostEnvironment environment)
        {
            _forecastRequestHandler = forecastRequestHandler;
            _repository = repository;
            _environment = environment;
        }

        public async Task Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            await _repository.AddTaskAsync(new EventData
            {
                Id = request.Id,
                FileName = request.FileName,
                Status = EventStatus.Started.ToString()
            });
            // await _repository.UpdateTaskStatusAsync(request.Id, EventStatus.Started);
            try
            {
                using var package = new ExcelPackage();
                await using (var stream =
                    File.OpenRead(Path.Combine(_environment.ContentRootPath, "uploads", request.FileName)))
                {
                    await package.LoadAsync(stream, cancellationToken);
                }

                var worksheet = package.Workbook.Worksheets[0];
                var row = 2;
                var forecast = new List<ForecastCommand>();
                while (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Value?.ToString()))
                {
                    for (var i = 1; i <= (worksheet.Dimension.Columns - 9) / 12; i++)
                        forecast.Add(new ForecastCommand
                        {
                            Org = worksheet.Cells[row, 2].Text,
                            Manager = worksheet.Cells[row, 3].Text,
                            USFocal = worksheet.Cells[row, 4].Text,
                            Project = worksheet.Cells[row, 5].Text,
                            SkillGroup = worksheet.Cells[row, 6].Text,
                            Business = worksheet.Cells[row, 7].Text,
                            Capability = worksheet.Cells[row, 8].Text,
                            Chargeline = worksheet.Cells[row, 9].Text,
                            ForecastConfidence = worksheet.Cells[row, 10].Text,
                            Comments = worksheet.Cells[row, 11 * i].Text,
                            Jan = Convert.ToDecimal(worksheet.Cells[row, 12 * i].Text),
                            Feb = Convert.ToDecimal(worksheet.Cells[row, 13 * i].Text),
                            Mar = Convert.ToDecimal(worksheet.Cells[row, 14 * i].Text),
                            Apr = Convert.ToDecimal(worksheet.Cells[row, 15 * i].Text),
                            May = Convert.ToDecimal(worksheet.Cells[row, 16 * i].Text),
                            June = Convert.ToDecimal(worksheet.Cells[row, 17 * i].Text),
                            July = Convert.ToDecimal(worksheet.Cells[row, 18 * i].Text),
                            Sep = Convert.ToDecimal(worksheet.Cells[row, 19 * i].Text),
                            Oct = Convert.ToDecimal(worksheet.Cells[row, 20 * i].Text),
                            Nov = Convert.ToDecimal(worksheet.Cells[row, 21 * i].Text),
                            Dec = Convert.ToDecimal(worksheet.Cells[row, 22 * i].Text),
                            Year = Convert.ToInt32(
                                $"{DateTime.Today.Year.ToString().Substring(0, 2)}{worksheet.Cells[1, 12 * i].Text.Split("-")[1]}")
                        });

                    row++;
                }

                var response = await _forecastRequestHandler.Handle(new AddUpdateForecastCommand {Forecasts = forecast},
                    cancellationToken);


                if (response is int)
                {
                    await _repository.UpdateTaskStatusAsync(request.Id, EventStatus.Completed);
                    File.Delete(Path.Combine(_environment.ContentRootPath, "uploads", request.FileName));
                }
                
                else
                    await _repository.UpdateTaskStatusAsync(request.Id, EventStatus.Failed,
                        JsonConvert.SerializeObject(request));
            }
            catch (Exception ex)
            {
                await _repository.UpdateTaskStatusAsync(request.Id, EventStatus.Failed,
                    $"Message: {ex.Message} Stacktrace: {ex.StackTrace}");
            }
        }
    }
}