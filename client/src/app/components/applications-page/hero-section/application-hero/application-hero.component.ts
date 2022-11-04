import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';
import { Application } from 'src/app/models/Application';

@Component({
  selector: 'app-application-hero',
  templateUrl: './application-hero.component.html',
  styleUrls: ['./application-hero.component.css'],
})
export class ApplicationHeroComponent implements OnInit, OnDestroy {
  constructor(private route: ActivatedRoute) {}

  DUMMYDATA: Application[] = [];
  pagesNumber!: number;
  currentPage = 1;
  qParamsSubscribition!: Subscription;
  ngOnInit(): void {
    this.currentPage = this.route.snapshot.queryParams['page'];
    this.qParamsSubscribition = this.route.queryParams.subscribe(
      (qParams: Params) => {
        this.currentPage = qParams['page'];
      }
    );
    this.DUMMYDATA = [
      new Application(
        1,
        'Mahir',
        'Prcanovic',
        'mahir.prcanovic.20@size.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        1,
        'Adna',
        'Salcin',
        'adnasalcin@etf.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
    ];
    this.pagesNumber = this.DUMMYDATA.length;
  }
  ngOnDestroy(): void {
    this.qParamsSubscribition.unsubscribe();
  }
}
