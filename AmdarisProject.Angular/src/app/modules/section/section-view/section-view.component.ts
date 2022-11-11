import { Component, Input, OnInit } from '@angular/core';
import { Section } from 'src/app/common/models/section/section';

@Component({
  selector: 'app-section-view',
  templateUrl: './section-view.component.html',
  styleUrls: ['./section-view.component.css']
})
export class SectionViewComponent implements OnInit {

  @Input()
  public sections: Section[] | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
