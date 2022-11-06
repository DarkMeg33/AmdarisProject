import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HostelsViewComponent } from './hostels-view.component';

describe('HostelsViewComponent', () => {
  let component: HostelsViewComponent;
  let fixture: ComponentFixture<HostelsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HostelsViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HostelsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
