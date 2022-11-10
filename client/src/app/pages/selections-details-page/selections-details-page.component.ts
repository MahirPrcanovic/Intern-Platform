import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  })
}
}