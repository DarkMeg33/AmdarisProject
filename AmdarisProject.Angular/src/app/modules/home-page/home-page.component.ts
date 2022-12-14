import { Hostel } from './../../models/hostel/hostel';
import { HostelService } from './../../services/hostel.service';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  public hostels: Hostel[] | undefined;

  constructor(private hostelService: HostelService) { }

  public ngOnInit(): void {
    this.SetHostels();
  }

  public SetHostels() {
    this.hostelService.getHostels().subscribe({
      next: (hostels) => {
        this.hostels = hostels;
      }
    });
  }

  // public hostels: Hostel[] | undefined;
  // public hostel: Hostel | undefined;
  // public id: number = -1;
  // public hostelNumber: number = 0;

  // public updateHostelDto: Hostel = {id: 0, hostelNumber: 0};

  // public GetById() {
  //   this.hostelService.getHostel(this.id).subscribe((h) => {
  //     this.hostel = h;
  //   });
  // }

  // public Get() {
  //   this.hostelService.getHostels().subscribe((h) => {
  //     this.hostels = h;
  //   });
  // }

  // public post() {
  //   this.hostelService.createHostel({
  //     id: 0,
  //     hostelNumber: this.hostelNumber
  //   }).subscribe();
  // }

  // public put() {
  //   this.hostelService.updateHostel(this.updateHostelDto).subscribe();
  // }

  // public delete1() {
  //   this.hostelService.deleteHostel(this.id).subscribe();
  // }
}
