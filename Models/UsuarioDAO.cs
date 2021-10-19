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
    class UsuarioDAO : IDAO<Usuario>
    {
        private static Conexao conn;

        public UsuarioDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Usuario t)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Usuario t)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> List()
        {
            try
            {
                List<Usuario> list = new List<Usuario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM usuario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Usuario()
                    {
                        Id = reader.GetInt32("id_user"),
                        Nome = reader.GetString("nome_user"),
                        Descricao = reader.GetString("descricao_user"),
                        Rg = reader.GetString("rg_user"),
                        Cpf = reader.GetString("cpf_user"),
                        Telefone = reader.GetString("telefone_user"),
                        Email = reader.GetString("email_user"),
                        Login = reader.GetString("login_user"),
                        Senha = reader.GetString("senha_user"),
                        DataNasc = reader.GetDateTime("datanasc_user"),
                        Tipo = reader.GetString("tipo_user")
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
