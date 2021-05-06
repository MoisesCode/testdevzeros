import { Injectable } from '@angular/core';
import { Interesado } from '../models/interesado';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InteresadoService {

  urlApi = 'https://localhost:5001/Interesado';
  interesado: Interesado;
  interesados: Interesado[];

  constructor(private http: HttpClient) { }

  post(interesado): Observable<Interesado> {
    return this.http.post<Interesado>(this.urlApi, interesado).pipe(
      tap(i => this.interesado = i)
    );
  }

  gets(): Observable<Interesado[]> {
    return this.http.get<Interesado[]>(this.urlApi).pipe(
      tap(i => this.interesados = i)
    );
  }

}
