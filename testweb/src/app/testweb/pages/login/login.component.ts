import { Component, OnInit } from '@angular/core';

import { Usuario } from '../../models/usuario';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  ruta = '/inicio';
  usuario: Usuario;
  formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService) { }

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

  buscar(): void {}
}
