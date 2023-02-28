using System;

using Models;

namespace Controller;

    public class Cidade
    {
          public static void CadastrarCidade(string id, string nome)
          {
             int idConvert = int.Parse(id);
             try
             {
               Cidade cidade = new Cidade(id, nome);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }
          }

          public static void BuscarCidade(string id)
          {
               int idConvert = int.Parse(id);
               try
               {
                    Cidade cidade = new Cidade(id, "");
               }
               catch (Exception e)
               {
                    Console.WriteLine(e.Message);
               }
          }
          
          public static void AtulizarCidade(string id, string nome)
          {
               Cidade cidade = new Cidade(id, nome);
               
          }

          public static void RemoverCidade(string id)
          {
               Cidade cidade = new Cidade(id, "");
               
          }



    } 