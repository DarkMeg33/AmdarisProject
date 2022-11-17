import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomViewComponent } from './room-view.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { ListItemViewComponent } from 'src/app/common/components/list-item-view/list-item-view.component';
import { DeleteBtnComponent } from 'src/app/common/components/delete-btn/delete-btn.component';
import { RoomEditModule } from '../room-edit/room-edit.module';



@NgModule({
  declarations: [
    RoomViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    DeleteBtnComponent,
    RoomEditModule
  ],
  exports: [
    RoomViewComponent
  ]
})
export class RoomViewModule { }
