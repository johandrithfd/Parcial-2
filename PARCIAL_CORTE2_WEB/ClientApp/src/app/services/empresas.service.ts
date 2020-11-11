import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { RespuestaConsulta } from '../Segundo Parcial/Modelos/respuesta-consulta';
import { Empresa } from '../Segundo Parcial/Modelos/empresa';
import { Respuesta } from '../Segundo Parcial/Modelos/respuesta';

@Injectable({
  providedIn: 'root'
})
export class EmpresasService {
  baseUrl: string;
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) { this.baseUrl = baseUrl; }

  get(): Observable<RespuestaConsulta<Empresa>> {
    return this.http.get<RespuestaConsulta<Empresa>>(this.baseUrl + 'api/Empresa')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<RespuestaConsulta<Empresa>>('Consulta Persona', null))
      );
  }

  ObtenerTotalDonaciones(empresaId: string): Observable<Respuesta<Empresa>> {
    return this.http.get<Respuesta<Empresa>>(this.baseUrl + 'api/Empresa/' + empresaId)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Respuesta<Empresa>>('Consulta Persona', null))
      );
  }

  post(empresa: Empresa): Observable<Respuesta<Empresa>> {

    return this.http.post<Respuesta<Empresa>>(this.baseUrl + 'api/Empresa', empresa)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Respuesta<Empresa>>('Registrar Persona', null))
      );
  }
}
