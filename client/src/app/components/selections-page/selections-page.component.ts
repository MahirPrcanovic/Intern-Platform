import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Selection } from 'src/app/models/Selection';


@Component({
  selector: 'app-selections-page',
  templateUrl: './selections-page.component.html',
  styleUrls: ['./selections-page.component.css']
})
export class SelectionsPageComponent implements OnInit, OnDestroy {
  constructor(private route: ActivatedRoute, private router: Router) {}
  Datum : Date = new Date();
  DUMMYDATA: Selection[] = [];
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
      new Selection(
        1,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        2,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        3,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        4,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        5,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        6,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        7,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        8,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        9,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
      new Selection(
        10,
        'Interns2022',
        this.Datum,
        this.Datum,
        'Lorem ipsum  Lorem ipsum Lorem ipsum Lorem ipsum',
        
      ),
     
   
    ];
    console.log(this.DUMMYDATA.length / 5);
    this.pagesNumber = this.DUMMYDATA.length / 5;
  }
  goPreviousPage() {
    if (+this.currentPage === 1) {
      return;
    } else {
      this.router.navigate(['/selections'], {
        queryParams: { page: this.currentPage - 1 },
      });
    }
  }
  goNextPage() {
    if (+this.currentPage === this.pagesNumber) {
      return;
    } else {
      this.router.navigate(['/selections'], {
        queryParams: { page: +this.currentPage + 1 },
      });
    }
  }
  ngOnDestroy(): void {
    this.qParamsSubscribition.unsubscribe();
  }
}

