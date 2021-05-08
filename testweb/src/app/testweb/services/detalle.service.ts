import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Detalle } from '../models/detalle';

@Injectable({
  providedIn: 'root'
})
export class DetalleService {

  urlApi = 'https://localhost:5001/Detalle';
  detalles: Detalle[];

  constructor(private http: HttpClient) { }

  getById(id: string): Observable<Detalle[]> {
    return this.http.get<Detalle[]>(this.urlApi + '/' + id).pipe(
      tap(d => this.detalles = d)
    );
  }
}
