using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Interface;
using MySql.Data.MySqlClient;
using SisAdv.Database;
using SisAdv.Models;
using SisAdv.Helpers;

namespace SisAdv.Models
{
    class ProcessoDAO : IDAO<Processo>
    {
        private Conexao conn;

        public ProcessoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Processo t)
        {
            throw new NotImplementedException();
        }

        public Processo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Processo t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL registrarProcesso(@descricao, @data, @status, @resultado, @servico)";

                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@data", t.DataProcesso?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@status", t.Status);
                query.Parameters.AddWithValue("@resultado", t.Resultado);
                query.Parameters.AddWithValue("@servico", t.Servico.Id);

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

        public List<Processo> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Processo t)
        {
            throw new NotImplementedException();
        }
    }
}
