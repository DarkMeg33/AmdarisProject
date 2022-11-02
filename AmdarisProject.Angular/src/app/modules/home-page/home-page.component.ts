import { HostelService } from './../../services/hostel.service';
import { Component, OnInit } from '@angular/core';
import { Hostel } from 'src/app/models/hostel/hostel';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  public hostels: Hostel[] = [];

  constructor(private hostelService: HostelService) { }

  ngOnInit(): void {
    this.hostelService.getHostels().subscribe((h) => {
      this.hostels = h;
    });
  }
}
