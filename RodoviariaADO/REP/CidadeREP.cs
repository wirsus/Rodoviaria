using Rodoviaria.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RodoviariaADO
{
    public class CidadeREP : RodoviariaREP
    {
        public List<Cidade> Selecionar()
        {
            return base.ExecuteReader<Cidade>("sp_cidade_buscar", Mapear, null);
        }

        public Cidade SelecionarComID(Int32 ID)
        {
            return base.ExecuteReader<Cidade>("sp_cidade_buscar", Mapear, new SqlParameter("@ID", ID)).FirstOrDefault();
        }

        public void Inserir(Cidade destino)
        {
            destino.IDCidade = Convert.ToInt32(base.ExecuteScalar("sp_cidade_inserir", Mapear(destino)));
        }

        public void Atualizar(Cidade destino)
        {
            var parametros = Mapear(destino).ToList();
            parametros.Add(new SqlParameter("id_cidade", destino.IDCidade));
            base.ExecuteNonQuery("sp_cidade_atualizar", parametros.ToArray());
        }

        public void Excluir(Int32 ID)
        {
            base.ExecuteNonQuery("sp_cidade_excluir", new SqlParameter("@ID", ID));
        }


        private SqlParameter[] Mapear(Cidade destino)
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("dc_uf", destino.UF));
            parametros.Add(new SqlParameter("dc_cidade", destino.Nome));
            parametros.Add(new SqlParameter("nr_distancia", destino.Distancia));

            return parametros.ToArray();
        }

        private Cidade Mapear(SqlDataReader registro)
        {
            var destino = new Cidade();
            destino.IDCidade = Convert.ToInt32(registro["id_cidade"]);
            destino.UF = registro["dc_uf"].ToString();
            destino.Nome = registro["dc_cidade"].ToString();
            destino.Distancia = Convert.ToInt32(registro["nr_distancia"]);

            return destino;
        }
    }
}