import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FloorEditComponent } from './floor-edit.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    FloorEditComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    FloorEditComponent
  ]
})
export class FloorEditModule { }
