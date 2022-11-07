import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SelectionsService } from 'src/app/services/selections.service';
import { Subscription } from 'rxjs';
import { NgForm } from '@angular/forms';
interface Selekcija {
  id:string;
  name: string;
  startDate: Date;
  endDate: Date;
  description: string;
}
@Component({
  selector: 'app-selection-edit-page',
  templateUrl: './selection-edit-page.component.html',
  styleUrls: ['./selection-edit-page.component.css']
})


export class SelectionEditPageComponent implements OnInit,OnDestroy {

  constructor(
    private selectionService: SelectionsService,
    private route: ActivatedRoute
  ) {}


  selectionId:string = '';
  /*selectionData: Selection = {
    Name: 'string',
    StartDate: new Date,
    EndDate: new Date,
    Description: 'string'
  };*/

  @ViewChild('selectionsForm') form!: NgForm; 
  data : Selekcija[] = [];
 
  
  ngSelect!: string;
  paramsSubscribition!: Subscription;

  ngOnInit(): void {
  this.paramsSubscribition = this.route.params.subscribe((params)=>{
    this.selectionId = params['id'];
  });
  /*this.selectionService
  .updateSelection(this.selectionData, this.selectionId)
  .subscribe((res: any) =>{
    console.log(res);
    this.selectionData = res.data;
    
  });*/
}
onEditClicked(id : string){
  const [routerLink]="['/selections', 'edit', selekcija.id]";
  let currentSelection = this.data.find((sel) => { return sel.id === id} );

  this.form.setValue({
    selectionName:currentSelection?.name,
    selectionStartDate:currentSelection?.startDate,
    selectionEndDate:currentSelection?.endDate,
    selectionDescription:currentSelection?.description
  });
  
}
  onSubmit(form: NgForm){
    console.log(form.form.value);
  }

  ngOnDestroy(): void {
    this.paramsSubscribition.unsubscribe();
  }
 
  }


