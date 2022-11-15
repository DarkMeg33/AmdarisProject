import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from 'src/app/modules/angular-material/angular-material.module';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-delete-btn',
  standalone: true,
  imports: [
    CommonModule, 
    AngularMaterialModule
  ],
  templateUrl: './delete-btn.component.html',
  styleUrls: ['./delete-btn.component.css']
})
export class DeleteBtnComponent implements OnInit {

  @Output()
  onDelete: EventEmitter<void> = new EventEmitter();

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }

  public onDeleteClicked() {
    const dialogRef = this.dialog.open(DeleteDialogComponent);
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.onDelete.emit();
      }
    });
  }
}
