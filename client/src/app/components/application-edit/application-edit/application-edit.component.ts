import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FullApplication } from 'src/app/interfaces/FullApplication';
import { ApplicationsService } from 'src/app/services/applications.service';

@Component({
  selector: 'app-application-edit',
  templateUrl: './application-edit.component.html',
  styleUrls: ['./application-edit.component.css'],
})
export class ApplicationEditComponent implements OnInit, OnDestroy {
  constructor(
    private applicationService: ApplicationsService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  formValid = true;
  loading = false;
  submitted = false;
  successfull = false;
  message = '';
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
    this.paramsSubscribition = this.route.params.subscribe((params) => {
      // console.log(params['id']);
      this.applicationId = params['id'];
    });
    this.applicationService
      .getSingleApplication(this.applicationId)
      .subscribe((res: any) => {
        console.log(res);
        this.applicationData = res.data;
        this.ngSelect = this.applicationData.status || '';
      });
  }
  onSubmit(form: NgForm) {
    this.loading = true;
    this.submitted = true;
    console.log(form.form.value);
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
    this.router.navigate(['applications']);
  }
  tryAgain() {
    this.submitted = false;
    this.loading = false;
    this.successfull = false;
  }
  addComment(f: NgForm) {
    console.log(f.form.value.comment);
    this.applicationService
      .addApplicationComment(this.applicationId, f.form.value.comment)
      .subscribe((response) => {
        console.log(response);
      });
  }
  ngOnDestroy(): void {
    this.paramsSubscribition.unsubscribe();
  }
}
