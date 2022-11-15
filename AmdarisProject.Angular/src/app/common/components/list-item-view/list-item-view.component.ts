import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from '../../../modules/angular-material/angular-material.module';
import { DeleteBtnComponent } from '../delete-btn/delete-btn.component';

@Component({
  selector: 'app-list-item-view',
  standalone: true,
  imports: [
    CommonModule,
    AngularMaterialModule,
    DeleteBtnComponent
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

  @Output()
  onDelete: EventEmitter<void> = new EventEmitter();

  @Output()
  onEdit: EventEmitter<void> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  public expand() {
    this.isExpanded = !this.isExpanded;
  }

  public onDeleteClicked() {
    this.onDelete.emit();
  }

  public onEditClicked() {
    this.onEdit.emit();
  }
}
