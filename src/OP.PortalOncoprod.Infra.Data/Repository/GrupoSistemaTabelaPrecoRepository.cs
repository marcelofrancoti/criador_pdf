using Dapper;
using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndexador.Infra.Data.Repository
{
    public class GrupoSistemaTabelaPrecoRepository : Repository<GrupoSistemaTabelaPreco>, IGrupoSistemaTabelaPrecoRepository
    {
        public GrupoSistemaTabelaPrecoRepository(PortalOncoprodContext context) : base(context)
        {

        }

        public GrupoSistemaTabelaPreco ObterPorDescricao(string nomeGrupo)
        {
            return Buscar(t => t.nomeGrupo == nomeGrupo).FirstOrDefault();
        }
        
        public void ObterPorCodigo(int id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT
                            * 
                        FROM 
                            KsGrupoSistemaTabelaPreco 
                        WHERE
                            ([rupoId = @grupoId)";

            var multi = cn.QueryMultiple(sql, new { codigo = id });
            var tabelaPrecoOncoprod = multi.Read<TabelaRegrasDMS>();
            cn.Close();
        }
        
        public Paged<GrupoSistemaTabelaPreco> ObterTodos(string descricao, int pageSize, int pageNumber)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT 
                               grupoId
                              ,nomeGrupo
                              ,elemento
                        FROM 
                            KsGrupoSistemaTabelaPreco ";
         

            var multi = cn.QueryMultiple(sql);
            var tabelaPrecoOncoprod = multi.Read<GrupoSistemaTabelaPreco>();
            //var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<GrupoSistemaTabelaPreco>()
            {
                List = tabelaPrecoOncoprod
                //Count = total
            };
            cn.Close();
            return pagedList;

        }

    }
}
