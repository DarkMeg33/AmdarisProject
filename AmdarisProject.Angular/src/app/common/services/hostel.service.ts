import { Hostel } from '../models/hostel/hostel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginationRequest } from '../models/pagination/pagination-request';
import { PaginationResult } from '../models/pagination/pagination-result';

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

  public getPagedHostels(paginationRequest: PaginationRequest): Observable<PaginationResult<Hostel>> {
    return this.httpClient.post<PaginationResult<Hostel>>("/api/hostels/pagination", paginationRequest);
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

  public saveHostel(hostel: Hostel): Observable<Hostel> {
    if (hostel.id === 0) {
      return this.createHostel(hostel);
    }

    return this.updateHostel(hostel);
  }
}
