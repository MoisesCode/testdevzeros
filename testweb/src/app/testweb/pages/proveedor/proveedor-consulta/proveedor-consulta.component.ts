import { Component, OnInit } from '@angular/core';

import { Proveedor } from 'src/app/testweb/models/proveedor';
import { ProveedorService } from 'src/app/testweb/services/proveedor.service';

@Component({
  selector: 'app-proveedor-consulta',
  templateUrl: './proveedor-consulta.component.html',
  styleUrls: ['./proveedor-consulta.component.css']
})
export class ProveedorConsultaComponent implements OnInit {

  proveedores: Proveedor[];
  constructor(private proveedorService: ProveedorService) { }

  ngOnInit(): void {
    this.consultar();
  }

  consultar(): void {
    this.proveedores = [];
    this.proveedorService.gets().subscribe( p =>
      this.proveedores = p
    );
  }
}
