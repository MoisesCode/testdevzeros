import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Usuario } from '../testweb/models/usuario';
import { UsuarioService } from '../testweb/services/usuario.service';

@Injectable({
  providedIn: 'root'
})
export class AuthVentasGuard implements CanActivate {

  usuario: Usuario = (JSON.parse(sessionStorage.getItem('currentUser')));

  constructor(private usuarioService: UsuarioService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    if (this.usuario.rol === 'interesado') {
      return true;
    }else if (this.usuario.rol === 'avaluos'){
      return true;
    }else if (this.usuario.rol === 'ventas'){
      return true;
    }else if (!sessionStorage.getItem('currentUser')){
      this.router.navigate(['/login']);
    }
  }
}
