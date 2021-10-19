using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Interface;
using MySql.Data.MySqlClient;
using SisAdv.Database;
using SisAdv.Models;

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
                    servico.Id= reader.GetInt32("id_servico");
                    servico.Cliente.Nome = reader.GetString("cliente_serv");
                    servico.Usuario.Nome = reader.GetString("advogado_serv");
                    servico.Valor = reader.GetDouble("valor_serv");
                    servico.Data = reader.GetDateTime("data_serv");
                    servico.Descricao = reader.GetString("descricao_serv");
                    servico.Cliente.Id = reader.GetInt32("fk_cliente");
                    servico.Usuario.Id = reader.GetInt32("fk_advogado");
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
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
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
                        /*
                        Id = reader.GetInt32("id_servico"),
                        Cliente = reader.GetString("id_cliente"),
                        AdvogadoNome = reader.GetString("advogado_serv"),
                        Valor = reader.GetDouble("valor_serv"),
                        Data = reader.GetDateTime("data_serv"),
                        Tipo = reader.GetString("tipo_serv"),
                        Descricao = reader.GetString("descricao_serv"),
                        Cliente = reader.GetInt32("fk_cliente"),
                        Advogado = reader.GetInt32("fk_advogado")

                        //Tem um cliente que está como Int, mas no banco de dados ele preenche o cliente String com o nome dele fazendo um select dentro de um PROCEDURE, espero dar certo
                        //Cliente = reader.GetInt32("fk_cliente"),

                        //Advogado = reader.GetInt32("fk_advogado"),*/
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
    }
}
