import { Hostel } from '../models/hostel/hostel';
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

  public getHostels(): Observable<Hostel[]> {
    return this.httpClient.get<Hostel[]>("/api/hostels");
  }

  public getHostel(id: number): Observable<Hostel> {
    return this.httpClient.get<Hostel>(`/api/hostels/${id}`);
  }

  public createHostel(hostel: Hostel): Observable<Hostel> {
    return this.httpClient.post<Hostel>("/api/hostels", hostel);
  }

  public updateHostel(hostel: Hostel): Observable<Hostel> {
    return this.httpClient.put<Hostel>(`/api/hostels/${hostel.id}`, hostel);
  }

  public deleteHostel(id: number) {
    return this.httpClient.delete(`/api/hostels/${id}`);
  }
}
