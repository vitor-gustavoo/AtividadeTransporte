namespace Controller
{
    public class Rota
    {
        public static void CadastrarRota(string id, string origemId, string destinoId, string caminhaoId, string data, string valor)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id Inválido");
            }
            int origemIdConvert = 0; 
            try {
                origemIdConvert = int.Parse(origemId);
            } catch (Exception) {
                throw new Exception("Id Inválido");
            }
            Models.Cidade origem = Models.Cidade.BuscarCidade(origemIdConvert);
            Models.Cidade destino = Models.Cidade.BuscarCidade(int.Parse(destinoId));
            Models.Caminhao caminhao = Models.Caminhao.BuscarCaminhao(int.Parse(caminhaoId));
            Models.Rota rota = new Models.Rota(idConvert, origem, destino, caminhao, data, double.Parse(valor));
        }
 
        public static void AlterarRota(string id, string origemId, string destinoId, string caminhaoId, string data, string valor)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Models.Cidade origem = Models.Cidade.BuscarCidade(int.Parse(origemId));
            Models.Cidade destino = Models.Cidade.BuscarCidade(int.Parse(destinoId));
            Models.Caminhao caminhao = Models.Caminhao.BuscarCaminhao(int.Parse(caminhaoId));
            Models.Rota.AlterarRota(idConvert, origem, destino, caminhao, data, Double.Parse(valor));
        }
 
        public static void ExcluirRota(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Models.Rota.ExcluirRota(idConvert);
        }
 
        public static Models.Rota BuscarRota(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Models.Rota.BuscarRota(idConvert);
        }

         
 
        public static List<string> ListarRotas()
        {
            List<string> stringRotas = new List<string>();
            IEnumerable<Models.Rota> rotas = from rota in Models.Rota.Rotas
                join origem in Models.Cidade.Cidades on rota.Origem.Id equals origem.Id
                join destino in Models.Cidade.Cidades on rota.Destino.Id equals destino.Id
                join caminhao in Models.Caminhao.Caminhoes on rota.Caminhao.Id equals caminhao.Id
                select rota;

            foreach (Models.Rota rota in rotas) {
                stringRotas.Add($"Id: {rota.Id}, Origem: {rota.Origem.Nome}, Destino: {rota.Destino.Nome}, Caminhão: {rota.Caminhao.Placa}, Data: {rota.Data}");
            }
            
            return stringRotas;
        }

       public static double MediaDeFrete()
        {
            double totalFrete = (from rota in Models.Rota.Rotas
            select rota.Valor).Average();
            return totalFrete;
        }
    }

}