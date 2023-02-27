namespace Models;

    public class Caminhao 
    {
        public int Id {get; set; }

        public string Placa {get; set; }

        public string Motorista { get; set;}

        public Caminhao(int id, string placa, string motorista)
        {
            Id = id;
            Placa = placa;
            Motorista = motorista;
        }
    }