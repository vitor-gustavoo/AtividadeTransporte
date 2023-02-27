

namespace Controller;

    public class cidadeController
    {
        public int Id {get; set; }

        public string Nome {get; set; }

        public cidadeController(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }