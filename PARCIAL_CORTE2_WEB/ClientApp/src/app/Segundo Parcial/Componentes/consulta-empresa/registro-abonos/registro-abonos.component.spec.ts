import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroAbonosComponent } from './registro-abonos.component';

describe('RegistroAbonosComponent', () => {
  let component: RegistroAbonosComponent;
  let fixture: ComponentFixture<RegistroAbonosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistroAbonosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistroAbonosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
