using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SisAdv.Database;
using SisAdv.Interface;
using SisAdv.Models;

namespace SisAdv.Models
{
    class ClienteDAO : IDAO<Cliente>
    { 
        private static Conexao conn;

        public ClienteDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Cliente t)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente t)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM cliente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    /*Observação: vou deixar esse comentário aqui pra vc Bruno, faltam coisas para 
                     * adicionar no Cliente.Cs (Model), 
                     * no banco de dados tem muito mais atributos.*/
                    list.Add(new Cliente()
                    {
                        Id = reader.GetInt32("id_cliente"),
                        Nome = reader.GetString("nome_cli"),
                        Rg = reader.GetString("rg_cli"),
                        Cpf = reader.GetString("cpf_cli")
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Cliente t)
        {
            throw new NotImplementedException();
        }
    }
}
