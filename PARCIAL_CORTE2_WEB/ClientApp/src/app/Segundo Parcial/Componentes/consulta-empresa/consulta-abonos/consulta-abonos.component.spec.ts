import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaAbonosComponent } from './consulta-abonos.component';

describe('ConsultaAbonosComponent', () => {
  let component: ConsultaAbonosComponent;
  let fixture: ComponentFixture<ConsultaAbonosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultaAbonosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultaAbonosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
