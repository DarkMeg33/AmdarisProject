import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomEditComponent } from './room-edit.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    RoomEditComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    RoomEditComponent
  ]
})
export class RoomEditModule { }
