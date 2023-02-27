namespace Models;

    public class Rota 
    {
        public int Id {get; set; }

        public int idCaminhao {get; set; }
        public string Partida {get; set; }
        public string Chegada {get; set; }
        public string Data {get; set; }

        public Rota(int id, int idCaminhao, string partida, string chegada, string data)
        {
            Id = id;
            Partida = partida;
            Chegada = chegada;
            Data = data;
        }

    }