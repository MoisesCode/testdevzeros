import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { InicioComponent } from './testweb/pages/inicio/inicio.component';
import { LoginComponent } from './testweb/pages/login/login.component';
import { InteresadoConsultaComponent } from './testweb/pages/interesado/interesado-consulta/interesado-consulta.component';
import { InteresadoRegistroComponent } from './testweb/pages/interesado/interesado-registro/interesado-registro.component';
import { ProductoRegistroComponent } from './testweb/pages/producto/producto-registro/producto-registro.component';
import { ProveedorRegistroComponent } from './testweb/pages/proveedor/proveedor-registro/proveedor-registro.component';
import { ProveedorConsultaComponent } from './testweb/pages/proveedor/proveedor-consulta/proveedor-consulta.component';

const routes: Routes = [
  {
    path: 'inicio',
    component: InicioComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'clientes',
    component: InteresadoConsultaComponent
  },
  {
    path: 'registrarCliente',
    component: InteresadoRegistroComponent
  },
  {
    path: 'registrarProducto',
    component: ProductoRegistroComponent
  },
  {
    path: 'registrarProveedor',
    component: ProveedorRegistroComponent
  },
  {
    path: 'proveedores',
    component: ProveedorConsultaComponent
  },
  {
    path: '**',
    redirectTo: 'login'
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
