import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Producto } from 'src/app/testweb/models/producto';
import { Proveedor } from 'src/app/testweb/models/proveedor';
import { ProductoService } from 'src/app/testweb/services/producto.service';
import { ProveedorService } from 'src/app/testweb/services/proveedor.service';

@Component({
  selector: 'app-producto-registro',
  templateUrl: './producto-registro.component.html',
  styleUrls: ['./producto-registro.component.css']
})
export class ProductoRegistroComponent implements OnInit {

  formGroup: FormGroup;
  producto: Producto;
  proveedor: Proveedor;
  encontrado: boolean;

  constructor(private formBuilder: FormBuilder, private productoService: ProductoService, private proveedorService: ProveedorService) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm(): void {
    this.producto = new Producto();
    this.producto.nombre = '';
    this.producto.precio = 0;
    this.producto.cantidad = 0;
    this.producto.descripcion = '';
    this.producto.descuento = 0;
    this.producto.nitProveedor = '';

    this.formGroup = this.formBuilder.group({
      nombre: [this.producto.nombre, Validators.required],
      precio: [this.producto.precio, Validators.required],
      cantidad: [this.producto.cantidad, Validators.required],
      descripcion: [this.producto.descripcion, Validators.required],
      descuento: [this.producto.descuento, Validators.required],
      nitProveedor: [this.producto.nitProveedor, Validators.required]
    });
  }

  onRegistrar(): void {
    if (this.formGroup.invalid && this.encontrado === false){
      return;
    }
    this.registrar();
  }

  registrar(): void {
    this.producto = this.formGroup.value;
    this.productoService.post(this.producto).subscribe( p =>
      console.log(p)
    );
  }

  buscar(): void {
    this.producto = this.formGroup.value;
    this.proveedorService.getByNit(this.producto.nitProveedor).subscribe( p =>
      this.proveedor = p
    );
    if (this.proveedor) {
      this.encontrado = true;
      return;
    }
    this.encontrado = false;
  }
}
