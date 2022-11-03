import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login-page/login.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: '', component: LandingPageComponent, pathMatch: 'full' },
   {
    path : 'login' , 
    component : LoginComponent
  },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
