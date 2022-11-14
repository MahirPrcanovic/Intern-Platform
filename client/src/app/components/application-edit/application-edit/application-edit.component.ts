import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FullApplication } from 'src/app/interfaces/FullApplication';
import { ApplicationsService } from 'src/app/services/applications.service';
import { ApplicantComment } from 'src/app/interfaces/ApplicantComment';
import { FullSelection } from 'src/app/interfaces/FullSelection';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-application-edit',
  templateUrl: './application-edit.component.html',
  styleUrls: ['./application-edit.component.css'],
})
export class ApplicationEditComponent implements OnInit, OnDestroy {
  constructor(
    private applicationService: ApplicationsService,
    private route: ActivatedRoute,
    private router: Router,
    private toast: NgToastService
  ) {}
  formValid = true;
  loading = false;
  submitted = false;
  successfull = false;
  noApplicant = false;
  message = '';
  acomments: ApplicantComment[] = [];
  selections: FullSelection[] = [];
  applicationId: string = '';

  applicationData: FullApplication = {
    firstName: 'string',
    lastName: 'string',
    email: 'string',
    educationLevel: 'string',
    coverLetter: 'string',
    cv: 'string',
    comments: [],
    selections: [],
    status: 'string',
    id: 'string',
  };
  ngSelect!: string;
  paramsSubscribition!: Subscription;
  ngOnInit(): void {
    this.loading = true;
    this.paramsSubscribition = this.route.params.subscribe((params) => {
      this.applicationId = params['id'];
    });
    this.fetchData(this.applicationId);
  }
  fetchData(applicationId: string) {
    this.applicationService.getSingleApplication(this.applicationId).subscribe(
      (res: any) => {
        this.applicationData = res.data;
        this.acomments = this.applicationData.comments;
        this.selections = this.applicationData.selections;
        this.ngSelect = this.applicationData.status || '';
        this.loading = false;
      },
      (error) => {
        this.loading = false;
        this.noApplicant = true;
      }
    );
  }
  onSubmit(form: NgForm) {
    this.loading = true;
    this.submitted = true;
    // console.log(form.form.value);
    this.applicationService
      .updateApplication(this.applicationId, form.form.value.status)
      .subscribe(
        (res: any) => {
          this.loading = false;
          this.successfull = res.success;
        },
        (error) => {
          this.loading = false;
          this.successfull = false;
          this.message = error.message;
        }
      );
  }
  goBack() {
    this.submitted = false;
    this.loading = false;
    this.successfull = false;
  }
  tryAgain() {
    this.submitted = false;
    this.loading = false;
    this.successfull = false;
  }
  addComment(f: NgForm) {
    // console.log(f.form.value.comment);

    this.applicationService
      .addApplicationComment(this.applicationId, f.form.value.comment)
      .subscribe(
        (response) => {
          // console.log(response);
          this.fetchData(this.applicationId);
          this.toast.success({
            detail: 'Success Message',
            summary: 'You succesfully added a comment.',
            position: 'tr',
            duration: 4000,
            sticky: false,
          });
        },
        (error) => {
          this.toast.error({
            detail: 'Error!',
            summary: 'Comment was not added.',
            position: 'tr',
            duration: 4000,
            sticky: false,
          });
        }
      );
  }
  ngOnDestroy(): void {
    this.paramsSubscribition.unsubscribe();
  }
}
