using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SisAdv.Interface;
using SisAdv.Database;
using SisAdv.Helpers;

namespace SisAdv.Models
{
    class DespesaDAO : IDAO<Despesa>
    {
        private static Conexao conn;

        public DespesaDAO()
        {
            conn = new Conexao();
        }


        public void Delete(Despesa t)
        {
            throw new NotImplementedException();
        }

        public Despesa GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Despesa t)
        {
            throw new NotImplementedException();
        }

        public List<Despesa> List()
        {
            throw new NotImplementedException();
        }

        public List<Despesa> ListConsulta(string origem, string data, double valor)
        {
            try
            {
                string textoSelect = "SELECT  * FROM despesa WHERE";

                List<Despesa> listConsulta = new List<Despesa>();

                var query = conn.Query();

                if ((origem != null) && (data != null) && (valor != 0.0))
                    query.CommandText = $"{textoSelect} origem_desp LIKE '%{origem}%' and data_desp = '{data}' and valor_desp = {valor}";
                else if ((origem != null) && (data != null))
                    query.CommandText = $"{textoSelect} origem_desp LIKE '%{origem}%' and data_desp = '{data}'";
                else if ((origem != null) && (valor != 0.0))
                    query.CommandText = $"{textoSelect} origem_desp LIKE '%{origem}%' and valor_desp = {valor}";
                else if ((valor != 0.0) && (data != null))
                    query.CommandText = $"{textoSelect} data_desp = '{data}' and valor_desp = {valor}";
                else if (valor != 0.0)
                    query.CommandText = $"{textoSelect} valor_desp = {valor}";
                else if (origem != null)
                    query.CommandText = $"{textoSelect} origem_desp LIKE '%{origem}%'";
                else if (data != null)
                    query.CommandText = $"{textoSelect} data_desp = '{data}'";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listConsulta.Add(new Despesa()
                    {
                        Origem = reader.GetString("origem_desp"),
                        Data = DAOHelper.GetDateTime(reader, "data_desp"),
                        Valor = DAOHelper.GetDouble(reader, ("valor_desp"))
                    });
                }

                return listConsulta;
            }
            catch (Exception)
            {

                throw;
            }
        }

            public void Update(Despesa t)
        {
            throw new NotImplementedException();
        }
    }
}
