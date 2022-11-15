import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { ButttonTextComponent } from 'src/app/components/buttton-type.component';
import { AddSelection } from 'src/app/models/AddSelection';
import { SelectionsService } from 'src/app/services/selections.service';


@Component({
  selector: 'app-selections-add-page',
  templateUrl: './selections-add-page.component.html',
  styleUrls: ['./selections-add-page.component.css']
})
export class SelectionsAddPageComponent implements OnInit {
  
  public classRef = ButttonTextComponent;

  constructor(
    private router: Router,
    private selectionService: SelectionsService,
    private toast: NgToastService,
     
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
        this.toast.success({detail:'Success Message', summary:'You succesfully edited selection.', position:'tr', duration:4000, sticky:false});
     this.goHome();
      }, err =>{
      this.toast.error({detail:'Fail Message', summary:'Error happend please try again.', position:'tr', duration:4000, sticky:false});
    }
      
      )
      

    
   }



  goHome() {
    this.router.navigate(['/selections']);
  }


}
