import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { Interesado } from '../models/interesado';

@Injectable({
  providedIn: 'root'
})
export class InteresadoService {

  urlApi = 'https://localhost:5001/Interesado';
  interesado: Interesado;
  interesados: Interesado[];
  interesadoModificar: Interesado;

  constructor(private http: HttpClient) { }

  post(interesado): Observable<Interesado> {
    return this.http.post<Interesado>(this.urlApi, interesado).pipe(
      tap(i => this.interesado = i)
    );
  }

  put(id: string, interesado: Interesado): Observable<Interesado> {
    return this.http.put<Interesado>(this.urlApi + '/' + id, interesado).pipe(
      tap(i => this.interesado = i)
    );
  }

  gets(): Observable<Interesado[]> {
    return this.http.get<Interesado[]>(this.urlApi).pipe(
      tap(i => this.interesados = i)
    );
  }

  getById(id): Observable<Interesado> {
    return this.http.get<Interesado>(this.urlApi + '/' + id).pipe(
      tap(p => this.interesado = p)
    );
  }

  delete(id: string): Observable<Interesado> {
    return this.http.delete<Interesado>(this.urlApi + '/' + id).pipe(
      tap(p => this.interesado = p)
    );
  }

  onModificar(interesado: Interesado): void {
    this.interesadoModificar = interesado;
  }
}
