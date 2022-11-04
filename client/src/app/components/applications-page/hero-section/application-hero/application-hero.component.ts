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
