import { Component, OnInit } from '@angular/core';

import { Producto } from '../../models/producto';
import { ProductoService } from '../../services/producto.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  productos: Producto[];

  constructor(private productoService: ProductoService) { }

  ngOnInit(): void {
    this.consultar();
  }

  consultar(): void {
    this.productos = [];
    this.productoService.gets().subscribe( p =>
      this.productos = p
    );
  }
}
