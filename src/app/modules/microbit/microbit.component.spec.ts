import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MicrobitComponent } from './microbit.component';

describe('MicrobitComponent', () => {
  let component: MicrobitComponent;
  let fixture: ComponentFixture<MicrobitComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MicrobitComponent]
    });
    fixture = TestBed.createComponent(MicrobitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
