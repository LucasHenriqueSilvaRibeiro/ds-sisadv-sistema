using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Interface;
using SisAdv.Helpers;
using MySql.Data.MySqlClient;
using SisAdv.Database;

namespace SisAdv.Models
{
    class PagamentoDAO : IDAO<Pagamento>
    {
        //Lembrar de testar todos depois e adicionar no cadastrar.cs

        private Conexao conn;
        public PagamentoDAO()
        {
            conn = new Conexao();
        }
        public void Delete(Pagamento t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "DELETE FROM pagamento WHERE id_pagamento = @id";

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

        public Pagamento GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM pagamento LEFT JOIN despesa ON fk_despesa = id_despesa " +
                                    "LEFT JOIN caixa ON fk_caixa = id_cx WHERE id_pagamento = @id"; 

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var pagamento = new Pagamento();

                while (reader.Read())
                {
                    pagamento.Id = reader.GetInt32("id_pagamento");
                    pagamento.Valor = DAOHelper.GetDouble(reader, "valor_pagamento");
                    pagamento.DataPagamento = DAOHelper.GetDateTime(reader, "data_pagamento");
                    pagamento.Origem = DAOHelper.GetString(reader, "origem_despesa");
                    pagamento.TipoPagamento = DAOHelper.GetString(reader, "tipo_pagamento");

                    if (!DAOHelper.IsNull(reader, "fk_despesa"))
                        pagamento.Despesa = new Despesa()
                        {
                            Id = reader.GetInt32("id_despesa"),
                            Origem = reader.GetString("origem_desp")
                        };

                    if (!DAOHelper.IsNull(reader, "fk_caixa"))
                        pagamento.Caixa = new Caixa()
                        {
                            Id = reader.GetInt32("id_cx"),
                            Mes = reader.GetString("mes_cx")
                        };
                }

                return pagamento;

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

        public void Insert(Pagamento t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL registrarPagamento(@tipo, @data, @despesa, @caixa)";

                query.Parameters.AddWithValue("@tipo", t.TipoPagamento);
                query.Parameters.AddWithValue("@data", t.DataPagamento?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@despesa", t.Despesa.Id);
                query.Parameters.AddWithValue("@caixa", t.Caixa.Id);

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

        public List<Pagamento> List()
        {
            try
            {
                List<Pagamento> list = new List<Pagamento>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM pagamento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Pagamento()
                    {
                        Id = reader.GetInt32("id_pagamento"),
                        TipoPagamento = DAOHelper.GetString(reader, "tipo_pagamento"),
                        DataPagamento = DAOHelper.GetDateTime(reader, "data_pagamento"),
                        Valor = DAOHelper.GetDouble(reader, "valor_pagamento"),

                        Despesa = DAOHelper.IsNull(reader, "fk_despesa") ? null : new Despesa() { Id = reader.GetInt32("fk_despesa"), Origem = reader.GetString("origem_despesa") },
                        Caixa = DAOHelper.IsNull(reader, "fk_caixa") ? null : new Caixa() { Id = reader.GetInt32("fk_caixa") }
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

        public void Update(Pagamento t)
        {
            try
            {
                var query = conn.Query();

                //não estou conseguindo atualizar valor e nem a origem na grid
                query.CommandText = "UPDATE pagamento SET tipo_pagamento = @tipo, data_pagamento = @data, " +
                                    "fk_despesa = @despesa, fk_caixa = @caixa WHERE id_pagamento = @id";

                query.Parameters.AddWithValue("@tipo", t.TipoPagamento);
                query.Parameters.AddWithValue("@data", t.DataPagamento?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@despesa", t.Despesa.Id);
                query.Parameters.AddWithValue("@caixa", t.Caixa.Id);
                //decidir se pode ou não alterar valor
                //query.Parameters.AddWithValue("@valor", t.Valor);

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
