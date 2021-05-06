import { Component, OnInit } from '@angular/core';
import { Factura } from 'src/app/testweb/models/factura';

@Component({
  selector: 'app-producto-detalle',
  templateUrl: './producto-detalle.component.html',
  styleUrls: ['./producto-detalle.component.css']
})
export class ProductoDetalleComponent implements OnInit {

  facturas: Factura[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
