import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
// import { Login } from './auth/auth.service';
import { LoginService } from '../services/login.service';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs';
import { pipe } from 'rxjs';
import { Router } from '@angular/router';
// import { Observable } from 'rxjs/Observable';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(public logService: LoginService, private router: Router) {}
  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.logService.getToken()}`,
      },
    });
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMsg = '';
        if (error.error instanceof ErrorEvent) {
        } else {
          if (error.status == 401) {
            localStorage.clear();
            this.router.navigate(['/login']);
          }
          if (error.status == 403) {
            errorMsg = '403';
          }
        }
        console.log(errorMsg);
        return throwError(() => new Error(errorMsg));
      })
    );
  }
}
