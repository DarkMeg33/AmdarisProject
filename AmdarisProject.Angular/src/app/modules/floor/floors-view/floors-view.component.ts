import { Component, Input, OnInit } from '@angular/core';
import { Floor } from 'src/app/common/models/floor/floor';

@Component({
  selector: 'app-floors-view',
  templateUrl: './floors-view.component.html',
  styleUrls: ['./floors-view.component.css']
})
export class FloorsViewComponent implements OnInit {

  @Input()
  public floors: Floor[] | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
