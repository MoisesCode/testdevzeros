import { Injectable } from '@angular/core';

import { Proveedor } from '../models/proveedor';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProveedorService {

  urlApi = 'https://localhost:5001/Proveedor';
  proveedor: Proveedor;
  proveedores: Proveedor[];

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
}
