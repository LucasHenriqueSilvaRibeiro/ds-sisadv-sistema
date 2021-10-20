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
using SisAdv.Views;

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
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM servico WHERE id_servico = @id";

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

        public Servico GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM servico LEFT JOIN cliente ON fk_cliente = id_cliente WHERE id_servico = @id ";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var servico = new Servico();

                while (!reader.Read())
                {
                    servico.Id = reader.GetInt32("id_servico");
                    servico.Valor = reader.GetDouble("valor_serv");
                    servico.Data = reader.GetDateTime("data_serv");
                    servico.Descricao = reader.GetString("descricao_serv");
                    servico.Tipo = reader.GetString("tipo_serv");

                    //CÓDIGO AULA 1:N

                    if (!DAOHelper.IsNull(reader, "fk_cliente"))
                        servico.Cliente = new Cliente()
                        {
                            Id = reader.GetInt32("id_cliente"),
                            Nome = reader.GetString("nome_cli")
                        };

                    //servico.Cliente.Id = reader.GetInt32("fk_cliente");
                    //servico.Usuario.Id = reader.GetInt32("fk_advogado");
                }

                return servico;

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

        public void Insert(Servico t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL inserirServico(@valor, @data, @tipo, @advogado, @cliente, @descricao)";

                query.Parameters.AddWithValue("@valor", t.Valor);
                query.Parameters.AddWithValue("@data", t.Data?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@tipo", t.Tipo);
                query.Parameters.AddWithValue("@advogado", t.Usuario.Id);
                query.Parameters.AddWithValue("@cliente", t.Cliente.Id);
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

        public List<Servico> List()
        {
            try
            {                
                List<Servico> list = new List<Servico>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM servico";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Servico()
                    {
                        Id = reader.GetInt32("id_servico"),
                        Valor = DAOHelper.GetDouble(reader, "valor_serv"),
                        Data = DAOHelper.GetDateTime(reader, "data_serv"),
                        Tipo = DAOHelper.GetString(reader, "tipo_serv"),
                        Descricao = DAOHelper.GetString(reader,"descricao_serv"),

                        //CÓDIGO AULA 1:N
                        Cliente = DAOHelper.IsNull(reader, "cliente_serv") ? null : new Cliente() { Id = reader.GetInt32("fk_cliente"), Nome = reader.GetString("cliente_serv") },
                        Usuario = DAOHelper.IsNull(reader, "usuario_serv") ? null : new Usuario() { Id = reader.GetInt32("fk_usuario"), Nome = reader.GetString("usuario_serv") }
                    }) ;                    
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

        public List<Servico> ListConsulta(string cliente, string data, string tipoServico)
        {
            try
            {
                List<Servico> listConsulta = new List<Servico>();                

                var query = conn.Query();

                if ((cliente != null) && (data != null) && (tipoServico != null))
                    query.CommandText = $"SELECT  * FROM servico LEFT JOIN cliente ON fk_cliente = id_cliente WHERE cliente_serv LIKE '{cliente}%' AND data_serv = '{data}' AND tipo_serv = '{tipoServico}'";
                else if ((cliente != null) && (data != null))
                    query.CommandText = $"SELECT * FROM servico LEFT JOIN cliente ON fk_cliente = id_cliente WHERE cliente_serv LIKE '{cliente}%' AND data_serv = '{data}'";
                else if ((cliente != null) && (tipoServico != null))
                    query.CommandText = $"SELECT * FROM servico LEFT JOIN cliente ON fk_cliente = id_cliente WHERE cliente_serv LIKE '{cliente}%' AND tipo_serv = '{tipoServico}'";
                else if ((tipoServico != null) && (data != null))
                    query.CommandText = $"SELECT * FROM servico LEFT JOIN cliente ON fk_cliente = id_cliente WHERE data_serv = '{data}' AND tipo_serv = '{tipoServico}'";
                else if (tipoServico != null)
                    query.CommandText = $"SELECT * FROM servic LEFT JOIN cliente ON fk_cliente = id_clienteo WHERE tipo_serv = '{tipoServico}'";                
                else if (cliente != null)                
                    query.CommandText = $"SELECT * FROM servico LEFT JOIN cliente ON fk_cliente = id_cliente WHERE cliente_serv LIKE '{cliente}%'";
                else if (data != null)                
                    query.CommandText = $"SELECT * FROM servico LEFT JOIN cliente ON fk_cliente = id_cliente WHERE data_serv = '{data}' ";                

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listConsulta.Add(new Servico()
                    {
                        Id = reader.GetInt32("id_servico"),
                        Data = DAOHelper.GetDateTime(reader, "data_serv"),
                        Tipo = DAOHelper.GetString(reader, "tipo_serv"),

                        //CÓDIGO AULA 1:N
                        Cliente = DAOHelper.IsNull(reader, "fk_cliente") ? null : new Cliente() { Id = reader.GetInt32("id_cliente"), Nome = reader.GetString("nome_cli"), 
                            Cpf = reader.GetString("cpf_cli"), Rg = reader.GetString("rg_cli") }
                        //Usuario = DAOHelper.IsNull(reader, "usuario_serv") ? null : new Usuario() { Id = reader.GetInt32("fk_usuario"), Nome = reader.GetString("usuario_serv") }
                    });
                }

                return listConsulta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Servico t)
        {
            throw new NotImplementedException();
        }
    }
}
