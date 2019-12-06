import React from 'react'
import { render, waitForDomChange, fireEvent } from '@testing-library/react'
import { WeatherForcast } from './WeatherForecast'

test("displays the forecast based on the user search", async () => {
    const firstDayForecast = {
        "date": "2019-12-06T00:00:00",
        "temperatureC": 25,
        "temperatureF": 76,
        "summary": "Light Rain"
    };
    const forecastProvider = (location) => location === "Honolulu" && Promise.resolve([
        firstDayForecast
    ]);
    const { getByText, getByPlaceholderText } = render(<WeatherForcast forecastProvider={forecastProvider} />);

    fireEvent.change(getByPlaceholderText("City"), { target: { value: "Honolulu" } });

    getByText("Get Forecast").click();
    await waitForDomChange();

    expect(getByText(firstDayForecast.date)).toBeDefined();
    expect(getByText(firstDayForecast.summary)).toBeDefined();
    expect(getByText(firstDayForecast.temperatureC.toString())).toBeDefined();
    expect(getByText(firstDayForecast.temperatureF.toString())).toBeDefined();
});

test("displays the an error when the search fails", async () => {
    const forecastProvider = () => Promise.reject();
    const { getByText, getByPlaceholderText } = render(<WeatherForcast forecastProvider={forecastProvider} />);

    fireEvent.change(getByPlaceholderText("City"), { target: { value: "Honolulu" } });

    getByText("Get Forecast").click();
    await waitForDomChange();

    expect(getByText("Unable to load forecast for \"Honolulu\".")).toBeDefined();
});