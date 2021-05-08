import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

import { Usuario } from '../testweb/models/usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {}

  usuario: Usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const rol = route.data.rol;
    const rol1 = route.data.rol1;
    if (rol === 'todos') {
      return true;
    }

    if (rol === this.usuario.rol || rol1 === this.usuario.rol) {
      return true;
    }

    if (this.usuario.rol === 'avaluos') {
      return true;
    }else if (!sessionStorage.getItem('currentUser')){
      this.router.navigate(['/Login']);
      return false;
    }
  }
}
