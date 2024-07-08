import { Component, OnInit } from '@angular/core';
import { ForecastService } from './services/forecast.service';
import { ForecastModel } from './forecast.model';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrl: './forecast.component.scss'
})
export class ForecastComponent implements OnInit{
  items: ForecastModel[] = [];
  constructor(private forecastService: ForecastService){}
  ngOnInit(): void {
    this.forecastService.getForecasts().subscribe((forecasts: any) => {
      this.items = [...forecasts];
    });
  }

}
