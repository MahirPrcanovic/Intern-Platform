import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Application } from 'src/app/models/Application';
import { ApplicationsService } from 'src/app/services/applications.service';
import { NgForm } from '@angular/forms';
import { Applicant } from 'src/app/interfaces/Applicant';

@Component({
  selector: 'app-application-hero',
  templateUrl: './application-hero.component.html',
  styleUrls: ['./application-hero.component.css'],
})
export class ApplicationHeroComponent implements OnInit, OnDestroy {
  queryParams = {
    page: 1,
    pageSize: 10,
    sortBy: null,
    filter: null,
    filterType: null,
  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private applicationService: ApplicationsService
  ) {}
  params: { [key: string]: string | number } = {};
  DUMMYDATA: Application[] = [];
  data: Applicant[] = [];
  pagesNumber!: number;
  currentPage = 1;
  qParamsSubscribition!: Subscription;
  numberOfPostsToFetch = 10;
  ngOnInit(): void {
    // this.currentPage = this.route.snapshot.queryParams['page'];
    this.qParamsSubscribition = this.route.queryParams.subscribe(
      (qParams: Params) => {
        // this.currentPage = qParams['page'];
        this.queryParams.page = qParams['page'] || 1;
        // console.log(qParams['page'] || 1);
        this.queryParams.pageSize = qParams['pageSize'] || 10;
        this.queryParams.sortBy = qParams['sortBy'];
        this.queryParams.filter = qParams['filter'];
        this.queryParams.filterType = qParams['filterType'];
        console.log(this.queryParams);
        this.fetchApplications();
      }
    );
  }
  fetchApplications() {
    this.applicationService
      .getAllApplications(this.queryParams)
      .subscribe((response: any) => {
        this.data = response.data;
        this.currentPage = 1;
        console.log(response);
        this.pagesNumber = response.pagesCount;
      });
  }
  goPreviousPage() {
    if (this.queryParams.page === 1) {
      return;
    } else {
      this.queryParams.page -= 1;
      this.fetchApplications();
    }
  }
  goNextPage() {
    if (this.queryParams.page === this.pagesNumber) {
      return;
    } else {
      this.queryParams.page = +this.queryParams.page + 1;
      this.fetchApplications();
    }
  }
  formSubmit(f: NgForm) {
    console.log(f.form.value);
    this.queryParams.filterType = f.form.value.filterType;
    const reqParams: { [key: string]: string | number } = {};
    console.log(f.form.value.filterType);
    this.queryParams.sortBy = f.form.value.sortBy;
    if (f.form.value.filter != '') {
      this.queryParams.filter = f.form.value.filter;
      // reqParams['page'] = 1;
      reqParams['filter'] = f.form.value.filter;
    }
    if (f.form.value.sortBy != '') {
      this.queryParams.sortBy = f.form.value.sortBy;
      reqParams['sortBy'] = f.form.value.sortBy;
    }
    if (f.form.value.filterType != '') {
      this.queryParams.filterType = f.form.value.filterType;
      reqParams['filterType'] = f.form.value.filterType;
    }
    reqParams['page'] = 1;
    this.params = reqParams;
    this.router.navigate(['/applications'], {
      queryParams: reqParams,
    });
  }
  getParams(num: number) {
    return { ...this.params, page: num };
  }
  ngOnDestroy(): void {
    this.qParamsSubscribition.unsubscribe();
  }
}
