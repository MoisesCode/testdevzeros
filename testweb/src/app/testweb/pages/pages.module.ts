import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { InicioComponent } from './inicio/inicio.component';
import { RouterModule } from '@angular/router';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ComponentsModule } from '../components/components.module';
import { InteresadoRegistroComponent } from './interesado/interesado-registro/interesado-registro.component';
import { InteresadoConsultaComponent } from './interesado/interesado-consulta/interesado-consulta.component';
import { ProductoRegistroComponent } from './producto/producto-registro/producto-registro.component';
import { ProveedorRegistroComponent } from './proveedor/proveedor-registro/proveedor-registro.component';
import { ProveedorConsultaComponent } from './proveedor/proveedor-consulta/proveedor-consulta.component';
import { ProductoDetalleComponent } from './producto/producto-detalle/producto-detalle.component';

@NgModule({
  declarations: [
    LoginComponent,
    InicioComponent,
    InteresadoRegistroComponent,
    InteresadoConsultaComponent,
    ProductoRegistroComponent,
    ProveedorRegistroComponent,
    ProveedorConsultaComponent,
    ProductoDetalleComponent
  ],
  exports: [
    LoginComponent,
    InicioComponent,
    InteresadoRegistroComponent,
    InteresadoConsultaComponent,
    ProductoRegistroComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ComponentsModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class PagesModule { }
