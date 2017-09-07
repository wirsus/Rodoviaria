using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RodoviariaADO
{
    public delegate T MapeamentoHandler<T>(SqlDataReader reader);

    public class RodoviariaREP
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["rodoviariaConnectionString"].ConnectionString;

        public List<T> ExecuteReader<T>(string nomeProcedure, MapeamentoHandler<T> metodoDeMapeamento, params SqlParameter[] parametros)
        {

            var lista = new List<T>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                //const string nomeProcedure = "ListaSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            lista.Add(metodoDeMapeamento(registro));
                        }
                    }
                }
            }

            return lista;
        }

        public object ExecuteScalar(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                //const string nomeprocedure = "transportadorainserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);

                    //comando.executenonquery();
                    return comando.ExecuteScalar();
                }
            }
        }

        public void ExecuteNonQuery(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
