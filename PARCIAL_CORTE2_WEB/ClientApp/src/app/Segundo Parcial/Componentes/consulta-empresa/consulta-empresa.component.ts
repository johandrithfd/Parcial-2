import { Component, OnInit } from '@angular/core';
import { EmpresasService } from '../../../services/empresas.service';
import { Empresa } from '../../Modelos/empresa';
import { Mensaje } from '../../../services/mensaje';

@Component({
  selector: 'app-consulta-empresa',
  templateUrl: './consulta-empresa.component.html',
  styleUrls: ['./consulta-empresa.component.css']
})
export class ConsultaEmpresaComponent implements OnInit {

  constructor(private empresaService: EmpresasService,private mensaje: Mensaje) { }
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

}
