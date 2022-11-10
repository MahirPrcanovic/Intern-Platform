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
import { SelectionsAddPageComponent } from './pages/selections-add-page/selections-add-page.component';
import { SelectionEditPageComponent } from './pages/selection-edit-page/selection-edit-page.component';
import { SelectionsDetailsPageComponent } from './pages/selections-details-page/selections-details-page.component';
import { AddApplicantToSelectionPageComponent } from './pages/add-applicant-to-selection-page/add-applicant-to-selection-page.component';
import { ApplicationHeroComponent } from './components/applications-page/hero-section/application-hero/application-hero.component';
import { ErrorPageComponent } from './pages/error-page/error-page/error-page.component';

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

    children: [
      { path: '', component: ApplicationHeroComponent },
      {
        path: 'edit/:id',
        component: ApplicationEditComponent,
        canActivate: [AuthGuardService],
      },
    ],
  },
  {
    path: 'applicationForm',
    component: ApplicationFormPageComponent,
  },

  {
    path: 'selections',
    component: SelectionsPageComponent,
    canActivate: [AuthGuardService],
  },

  {
    path: 'selections/addNewSelection',
    component: SelectionsAddPageComponent,
    canActivate: [AuthGuardService],
  },

  {
    path: 'selections/edit/:id',
    component: SelectionEditPageComponent,
    canActivate: [AuthGuardService],
  },

  {
    path: 'selections/details/:id',
    component: SelectionsDetailsPageComponent,
    canActivate: [AuthGuardService],
  },

  {
    path: 'selections/addToSelection/:selectionId',
    component: AddApplicantToSelectionPageComponent,
    canActivate: [AuthGuardService],
  },

  {
    path: 'users',
    component: UsersPageComponent,
    canActivate: [AuthGuardService],
  },
  { path: '**', component: ErrorPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
