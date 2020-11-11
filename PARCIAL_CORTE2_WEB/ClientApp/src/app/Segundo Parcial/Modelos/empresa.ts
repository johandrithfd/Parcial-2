import { Credito } from "./credito";

export class Empresa {
  empresaId: string;
  nombre: string;
  cantidadTrabajadores: number;
  valorActivos: number;
  tipo: string;
  credito: Credito = new Credito();
}
