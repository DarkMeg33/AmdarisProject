import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Section } from 'src/app/common/models/section/section';
import { SectionService } from 'src/app/common/services/section.service';

@Component({
  selector: 'app-section-edit',
  templateUrl: './section-edit.component.html',
  styleUrls: ['./section-edit.component.css']
})
export class SectionEditComponent implements OnInit {

  public readonly ACTION_CANCEL: string = "CANCELED";
  public readonly ACTION_UPDATE: string = "UPDATED";
  public readonly ACTION_CREATE: string = "CREATED";

  public title: string;

  public section: Section;
  public sectionEditForm: FormGroup;

  constructor(
    private sectionService: SectionService,
    @Inject(MAT_DIALOG_DATA) public data: Section
  ) { 
    this.section = data;

    if (this.section.id === 0) {
      this.title = "Add section";
    } else {
      this.title = "Edit section";
    }

    this.sectionEditForm = new FormGroup({
      id: new FormControl(this.section.id, [Validators.required]),
      sectionNumber: new FormControl(this.section.sectionNumber, [Validators.required])
    });
  }

  ngOnInit(): void {
  }

  public editSection() {
    let sectionFromForm = this.sectionEditForm.value;
    this.section = {
      id: sectionFromForm.id,
      sectionNumber: sectionFromForm.sectionNumber,
      floorId: this.section.floorId
    }
    this.sectionService.saveSection(this.section).subscribe();
  }

}
