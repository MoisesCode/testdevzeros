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
    if (this.usuario.rol === 'avaluos') {
      return true;
    }else if (!sessionStorage.getItem('currentUser')){
      this.router.navigate(['/Login']);
      return false;
    }
  }
}
