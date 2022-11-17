import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionViewComponent } from './section-view.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { ListItemViewComponent } from 'src/app/common/components/list-item-view/list-item-view.component';
import { RoomViewModule } from '../../room/room-view/room-view.module';
import { SectionEditModule } from '../section-edit/section-edit.module';



@NgModule({
  declarations: [
    SectionViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ListItemViewComponent,
    RoomViewModule,
    SectionEditModule
  ],
  exports: [
    SectionViewComponent
  ]
})
export class SectionViewModule { }
