import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/common/models/room/room';
import { DataTransferService } from 'src/app/common/services/data-transfer.service';
import { ImageService } from 'src/app/common/services/image.service';
import { RoomService } from 'src/app/common/services/room.service';

@Component({
  selector: 'app-room-data-view',
  templateUrl: './room-data-view.component.html',
  styleUrls: ['./room-data-view.component.css']
})
export class RoomDataViewComponent implements OnInit {

  public roomId: number = 0;
  public room!: Room;
  public image!: File;

  constructor(
    private dataTransferService: DataTransferService,
    private roomService: RoomService,
    private imageService: ImageService
  ) { }

  ngOnInit(): void {
    this.dataTransferService.dataSubject.subscribe((data: number) => this.roomId = data);
    this.roomService.getRoom(this.roomId).subscribe((response: Room) => {
      this.room = response;
      this.imageService.getImage(this.roomId).subscribe((response: File) => {
        this.image = response;
      });
    });
  }

}
