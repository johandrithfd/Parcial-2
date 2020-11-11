import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Abono } from 'src/app/Segundo Parcial/Modelos/abono';
import { AbonosService } from 'src/app/services/abonos.service';
import {FormGroup,Validators,FormBuilder} from '@angular/forms';
import { Mensaje } from 'src/app/services/mensaje';

@Component({
  selector: 'app-registro-abonos',
  templateUrl: './registro-abonos.component.html',
  styleUrls: ['./registro-abonos.component.css']
})
export class RegistroAbonosComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal,private abonoService : AbonosService,private formBuilder : FormBuilder,private mensaje: Mensaje) { }
  @Input() creditoId: number ;
  abono : Abono  = new Abono();
  formularioRegistro : FormGroup;
  ngOnInit(): void {
    this.EstablecerValidacionesFormulario  ();
  }
  registrarAbono() {
    this.abono.creditoId = this.creditoId;
    this.abonoService.post(this.abono).subscribe(e => {
      this.mensaje.Informar("Registro Abono",e.mensaje);
    });
    this.activeModal.dismiss();
  }

  EstablecerValidacionesFormulario  ()
  {
    this.formularioRegistro = this.formBuilder.group(
      {
        valorAbono : [,[Validators.required ,Validators.pattern('^[0-9]+$')]]
      }
    );
  }

  get valorAbono ()
  {
    return this.formularioRegistro.get('valorAbono');
  }


}
