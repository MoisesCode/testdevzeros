import { Injectable } from '@angular/core';
import { Producto } from '../models/producto';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  urlApi = 'https://localhost:5001/Producto';
  producto: Producto;
  productos: Producto[];

  constructor(private http: HttpClient) { }

  post(producto): Observable<Producto> {
    return this.http.post<Producto>(this.urlApi, producto).pipe(
      tap(i => this.producto = i)
    );
  }

  gets(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.urlApi).pipe(
      tap(i => this.productos = i)
    );
  }

}
