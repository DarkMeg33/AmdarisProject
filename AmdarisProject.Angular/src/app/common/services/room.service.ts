import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Room } from '../models/room/room';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public createRoom(room: Room): Observable<Room> {
    return this.httpClient.post<Room>("/api/rooms", room);
  }

  public updateRoom(room: Room): Observable<Room> {
    return this.httpClient.put<Room>(`/api/rooms/${room.id}`, room);
  }

  public deleteRoom(id: number) {
    return this.httpClient.delete(`/api/rooms/${id}`);
  }

  public saveRoom(room: Room): Observable<Room> {
    if (room.id === 0) {
      return this.createRoom(room);
    }

    return this.updateRoom(room);
  }
}
