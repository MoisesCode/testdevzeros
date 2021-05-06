import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { map, catchError } from 'rxjs/operators';

import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  urlApi = 'https://localhost:5001/Login';
  usuario: Usuario;

  constructor(private http: HttpClient) { }

  getUser(usuario: Usuario): Observable<void> {
    const correo = usuario.correo;
    const contrasena = usuario.contrasena;

    return this.http.post<any>(this.urlApi, { correo, contrasena }).pipe(
      map( u => {
        if (u){
          sessionStorage.setItem('currentUser', JSON.stringify(u));
        }
        return u;
      })
    );
  }
}
