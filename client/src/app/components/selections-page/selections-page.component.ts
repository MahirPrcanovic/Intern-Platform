import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Selection } from 'src/app/models/Selection';
import { SelectionsService } from 'src/app/services/selections.service';
import { NgForm } from '@angular/forms';
import { Sort } from '@angular/material/sort';
import { ButttonTextComponent } from '../buttton-type.component';
interface Selekcija {
  id: string;
  name: string;
  startDate: Date;
  endDate: Date;
  description: string;
}

@Component({
  selector: 'app-selections-page',
  templateUrl: './selections-page.component.html',
  styleUrls: ['./selections-page.component.css'],
})
export class SelectionsPageComponent implements OnInit, OnDestroy {
  queryParams = {
    pageNumber: 1,
    pageSize: 5,
    sort: '',
    filterBy: '',
  };
  public classRef = ButttonTextComponent;
  sortedData:Selekcija[] = [];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private selectionService: SelectionsService,

  ) {}
  params: { [key: string]: string | number } = {};
  DUMMYDATA: Selection[] = [];
  gridSort = ""; 


  pagesNumber!: number;
  currentPage = 1;
  qParamsSubscribition!: Subscription;
  numberOfPostsToFetch = 5;
  ngOnInit(): void {
    this.qParamsSubscribition = this.route.queryParams.subscribe(
      (qParams: Params) => {
        this.queryParams.pageNumber = qParams['pageNumber'] || 1;
        this.queryParams.pageSize = qParams['pageSize'] || 5;
        this.queryParams.sort = qParams['sort'];
        this.queryParams.filterBy = qParams['filterBy'];
        this.fetchSelections();
      }
    );

  }
  fetchSelections() {
    this.selectionService
      .getAllSelections(this.queryParams)
      .subscribe((response: any) => {
        this.sortedData = response.data;
        this.currentPage = 1;
        this.pagesNumber = response.pagesCount;
      });
      
  }

  sortData(sort: Sort) {
      this.gridSort =  sort.direction;
      this.queryParams.sort = sort.direction;
      this.fetchSelections();
  }



  goToPreviousPage() {
    if (this.queryParams.pageNumber === 1) {
      return;
    } else {
      this.queryParams.pageNumber -= 1;
      this.fetchSelections();
    }
  }

  goNextPage() {
    if (this.queryParams.pageNumber === this.pagesNumber) {
      return;
    } else {
      this.queryParams.pageNumber = +this.queryParams.pageNumber + 1;
      this.fetchSelections();
    }
  }

  formSubmit(f: NgForm) {
    // console.log(f.form.value);
    const reqParams: { [key: string]: string | number } = {};
    if (f.form.value.filterBy != '') {
      this.queryParams.filterBy = f.form.value.filterBy;
      reqParams['filterBy'] = f.form.value.filterBy;
    }
    if (f.form.value.sort != '') {
      this.queryParams.sort = f.form.value.sort;
      reqParams['sort'] = f.form.value.sort;
    }
    if(this.gridSort != ''){      
      this.queryParams.sort = this.gridSort;
      reqParams['sort'] = this.gridSort;
    }

    reqParams['pageNumber'] = 1;
    this.params = reqParams;
    this.router.navigate(['/selections'], {
      queryParams: reqParams,
    });
  }

  getParams(num: number) {
    return { ...this.params, pageNumber: num };
  }

  ngOnDestroy(): void {
    this.qParamsSubscribition.unsubscribe();
  }
}
