import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { WeatherForcast } from './components/WeatherForecast'
import { Counter } from './components/Counter';

import './custom.css'

const forecastProvider = async location => await fetch(`weatherforecast?location=${encodeURI(location)}`)
  .then(response => response.json());

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/weather' render={() => <WeatherForcast forecastProvider={forecastProvider} />} />
      </Layout>
    );
  }
}
