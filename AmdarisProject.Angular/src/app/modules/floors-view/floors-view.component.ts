import { Component, Input, OnInit } from '@angular/core';
import { HostelTemp } from 'src/app/models/hostel/hostelTemp';

@Component({
  selector: 'app-floors-view',
  templateUrl: './floors-view.component.html',
  styleUrls: ['./floors-view.component.css']
})
export class FloorsViewComponent implements OnInit {

  @Input()
  public hostel!: HostelTemp;

  constructor() { }

  ngOnInit(): void {
  }

}
