import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './components/header/header.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login-page/login.component';

import { HeroSectionComponent } from './components/landing-page/hero-section/hero-section/hero-section.component';
import { SelectionSectionComponent } from './components/landing-page/selection-section/selection-section.component';
import { SubscribeSectionComponent } from './components/landing-page/subscribe-section/subscribe-section.component';
import { FooterComponent } from './components/footer/footer/footer.component';

import { DashboardHeaderComponent } from './components/applications-page/header/dashboard-header/dashboard-header.component';
import { ApplicationsPageComponent } from './pages/applications-page/applications-page/applications-page.component';
import { ApplicationHeroComponent } from './components/applications-page/hero-section/application-hero/application-hero.component';
import { ApplicationFormPageComponent } from './pages/application-form-page/application-form-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplicationEditComponent } from './components/application-edit/application-edit/application-edit.component';
import { SelectionEditPageComponent } from './pages/selection-edit-page/selection-edit-page.component';
import { SelectionsPageComponent } from './components/selections-page/selections-page.component';
import { SelectionsAddPageComponent } from './pages/selections-add-page/selections-add-page.component';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { UsersPageComponent } from './pages/users-page/users-page/users-page.component';
import { UsersHeroComponent } from './components/users-page/users-hero/users-hero.component';
import { DatePipe } from '@angular/common';
import { SelectionsDetailsPageComponent } from 'src/app/pages/selections-details-page/selections-details-page.component';
import { AddApplicantToSelectionPageComponent } from './pages/add-applicant-to-selection-page/add-applicant-to-selection-page.component';
import { ErrorPageComponent } from './pages/error-page/error-page/error-page.component';
import { ErrorHeroComponent } from './components/error-page/error-hero/error-hero/error-hero.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgToastModule} from 'ng-angular-popup';
import {MatSortModule} from '@angular/material/sort';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    LandingPageComponent,
    HeroSectionComponent,
    SelectionSectionComponent,
    SubscribeSectionComponent,
    FooterComponent,
    ApplicationFormPageComponent,
    DashboardHeaderComponent,
    ApplicationsPageComponent,
    ApplicationHeroComponent,
    ApplicationEditComponent,
    SelectionEditPageComponent,
    SelectionsPageComponent,
    SelectionsAddPageComponent,
    UsersPageComponent,
    UsersHeroComponent,
    SelectionsDetailsPageComponent,
    AddApplicantToSelectionPageComponent,
    ErrorPageComponent,
    ErrorHeroComponent,
    
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgToastModule,
    MatSortModule,
    
  ],
  providers: [
    DatePipe,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
