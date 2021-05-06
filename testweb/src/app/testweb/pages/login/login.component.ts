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

  ruta: string;
  usuario: Usuario;
  formGroup: FormGroup;
  permitirAcceso = false;

  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService, private router: Router) { }

  ngOnInit(): void {
    this.buildForm();
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

  buscar(): void {
    this.usuario = this.formGroup.value;
    this.usuarioService.getUser(this.usuario).subscribe( u => {
      this.usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
      if (this.usuario.rol === 'avaluos'){
        this.permitirAcceso = true;
      } else if (this.usuario.rol === 'interesado') {
        this.permitirAcceso = true;
      } else if (this.usuario.rol === 'ventas'){
        this.permitirAcceso = true;
      }else { this.permitirAcceso = false; }
    });
    this.redireccionar();
  }

  redireccionar(): void{
    if (this.permitirAcceso){
      this.router.navigate(['/inicio']);
    }
  }
}
