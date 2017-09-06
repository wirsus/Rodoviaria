using Rodoviaria.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RodoviariaADO
{
    public class OnibusREP : RodoviariaREP
    {
        public List<Onibus> Selecionar()
        {
            return base.ExecuteReader<Onibus>("sp_onibus_buscar", Mapear, null);
        }

        public Onibus SelecionarComID(Int32 ID)
        {
            return ExecuteReader("sp_onibus_buscar", Mapear, new SqlParameter("@id", ID)).FirstOrDefault();
        }

        public void Inserir(Onibus onibus)
        {
            onibus.IDOnibus = Convert.ToInt32(base.ExecuteScalar("sp_onibus_inserir", Mapear(onibus)));
        }

        public void Atualizar(Onibus onibus)
        {
            var parametros = Mapear(onibus).ToList();
            parametros.Add(new SqlParameter("id_onibus", onibus.IDOnibus));
            base.ExecuteNonQuery("sp_onibus_atualizar", parametros.ToArray());
        }

        public void Excluir(Int32 ID)
        {
            base.ExecuteNonQuery("sp_onibus_excluir", new SqlParameter("id_onibus", ID));
        }


        private SqlParameter[] Mapear(Onibus onibus)
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("nm_cor", onibus.Cor));
            parametros.Add(new SqlParameter("nr_custo_km", onibus.CustoPorKm));


            return parametros.ToArray();
        }

        private Onibus Mapear(SqlDataReader registro)
        {
            var onibus = new Onibus();
            onibus.IDOnibus = Convert.ToInt32(registro["id_onibus"]);
            onibus.Cor = registro["nm_cor"].ToString();
            onibus.CustoPorKm = Convert.ToDecimal(registro["nr_custo_km"]);

            return onibus;
        }

    }
}