import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Hostel } from 'src/app/common/models/hostel/hostel';
import { HostelService } from 'src/app/common/services/hostel.service';

@Component({
  selector: 'app-hostel-edit',
  templateUrl: './hostel-edit.component.html',
  styleUrls: ['./hostel-edit.component.css']
})
export class HostelEditComponent implements OnInit {

  public readonly ACTION_CANCEL: string = "CANCELED";
  public readonly ACTION_UPDATE: string = "UPDATED";
  public readonly ACTION_CREATE: string = "CREATED";

  public title: string;

  public hostel: Hostel;
  public hostelEditForm: FormGroup;

  constructor(
    private hostelService: HostelService,
    @Inject(MAT_DIALOG_DATA) public data: Hostel
  ) { 
    this.hostel = data;

    if (this.hostel.id === 0) {
      this.title = "Add hostel";
    } else {
      this.title = "Edit hostel";
    }

    this.hostelEditForm = new FormGroup({
      id: new FormControl(this.hostel.id, [Validators.required]),
      hostelNumber: new FormControl(this.hostel.hostelNumber, [Validators.required])
    });
  }

  ngOnInit(): void {
  }

  public editHostel() {
    this.hostel = this.hostelEditForm.value;
    this.hostelService.saveHostel(this.hostel).subscribe();
  }

}
