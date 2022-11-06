import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Application } from 'src/app/models/Application';
import { ApplicationsService } from 'src/app/services/applications.service';
interface Applicant {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  educationLevel: string;
  status: string;
}

@Component({
  selector: 'app-application-hero',
  templateUrl: './application-hero.component.html',
  styleUrls: ['./application-hero.component.css'],
})
export class ApplicationHeroComponent implements OnInit, OnDestroy {
  queryParams = {
    page: 1,
    pageSize: 1,
    sortBy: null,
    filter: null,
  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private applicationService: ApplicationsService
  ) {}

  DUMMYDATA: Application[] = [];
  data: Applicant[] = [];
  pagesNumber!: number;
  currentPage = 1;
  qParamsSubscribition!: Subscription;
  numberOfPostsToFetch = 10;
  ngOnInit(): void {
    this.currentPage = this.route.snapshot.queryParams['page'];
    this.qParamsSubscribition = this.route.queryParams.subscribe(
      (qParams: Params) => {
        this.currentPage = qParams['page'];
        this.queryParams.page = qParams['page'];
        this.queryParams.pageSize = qParams['pageSize'];
        this.queryParams.sortBy = qParams['sortBy'];
        this.queryParams.filter = qParams['filter'];
        this.fetchApplications();
      }
    );
  }
  fetchApplications() {
    console.log(this.queryParams);
    this.applicationService
      .getAllApplications(this.queryParams)
      .subscribe((response: any) => {
        this.data = response.data;
        this.currentPage = 1;
        console.log(response);
        this.pagesNumber = response.pagesCount;
      });
  }
  loadPage(num: number) {
    // this
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
  ngOnDestroy(): void {
    this.qParamsSubscribition.unsubscribe();
  }
}
