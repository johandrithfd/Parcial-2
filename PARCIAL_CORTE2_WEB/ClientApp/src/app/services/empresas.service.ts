import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
@Injectable({
  providedIn: 'root'
})
export class EmpresasService {

  constructor() { }
}
