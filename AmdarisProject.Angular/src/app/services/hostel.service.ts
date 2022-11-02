import { Hostel } from './../modules/hostel/hostel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HostelService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getHostels(): Observable<Hostel> {
    return this.httpClient.get<Hostel>("/api/hostels");
  }
}
