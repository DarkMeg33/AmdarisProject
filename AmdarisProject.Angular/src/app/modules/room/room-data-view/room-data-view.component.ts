import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
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
  public image!: SafeUrl;

  constructor(
    private dataTransferService: DataTransferService,
    private roomService: RoomService,
    private imageService: ImageService,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.dataTransferService.dataSubject.subscribe((data: number) => this.SetRoom(data));
  }

  public SetRoom(roomId: number) {
    this.roomId = roomId;

    this.roomService.getRoom(this.roomId).subscribe({
      next: (response: Room) => {
        this.room = response;
        this.imageService.getImage(this.roomId).subscribe({
          next: (response: Blob) => {
            console.log(response);
            const blob = new Blob([response], { type: "image/jpeg" });
            const objectURL = URL.createObjectURL(blob);
            const img = this.sanitizer.bypassSecurityTrustUrl(objectURL);
            this.image = img;
          }
        });
      }
    });
  }

}
