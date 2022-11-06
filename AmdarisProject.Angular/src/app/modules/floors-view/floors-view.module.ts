import { ListItemViewComponent } from './../list-item-view/list-item-view.component';
import { AngularMaterialModule } from './../angular-material/angular-material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FloorsViewComponent } from './floors-view.component';



@NgModule({
  declarations: [
    FloorsViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ListItemViewComponent
  ],
  exports: [
    FloorsViewComponent
  ]
})
export class FloorsViewModule { }
