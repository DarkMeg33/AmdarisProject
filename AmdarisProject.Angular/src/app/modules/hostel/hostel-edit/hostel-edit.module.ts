import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HostelEditComponent } from './hostel-edit.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    HostelEditComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    HostelEditComponent
  ]
})
export class HostelEditModule { }
