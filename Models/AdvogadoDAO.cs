using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SisAdv.Database;
using SisAdv.Interface;

namespace SisAdv.Models
{
    class AdvogadoDAO : IDAO<Advogado>
    {
        private static Conexao conn;

        public AdvogadoDAO()
        {
            conn = new Conexao();
        }
    
        public void Delete(Advogado t)
        {
            throw new NotImplementedException();
        }

        public Advogado GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Advogado t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL inserirAdvogado(@nome, @cpf, @rg, @data, @email, @telefone, @descricao)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@data", t.DataNasc?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@rg", t.Rg);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@descricao", t.Descricao);

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

        public List<Advogado> List()
        {
            try
            {
                List<Advogado> list = new List<Advogado>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM advogado";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Advogado()
                    {
                        Id = reader.GetInt32("id_advogado"),
                        Nome = reader.GetString("nome_adv"),
                        Descricao = reader.GetString("descricao_adv"),
                        Rg = reader.GetString("rg_adv"),
                        Cpf = reader.GetString("cpf_adv"),
                        Telefone = reader.GetString("telefone_adv"),
                        Email = reader.GetString("e_mail_adv"),
                        DataNasc = reader.GetDateTime("data_nasc_adv")
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Advogado t)
        {
            throw new NotImplementedException();
        }
    }
}
