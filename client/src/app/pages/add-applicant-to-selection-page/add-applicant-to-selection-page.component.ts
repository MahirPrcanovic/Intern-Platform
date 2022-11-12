import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { Subscription } from 'rxjs/internal/Subscription';
import { FullSelection } from 'src/app/interfaces/FullSelection';
import { Application } from 'src/app/models/Application';
import { ApplicationsService } from 'src/app/services/applications.service';
import { SelectionsService } from 'src/app/services/selections.service';
interface Applicant {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  educationLevel: string;
  status: string;
}
@Component({
  selector: 'app-add-applicant-to-selection-page',
  templateUrl: './add-applicant-to-selection-page.component.html',
  styleUrls: ['./add-applicant-to-selection-page.component.css'],
})
export class AddApplicantToSelectionPageComponent implements OnInit {
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
    private selectionService: SelectionsService,
    private applicationService: ApplicationsService,
    private toast: NgToastService,
  ) {}

  data: FullSelection = {
    id: '',
    name: '',
    startDate: new Date(),
    endDate: new Date(),
    description: '',
    comments: [],
    applications: [],
  };

  applicantForSelection: Application = {
    Id: '',
    firstName: '',
    lastName: '',
    Email: '',
    EducationLevel: '',
    CoverLetter: '',
    CV: '',
    Status: '',
  };
  applicantsInSelection: Applicant[] = [];
  pagesNumber!: number;
  currentPage = 1;
  qParamsSubscribition!: Subscription;
  numberOfPostsToFetch = 5;
  params: { [key: string]: string | number } = {};

  added: boolean = false;

  ngOnInit(): void {
    this.selectionService
      .getSingleSelection(this.route.snapshot.params['selectionId'])
      .subscribe((result: any) => {
        this.data = result.data;
      });
      this.qParamsSubscribition = this.route.queryParams.subscribe(
        (qParams: Params) => {
          this.queryParams.page = qParams['page'] || 1;
        
          this.queryParams.pageSize = qParams['pageSize'] || 10;
          this.queryParams.sortBy = qParams['sortBy'];
          this.queryParams.filter = qParams['filter'];
          this.queryParams.filterType = qParams['filterType'];
      this.fetchApplicants();
        }
      );
   
  }

  fetchApplicants(){
    this.applicationService
    .getAllApplications(this.queryParams)
    .subscribe((response: any) => {
      this.applicantsInSelection = response.data;
      this.currentPage = 1;
      this.pagesNumber = response.pagesCount;
      // console.log(response);
    });
  }

  addApplicantToSelection(id: string) {
    this.applicationService
      .getSingleApplication(id)
      .subscribe((result: any) => {
        this.applicantForSelection = result.data;
      });
    this.selectionService
      .addApplicantToSelection(
        this.route.snapshot.params['selectionId'],
        id,
        this.applicantForSelection
      )
      .subscribe((result: any) => {
        this.toast.success({detail:'Success Message', summary:'You added new applicant to selection.', position:'tr', duration:5000, sticky:false});

      }, err =>{
        this.toast.error({detail:'Fail Message', summary:'Error happend please try again.', position:'tr', duration:5000, sticky:false});
      }

      );
  
  }

  goToPreviousPage() {
    if (this.queryParams.page === 1) {
      return;
    } else {
      this.queryParams.page -= 1;
      this.fetchApplicants();
    }
  }

  goNextPage() {
    if (this.queryParams.page === this.pagesNumber) {
      return;
    } else {
      this.queryParams.page = +this.queryParams.page + 1;
      this.fetchApplicants();
    }
  }
  getParams(num: number) {
    return { ...this.params, page: num };
  }
}
