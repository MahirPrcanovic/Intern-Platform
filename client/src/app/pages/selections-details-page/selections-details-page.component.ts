import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { FullSelection } from 'src/app/interfaces/FullSelection';
import { Application } from 'src/app/models/Application';
import { SelectionsService } from 'src/app/services/selections.service';

@Component({
  selector: 'app-selections-details-page',
  templateUrl: './selections-details-page.component.html',
  styleUrls: ['./selections-details-page.component.css']
})
export class SelectionsDetailsPageComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private selectionService: SelectionsService,
    private toast: NgToastService,
  ) { }

data:FullSelection  = {
  id: '',
  name: '',
  startDate: new Date(),
  endDate: new Date(),
  description: '',
  comments: [],
  applications: []
};

deleted : boolean = false;

  ngOnInit(): void {
    this.selectionService.getSingleSelection(this.route.snapshot.params['id']).subscribe((result : any) =>{
      this.data = result.data;
      console.log(result);

      
    });
}

deleteApplicant(selectionId: string, applicationsid: string){
  this.selectionService.deleteApplicantFromSelection(selectionId,applicationsid).subscribe((result : any) =>{
    console.log('Deleted user');
    this.deleted = true;
    this.toast.success({detail:'Success Message', summary:'You added new applicant to selection.', position:'tr', duration:5000, sticky:false});

      }, err =>{
        this.toast.error({detail:'Fail Message', summary:'Error happend please try again.', position:'tr', duration:5000, sticky:false});
      }
  );
}
}