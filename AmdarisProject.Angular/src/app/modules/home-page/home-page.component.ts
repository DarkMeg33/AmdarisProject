import { Component, OnInit } from '@angular/core';
import { DataTransferService } from 'src/app/common/services/data-transfer.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(
    private dataTransferService: DataTransferService
  ) { }

  public ngOnInit(): void {
  }
}
