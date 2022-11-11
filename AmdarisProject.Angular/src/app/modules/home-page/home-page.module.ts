import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './home-page.component';
import { FormsModule } from '@angular/forms';
import { AngularMaterialModule } from '../angular-material/angular-material.module';
import { HostelsViewModule } from '../hostel/hostels-view/hostels-view.module';



@NgModule({
  declarations: [
    HomePageComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    AngularMaterialModule,
    HostelsViewModule
  ],
  exports: [
    HomePageComponent
  ]
})
export class HomePageModule { }
