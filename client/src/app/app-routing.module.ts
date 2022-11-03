import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login-page/login.component';

const routes: Routes = [
  {
    path : 'login' , 
    component : LoginComponent
  },
 
{ path: '', component: LandingPageComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
