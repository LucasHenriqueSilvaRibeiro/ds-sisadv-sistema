using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Interface;
using SisAdv.Helpers;
using MySql.Data.MySqlClient;
using SisAdv.Database;

namespace SisAdv.Models
{
    class PagamentoDAO : IDAO<Pagamento>
    {
        //Lembrar de testar todos depois e adicionar no cadastrar.cs

        private Conexao conn;
        public PagamentoDAO()
        {
            conn = new Conexao();
        }
        public void Delete(Pagamento t)
        {
            throw new NotImplementedException();
        }

        public Pagamento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Pagamento t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL registrarPagamento(@tipo, @data, @despesa, @caixa)";

                query.Parameters.AddWithValue("@tipo", t.TipoPagamento);
                query.Parameters.AddWithValue("@data", t.DataPagamento?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@despesa", t.Despesa.Id);
                query.Parameters.AddWithValue("@caixa", t.Caixa.Id);

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Pagamento> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Pagamento t)
        {
            throw new NotImplementedException();
        }
    }
}
