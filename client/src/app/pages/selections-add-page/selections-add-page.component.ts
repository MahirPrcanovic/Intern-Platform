import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SelectionsService } from 'src/app/services/selections.service';


@Component({
  selector: 'app-selections-add-page',
  templateUrl: './selections-add-page.component.html',
  styleUrls: ['./selections-add-page.component.css']
})
export class SelectionsAddPageComponent implements OnInit {
  

  constructor(
    private router: Router,
    private selectionService: SelectionsService,
    private http : HttpClient,
     
  ) {}

  selectionFormValid = true;
  loading = false;
  submitted = false;
  message = '';

  ngOnInit(): void {
  }

  onSubmit(f : NgForm) {
    this.loading = true;
    console.log("Adna on submit:");
    console.log(f);
    if(!f.valid){
      this.submitted = true;
      this.selectionFormValid = false;
      this.loading = false;
      return;
    }

    this.selectionService.postData(f.form.value).subscribe(
        (response) =>{
          this.submitted = f.submitted;
          this.selectionFormValid = f.form.valid;
          this.loading = false;
          console.log(response);
        },
        (error) =>{
          this.loading = false;
          this.message = error.statusText;
          this.submitted = f.submitted;
          console.log(error);
        }

    );
  }
  resetForm(){
    this.selectionFormValid = true;
    this.submitted = false;
  }

  goHome() {
    this.router.navigate(['/selections']);
  }

}
