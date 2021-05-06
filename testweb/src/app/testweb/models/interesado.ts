import { Factura } from './factura';

export class Interesado {
  id: string;
  nombre: string;
  celular: string;
  correo: string;
  contrasena: string;
  facturas: Factura[];
}
