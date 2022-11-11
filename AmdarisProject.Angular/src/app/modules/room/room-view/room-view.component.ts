import { Component, Input, OnInit } from '@angular/core';
import { Room } from 'src/app/common/models/room/room';

@Component({
  selector: 'app-room-view',
  templateUrl: './room-view.component.html',
  styleUrls: ['./room-view.component.css']
})
export class RoomViewComponent implements OnInit {

  @Input()
  public rooms: Room[] | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
