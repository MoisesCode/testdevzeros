import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Usuario } from '../testweb/models/usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthVentasGuard implements CanActivate {

  usuario: Usuario = (JSON.parse(sessionStorage.getItem('currentUser')));

  constructor(private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const rol = route.data.rol;
    const rol1 = route.data.rol1;
    if (rol === 'todos' || rol === this.usuario.rol) {
      return true;
    }else{ this.router.navigate(['/login']); }

    if (rol === this.usuario.rol || rol1 === this.usuario.rol) {
      return true;
    }
  }
}
