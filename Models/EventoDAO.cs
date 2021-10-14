using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Interface;
using SisAdv.Database;

namespace SisAdv.Models
{
    class EventoDAO : IDAO<Evento>
    {
        private static Conexao conn;

        public EventoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Evento t)
        {
            throw new NotImplementedException();
        }

        public Evento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Evento t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO evento (titulo_even, horario_even, data_even, descricao_even, importancia_even, notificacao_even)" + 
                    "VALUES (@titulo, @horario, @data, @descricao, @importancia, @notificacao)";

                query.Parameters.AddWithValue("@titulo", t.Titulo);
                query.Parameters.AddWithValue("@horario", t.Horario);
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@importancia", t.Importancia);
                query.Parameters.AddWithValue("@notificacao", t.Notificacao);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não será inserido. Tente novamente após corrigir algum erro.");

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

        public List<Evento> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Evento t)
        {
            throw new NotImplementedException();
        }
    }
}
