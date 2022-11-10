import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AddSelection } from 'src/app/models/AddSelection';
import { Selection } from 'src/app/models/Selection';
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
    private datePipe: DatePipe
     
  ) {}

  selectionFormValid = true;
  loading = false;
  submitted = false;
  message = '';

  addSelection = new FormGroup({
    name: new FormControl('name'),
    startDate :  new FormControl('startDate'),
    endDate :  new FormControl('endDate'),
    description :  new FormControl('description'),
     
  });

  ngOnInit(): void {
  }



   AddData(){

    if(!this.addSelection.valid){
      this.submitted = true;
      this.selectionFormValid = false;
      this.loading = false;
      return;
    }
    this.selectionService.postData(
      new AddSelection(
      this.addSelection.get('name')!.value!,
      new Date(this.addSelection.get('startDate')!.value!),
      new Date(this.addSelection.get('endDate')!.value!),
      this.addSelection.get('description')!.value!)).subscribe((result  : any) => {
        this.submitted = true;
        this.selectionFormValid = true;
        this.loading = false;
      })
      

    
   }

  resetForm(){
    this.selectionFormValid = true;
    this.submitted = false;
  }

  goHome() {
    this.router.navigate(['/selections']);
  }


}
