import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  User: Subject<{ token: string; userName: string }> = new Subject();
  constructor(private loginService: LoginService, private router: Router) {}
  error = '';
  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      this.router.navigate(['/applications']);
    }
  }
  onSubmit(f: NgForm) {
    // console.log(f.form.value);
    let user = {
      userName: f.form.value.userName,
      password: f.form.value.password,
      rememberMe: f.form.value.rememberMe || false,
    };
    this.loginService.login(user).subscribe(
      (response: any) => {
        // console.log(response);
        this.error = '';
        this.User.next({ token: response.token, userName: response.userName });
        localStorage.setItem('token', response.token);
        this.router.navigate(['/applications']);
      },
      (error) => {
        this.error = 'Username or password are incorrect!';
      }
    );
  }
}
