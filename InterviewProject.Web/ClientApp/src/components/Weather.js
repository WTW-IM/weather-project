import React from "react";
import Autocomplete from "react-autocomplete";
import { WeatherApiInstance } from "../service/WeatherApiService";
import useDebounce from "./debounce/DebounceHook";
import { Row, Col } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes } from "@fortawesome/free-solid-svg-icons";
import { AuthServiceInstance } from '../service/AuthService';
import { AxiosLoadingRenderProps } from './axios/Wrapper';

export function Weather(props) {
  const [query, saveQuery] = React.useState("");
  const [locations, saveLocations] = React.useState([]);
  const [forecasts, saveForecasts] = React.useState([]);
  const [isAuthorized, saveIsAuthorized] = React.useState(false);

  React.useEffect(() => {
   
    if (!isAuthorized) {
      const checkAuth = async () => {
        AuthServiceInstance.registerLoginCallback(user => {
          if (user && user.access_token) {
            saveIsAuthorized(true);
          }
        });
        await AuthServiceInstance.authGuard();
      };
      checkAuth();
    }

  }, [isAuthorized]);

  const formatTemp = temp => {
    return Math.round(temp);
  };

  const convertToFahrenheit = temp => {
    return temp * 1.8 + 32;
  };

  const renderForecasts = () => {
    let content;
    if (forecasts && forecasts.length > 0) {
      content = (
        <table className="table table-striped" aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Date</th>
              <th>Temp. (C)</th>
              <th>Temp. (F)</th>
              <th>Summary</th>
            </tr>
          </thead>
          <tbody>
            {forecasts.map(forecast => (
              <tr key={forecast.applicable_date}>
                <td>{forecast.displayDate}</td>
                <td>{formatTemp(forecast.the_temp)}</td>
                <td>{formatTemp(convertToFahrenheit(forecast.the_temp))}</td>
                <td>{forecast.weather_state_name}</td>
              </tr>
            ))}
          </tbody>
        </table>
      );
    }
    return content;
  };

  const clearSearch = e => {
    e.preventDefault();
    saveQuery("");
    saveLocations([]);
    saveForecasts([]);
  };

  const debouncedSearch = useDebounce(query, 20);

  return (
    <div>
      <AxiosLoadingRenderProps/>
      <Row>
        <Col>
          <h1 id="tabelLabel">Weather Forecast</h1>
          <p>This component fetches weather data from metaweather.com</p>
        </Col>
      </Row>
      <Row>
        <Col>
          <label htmlFor="locations-autocomplete">Search for a city:</label>
        </Col>
        <Col>
          <Autocomplete
            className="w-100"
            inputProps={{
              id: "locations-autocomplete",
              style: { width: "100%" }
            }}
            wrapperStyle={{
              position: "relative",
              display: "inline-block",
              width: "100%"
            }}
            value={query}
            items={locations}
            getItemValue={item => item.title}
            onSelect={async (value, item) => {
              const forecast = await WeatherApiInstance.getForecast(item.woeid);
              saveForecasts(forecast.consolidated_weather);
              saveQuery(value);
              saveLocations([item]);
            }}
            onChange={async (event, value) => {
              saveQuery(value);
              saveLocations([]);
              saveForecasts([]);
              if (debouncedSearch && debouncedSearch.length > 1) {
                const items = await WeatherApiInstance.locationSearch(value);
                if (items) {
                  saveLocations(items);
                }
              }
            }}
            renderMenu={children => <div className="menu">{children}</div>}
            renderItem={(item, isHighlighted) => {
              return (
                <div
                  style={{ background: isHighlighted ? "lightgray" : "white" }}
                >
                  {item.title}
                </div>
              );
            }}
          />
        </Col>
        <Col>
          <a className="float-left" onClick={clearSearch}>
            <FontAwesomeIcon icon={faTimes} />
          </a>
        </Col>
      </Row>
      <Row className="pt-5">
        <Col>{renderForecasts()}</Col>
      </Row>
    </div>
  );
}