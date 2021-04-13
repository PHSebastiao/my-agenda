export class Event {
  id: number;
  tipo: string;
  titulo: string;
  descricao: string;
  dataInicio: Date;
  dataFim: Date;
  local: string;
  participantes: object[];
}
