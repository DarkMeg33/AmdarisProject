import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HostelsViewComponent } from './hostels-view.component';
import { AngularMaterialModule } from '../../angular-material/angular-material.module';
import { FloorsViewModule } from '../../floor/floors-view/floors-view.module';
import { ListItemViewComponent } from '../../../common/components/list-item-view/list-item-view.component';
import { SectionViewModule } from '../../section/section-view/section-view.module';



@NgModule({
  declarations: [
    HostelsViewComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    FloorsViewModule,
    ListItemViewComponent
  ],
  exports: [
    HostelsViewComponent
  ]
})
export class HostelsViewModule { }
