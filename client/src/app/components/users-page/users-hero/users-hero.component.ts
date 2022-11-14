import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
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
  constructor(private usersService: UserService, private router: Router) {}
  loading = false;
  notFound = false;
  data: User[] = [];
  error: boolean = false;
  submitted: boolean = false;
  deletionSuccess: boolean = false;
  deletionActivated: boolean = false;
  ngOnInit(): void {
    this.loading = true;
    this.fetchData();
  }
  fetchData() {
    this.usersService.getAllUsers().subscribe(
      (response: any) => {
        this.data = response.data;
        this.loading = false;
      },
      (error) => {
        this.loading = false;
        this.notFound = true;
        if (error == 'Error: 403') {
          this.router.navigate(['/applications']);
        }
      }
    );
  }
  deleteUser(id: string) {
    // console.log(id);
    this.deletionActivated = true;
    this.usersService.deleteUser(id).subscribe(
      (response: any) => {
        // console.log(response);
        if (response.success) {
          this.deletionSuccess = true;
          this.data = this.data.filter((obj) => obj.id !== id);
        } else {
          this.deletionSuccess = false;
        }
      },
      (error) => {
        // console.log(error);
      }
    );
    setTimeout(() => {
      this.deletionActivated = false;
      this.deletionSuccess = false;
    }, 3000);
  }
  addUser(form: NgForm) {
    this.submitted = true;
    const obj = {
      userName: form.form.value.userName,
      password: form.form.value.password,
      email: form.form.value.email,
    };
    // console.log(form.form.value.password);
    this.usersService.addUser(obj).subscribe(
      (response: any) => {
        // console.log(response);
        if (!response.success) {
          this.error = true;
        } else {
          this.error = false;
          const user = {
            id: response.data,
            userName: obj.userName,
          };
          this.data.push(user);
        }
      },
      (error) => {
        this.error = true;
      }
    );
    setTimeout(() => {
      this.error = false;
      this.submitted = false;
      form.resetForm();
    }, 3000);
  }
}
