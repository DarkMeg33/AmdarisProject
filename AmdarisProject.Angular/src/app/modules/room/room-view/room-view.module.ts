import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomViewComponent } from './room-view.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { ListItemViewComponent } from 'src/app/common/components/list-item-view/list-item-view.component';



@NgModule({
  declarations: [
    RoomViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ListItemViewComponent
  ],
  exports: [
    RoomViewComponent
  ]
})
export class RoomViewModule { }
