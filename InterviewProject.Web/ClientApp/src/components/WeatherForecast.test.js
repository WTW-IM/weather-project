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

test("displays an error when the search fails", async () => {
    const forecastProvider = () => Promise.reject();
    const { getByText, getByPlaceholderText } = render(<WeatherForcast forecastProvider={forecastProvider} />);

    fireEvent.change(getByPlaceholderText("City"), { target: { value: "Honolulu" } });

    getByText("Get Forecast").click();
    await waitForDomChange();

    expect(getByText("Unable to load forecast for \"Honolulu\".")).toBeDefined();
});

test("does not search when city is blank (and the search button is therefor disabled)", async () => {
    let forecastWasRequested = false;
    const forecastProvider = () => {
        forecastWasRequested = true;
        return Promise.resolve([]);
    };
    const { getByText, getByPlaceholderText } = render(<WeatherForcast forecastProvider={forecastProvider} />);

    fireEvent.change(getByPlaceholderText("City"), { target: { value: "  " } });

    getByText("Get Forecast").click();

    expect(forecastWasRequested).toBe(false);
});