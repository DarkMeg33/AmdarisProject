import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FloorsViewComponent } from './floors-view.component';
import { ListItemViewComponent } from '../../../common/components/list-item-view/list-item-view.component';
import { SectionViewModule } from '../../section/section-view/section-view.module';
import { FloorEditModule } from '../floor-edit/floor-edit.module';



@NgModule({
  declarations: [
    FloorsViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    ListItemViewComponent,
    SectionViewModule,
    FloorEditModule
  ],
  exports: [
    FloorsViewComponent
  ]
})
export class FloorsViewModule { }
