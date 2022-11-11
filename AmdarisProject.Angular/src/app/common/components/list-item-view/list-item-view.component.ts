import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from '../../../modules/angular-material/angular-material.module';

@Component({
  selector: 'app-list-item-view',
  standalone: true,
  imports: [
    CommonModule,
    AngularMaterialModule
  ],
  templateUrl: './list-item-view.component.html',
  styleUrls: ['./list-item-view.component.css']
})
export class ListItemViewComponent implements OnInit {

  @Input()
  public title: string = "";

  @Input()
  public canExpand: boolean = false;

  public isExpanded: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  public expand() {
    this.isExpanded = !this.isExpanded;
  }
}
