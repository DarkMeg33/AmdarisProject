import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatRadioGroup } from '@angular/material/radio';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Hostel } from 'src/app/common/models/hostel/hostel';
import { PaginationRequest } from 'src/app/common/models/pagination/pagination-request';
import { PaginationResult } from 'src/app/common/models/pagination/pagination-result';
import { SortDirection } from 'src/app/common/models/pagination/sort-direction';
import { SortingRequest } from 'src/app/common/models/pagination/sorting-request';
import { HostelService } from 'src/app/common/services/hostel.service';
import { HostelEditComponent } from '../hostel-edit/hostel-edit.component';

@Component({
  selector: 'app-hostels-view',
  templateUrl: './hostels-view.component.html',
  styleUrls: ['./hostels-view.component.css']
})
export class HostelsViewComponent implements OnInit, AfterViewInit {

  public hostels: Hostel[] | undefined;
  public paginationResult: PaginationResult<Hostel> | undefined;
  public sortingRequest: SortingRequest | undefined;

  @ViewChild(MatPaginator, {static: false}) 
  paginator: MatPaginator | undefined;

  public sortingDirection: string = "0";

  constructor(
    private hostelService: HostelService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngAfterViewInit(): void {
    this.setHostels();
  }

  ngOnInit(): void {
  }

  public setHostels() {
    let sortingRequest = new SortingRequest("HostelNumber", 
      this.sortingDirection === "0" ? SortDirection.Ascending : SortDirection.Descending);

    let paginationRequest = new PaginationRequest(this.paginator!, sortingRequest);
    this.hostelService.getPagedHostels(paginationRequest).subscribe((result) => {
      this.paginationResult = result;
      this.hostels = result.items;
    });
  }

  public deleteHostel(id: number) {
    this.hostelService.deleteHostel(id).subscribe(() => {
      this.snackBar.open('The item has been deleted successfully.', 'Close', {
        duration: 1500
      });
      this.setHostels();
    });
  }

  public editHostel(hostel?: Hostel) {
    const dialogRef = this.dialog.open(HostelEditComponent, {
      data: hostel ? hostel : { id: 0 }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_UPDATE) {
        this.snackBar.open('The item has been updated successfully.', 'Close', {
          duration: 2500
        });
        this.setHostels();
      } else if (result === dialogRef.componentInstance.ACTION_CREATE) {
        this.snackBar.open('The item has been created successfully.', 'Close', {
          duration: 2500
        });
        this.setHostels();
      }
    });
  }
}