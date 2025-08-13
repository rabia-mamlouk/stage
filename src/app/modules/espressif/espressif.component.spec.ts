import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EspressifComponent } from './espressif.component';

describe('EspressifComponent', () => {
  let component: EspressifComponent;
  let fixture: ComponentFixture<EspressifComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EspressifComponent]
    });
    fixture = TestBed.createComponent(EspressifComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
