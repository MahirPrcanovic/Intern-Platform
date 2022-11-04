import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-application-form-page',
  templateUrl: './application-form-page.component.html',
  styleUrls: ['./application-form-page.component.css'],
})
export class ApplicationFormPageComponent implements OnInit {
  constructor(private router: Router) {}
  formValid = true;
  submitted = false;
  ngOnInit(): void {}
  onSubmit(f: NgForm) {
    console.log(f);
    this.submitted = f.submitted;
    this.formValid = f.form.valid;
  }
  resetForm() {
    this.formValid = true;
    this.submitted = false;
  }
  goHome() {
    this.router.navigate(['/']);
  }
}
