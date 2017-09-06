using Rodoviaria.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RodoviariaADO
{
    public class PassageiroREP : RodoviariaREP
    {
        public List<Passageiro> Selecionar()
        {
            return base.ExecuteReader<Passageiro>("sp_passageiro_buscar", Mapear, null);
        }

        public Passageiro SelecionarComID(Int32 ID)
        {
            return base.ExecuteReader<Passageiro>("sp_passageiro_buscar", Mapear, new SqlParameter("@id", ID)).FirstOrDefault();
        }

        public void Inserir(Passageiro passageiro)
        {
            passageiro.IDPassageiro = Convert.ToInt32(base.ExecuteScalar("sp_passageiro_inserir", Mapear(passageiro)));
        }

        public void Atualizar(Passageiro passageiro)
        {
            var parametros = Mapear(passageiro).ToList();
            parametros.Add(new SqlParameter("id_passageiro", passageiro.IDPassageiro));
            base.ExecuteNonQuery("sp_passageiro_atualizar", parametros.ToArray());
        }

        public void Excluir(Int32 ID)
        {
            base.ExecuteNonQuery("sp_passageiro_excluir", new SqlParameter("id_passageiro", ID));
        }


        private SqlParameter[] Mapear(Passageiro passageiro)
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("nm_passageiro", passageiro.Nome));
            parametros.Add(new SqlParameter("dt_nascimento", passageiro.Nascimento));
            parametros.Add(new SqlParameter("nr_dinheiro", passageiro.Dinheiro));


            return parametros.ToArray();
        }

        private Passageiro Mapear(SqlDataReader registro)
        {
            var passageiro = new Passageiro();
            passageiro.IDPassageiro = Convert.ToInt32(registro["id_passageiro"]);
            passageiro.Nome = registro["nm_passageiro"].ToString();
            passageiro.Nascimento = Convert.ToDateTime(registro["dt_nascimento"]);
            passageiro.Dinheiro = Convert.ToDecimal(registro["nr_dinheiro"]);

            return passageiro;
        }
    }
}