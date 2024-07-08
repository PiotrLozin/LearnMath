import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  constructor(private httpClient: HttpClient) { }

  getForecasts(){
    return this.httpClient.get("http://localhost:5074/WeatherForecast");
  }
}
