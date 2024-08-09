using Dapper;
using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndexador.Infra.Data.Repository
{
    public class UsuarioTabelaPrecoRepository : Repository<UsuarioTabelaRegrasDMS>, IUsuarioTabelaPrecoRepository
    {
        public UsuarioTabelaPrecoRepository(PortalOncoprodContext context)
          : base(context)
        {
            

        }
      
        public List<UsuarioTabelaRegrasDMS> ObterPorUsuarioId(string usuarioId)
        {
            var cn = Db.Database.Connection;
            try
            {
               
                cn.Open();
                var sql = @" SELECT [usuarioTabelaRegrasDMSId]
                                  ,[usuarioId]
                                  ,[grupoId]
                              FROM [dbo].[UsuarioTabelaRegrasDMS] where usuarioId = '" + usuarioId + "'";

                var multi = cn.QueryMultiple(sql, new { codigo = usuarioId });
               
                return multi.Read<UsuarioTabelaRegrasDMS>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();

            }

            
           
        }

    }
}
