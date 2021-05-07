import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Interesado } from 'src/app/testweb/models/interesado';
import { InteresadoService } from 'src/app/testweb/services/interesado.service';

import { Location } from '@angular/common';
@Component({
  selector: 'app-interesado-registro',
  templateUrl: './interesado-registro.component.html',
  styleUrls: ['./interesado-registro.component.css']
})
export class InteresadoRegistroComponent implements OnInit {

  formGroup: FormGroup;
  interesado: Interesado;

  constructor(private formBuilder: FormBuilder, private interesadoService: InteresadoService, private localtion: Location) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm(): void{
    this.interesado = new Interesado();
    this.interesado.facturas = [];
    this.interesado.id = '';
    this.interesado.nombre = '';
    this.interesado.celular = '';
    this.interesado.correo = '';
    this.interesado.contrasena = '';

    this.formGroup = this.formBuilder.group({
      id: [this.interesado.id, Validators.required],
      nombre: [this.interesado.nombre, Validators.required],
      celular: [this.interesado.celular, Validators.required],
      correo: [this.interesado.correo, Validators.required],
      contrasena: [this.interesado.contrasena, Validators.required]
    });
  }

  onRegistrar(): void {
    if (this.formGroup.invalid){
      return;
    }
    this.registrar();
  }

  registrar(): void {
    this.interesado = this.formGroup.value;
    this.interesadoService.post(this.interesado).subscribe( i =>
      this.localtion.back()
    );
  }

}
