import React, { useState } from 'react'
import { TextInput } from './TextInput'
import { Button } from './Button'
import './WeatherForecast.css'

export function WeatherForcast(props) {
    const [city, setCity] = useState("");
    const [forecasts, setForecasts] = useState(null);
    const getForecast = async () => setForecasts(await props.forecastProvider(city));

    return <div>
        <form onSubmit={getForecast}>
            <div className="forecast-search">
                <TextInput autofocus placeholder="City" value={city} onChange={setCity} />
                <Button
                    type="submit"
                    onClick={getForecast}
                    className="btn btn-primary forecast-search-button"
                    runningDisplay={<i>Loading...</i>}>
                    Get Forecast
                </Button>
            </div>
        </form>

        {forecasts && <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>}
    </div>
}