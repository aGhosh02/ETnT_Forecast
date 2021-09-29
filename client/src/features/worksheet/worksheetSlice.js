import {createAsyncThunk, createSlice, PayloadAction} from "@reduxjs/toolkit";
import _ from "lodash";
import api from "../../utils/api";
import {FORECAST, LOOKUP, UPLOAD} from "../../utils/endpoints";

let cancelToken;
const INITIAL_VALUE = {
    forecast: null,
    selectedYear: null,
    orgs: [],
    users: [],
    projects: [],
    skills: [],
    business: [],
    capabilities: [],
    forecastConfidence: [],
    fyYears: [],
}

export const getForecast = createAsyncThunk(
    "forecast/get",
    async (selectedFyYear) => {
        const response = await api.get(FORECAST + "/" + selectedFyYear);
        return response.data.result;
    }
)

export const getLookupData = createAsyncThunk(
    "forecast/lookup",
    async () => {
        const response = await api.get(LOOKUP);
        return response.data.result;
    }
)

export const uploadForecast = createAsyncThunk("forecast/upload",
    async (file) => {
        const formData = new FormData();
        formData.append("file", file);
        const response = await api.post(UPLOAD, formData, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
        return response.data.result;
    })

export const saveForecast = createAsyncThunk("forecast/save",
    async (_, thunkAPI) => {
        debugger;
        const response = await api.post(
            FORECAST,
            JSON.stringify(
                {
                    forecasts: thunkAPI.getState().worksheet.forecast
                        .filter(x => x.isEdited)
                        .map(x => ({...x, year: thunkAPI.getState().worksheet.selectedYear}))
                }));
        return response.data.result;
    })

export const worksheetSlice = createSlice({
    name: "forecast",
    initialState: INITIAL_VALUE,
    reducers: {
        setColValue: (state, action) => {
            const rowId = action.payload.id;
            const forecast = state.forecast.filter(x => x.id == rowId)[0];
            if(['chargeLine','comments'].includes(action.payload.key)){
                forecast[action.payload.key] = action.payload.value;
            }
            else {
                forecast[action.payload.key] = parseInt(action.payload.value);
            }
            forecast["isEdited"] = true;
        },
        setSelectedYear: (state, action) => {
            state.selectedYear = action.payload;
        }
    },
    extraReducers: {
        [getForecast.fulfilled]: (state, action) => {
            state.forecast = action.payload;
        },
        [getLookupData.fulfilled]: (state, action) => {
            state.orgs = action.payload.orgs;
            state.users = action.payload.users;
            state.projects = action.payload.projects;
            state.skills = action.payload.skills;
            state.business = action.payload.business;
            state.capabilities = action.payload.capabilities;
            state.forecastConfidence = action.payload.forecastConfidence;
            state.fyYears = action.payload.fyYears;
            const currentYearIndex = state.fyYears.indexOf(new Date().getFullYear())
            state.selectedYear = currentYearIndex > -1 ? state.fyYears[currentYearIndex] : _.last(state.fyYears)
        }
    }
});

export const {setColValue, setSelectedYear} = worksheetSlice.actions;
export const selectForecast = (state) => state.worksheet.forecast;
export const selectFyYears = (state) => state.worksheet.fyYears;
export const selectSelectedYear = (state) => state.worksheet.selectedYear;
export const selectOrgs = (state) => state.worksheet.orgs;
export const selectUsers = (state) => state.worksheet.users;
export const selectProjects = (state) => state.worksheet.projects;
export const selectSkills = (state) => state.worksheet.skills;
export const selectBusiness = (state) => state.worksheet.business;
export const selectCapability = (state) => state.worksheet.capabilities;
export const selectCategory = (state) => state.worksheet.forecastConfidence;
export default worksheetSlice.reducer;