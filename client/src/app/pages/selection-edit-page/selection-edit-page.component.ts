import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SelectionsService } from 'src/app/services/selections.service';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { DatePipe, formatDate } from '@angular/common';
import {Selection} from 'src/app/models/Selection'
import { NgToastService } from 'ng-angular-popup';
import {ButttonTextComponent} from 'src/app/components/buttton-type.component';

@Component({
  selector: 'app-selection-edit-page',
  templateUrl: './selection-edit-page.component.html',
  styleUrls: ['./selection-edit-page.component.css']
})
export class SelectionEditPageComponent implements OnInit {

  public classRef = ButttonTextComponent;

  constructor(
    private selectionService: SelectionsService,
    private route: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe,
    private toast: NgToastService,
  ) {}


  editSelection = new FormGroup({
    name: new FormControl('name'),
    startDate :  new FormControl('startDate'),
    endDate :  new FormControl('endDate'),
    description :  new FormControl('description'),
     
  
  });
  

  updated : boolean = false;
  acomments: any[] = [];
  selection: any;
 

  ngOnInit(): void {
    this.selectionService.getSingleSelection(this.route.snapshot.params['id']).subscribe((result : any) =>{
      console.log("datum");
      console.log(result.data.startDate);
      this.selection = result.data;
      this.editSelection = new FormGroup({
         name: new FormControl(result.data.name),
         startDate :  new FormControl(formatDate(result.data.startDate, 'yyyy-MM-dd', 'en')),
         endDate :  new FormControl(formatDate(result.data.endDate, 'yyyy-MM-dd', 'en')),
         description :  new FormControl(result.data.description),
       });
        this.acomments = result.data.selectionComments;
        console.log(this.editSelection.value.startDate);
        console.log("Acomments niz");
        console.log(this.acomments);
    
    });
}




EditData(){   
  this.selectionService.updateSelection(this.route.snapshot.params['id'],
  new Selection(this.route.snapshot.params['id'], 
    this.editSelection.get('name')!.value!, 
    new Date(this.editSelection.get('startDate')!.value!),
    new Date(this.editSelection.get('endDate')!.value!),
    this.editSelection.get('description')!.value!)).subscribe((result : any) =>{
      this.updated = true;
      this.toast.success({detail:'Success Message', summary:'You succesfully edited selection.', position:'tr', duration:4000, sticky:false});
    }, err =>{
    this.toast.error({detail:'Fail Message', summary:'Error happend please try again.', position:'tr', duration:4000, sticky:false});
  }
    );
}
   
addComment(f: NgForm) {

  this.selectionService
    .addSelectionComment(this.route.snapshot.params['id'], f.form.value.comment)
    .subscribe((response : any ) => {
   
     this.acomments.push(response.value.data);
    
      
    });
}
  }
