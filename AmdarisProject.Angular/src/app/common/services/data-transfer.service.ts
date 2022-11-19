import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataTransferService {

  constructor() { }

  public dataSubject = new Subject<number>();

  public SentData(data: number) {
    this.dataSubject.next(data);
  }
}
