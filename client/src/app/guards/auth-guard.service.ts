import { Injectable } from '@angular/core';
import { Router, CanActivate, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../services/login.service';
@Injectable({
  providedIn: 'root',
})
export class AuthGuardService implements CanActivate {
  constructor(public loginService: LoginService, public router: Router) {}
  canActivate():
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    if (!this.loginService.isAuthenticated()) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
