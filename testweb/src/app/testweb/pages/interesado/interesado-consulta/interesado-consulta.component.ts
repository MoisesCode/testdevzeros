import { Component, OnInit } from '@angular/core';
import { Interesado } from 'src/app/testweb/models/interesado';

import { InteresadoService } from 'src/app/testweb/services/interesado.service';

@Component({
  selector: 'app-interesado-consulta',
  templateUrl: './interesado-consulta.component.html',
  styleUrls: ['./interesado-consulta.component.css']
})
export class InteresadoConsultaComponent implements OnInit {

  interesados: Interesado[] = [];
  idEliminar: string;

  constructor(private interesadoService: InteresadoService) { }

  ngOnInit(): void {
    this.consultar();
  }

  consultar(): void {
    this.interesados = [];
    this.interesadoService.gets().subscribe( i =>
      this.interesados = i
    );
  }

  onClick(id: string): void {
    this.idEliminar = id;
  }

  eliminar(): void {
    this.interesadoService.delete(this.idEliminar).subscribe();
    window.location.reload();
  }

  onModificar(interado: Interesado): void {
    this.interesadoService.onModificar(interado);
  }

  onNuevoInteresado(): void {
    this.interesadoService.interesadoModificar = null;
  }
}
