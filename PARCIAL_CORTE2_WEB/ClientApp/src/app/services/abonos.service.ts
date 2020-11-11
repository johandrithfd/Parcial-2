import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { RespuestaConsulta } from '../Segundo Parcial/Modelos/respuesta-consulta';
import { Abono } from '../Segundo Parcial/Modelos/Abono';
import { Respuesta } from '../Segundo Parcial/Modelos/respuesta';

@Injectable({
  providedIn: 'root'
})
export class AbonosService {
  baseUrl: string;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {this.baseUrl = baseUrl; }

  get(creditoId :number): Observable<RespuestaConsulta<Abono>> {
    return this.http.get<RespuestaConsulta<Abono>>(this.baseUrl + 'api/Abono/'+creditoId)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<RespuestaConsulta<Abono>>('Consulta Persona', null))
      );
  }

  post(Abono: Abono): Observable<Respuesta<Abono>> {

    return this.http.post<Respuesta<Abono>>(this.baseUrl + 'api/Abono', Abono)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Respuesta<Abono>>('Registrar Persona', null))
      );
  }
}
