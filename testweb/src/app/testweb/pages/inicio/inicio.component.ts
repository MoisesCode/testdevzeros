import { Component, OnInit } from '@angular/core';

import { Producto } from '../../models/producto';
import { Usuario } from '../../models/usuario';
import { ProductoService } from '../../services/producto.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  productos: Producto[];

  constructor(private productoService: ProductoService) { }

  usuario: Usuario;
  usuarioInteresado = false;
  usuarioVentas = false;

  permisoRegistrarProductos = false;
  permisoEliminarProductos = false;
  permisoModificarProductos = false;
  permisoGenerarFactura = false;
  ngOnInit(): void {
    this.usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
    this.verificarPermiso();
    this.consultar();
  }

  verificarPermiso(): void{
    if (this.usuario.rol === 'interesado'){
      this.usuarioInteresado = false;
      this.permisoGenerarFactura = false;
    }else if (this.usuario.rol === 'ventas'){
      this.permisoRegistrarProductos = false;
      this.permisoEliminarProductos = false;
      this.permisoGenerarFactura = true;
    }else if (this.usuario.rol === 'avaluos'){
      this.permisoRegistrarProductos = true;
      this.permisoEliminarProductos = true;
      this.permisoModificarProductos = true;
      this.permisoGenerarFactura = false;
    }else{
      this.usuarioInteresado = true;
      this.usuarioVentas = false;
    }
  }

  consultar(): void {
    this.productos = [];
    this.productoService.gets().subscribe( p =>
      this.productos = p
    );
  }

  productoId(producto: Producto): void {
    this.productoService.guardarProducto(producto);
  }
}
