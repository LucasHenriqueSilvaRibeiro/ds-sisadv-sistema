using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Interface;
using MySql.Data.MySqlClient;
using SisAdv.Database;

namespace SisAdv.Models
{
    class ServicoDAO : IDAO<Servico>
    {
        private static Conexao conn;

        public ServicoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Servico t)
        {
            throw new NotImplementedException();
        }

        public Servico GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Servico t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL inserirServico(@valor, @data, @tipo, @advogado, @cliente, @evento)";

                query.Parameters.AddWithValue("@valor", t.Valor);
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@tipo", t.Tipo);
                query.Parameters.AddWithValue("@advogado", t.Advogado);
                query.Parameters.AddWithValue("@cliente", t.Cliente);
                query.Parameters.AddWithValue("@evento", t.Evento);

                var result = query.ExecuteNonQuery();

                /*if (result == 0)
                    throw new Exception("O registro não será inserido. Tente novamente após corrigir algum erro.");*/

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

        public List<Servico> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Servico t)
        {
            throw new NotImplementedException();
        }
    }
}
