using Controller;

namespace Models

{
    public class Rota 
    {
        public int Id {get; set; }
        private int _origemId;
        public Cidade Origem {get; set;}
        private int _destinoId;
        public Cidade Destino {get; set;}
        private int _caminhaoId;
        public Caminhao Caminhao {get; set; }
        public string Data {get; set; }

        public static List<Rota> Rotas {get; set;} = new List<Rota>();

        public Rota(int id, Cidade origem, Cidade destino, Caminhao caminhao, string data)
        {
            Id = id;
            Origem = origem;
            _origemId = origem.Id;
            Destino = destino;
            _destinoId = destino.Id;
            Caminhao = caminhao;
            _caminhaoId = caminhao.Id;
            Data = data;

            Rotas.Add(this);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Origem: {Origem}, Destino: {Destino}, Caminhão: {Caminhao}, Data: {Data}";
        }

        public static void AlterarRota(int id, Cidade origem, Cidade destino, Caminhao caminhao, string data)
        {
            Rota rota = BuscarRota(id);
            rota.Origem = origem;
            rota.Destino = destino;
            rota.Caminhao = caminhao;
            rota.Data = data;
        }

        public static void ExcluirRota(int id)
        {
            Rota rota = BuscarRota(id);
            Rotas.Remove(rota);
        }

        public static Rota BuscarRota(int id)
        {
            Rota? rota = Rotas.Find(r => r.Id == id);
            if(rota == null){
                throw new Exception("Rota não localizada!");
            }
            return rota;
        }


    }
}