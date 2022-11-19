import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getImage(roomId: number): Observable<any> {
    return this.httpClient.get(`/api/images/${roomId}`);
  }

  public createImage(fileForm: FormData, roomId: number): Observable<any> {
    return this.httpClient.post(`/api/images/${roomId}`, fileForm);
  }

  public updateImage(fileForm: FormData, roomId: number): Observable<any> {
    return this.httpClient.put(`/api/images/${roomId}`, fileForm);
  }

  public deleteImage(roomId: number): Observable<any> {
    return this.httpClient.delete(`/api/images/${roomId}`);
  }
}
