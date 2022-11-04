import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Application } from 'src/app/models/Application';

@Component({
  selector: 'app-application-hero',
  templateUrl: './application-hero.component.html',
  styleUrls: ['./application-hero.component.css'],
})
export class ApplicationHeroComponent implements OnInit, OnDestroy {
  constructor(private route: ActivatedRoute, private router: Router) {}

  DUMMYDATA: Application[] = [];
  pagesNumber!: number;
  currentPage = 1;
  qParamsSubscribition!: Subscription;
  numberOfPostsToFetch = 10;
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
        2,
        'Adna',
        'Salcin',
        'adnasalcin@etf.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        3,
        'Mahir',
        'Prcanovic',
        'mahir.prcanovic.20@size.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        4,
        'Adna',
        'Salcin',
        'adnasalcin@etf.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        5,
        'Mahir',
        'Prcanovic',
        'mahir.prcanovic.20@size.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        6,
        'Adna',
        'Salcin',
        'adnasalcin@etf.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        7,
        'Mahir',
        'Prcanovic',
        'mahir.prcanovic.20@size.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        8,
        'Adna',
        'Salcin',
        'adnasalcin@etf.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        9,
        'Mahir',
        'Prcanovic',
        'mahir.prcanovic.20@size.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
      new Application(
        10,
        'Adna',
        'Salcin',
        'adnasalcin@etf.ba',
        'Bachelor',
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        'Lorem ipsum Lorem ipsum Lorem ipsum',
        'Applied'
      ),
    ];
    console.log(this.DUMMYDATA.length / 5);
    this.pagesNumber = this.DUMMYDATA.length / 5;
  }
  goPreviousPage() {
    if (+this.currentPage === 1) {
      return;
    } else {
      this.router.navigate(['/applications'], {
        queryParams: { page: this.currentPage - 1 },
      });
    }
  }
  goNextPage() {
    if (+this.currentPage === this.pagesNumber) {
      return;
    } else {
      this.router.navigate(['/applications'], {
        queryParams: { page: +this.currentPage + 1 },
      });
    }
  }
  ngOnDestroy(): void {
    this.qParamsSubscribition.unsubscribe();
  }
}
