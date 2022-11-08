import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/users.service';
interface User {
  id: string;
  userName: string;
}
@Component({
  selector: 'app-users-hero',
  templateUrl: './users-hero.component.html',
  styleUrls: ['./users-hero.component.css'],
})
export class UsersHeroComponent implements OnInit {
  constructor(private usersService: UserService) {}
  data: User[] = [];
  ngOnInit(): void {
    this.fetchData();
  }
  fetchData() {
    this.usersService.getAllUsers().subscribe((response: any) => {
      this.data = response.data;
    });
  }
  deleteUser(id: string) {
    this.usersService.deleteUser(id).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
