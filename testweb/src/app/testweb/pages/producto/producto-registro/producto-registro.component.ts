import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
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
  encontrado = false;
  factura: Factura;
  detalle: Detalle;

  constructor(
    private formBuilder: FormBuilder,
    private facturaService: FacturaService,
    private proveedorService: ProveedorService,
    private location: Location) { }

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
    this.factura.tipo = 'Compra';
    this.factura.detalles.push(this.crearDetalle(producto));
    this.factura.descuento = this.calcularDescuentoFactura(this.factura.detalles);
    this.factura.total = this.calcularTotalFactura(this.factura.detalles);
  }
  crearDetalle(producto: Producto): Detalle {
    this.detalle = new Detalle();
    producto.id = this.generarId();
    producto.fecha = new Date();
    this.detalle.cantidad = producto.cantidad;
    this.detalle.total = this.calcularTotalDetalle(this.producto.cantidad, this.producto.precio);
    this.detalle.descuento = this.producto.descuento;
    this.detalle.idProducto = producto.id;
    this.detalle.producto = producto;
    return this.detalle;
  }
  verificarInputs(p: Producto): boolean {
    if (p.cantidad > 0 || p.cantidad > 0) {
      return true;
    }
    alert('El precio y la cantidad deben ser mayor a 0');
    return false;
  }

  generarId(): string {
    const min = 1;
    const max = 300;
    return String(Math.floor((Math.random() * max) + min));
  }
  onRegistrar(): void {
    if (this.formGroup.invalid || this.encontrado === false){
      alert('El proveedor no ha sido encontrado');
      return;
    }
    this.registrar();
  }

  registrar(): void {
    this.producto = this.formGroup.value;
    if (this.verificarInputs(this.producto)){
      this.crearFactura(this.producto);
      this.facturaService.post(this.factura).subscribe( f => {
        this.factura = f;
        console.log(this.factura);
        this.location.back();
      });
    }
  }

  buscar(): void {
    this.producto = this.formGroup.value;
    this.proveedorService.getByNit(this.producto.nitProveedor).subscribe( p => {
      this.proveedor = p;
      if (this.proveedor) {
        this.encontrado = true;
        return;
      }
      this.encontrado = false;
    });
  }

  calcularTotalFactura(detalle: Detalle[]): number {
    let total = 0;
    detalle.forEach( d => {
      total = total + d.total;
    });
    return total;
  }
  calcularTotalDetalle(cantidad, precio): number {
    return cantidad * precio;
  }
  calcularDescuentoFactura(detalle: Detalle[]): number {
    let descuento = 0;
    detalle.forEach( d => {
      descuento = descuento + d.descuento;
    });
    return descuento;
  }
}
