import { Producto } from './producto';

export class Detalle {
  id: string;
  facturaId: string;
  cantidad: number;
  descuento: number;
  total: number;
  producto: Producto;
}
