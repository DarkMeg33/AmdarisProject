import { Component, OnInit } from '@angular/core';
import { Hostel } from 'src/app/common/models/hostel/hostel';
import { HostelService } from 'src/app/common/services/hostel.service';

@Component({
  selector: 'app-hostels-view',
  templateUrl: './hostels-view.component.html',
  styleUrls: ['./hostels-view.component.css']
})
export class HostelsViewComponent implements OnInit {

  public hostels: Hostel[] | undefined;

  constructor(
    private hostelService: HostelService
  ) {}

  ngOnInit(): void {
    this.SetHostels();
  }

  public SetHostels() {
    this.hostelService.getHostels().subscribe({
      next: (hostels) => {
        this.hostels = hostels;
      }
    });
  }
}