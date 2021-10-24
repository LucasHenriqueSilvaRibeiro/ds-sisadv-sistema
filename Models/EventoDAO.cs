using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Interface;
using SisAdv.Database;
using MySql.Data.MySqlClient;
using SisAdv.Helpers;

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
                query.CommandText = "CALL inserirEvento (@titulo,  @data, @horario, @descricao, @importancia, @notificacao)";

                query.Parameters.AddWithValue("@titulo", t.Titulo);
                query.Parameters.AddWithValue("@horario", t.Horario);
                query.Parameters.AddWithValue("@data", t.Data);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@importancia", t.Importancia);
                query.Parameters.AddWithValue("@notificacao", t.Notificacao);

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

        public List<Evento> List()
        {
            try
            {
                List<Evento> list = new List<Evento>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM evento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Evento()
                    {
                        Id = reader.GetInt32("id_evento"),
                        Importancia = reader.GetString("importancia_even"),
                        Horario = DAOHelper.GetString(reader, "horario_even"),
                        Data = DAOHelper.GetDateTime(reader, "data_even"),
                        Descricao = DAOHelper.GetString(reader, "descricao_even"),
                        Notificacao = reader.GetBoolean("notificacao_even"),
                        Titulo = DAOHelper.GetString(reader, "titulo_even")
                    });
                }

                return list;
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

        public void Update(Evento t)
        {
            throw new NotImplementedException();
        }
    }
}
