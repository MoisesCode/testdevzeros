import { Component, OnInit } from '@angular/core';
import { Detalle } from 'src/app/testweb/models/detalle';
import { Factura } from 'src/app/testweb/models/factura';
import { Producto } from 'src/app/testweb/models/producto';
import { DetalleService } from 'src/app/testweb/services/detalle.service';
import { ProductoService } from 'src/app/testweb/services/producto.service';

@Component({
  selector: 'app-producto-detalle',
  templateUrl: './producto-detalle.component.html',
  styleUrls: ['./producto-detalle.component.css']
})
export class ProductoDetalleComponent implements OnInit {

  detalle: Detalle = new Detalle();
  producto: Producto;
  detalles: Detalle[] = [];

  constructor(private productoService: ProductoService, private detalleService: DetalleService) { }

  ngOnInit(): void {
    this.producto = this.productoService.productoNuevo;
    this.buscarDetalle();
  }

  buscarDetalle(): void {
    this.detalleService.getById(this.producto.detalleId).subscribe(d =>
      this.detalle = d
    );
  }
}
