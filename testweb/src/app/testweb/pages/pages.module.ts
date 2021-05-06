import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { InicioComponent } from './inicio/inicio.component';
import { RouterModule } from '@angular/router';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ComponentsModule } from '../components/components.module';
import { InteresadoRegistroComponent } from './interesado/interesado-registro/interesado-registro.component';
import { InteresadoConsultaComponent } from './interesado/interesado-consulta/interesado-consulta.component';

@NgModule({
  declarations: [
    LoginComponent,
    InicioComponent,
    InteresadoRegistroComponent,
    InteresadoConsultaComponent
  ],
  exports: [
    LoginComponent,
    InicioComponent,
    InteresadoRegistroComponent,
    InteresadoConsultaComponent
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
