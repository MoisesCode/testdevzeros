import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { InicioComponent } from './testweb/pages/inicio/inicio.component';
import { LoginComponent } from './testweb/pages/login/login.component';
import { InteresadoConsultaComponent } from './testweb/pages/interesado/interesado-consulta/interesado-consulta.component';
import { InteresadoRegistroComponent } from './testweb/pages/interesado/interesado-registro/interesado-registro.component';

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
