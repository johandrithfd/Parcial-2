import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { EmpresasService } from '../../../services/empresas.service';
import { Empresa } from '../../Modelos/empresa';
import { Mensaje } from '../../../services/mensaje';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConsultaAbonosComponent } from './consulta-abonos/consulta-abonos.component';

@Component({
  selector: 'app-consulta-empresa',
  templateUrl: './consulta-empresa.component.html',
  styleUrls: ['./consulta-empresa.component.css']
})
export class ConsultaEmpresaComponent implements OnInit {

  constructor(private empresaService: EmpresasService,private mensaje: Mensaje,private modalService: NgbModal) { }
  empresas: Empresa[] = [];
  ngOnInit(): void {
    this.consultarEmpresas();
  }

  consultarEmpresas() {
    this.empresaService.get().subscribe(e => {
      if (!e.error)
      {
        this.empresas = e.elementos;
      }
      this.mensaje.Informar("Consulta Empresas",e.mensaje);
    });
  }

  AbrirConsulta(creditoId: number) {
    const consultaBox = this.modalService.open(ConsultaAbonosComponent)
        consultaBox.componentInstance.creditoId = creditoId;
  }

}
