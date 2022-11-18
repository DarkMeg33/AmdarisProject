import { HttpClient, HttpHandler } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Room } from 'src/app/common/models/room/room';
import { ImageService } from 'src/app/common/services/image.service';
import { RoomService } from 'src/app/common/services/room.service';

@Component({
  selector: 'app-room-edit',
  templateUrl: './room-edit.component.html',
  styleUrls: ['./room-edit.component.css']
})
export class RoomEditComponent implements OnInit {

  public readonly ACTION_CANCEL: string = "CANCELED";
  public readonly ACTION_UPDATE: string = "UPDATED";
  public readonly ACTION_CREATE: string = "CREATED";

  public title: string;

  public room: Room;
  public roomEditForm: FormGroup;
  public image: File | undefined;

  constructor(
    private roomService: RoomService,
    private imageService: ImageService,
    @Inject(MAT_DIALOG_DATA) public data: Room
  ) { 
    this.room = data;

    if (this.room.id === 0) {
      this.title = "Add room";
    } else {
      this.title = "Edit room";
    }

    this.roomEditForm = new FormGroup({
      id: new FormControl(this.room.id, [Validators.required]),
      roomNumber: new FormControl(this.room.roomNumber, [Validators.required]),
      image: new FormControl('', [Validators.required])
    });
  }

  ngOnInit(): void {
  }

  public onImageChanged(event: any) {
    let file: File = event.target.files[0];
    
    if (file.type != 'image/jpeg') {
      this.roomEditForm.controls['image'].reset();
    }
    this.image = file;
  }

  public editRoom() {
    let roomFromForm = this.roomEditForm.value;
    this.room = {
      id: roomFromForm.id,
      roomNumber: roomFromForm.roomNumber,
      sectionId: this.room.sectionId
    }
    this.roomService.saveRoom(this.room).subscribe((room: Room) => {
      let formData = new FormData();
      formData.append('file', this.image!, this.image!.name);

      if (this.title === "Add room") {
        this.imageService.createImage(formData, room.id).subscribe();
      } else {
        this.imageService.updateImage(formData, room.id).subscribe();
      }

    });
  }

}
