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
import { ProductoDetalleComponent } from './testweb/pages/producto/producto-detalle/producto-detalle.component';

import { AuthGuard } from './guards/auth.guard';
import { AuthInteresadoGuard } from './guards/auth-interesado.guard';
import { AuthVentasGuard } from './guards/auth-ventas.guard';

const routes: Routes = [
  {
    path: 'inicio',
    canActivate: [AuthGuard, AuthInteresadoGuard, AuthVentasGuard],
    component: InicioComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'clientes',
    canActivate: [AuthGuard],
    component: InteresadoConsultaComponent
  },
  {
    path: 'registrarCliente',
    canActivate: [AuthGuard],
    component: InteresadoRegistroComponent
  },
  {
    path: 'registrarProducto',
    canActivate: [AuthGuard],
    component: ProductoRegistroComponent
  },
  {
    path: 'registrarProveedor',
    canActivate: [AuthGuard],
    component: ProveedorRegistroComponent
  },
  {
    path: 'proveedores',
    canActivate: [AuthGuard],
    component: ProveedorConsultaComponent
  },
  {
    path: 'detalles',
    component: ProductoDetalleComponent
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
