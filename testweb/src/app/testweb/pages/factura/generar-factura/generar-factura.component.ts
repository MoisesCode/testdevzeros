import { Component, OnInit } from '@angular/core';
import { Detalle } from 'src/app/testweb/models/detalle';
import { Factura } from 'src/app/testweb/models/factura';
import { Interesado } from 'src/app/testweb/models/interesado';

import { Producto } from 'src/app/testweb/models/producto';
import { FacturaService } from 'src/app/testweb/services/factura.service';
import { InteresadoService } from 'src/app/testweb/services/interesado.service';
import { ProductoService } from 'src/app/testweb/services/producto.service';

@Component({
  selector: 'app-generar-factura',
  templateUrl: './generar-factura.component.html',
  styleUrls: ['./generar-factura.component.css']
})
export class GenerarFacturaComponent implements OnInit {

  factura: Factura;
  productos: Producto[];
  productosAgregados: Producto[] = [];
  Detalles: Detalle[] = [];
  detalle: Detalle;
  productoAgg: Producto;
  encontrado = false;
  interesado: Interesado;

  clienteId = '';

  cantidad = 0;
  precio = 0;
  descuento = 0;

  descuentoview = 0;
  totalview = 0;

  constructor(
    private productoService: ProductoService,
    private interesadoService: InteresadoService,
    private facturaService: FacturaService ) { }

  ngOnInit(): void {
    this.consultar();
    this.crearFactura();
  }

  crearFactura(): void {
    this.factura = new Factura();
    this.factura.detalles = [];
    this.factura.tipo = 'Venta';
  }

  consultar(): void {
    this.productos = [];
    this.productoService.gets().subscribe( p =>
      this.productos = p
    );
  }

  agregar(p: Producto): void {
    this.productoAgg = new Producto();
    this.productoAgg = p;

    if (this.verificarCantidad()){
      this.productoAgg.descuento = this.descuento;
      if (this.factura.detalles.length === 0) {
        this.factura.detalles.push(this.crearDetalle(this.productoAgg));
        this.calcularTotalFactura();
        this.calcularTotalDescuento();
        return;
      }else{
        this.factura.detalles.forEach(d => {
          if (d.producto.id === this.productoAgg.id) {
            this.encontrado = true;
          }else{
            this.encontrado = false;
          }
        });
      }

      if (this.encontrado) {
        alert('Este producto ya ha sido agregado');
      }else{
        this.factura.detalles.push(this.crearDetalle(this.productoAgg));
        this.calcularTotalFactura();
        this.calcularTotalDescuento();
      }
    }
  }

  verificarCantidad(): boolean {
    if (this.cantidad === 0) {
      alert('La cantidad no pueder ser 0');
      return false;
    }
    return true;
  }

  verificarPrecio(p: Producto): number {
    if (this.precio === 0) {
      return p.precio;
    }
    return this.precio;
  }

  crearDetalle(p: Producto): Detalle {
    this.detalle = new Detalle();
    this.detalle.precioProducto = this.verificarPrecio(p);
    this.detalle.cantidad = this.cantidad;
    this.detalle.descuento = this.descuento;
    this.detalle.producto = p;
    this.detalle.idProducto = p.id;
    this.detalle.total = this.calcularTotalDetalle(this.detalle.cantidad, this.detalle.precioProducto, this.detalle.descuento);
    this.productosAgregados.push(p);
    return this.detalle;
  }

  calcularDescuento(): void {}

  calcularTotalDetalle(cantidad, precio, descuento): number {
    const total = cantidad * precio;
    return total - descuento;
  }

  calcularTotalFactura(): void {
    this.totalview = 0;
    this.factura.detalles.forEach(d => {
      this.totalview = this.totalview + d.total;
    });
    this.factura.total = this.totalview;
  }

  calcularTotalDescuento(): void {
    this.descuentoview = 0;
    this.factura.detalles.forEach( d => {
      this.descuentoview = this.descuentoview + d.producto.descuento;
    });
    this.factura.descuento = this.descuentoview;
  }

  generarFactura(): void {
    if (this.factura.detalles.length === 0){
      alert('Debe agregar al menos un detalle');
      return;
    }else{
      this.facturaService.post(this.factura).subscribe( f => {
        console.log(f);
      });
    }
  }

  buscarCliente(): void {
    if (this.clienteId.trim().length > 0) {
      this.interesadoService.getById(this.clienteId).subscribe( i => {
        if (i !== null) {
          this.interesado = i;
          this.factura.interesado = this.interesado;
          alert('Cliente encontrado');
          return;
        }
        alert('Cliente no encontrado');
        return;
      });
      return;
    }
    alert('Digite una identificacon para cliente id');
  }
}
