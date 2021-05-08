import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

import { Usuario } from '../testweb/models/usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthInteresadoGuard implements CanActivate {

  usuario: Usuario = (JSON.parse(sessionStorage.getItem('currentUser')));

  constructor(private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const rol = route.data.rol;
    if (rol === 'todos') {
      return true;
    }

    if (this.usuario.rol === 'interesado') {
      return true;
    }else if (!sessionStorage.getItem('currentUser')){
      this.router.navigate(['/Login']);
      return false;
    }
  }
}
