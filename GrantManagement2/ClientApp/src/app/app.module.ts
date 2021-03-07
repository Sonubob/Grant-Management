import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { HomeModule } from '../app/home/home.module';
import { ApplicantModule } from '../app/applicant/applicant.module';
import { ErrorDetailsComponent } from '../app/error-details/error-details.component';

import { AppComponent } from './app.component';

//import { NavMenuComponent } from './nav-menu/nav-menu.component';
//import { HomeComponent } from './home/home.component';
//import { CounterComponent } from './counter/counter.component';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { CoreItemsModule } from './core-items/core-items.module';


//import { AdminModule } from './admin/admin.module';



@NgModule({
  declarations: [
    AppComponent,

    //  HomeComponent,
    //CounterComponent,
    ErrorDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HomeModule, 
    AppRoutingModule,
    ApplicantModule,
    BrowserAnimationsModule, MatFormFieldModule, MatCardModule, CoreItemsModule
 //, AdminModule  
  ],
  exports: [ErrorDetailsComponent],
  //providers: [
  //  { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } }
  //],
  bootstrap: [AppComponent]
})

//export function getBaseUrl(): string {
//  return AppConstants.baseUrl;
//}
export class AppModule {


}
