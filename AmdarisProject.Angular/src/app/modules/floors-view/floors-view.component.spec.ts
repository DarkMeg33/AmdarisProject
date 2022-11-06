import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FloorsViewComponent } from './floors-view.component';

describe('FloorsViewComponent', () => {
  let component: FloorsViewComponent;
  let fixture: ComponentFixture<FloorsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FloorsViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FloorsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
