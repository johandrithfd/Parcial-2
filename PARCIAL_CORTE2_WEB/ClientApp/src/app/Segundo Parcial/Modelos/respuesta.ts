export class Respuesta <G>
{
  constructor(Elemento: G) {
    this.elemento = Elemento;
  }
  elemento: G;
  mensaje: string;
  error: boolean;
}
