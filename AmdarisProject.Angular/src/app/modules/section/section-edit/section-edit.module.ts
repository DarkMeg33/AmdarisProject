import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionEditComponent } from './section-edit.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    SectionEditComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    SectionEditComponent
  ]
})
export class SectionEditModule { }
