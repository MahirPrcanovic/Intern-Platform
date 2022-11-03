import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login-page/login.component';
import { AppComponent } from './app.component';
import { ApplicationFormPageComponent } from './pages/application-form-page/application-form-page.component';

const routes: Routes = [
  { path: '', component: LandingPageComponent, pathMatch: 'full' },
   {
    path : 'login' , 
    component : LoginComponent
  },
  {
    path : 'applicationForm' , 
    component : ApplicationFormPageComponent
  },
  
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
