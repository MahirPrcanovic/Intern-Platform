import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ApplicationsService } from 'src/app/services/applications.service';

@Component({
  selector: 'app-application-form-page',
  templateUrl: './application-form-page.component.html',
  styleUrls: ['./application-form-page.component.css'],
})
export class ApplicationFormPageComponent implements OnInit {
  constructor(
    private router: Router,
    private http: HttpClient,
    private applicationService: ApplicationsService
  ) {}
  formValid = true;
  loading = false;
  submitted = false;
  message = '';
  ngOnInit(): void {}
  onSubmit(f: NgForm) {
    this.loading = true;
    // console.log(f);
    if (!f.valid) {
      this.submitted = true;
      this.formValid = false;
      this.loading = false;
      return;
    }
    this.applicationService.postData(f.form.value).subscribe(
      (response) => {
        this.submitted = f.submitted;
        this.formValid = f.form.valid;
        this.loading = false;
        // console.log(response);
      },
      (error) => {
        this.loading = false;
        this.message = error.statusText;
        this.submitted = f.submitted;
        this.formValid = false;
        // console.log(error);
      }
    );
  }
  resetForm() {
    this.formValid = true;
    this.submitted = false;
  }
  goHome() {
    this.router.navigate(['/']);
  }
}
