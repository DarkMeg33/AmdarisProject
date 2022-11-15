import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from 'src/app/modules/angular-material/angular-material.module';

@Component({
  selector: 'app-delete-dialog',
  standalone: true,
  imports: [CommonModule, AngularMaterialModule],
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css']
})
export class DeleteDialogComponent implements OnInit {

  public readonly ACTION_CANCEL: string = "CANCELED";
  public readonly ACTION_CONFIRM: string = "CONFIRMED";

  constructor() { }

  ngOnInit(): void {
  }

}
