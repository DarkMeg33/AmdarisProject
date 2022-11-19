import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomDataViewComponent } from './room-data-view.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';



@NgModule({
  declarations: [
    RoomDataViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule
  ],
  exports: [
    RoomDataViewComponent
  ]
})
export class RoomDataViewModule { }
