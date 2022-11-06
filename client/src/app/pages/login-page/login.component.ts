import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subject } from 'rxjs';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  User: Subject<{ Id: string; userName: string }> = new Subject();
  constructor(private loginService: LoginService) {}

  ngOnInit(): void {}
  onSubmit(f: NgForm) {
    console.log(f.form.value);
    let user = {
      userName: f.form.value.userName,
      password: f.form.value.password,
      rememberMe: f.form.value.rememberMe,
    };
    this.loginService.login(user).subscribe((response) => {
      console.log(response);
    });
  }
}
