namespace Models

{
    public class Caminhao 
    {
        public int Id {get; set; }

        public string Placa {get; set; }

        public string Motorista { get; set;}

         public static List<Caminhao> Caminhoes {get; set;} = new List<Caminhao>();

        public Caminhao(int id, string placa, string motorista)
        {
            Id = id;
            Placa = placa;
            Motorista = motorista;
        }


        public override string ToString()
        {
            return $"Id: {Id} - Placa: {Placa} - Motorista: {Motorista}";
        }

        public static void AlterarCaminhao(int id, string placa, string motorista)
        {
            Caminhao caminhao = BuscarCaminhao(id);
            caminhao.Placa = placa;
            caminhao.Motorista = motorista;
        }

        public static void ExcluirCaminhao(int id)
        {
            Caminhao caminhao = BuscarCaminhao(id);
            Caminhoes.Remove(caminhao);
        }

        public static Caminhao BuscarCaminhao(int id)
        {
            Caminhao? caminhao = Caminhoes.Find(ca => ca.Id == id);
            if(caminhao == null){
                throw new Exception("Caminhão não localizado!");
            }
             return caminhao;
        }
    }   


}
