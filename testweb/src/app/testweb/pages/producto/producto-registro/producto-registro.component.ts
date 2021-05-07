import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Detalle } from 'src/app/testweb/models/detalle';
import { Factura } from 'src/app/testweb/models/factura';
import { Producto } from 'src/app/testweb/models/producto';
import { Proveedor } from 'src/app/testweb/models/proveedor';
import { FacturaService } from 'src/app/testweb/services/factura.service';
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
  factura: Factura;
  detalle: Detalle;

  constructor(private formBuilder: FormBuilder, private facturaService: FacturaService, private proveedorService: ProveedorService) { }

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

  crearFactura(producto: Producto): void{
    this.factura = new Factura();
    this.factura.detalles = [];
    this.factura.total = 0;
    this.factura.tipo = 'Compra';
    this.factura.descuento = 0;
    this.factura.detalles.push(this.crearDetalle(producto));
  }
  crearDetalle(producto: Producto): Detalle {
    this.detalle = new Detalle();
    this.detalle.cantidad = producto.cantidad;
    this.detalle.total = 0;
    this.detalle.producto = producto;
    return this.detalle;
  }

  onRegistrar(): void {
    if (this.formGroup.invalid && this.encontrado === false){
      return;
    }
    this.registrar();
  }

  registrar(): void {
    this.producto = this.formGroup.value;
    this.crearFactura(this.producto);
    this.facturaService.post(this.factura).subscribe( f => {
      this.factura = f;
      console.log(this.factura);
    });
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
