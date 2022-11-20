import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Floor } from 'src/app/common/models/floor/floor';
import { Hostel } from 'src/app/common/models/hostel/hostel';
import { AccountService } from 'src/app/common/services/account.service';
import { FloorService } from 'src/app/common/services/floor.service';
import { FloorEditComponent } from '../floor-edit/floor-edit.component';

@Component({
  selector: 'app-floors-view',
  templateUrl: './floors-view.component.html',
  styleUrls: ['./floors-view.component.css']
})
export class FloorsViewComponent implements OnInit {

  @Input()
  public floors: Floor[] | undefined;

  @Input()
  public hostelId: number | undefined;

  @Output()
  public onFloorChange: EventEmitter<void> = new EventEmitter();

  constructor(
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
    private floorService: FloorService,
    public accountService: AccountService
  ) { }

  ngOnInit(): void {
  }

  public floorChanged() {
    this.onFloorChange.emit();
  }

  public deleteFloor(id: number) {
    this.floorService.deleteFloor(id).subscribe(() => {
      this.snackBar.open('The item has been deleted successfully.', 'Close', {
        duration: 1500
      });
      this.floorChanged();
    });
  }

  public editFloor(floor?: Floor) {
    const dialogRef = this.dialog.open(FloorEditComponent, {
      data: floor ? floor : { id: 0, hostelId: this.hostelId }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_UPDATE) {
        this.snackBar.open('The item has been updated successfully.', 'Close', {
          duration: 2500
        });
        this.floorChanged();
      } else if (result === dialogRef.componentInstance.ACTION_CREATE) {
        this.snackBar.open('The item has been created successfully.', 'Close', {
          duration: 2500
        });
        this.floorChanged();
      }
    });
  }

}
