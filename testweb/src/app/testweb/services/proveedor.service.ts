import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { Proveedor } from '../models/proveedor';

@Injectable({
  providedIn: 'root'
})
export class ProveedorService {

  urlApi = 'https://localhost:5001/Proveedor';
  proveedor: Proveedor;
  proveedores: Proveedor[];
  proveedorModificar: Proveedor;

  constructor(private http: HttpClient) { }

  post(proveedor): Observable<Proveedor> {
    return this.http.post<Proveedor>(this.urlApi, proveedor).pipe(
      tap(p => this.proveedor = p)
    );
  }

  gets(): Observable<Proveedor[]> {
    return this.http.get<Proveedor[]>(this.urlApi).pipe(
      tap(p => this.proveedores = p)
    );
  }

  getByNit(id): Observable<Proveedor> {
    return this.http.get<Proveedor>(this.urlApi + '/' + id).pipe(
      tap(p => this.proveedor = p)
    );
  }

  delete(id: string): Observable<Proveedor> {
    return this.http.delete<Proveedor>(this.urlApi + '/' + id).pipe(
      tap(p => this.proveedor = p)
    );
  }

  onModificar(p: Proveedor): void {
    this.proveedorModificar = p;
  }

  put(nit: string, proveedor: Proveedor): Observable<Proveedor> {
    return this.http.put<Proveedor>(this.urlApi + '/' + nit, proveedor).pipe(
      tap(i => this.proveedor = i)
    );
  }
}
