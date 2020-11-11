import { Component, OnInit } from '@angular/core';
import { EmpresasService } from 'src/app/services/empresas.service';
import { Mensaje } from 'src/app/services/mensaje';
import { Empresa } from '../../Modelos/empresa';
import {FormGroup,Validators,FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-registro-empresa',
  templateUrl: './registro-empresa.component.html',
  styleUrls: ['./registro-empresa.component.css']
})
export class RegistroEmpresaComponent implements OnInit {

  formularioRegistro : FormGroup;
  empresa: Empresa= new Empresa();

  constructor(private empresaService: EmpresasService,private mensaje: Mensaje,private formBuilder : FormBuilder) { }

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
  }

  registrarEmpresa() {
    this.empresaService.post(this.empresa).subscribe(e => {
      if (!e.error)
      {
        this.empresa = e.elemento;
      }
      this.mensaje.Informar("Consulta Empresas",e.mensaje);
    });
  }

  EstablecerValidacionesFormulario  ()
  {
    this.formularioRegistro = this.formBuilder.group(
      {
        empresaId : ['',[Validators.required]],
        nombre : ['',[Validators.required,Validators.minLength(7),Validators.maxLength(30)]],
        cantidadTrabajadores : [,[Validators.required,Validators.pattern('^[0-9]+$')]],
        valorActivos : [,[Validators.required,Validators.pattern('^[0-9]+$')]]
      }
    );
  }

  get empresaId ()
  {
    return this.formularioRegistro.get('empresaId');
  }
  get nombre ()
  {
    return this.formularioRegistro.get('nombre');
  }
  get cantidadTrabajadores ()
  {
    return this.formularioRegistro.get('cantidadTrabajadores');
  }
  get valorActivos ()
  {
    return this.formularioRegistro.get('valorActivos');
  }
}
