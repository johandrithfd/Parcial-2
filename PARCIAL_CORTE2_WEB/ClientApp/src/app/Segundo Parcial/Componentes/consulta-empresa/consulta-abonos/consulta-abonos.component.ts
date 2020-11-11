import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Credito } from 'src/app/Segundo Parcial/Modelos/credito';
import { Input } from '@angular/core';
import { Abono } from 'src/app/Segundo Parcial/Modelos/abono';
import { AbonosService } from 'src/app/services/abonos.service';
@Component({
  selector: 'app-consulta-abonos',
  templateUrl: './consulta-abonos.component.html',
  styleUrls: ['./consulta-abonos.component.css']
})
export class ConsultaAbonosComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal,private abonoService : AbonosService) { }
  @Input() creditoId: number ;
  abonos : Abono [] = [];

  ngOnInit(): void {
    this.consultarAbonos();
  }

  consultarAbonos() {
    this.abonoService.get(this.creditoId).subscribe(e => {
      if (!e.error)
      {
        this.abonos = e.elementos;
      }
    });
  }

}
