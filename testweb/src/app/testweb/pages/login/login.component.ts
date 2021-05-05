import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  ruta = '/inicio';

  constructor() { }

  ngOnInit(): void {
  }

  onClick(): void{
    this.ruta = '/inicio';
  }
}
