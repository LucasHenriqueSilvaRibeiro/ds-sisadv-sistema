using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SisAdv.Database;
using SisAdv.Interface;
using System.Windows;//tirar dps

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
            try
            {
                var query = conn.Query();

                //Verificar tabela processo;
                query.CommandText = "DELETE FROM cliente WHERE id_cliente = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Registro não foi deletado da base de dados. Verifique e tente novamente.");

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
    

        public Cliente GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM cliente WHERE id_cliente = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var cliente = new Cliente();

                while (reader.Read())
                {
                    cliente.Id = reader.GetInt32("id_cliente");                    
                    cliente.Profissao = reader.GetString("profissao_cli");
                    //cliente.Cpf = reader.GetString("cpf_cli");
                    cliente.Descricao = reader.GetString("descricao_cli");
                    cliente.Nome = reader.GetString("nome_cli");
                    cliente.Rg = reader.GetString("rg_cli");
                }

                MessageBox.Show($"nome {cliente.Nome} descrição {cliente.Descricao} email {cliente.Email} profissão {cliente.Profissao} telefone {cliente.Telefone}", "", MessageBoxButton.OK, MessageBoxImage.Information);


                return cliente;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
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

        public List<Cliente> ListConsulta(string nome, string rg, string cpf)
        {
            try
            {
                string textoSelect = "SELECT  * FROM cliente WHERE";

                List<Cliente> listConsulta = new List<Cliente>();

                var query = conn.Query();

                if ((nome != null) && (rg != null) && (cpf != null))
                    query.CommandText = $"{textoSelect} nome_cli like '%{nome}%' and rg_cli like '{rg}%' and cpf_cli like '{cpf}%'";
                else if ((nome != null) && (rg != null))
                    query.CommandText = $"{textoSelect} nome_cli like '%{nome}%' and rg_cli like '{rg}%'";
                else if ((nome != null) && (cpf != null))
                    query.CommandText = $"{textoSelect} nome_cli like '%{nome}%' and cpf_cli like '{cpf}%'";
                else if ((cpf != null) && (rg != null))
                    query.CommandText = $"{textoSelect} rg_cli like '{rg}%' and cpf_cli like '{cpf}%'";
                else if (cpf != null)
                    query.CommandText = $"{textoSelect} cpf_cli like '{cpf}%'";
                else if (nome != null)
                    query.CommandText = $"{textoSelect} nome_cli like '%{nome}%'";
                else if (rg != null)
                    query.CommandText = $"{textoSelect} rg_cli like '{rg}%'";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listConsulta.Add(new Cliente()
                    {
                        Id = reader.GetInt32("id_cliente"),
                        Nome = reader.GetString("nome_cli"),
                        Rg = reader.GetString("rg_cli"),
                        Cpf = reader.GetString("cpf_cli")
                    });
                }

                return listConsulta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Cliente t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "SET nome_cli = @nome, cpf_cli = @cpf, rg_cli = @rg, telefone_cli = @telefone," +  
                                    "profissao_cli = @profissao, descricao_cli = @descricao WHERE id_cliente = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@rg", t.Rg);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@profissao", t.Profissao);
                query.Parameters.AddWithValue("@descricao", t.Descricao);

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada.");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
