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

  ngOnInit(): void {
    this.usuario = (JSON.parse(sessionStorage.getItem('currentUser')));
    this.verificarPermiso();
    this.consultar();
  }

  verificarPermiso(): void{
    if (this.usuario.rol === 'interesado'){
      this.usuarioInteresado = false;
    }else{
      this.usuarioInteresado = true;
    }
  }

  consultar(): void {
    this.productos = [];
    this.productoService.gets().subscribe( p =>
      this.productos = p
    );
  }
}
