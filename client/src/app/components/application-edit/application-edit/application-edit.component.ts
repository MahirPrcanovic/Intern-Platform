import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
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
    private route: ActivatedRoute
  ) {}
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
    console.log(form.form.value);
  }
  ngOnDestroy(): void {
    this.paramsSubscribition.unsubscribe();
  }
}
