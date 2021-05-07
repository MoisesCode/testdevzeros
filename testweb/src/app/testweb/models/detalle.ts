import { Producto } from './producto';

export class Detalle {
  id: string;
  facturaId: string;
  cantidad: number;
  total: number;
  descuento: number;
  idProducto: string;
  producto: Producto;
}
