import { Detalle } from './detalle';
import { Interesado } from './interesado';

export class Factura {
  id: string;
  tipo: string;
  descuento: number;
  total: number;
  idInteresado: string;
  interesado?: Interesado;
  detalles: Detalle[];
}
