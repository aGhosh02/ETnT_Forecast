using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Service.Abstractions;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public ForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForecast()
        {
            return Ok(await _forecastService.GetAllForecast());
        }

        [HttpGet]
        [Route("GetAllFore")]
        public async Task<IActionResult> GetAllFore()
        {
            var c =
                "[{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Java FullStack\",\"Business Unit\":\"BGS\",\"Capability\":\"Training Solutions\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Java Full Stack\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Cloud Tech(AWS,Azure,GCP,Openshift,Kubernettes,REST API,WebServices)\",\"Business Unit\":\"BGS\",\"Capability\":\"Training Solutions\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Cloud\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Scrum Master Scaled Agile Roles\",\"Business Unit\":\"BGS\",\"Capability\":\"Training Solutions\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Agile\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Java FullStack\",\"Business Unit\":\"BGS\",\"Capability\":\"Crew Management\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Java Full Stack \",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Scrum Master Scaled Agile Roles\",\"Business Unit\":\"BGS\",\"Capability\":\"Crew Management\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Agile\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Product OwnerSME\",\"Business Unit\":\"BGS\",\"Capability\":\"Crew Management\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Product Owner\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Java FullStack\",\"Business Unit\":\"BGS\",\"Capability\":\"Training Solutions\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Java Full Stack \",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Scrum Master Scaled Agile Roles\",\"Business Unit\":\"BGS\",\"Capability\":\"Training Solutions\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Agile\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"Automation Test tools(SeleniumProtractorTest  complete etc)\",\"Business Unit\":\"BGS\",\"Capability\":\"Aviation Parts Marketplace Ecommerce\",\"Forecast Confidence\":\"Soft Commitment\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"ETL tools (Informatica, Talend, ODI, BODS, Pentaho Kettle..),\",\"Business Unit\":\"BGS\",\"Capability\":\"Aviation Parts Marketplace Ecommerce\",\"Forecast Confidence\":\"Soft Commitment\",\"Comments\":\"Skill Group: Informatica\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"DevOps Tools(Jenkins, Bamboo etc)\",\"Business Unit\":\"BGS\",\"Capability\":\"Aviation Parts Marketplace Ecommerce\",\"Forecast Confidence\":\"Soft Commitment\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"},{\"ET&T Org\":\"Aviation Biz Ops(BGS)\",\"Manager\":\"<First Name> <Last Name>\",\"US Focal\":\"<First Name> <Last Name>\",\"Project \":\"<Project Name>\",\"Skill Group\":\"ERP and CRM Tools (SAPSAP Hybris and others)\",\"Business Unit\":\"BGS\",\"Capability\":\"Aviation Parts Marketplace Ecommerce\",\"Forecast Confidence\":\"Soft Commitment\",\"Jan\":\"0.001\",\"Feb\":\"0.001\",\"Mar\":\"0.001\",\"Apr\":\"0.001\",\"May\":\"0.001\",\"Jun\":\"0.001\",\"July\":\"0.001\",\"Aug\":\"0.001\",\"Sep\":\"0.001\",\"Oct\":\"0.001\",\"Nov\":\"0.001\",\"Dec\":\"0.001\"}]";
            var json = JArray.Parse(c);
            return Ok(c);
        }
    }
}