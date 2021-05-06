import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { PagesModule } from './testweb/pages/pages.module';
import { ComponentsModule } from './testweb/components/components.module';

import { HttpClientModule } from '@angular/common/http';

import { InteresadoService } from './testweb/services/interesado.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PagesModule,
    ComponentsModule,
    HttpClientModule
  ],
  providers: [InteresadoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
