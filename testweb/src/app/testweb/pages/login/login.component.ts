import { Component, OnInit } from '@angular/core';

import { Usuario } from '../../models/usuario';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../../services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario: Usuario;
  formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService, private router: Router) { }

  ngOnInit(): void {
    this.buildForm();
    this.logIn();
  }

  private buildForm(): void {
    this.usuario = new Usuario();
    this.usuario.correo = '';
    this.usuario.contrasena = '';
    this.formGroup = this.formBuilder.group({
      correo: [this.usuario.correo, Validators.required],
      contrasena: [this.usuario.contrasena, Validators.required]
    });
  }

  onClick(): void{
    if (this.formGroup.invalid){
      return;
    }
    this.buscar();
  }

  logIn(): void {
    this.usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
    if (this.usuario !== null) {
      this.router.navigate(['/inicio']);
    }
  }

  buscar(): void {
    this.usuario = this.formGroup.value;
    this.usuarioService.getUser(this.usuario).subscribe( u => {
      this.usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
      if (this.usuario.rol === 'avaluos' || this.usuario.rol === 'interesado' || this.usuario.rol === 'ventas'){
        this.router.navigate(['/inicio']);
      }
    });
  }
}
