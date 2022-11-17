import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Floor } from 'src/app/common/models/floor/floor';
import { FloorService } from 'src/app/common/services/floor.service';

@Component({
  selector: 'app-floor-edit',
  templateUrl: './floor-edit.component.html',
  styleUrls: ['./floor-edit.component.css']
})
export class FloorEditComponent implements OnInit {

  public readonly ACTION_CANCEL: string = "CANCELED";
  public readonly ACTION_UPDATE: string = "UPDATED";
  public readonly ACTION_CREATE: string = "CREATED";

  public title: string;

  public floor: Floor;
  public floorEditForm: FormGroup;

  constructor(
    private floorService: FloorService,
    @Inject(MAT_DIALOG_DATA) public data: Floor
  ) { 
    this.floor = data;

    if (this.floor.id === 0) {
      this.title = "Add floor";
    } else {
      this.title = "Edit floor";
    }

    this.floorEditForm = new FormGroup({
      id: new FormControl(this.floor.id, [Validators.required]),
      floorNumber: new FormControl(this.floor.floorNumber, [Validators.required])
    });
  }

  ngOnInit(): void {
  }

  public editFloor() {
    let floorFromForm = this.floorEditForm.value;
    this.floor = {
      id: floorFromForm.id,
      floorNumber: floorFromForm.floorNumber,
      hostelId: this.floor.hostelId
    }
    this.floorService.saveFloor(this.floor).subscribe();
  }
}
