using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisAdv.Database;
using SisAdv.Helpers;
using SisAdv.Interface;
using MySql.Data.MySqlClient;

namespace SisAdv.Models
{
    class CaixaDAO : IDAO<Caixa>
    {
        private static Conexao conn;

        public CaixaDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Caixa t)
        {
            try
            {
                var query = conn.Query();

                //Verificar tabela processo;
                query.CommandText = "DELETE FROM caixa WHERE id_cx = @id";

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

        public Caixa GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM caixa WHERE id_cx = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var caixa = new Caixa();

                while (reader.Read())
                {
                    caixa.Id = reader.GetInt32("id_cx");
                    caixa.SaldoInicial = reader.GetDouble("saldo_inicial_cx");
                    caixa.SaldoFinal = reader.GetDouble("saldo_final_cx");
                    caixa.TotalDespesa = reader.GetDouble("total_despesa_cx");
                    caixa.TotalLucro = reader.GetDouble("total_lucro_cx");
                    caixa.Mes = reader.GetString("mes_cx");
                }

                return caixa;

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

        public void Insert(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL cadastrarCaixa (@mes)";

                query.Parameters.AddWithValue("@mes", t.Mes);

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

        public void InsertInicial(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL cadastrarCaixaInicial (@mes, @valorinicial)";

                query.Parameters.AddWithValue("@mes", t.Mes);
                query.Parameters.AddWithValue("@valorinicial", t.SaldoInicial);

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

        public List<Caixa> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Caixa t)
        {
            throw new NotImplementedException();
        }
    }
}
