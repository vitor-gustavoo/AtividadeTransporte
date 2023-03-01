


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

        public static List<string> ListarCaminhoes()
        {
            List<string> stringCaminhoes = new List<string>();
            IEnumerable<Models.Caminhao> caminhoes = from caminhao in Models.Caminhao.Caminhoes
                select caminhao;
            
            foreach (Models.Caminhao caminhao1 in caminhoes){
                stringCaminhoes.Add($"Id: {caminhao1.Id}, Placa: {caminhao1.Placa}, caminhão: {caminhao1.Motorista}");
            }
            return stringCaminhoes;
        }
        

            
    }
    

}
