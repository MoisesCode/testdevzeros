import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Proveedor } from 'src/app/testweb/models/proveedor';
import { ProveedorService } from 'src/app/testweb/services/proveedor.service';

@Component({
  selector: 'app-proveedor-registro',
  templateUrl: './proveedor-registro.component.html',
  styleUrls: ['./proveedor-registro.component.css']
})
export class ProveedorRegistroComponent implements OnInit {

  formGroup: FormGroup;
  proveedor: Proveedor;

  constructor(private formBuilder: FormBuilder, private proveedorService: ProveedorService, private location: Location) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm(): void {
    this.proveedor = new Proveedor();
    this.proveedor.productos = [];
    this.proveedor.nit = '';
    this.proveedor.nombre = '';
    this.proveedor.celular = '';

    this.formGroup = this.formBuilder.group({
      nit: [this.proveedor.nit, Validators.required],
      nombre: [this.proveedor.nombre, Validators.required],
      celular: [this.proveedor.celular, Validators.required]
    });
  }

  onRegistrar(): void {
    if (this.formGroup.invalid){
      return;
    }
    this.registrar();
  }

  registrar(): void {
    this.proveedor = this.formGroup.value;
    this.proveedorService.post(this.proveedor).subscribe( p =>
      this.location.back()
    );
  }
}
