import { Component, Input, OnInit } from '@angular/core';
import { Hostel } from 'src/app/common/models/hostel/hostel';

@Component({
  selector: 'app-floors-view',
  templateUrl: './floors-view.component.html',
  styleUrls: ['./floors-view.component.css']
})
export class FloorsViewComponent implements OnInit {

  @Input()
  public hostel!: Hostel;

  constructor() { }

  ngOnInit(): void {
  }

}
