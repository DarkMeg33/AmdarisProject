import { Component, OnInit } from '@angular/core';
import { Hostel } from 'src/app/common/models/hostel/hostel';

const _DATA: Hostel[] = [
  {
    id: 1,
    hostelNumber: 1,
    floors: [{id: 1, floorNumber: 1, hostelId: 1}, {id: 2, floorNumber: 2, hostelId: 1}, {id: 3, floorNumber: 3, hostelId: 1}],
  },
  {
    id: 2,
    hostelNumber: 2,
  },
  {
    id: 3,
    hostelNumber: 3,
    floors: [{id: 4, floorNumber: 1, hostelId: 3}, {id: 5, floorNumber: 2, hostelId: 3}]
  }
];

@Component({
  selector: 'app-hostels-view',
  templateUrl: './hostels-view.component.html',
  styleUrls: ['./hostels-view.component.css']
})
export class HostelsViewComponent implements OnInit {

  public data: Hostel[];

  public isExpandable: boolean = false;
  public isOpened: boolean = false;

  constructor() {
    this.data = _DATA;
  }

  ngOnInit(): void {
  }

  public canExpand(hostel: Hostel): boolean {
    this.isExpandable = hostel.floors ? true: false
    return this.isExpandable;
  }

  public open() {
    this.isOpened = !this.isOpened;
  }
}