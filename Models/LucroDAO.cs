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
    class LucroDAO : IDAO<Lucro>
    {
        private static Conexao conn;

        public LucroDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Lucro t)
        {
            throw new NotImplementedException();
        }

        public Lucro GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Lucro t)
        {
            throw new NotImplementedException();
        }

        public List<Lucro> List()
        {
            throw new NotImplementedException();
        }

        public List<Lucro> ListConsulta(string origem, string data, double valor)
        {
            try
            {
                string textoSelect = "SELECT  * FROM lucro WHERE";

                List<Lucro> listConsulta = new List<Lucro>();

                var query = conn.Query();

                if ((origem != null) && (data != null) && (valor != 0.0))
                    query.CommandText = $"{textoSelect} origem_luc LIKE '{origem}%' and data_luc = '{data}' and valor_luc = {valor}";
                else if ((origem != null) && (data != null))
                    query.CommandText = $"{textoSelect} origem_luc LIKE '{origem}%' and data_luc = '{data}'";
                else if ((origem != null) && (valor != 0.0))
                    query.CommandText = $"{textoSelect} origem_luc LIKE '{origem}%' and valor_luc = {valor}";
                else if ((valor != 0.0) && (data != null))
                    query.CommandText = $"{textoSelect} data_luc = '{data}' and valor_luc = {valor}";
                else if (valor != 0.0)
                    query.CommandText = $"{textoSelect} valor_luc = {valor}";
                else if (origem != null)
                    query.CommandText = $"{textoSelect} origem_luc LIKE '{origem}%'";
                else if (data != null)
                    query.CommandText = $"{textoSelect} data_luc = '{data}'";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listConsulta.Add(new Lucro()
                    {
                        Origem = reader.GetString("origem_luc"),
                        Data = DAOHelper.GetDateTime(reader, "data_luc"),
                        Valor = DAOHelper.GetDouble(reader, ("valor_luc"))
                    });
                }

                return listConsulta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Lucro t)
        {
            throw new NotImplementedException();
        }
    }
}
