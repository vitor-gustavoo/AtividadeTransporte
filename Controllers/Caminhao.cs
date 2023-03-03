


namespace Controller

{
    public class Caminhao
    {
        private static void ValidaPlaca(string placa)
        {
            string[] placaSplit = placa.Split('-');
            if(placaSplit.Length !=2) {
                throw new Exception("Placa Inválida!");
            }
            if(placaSplit[0].Length !=3) {
                throw new Exception("Placa Inválida!");
            }
            if(placaSplit[1].Length != 4){
                throw new Exception("Placa Inválida!");
            }

            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";

            foreach (char letra in placaSplit[0]) {
                if(!letras.Contains(letra.ToString())) {
                    throw new Exception("Placa Inválida");
                }
            }

            foreach (char numero in placaSplit[0]) {
                if(!numeros.Contains(numeros.ToString())) {
                    throw new Exception("Placa Inválida");
                }
            }
        }
        public static void CadastrarCaminhao(string id, string placa, string motorista) 
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id Inválido");
            }

            ValidaPlaca(placa);
            Models.Caminhao caminhao = new Models.Caminhao(idConvert, placa, motorista);
        }

        public static void AlterarCaminhao(string id, string placa, string motorista)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            ValidaPlaca(placa);
            Models.Caminhao.AlterarCaminhao(idConvert, placa, motorista);
        }

        public static void ExcluirCaminhao(string id) 
        {
            int idConvert = 0;
            try
            {
                idConvert = int.Parse(id);
            }
            catch (Exception)
            {
                throw new Exception("Id Inválido!");
            }

            Models.Caminhao.ExcluirCaminhao(idConvert);
        }

        public static void BuscarCaminhao(string id)
        {
            int idConvert = 0;
            try
            {
                idConvert = int.Parse(id);
            }
            catch (Exception)
            {
                throw new Exception("Id Inválido");
            }

            Models.Caminhao.BuscarCaminhao(idConvert);
        }

        public static void TotalRotasCaminhao(string id) 
        {
            int idConvert = 0;
            try
            {
                idConvert = int.Parse(id);
            }
            catch (Exception)
            {
                throw new Exception("Id Inválido");
            }
            Models.Caminhao.CalculaRota(idConvert);
           
        }
        public static int CalculaRota(int id)
        {
            int qtdCaminhoes =(from caminhao in Models.Caminhao.Caminhoes
                where caminhao.Id == id join rota in Models.Rota.Rotas on caminhao.Id equals rota.Caminhao.Id
                select caminhao).Count();

                if(qtdCaminhoes == 0) {
                    throw new Exception("Total de rotas não encontrado");
                }
                else
                {
                   return qtdCaminhoes;
                }     
        }
              public static double CalculaRotaEmReais(int id)
        {
            double valorRotas = (from rota in Models.Rota.Rotas
                where rota.Caminhao.Id == id join caminhao in Models.Caminhao.Caminhoes on rota.Caminhao.Id equals caminhao.Id
                select rota.Valor).Sum();
           
                if(valorRotas == 0) {
                    throw new Exception("Não existe valor de rotas para esse caminhão");
                }
                else
                {
                   return valorRotas;
                }
        }

     

        public static List<string> ListarCaminhoes()
        {
            List<string> stringCaminhoes = new List<string>();
            IEnumerable<Models.Caminhao> caminhoes = from caminhao in Models.Caminhao.Caminhoes
                select caminhao;
            
            foreach (Models.Caminhao caminhao in caminhoes){
                stringCaminhoes.Add($"Id: {caminhao.Id}, Placa: {caminhao.Placa}, caminhão: {caminhao.Motorista}");
            }
            return stringCaminhoes;
        }
            
    }   

}
