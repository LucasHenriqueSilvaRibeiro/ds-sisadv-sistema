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
                query.CommandText = "SELECT * FROM servico WHERE id_servico = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var servico = new Servico();

                while (!reader.Read())
                {
                    servico.Id = reader.GetInt32("id_servico");
                    servico.ClienteNome = reader.GetString("cliente_serv");
                    servico.UsuarioNome = reader.GetString("advogado_serv");
                    servico.Valor = reader.GetDouble("valor_serv");
                    servico.Data = reader.GetDateTime("data_serv");
                    servico.Descricao = reader.GetString("descricao_serv");
                    //servico.Cliente.Id = reader.GetInt32("fk_cliente");
                    //servico.Usuario.Id = reader.GetInt32("fk_advogado");
                    servico.Tipo = reader.GetString("tipo_serv");
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

                var result = query.ExecuteNonQuery();
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
                        ClienteNome = reader.GetString("cliente_serv"),
                        UsuarioNome = reader.GetString("usuario_serv"),
                        Data = DAOHelper.GetDateTime(reader, "data_serv"),
                        Tipo = DAOHelper.GetString(reader, "tipo_serv"),
                        Descricao = DAOHelper.GetString(reader,"descricao_serv")
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

        public void Update(Servico t)
        {
            throw new NotImplementedException();
        }

        public List<Servico> ListConsulta(string cliente, string data, string tipoServico)
        {
            try
            {
                List<Servico> listConsulta = new List<Servico>();                

                var query = conn.Query();

                if ((cliente != null) && (data != null) && (tipoServico != null))
                    query.CommandText = $"SELECT id_servico, data_serv, cliente_serv, usuario_serv, tipo_serv FROM servico WHERE cliente_serv LIKE '{cliente}%' AND data_serv = '{data}' AND tipo_serv = '{tipoServico}'";
                else if ((cliente != null) && (data != null))
                    query.CommandText = $"SELECT id_servico, data_serv, cliente_serv, usuario_serv, tipo_serv FROM servico WHERE cliente_serv LIKE '{cliente}%' AND data_serv = '{data}'";
                else if ((cliente != null) && (tipoServico != null))
                    query.CommandText = $"SELECT id_servico, data_serv, cliente_serv, usuario_serv, tipo_serv FROM servico WHERE cliente_serv LIKE '{cliente}%' AND tipo_serv = '{tipoServico}'";
                else if ((tipoServico != null) && (data != null))
                    query.CommandText = $"SELECT id_servico, data_serv, cliente_serv, usuario_serv, tipo_serv FROM servico WHERE data_serv = '{data}' AND tipo_serv = '{tipoServico}'";
                else if (tipoServico != null)
                    query.CommandText = $"SELECT id_servico, data_serv, cliente_serv, usuario_serv, tipo_serv FROM servico WHERE tipo_serv = '{tipoServico}'";                
                else if (cliente != null)                
                    query.CommandText = $"SELECT id_servico, data_serv, cliente_serv, usuario_serv, tipo_serv FROM servico WHERE cliente_serv LIKE '{cliente}%'";
                else if (data != null)                
                    query.CommandText = $"SELECT id_servico, data_serv, cliente_serv, usuario_serv, tipo_serv FROM servico WHERE data_serv = '{data}'";                

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listConsulta.Add(new Servico()
                    {
                        Id = reader.GetInt32("id_servico"),
                        ClienteNome = reader.GetString("cliente_serv"),
                        UsuarioNome = reader.GetString("usuario_serv"),
                        Data = DAOHelper.GetDateTime(reader, "data_serv"),
                        Tipo = DAOHelper.GetString(reader, "tipo_serv"),
                    });
                }

                return listConsulta;
            }
            catch (Exception)
            {

                throw;
            }


            /*
            string sql = @"select * from tabela where upper(nome) like '%" + textBox1.Text.ToUpper() + "%' or upper(endereco) like '%" + textBox1.Text.ToUpper() + "%';";

            SqlConnection conn = new SqlConnection("sua string de conexao");
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            conn.Close();
            da.Dispose();


            dataGridView1.DataSource = dt;*/

        }
    }
}
