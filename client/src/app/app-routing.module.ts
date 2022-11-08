import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login-page/login.component';
import { ApplicationsPageComponent } from './pages/applications-page/applications-page/applications-page.component';
import { ApplicationFormPageComponent } from './pages/application-form-page/application-form-page.component';
import { ApplicationEditComponent } from './components/application-edit/application-edit/application-edit.component';
import { SelectionsPageComponent } from './components/selections-page/selections-page.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { UsersPageComponent } from './pages/users-page/users-page/users-page.component';

const routes: Routes = [
  { path: '', component: LandingPageComponent, pathMatch: 'full' },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'applications',
    component: ApplicationsPageComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'applications/edit/:id',
    component: ApplicationEditComponent,
    canActivate: [AuthGuardService],
  },

  {
    path: 'applicationForm',
    component: ApplicationFormPageComponent,
  },

  { path: 'selections', component: SelectionsPageComponent },
  { path: 'users', component: UsersPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
