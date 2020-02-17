import { axiosInstance } from "../components/axios/Wrapper";

export default class WeatherApi {

    getForecast = async (cityCode) => {
        try {
            const requestUrl = encodeURI(`/api/WeatherForecast/${cityCode}`);
            const response = await axiosInstance.get(requestUrl)
            return response.data;    
        } catch(e) {
            console.log(e);
        }
    }

    locationSearch = async (query) => {
        try {
            const requestUrl = encodeURI(`/api/WeatherForecast/location-search/${query}`);
            const response = await axiosInstance.get(requestUrl)            
            return response.data;    
        } catch(e) {
            console.log(e);
        }
    }
}

export const WeatherApiInstance = new WeatherApi();
