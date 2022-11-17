import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Floor } from '../models/floor/floor';

@Injectable({
  providedIn: 'root'
})
export class FloorService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public createFloor(floor: Floor): Observable<Floor> {
    return this.httpClient.post<Floor>("/api/floors", floor);
  }

  public updateFloor(floor: Floor): Observable<Floor> {
    return this.httpClient.put<Floor>(`/api/floors/${floor.id}`, floor);
  }

  public deleteFloor(id: number) {
    return this.httpClient.delete(`/api/floors/${id}`);
  }

  public saveFloor(floor: Floor): Observable<Floor> {
    if (floor.id === 0) {
      return this.createFloor(floor);
    }

    return this.updateFloor(floor);
  }
}
