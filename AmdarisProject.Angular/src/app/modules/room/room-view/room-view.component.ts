import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Room } from 'src/app/common/models/room/room';
import { AccountService } from 'src/app/common/services/account.service';
import { DataTransferService } from 'src/app/common/services/data-transfer.service';
import { RoomService } from 'src/app/common/services/room.service';
import { RoomEditComponent } from '../room-edit/room-edit.component';

@Component({
  selector: 'app-room-view',
  templateUrl: './room-view.component.html',
  styleUrls: ['./room-view.component.css']
})
export class RoomViewComponent implements OnInit {

  @Input()
  public rooms: Room[] | undefined;

  @Input()
  public sectionId: number | undefined;

  @Output()
  public onRoomChange: EventEmitter<void> = new EventEmitter();

  constructor(
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
    private roomService: RoomService,
    private dataTranferService: DataTransferService,
    public accountService: AccountService
  ) { }

  ngOnInit(): void {
  }

  public roomLinkClicked(roomId: number) {
    this.dataTranferService.SentData(roomId);
  }

  public roomChanged() {
    this.onRoomChange.emit();
  }

  public deleteRoom(id: number) {
    this.roomService.deleteRoom(id).subscribe(() => {
      this.snackBar.open('The item has been deleted successfully.', 'Close', {
        duration: 1500
      });
      this.roomChanged();
    });
  }

  public editRoom(room?: Room) {
    const dialogRef = this.dialog.open(RoomEditComponent, {
      data: room ? room : { id: 0, sectionId: this.sectionId }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_UPDATE) {
        this.snackBar.open('The item has been updated successfully.', 'Close', {
          duration: 2500
        });
        this.roomChanged();
      } else if (result === dialogRef.componentInstance.ACTION_CREATE) {
        this.snackBar.open('The item has been created successfully.', 'Close', {
          duration: 2500
        });
        this.roomChanged();
      }
    });
  }

}
