import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Section } from 'src/app/common/models/section/section';
import { SectionService } from 'src/app/common/services/section.service';
import { SectionEditComponent } from '../section-edit/section-edit.component';

@Component({
  selector: 'app-section-view',
  templateUrl: './section-view.component.html',
  styleUrls: ['./section-view.component.css']
})
export class SectionViewComponent implements OnInit {

  @Input()
  public sections: Section[] | undefined;

  @Input()
  public floorId: number | undefined;

  @Output()
  public onSectionChange: EventEmitter<void> = new EventEmitter();

  constructor(
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
    private sectionService: SectionService
  ) { }

  ngOnInit(): void {
  }

  public sectionChanged() {
    this.onSectionChange.emit();
  }

  public deleteSection(id: number) {
    this.sectionService.deleteSection(id).subscribe(() => {
      this.snackBar.open('The item has been deleted successfully.', 'Close', {
        duration: 1500
      });
      this.sectionChanged();
    });
  }

  public editSection(section?: Section) {
    const dialogRef = this.dialog.open(SectionEditComponent, {
      data: section ? section : { id: 0, floorId: this.floorId }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_UPDATE) {
        this.snackBar.open('The item has been updated successfully.', 'Close', {
          duration: 2500
        });
        this.sectionChanged();
      } else if (result === dialogRef.componentInstance.ACTION_CREATE) {
        this.snackBar.open('The item has been created successfully.', 'Close', {
          duration: 2500
        });
        this.sectionChanged();
      }
    });
  }

}
