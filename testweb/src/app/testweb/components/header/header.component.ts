import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from '../../models/usuario';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  usuario: Usuario;
  usuarioInteresado = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
    this.verificarPermiso();
  }

  onClick(): void {
    sessionStorage.removeItem('currentUser');
    this.router.navigate(['/login']);
    window.location.reload();
    this.router.navigate(['/login']);
  }

  verificarPermiso(): void{
    if (this.usuario.rol === 'interesado'){
      this.usuarioInteresado = false;
    }else{
      this.usuarioInteresado = true;
    }
  }
}
