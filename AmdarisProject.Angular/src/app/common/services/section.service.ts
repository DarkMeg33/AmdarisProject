import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Section } from '../models/section/section';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public createSection(section: Section): Observable<Section> {
    return this.httpClient.post<Section>("/api/sections", section);
  }

  public updateSection(section: Section): Observable<Section> {
    return this.httpClient.put<Section>(`/api/sections/${section.id}`, section);
  }

  public deleteSection(id: number) {
    return this.httpClient.delete(`/api/sections/${id}`);
  }

  public saveSection(section: Section): Observable<Section> {
    if (section.id === 0) {
      return this.createSection(section);
    }

    return this.updateSection(section);
  }
}
