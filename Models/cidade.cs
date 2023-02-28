using System;





namespace Models
{

    public class Cidade
    {
        public int Id {get; set; }

        public string Nome {get; set; }

        public Cidade(int id, string nome)
        {
            Id = id;
            Nome = nome;

            Cidades.Add(this);
        }

        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome}";
        }
        public static List<Cidade> Cidades = new List<Cidade>();

        public static void AlterarCidade(int id, string nome)
        {
            Cidade? cidade = Cidades.Find(c => c.Id == id);
            Cidades.Nome = nome;
        }

        public static void RemoverCidade(int id)
        {
            Cidade? cidade = Cidades.Find(c => c.Id == id);
            Cidades.Remove(cidade);
        }

        public  BuscarCidade(int id)
        {
            Cidade? cidade = Cidades.Find(c => c.Id == id);
            if (cidade == null){
                throw new Exception("Cidade não encontrada");
            }
            return cidade;
        }

    }
}
    



