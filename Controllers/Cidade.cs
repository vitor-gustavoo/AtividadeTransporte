using System;

using Models;

namespace Controller

{
  public class Cidade
    {
        public static void CadastrarCidade(string id, string nome)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Models.Cidade cidade = new Models.Cidade(idConvert, nome);
        }

        public static void AlterarCidade(string id, string nome)
        {
            int idConvert = int.Parse(id);
            try
            {
                Models.Cidade cidade = new Models.Cidade(idConvert, nome);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Id inválido! {e}");
            }

            Models.Cidade.AlterarCidade(idConvert, nome);
        
        }

        public static void ExcluirCidade(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Models.Cidade.ExcluirCidade(idConvert);
        }

        public static Models.Cidade BuscarCidade(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Models.Cidade.BuscarCidade(idConvert);
    
        }
        
        public static List<string> ListarCidades()
        {
            List<string> stringCidades = new List<string>();
            IEnumerable<Models.Cidade> cidades = from cidade in Models.Cidade.Cidades
                select cidade;

            foreach (Models.Cidade cidade in cidades) {
                stringCidades.Add($"Id: {cidade.Id}, Nome: {cidade.Nome}");
            }

            return stringCidades;
        }

    }      
  
}