import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SelectionsService } from 'src/app/services/selections.service';
import { FormControl, FormGroup } from '@angular/forms';
import { DatePipe } from '@angular/common';
import {Selection} from 'src/app/models/Selection'


@Component({
  selector: 'app-selection-edit-page',
  templateUrl: './selection-edit-page.component.html',
  styleUrls: ['./selection-edit-page.component.css']
})
export class SelectionEditPageComponent implements OnInit {

  constructor(
    private selectionService: SelectionsService,
    private route: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe
  ) {}

  editSelection = new FormGroup({
    name: new FormControl('name'),
    startDate :  new FormControl('startDate'),
    endDate :  new FormControl('endDate'),
    description :  new FormControl('description'),
  });

  updated : boolean = false;

  ngOnInit(): void {
    this.selectionService.getSingleSelection(this.route.snapshot.params['id']).subscribe((result : any) =>{
      
      this.editSelection = new FormGroup({
         name: new FormControl(result.data.name),
         startDate :  new FormControl(this.datePipe.transform(result.data.startDate,'yyyy-MM-dd')),
         endDate :  new FormControl(this.datePipe.transform(result.data.endDate,'yyyy-MM-dd')),
         description :  new FormControl(result.data.description),
       });
  
    
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
    })
}
   
  }
