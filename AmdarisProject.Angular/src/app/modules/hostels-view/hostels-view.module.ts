import { ListItemViewComponent } from './../list-item-view/list-item-view.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HostelsViewComponent } from './hostels-view.component';
import { AngularMaterialModule } from '../angular-material/angular-material.module';
import { FloorsViewModule } from '../floors-view/floors-view.module';



@NgModule({
  declarations: [
    HostelsViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    FloorsViewModule,
    ListItemViewComponent
  ],
  exports: [
    HostelsViewComponent
  ]
})
export class HostelsViewModule { }
