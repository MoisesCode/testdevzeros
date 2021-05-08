import { Producto } from './producto';

export class Detalle {
  id: string;
  facturaId: string;
  cantidad: number;
  total: number;
  descuento: number;
  precioProducto: number;
  idProducto: string;
  producto: Producto;
}
