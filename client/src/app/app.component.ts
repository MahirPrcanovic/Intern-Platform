import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'client';
  constructor(private http: HttpClient) {}
  ngOnInit() {
    AOS.init();
    this.http
      .get('https://localhost:7213/WeatherForecast')
      .subscribe((data) => console.log(data));
  }
}
