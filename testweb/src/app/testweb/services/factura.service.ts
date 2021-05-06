import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Factura } from '../models/factura';

@Injectable({
  providedIn: 'root'
})
export class FacturaService {

  urlApi = 'https://localhost:5001/Factura';
  factura: Factura;
  facturas: Factura[];

  constructor(private http: HttpClient) { }

  post(factura: Factura): Observable<Factura> {
    return this.http.post<Factura>(this.urlApi, factura).pipe(
      tap(f => this.factura = f)
    );
  }

  gets(): Observable<Factura[]> {
    return this.http.get<Factura[]>(this.urlApi).pipe(
      tap(f => this.facturas = f)
    );
  }
}
