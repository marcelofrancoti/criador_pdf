// Decompiled with JetBrains decompiler
// Type: SistemaIndexador.Infra.Data.Repository.TabelaPrecoOncoprodRepository
// Assembly: SistemaIndexador.Infra.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F67B7BB-2225-4DB4-A5BF-8DE3064A74CC
// Assembly location: C:\Users\redbu\OneDrive\Área de Trabalho\PortalConsultas\bin\SistemaIndexador.Infra.Data.dll

using Dapper;
using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaIndexador.Infra.Data.Repository
{
    public class TabelaRegrasDMSRepository : Repository<TabelaRegrasDMS>, ITabelaPrecoOncoprodRepository, IRepository<TabelaRegrasDMS>, IDisposable
    {
        public TabelaRegrasDMSRepository(PortalOncoprodContext context) : base(context)
        {
        }

        public TabelaRegrasDMS ObterPorDescricao(string DescricaoOutrosDocs) => this.Buscar((Expression<Func<TabelaRegrasDMS, bool>>)(t => t.DescricaoOutrosDocs == DescricaoOutrosDocs)).FirstOrDefault<TabelaRegrasDMS>();

        public TabelaRegrasDMS ObterPorId(int id) => this.Buscar((Expression<Func<TabelaRegrasDMS, bool>>)(t => t.id == id)).FirstOrDefault<TabelaRegrasDMS>();

        public TabelaRegrasDMS ObterPorCodGrupo(string CodGrupo) => this.Buscar((Expression<Func<TabelaRegrasDMS, bool>>)(t => t.CodGrupo == CodGrupo)).FirstOrDefault<TabelaRegrasDMS>();

        public TabelaRegrasDMS ObterPorGrupoAutorizacao(string GrupoAutorizacoes) => this.Buscar((Expression<Func<TabelaRegrasDMS, bool>>)(t => t.GrupoAutorizacoes == GrupoAutorizacoes)).FirstOrDefault<TabelaRegrasDMS>();

        public void ObterPorCodigo(string id)
        {
            DbConnection connection = this.Db.Database.Connection;
            #region query
            string sql = string.Format(@"SELECT [Id]
                  ,[Infotipo]
                  ,[Subinfotipo]
                  ,[FormularioKitAdmissao]
                  ,[OutrosDocumentosControlados]
                  ,[Obrigatorio]
                  ,[Regra]
                  ,[DescricaoOutrosDocs]
                  ,[NomeFunçcao]
                  ,[TipoMedida]
                  ,[NomeUsuario]
                  ,[Data]
                  ,[CampoDaCtg]
                  ,[GrupoAutorizacoes]
                  ,[CodGrupo]
              FROM[SistemaIndexador].[dbo].[TabelaRegrasDMS] where id = {0}", id);
            #endregion
            connection.QueryMultiple(sql, (object)new
            {
                codigo = id
            }).Read<TabelaRegrasDMS>();
            connection.Close();
        }

        public new void ExcluirExcel()
        {
            DbConnection connection = this.Db.Database.Connection;
            connection.Execute("DELETE FROM [SistemaIndexador].[dbo].[TabelaRegrasDMS]");
            connection.Close();
        }

        public Paged<TabelaRegrasDMS> ObterTodos(string descricao, int pageSize, int pageNumber)
        {
            DbConnection connection = this.Db.Database.Connection;
            #region query
            string sql = @"SELECT [Id]
                          ,[Infotipo]
                          ,[Subinfotipo]
                          ,[FormularioKitAdmissao]
                          ,[OutrosDocumentosControlados]
                          ,[Obrigatorio]
                          ,[Regra]
                          ,[DescricaoOutrosDocs]
                          ,[NomeFunçcao]
                          ,[TipoMedida]
                          ,[NomeUsuario]
                          ,[Data]
                          ,[CampoDaCtg]
                          ,[GrupoAutorizacoes]
                          ,[CodGrupo]
                      FROM[SistemaIndexador].[dbo].[TabelaRegrasDMS]";
            #endregion
            IEnumerable<TabelaRegrasDMS> tabelaPrecoOncoprods = connection.QueryMultiple(sql).Read<TabelaRegrasDMS>();
            Paged<TabelaRegrasDMS> paged = new Paged<TabelaRegrasDMS>()
            {
                List = tabelaPrecoOncoprods
            };
            connection.Close();
            return paged;
        }

        public TabelaRegrasDMS ObterPorIdTabela(int id)
        {
            #region query
            string sql = string.Format(@"SELECT [Id]
                  ,[Infotipo]
                  ,[Subinfotipo]
                  ,[FormularioKitAdmissao]
                  ,[OutrosDocumentosControlados]
                  ,[Obrigatorio]
                  ,[Regra]
                  ,[DescricaoOutrosDocs]
                  ,[NomeFunçcao]
                  ,[TipoMedida]
                  ,[NomeUsuario]
                  ,[Data]
                  ,[CampoDaCtg]
                  ,[GrupoAutorizacoes]
                  ,[CodGrupo]
              FROM[SistemaIndexador].[dbo].[TabelaRegrasDMS]  WHERE id = '{0}'", id.ToString().PadLeft(5, '0'));
            #endregion
            TabelaRegrasDMS tabelaPrecoOncoprod1 =
                this.Db.Database.Connection.QueryMultiple(sql
                       ).Read<TabelaRegrasDMS>().FirstOrDefault<TabelaRegrasDMS>();
            TabelaRegrasDMS tabelaPrecoOncoprod2 = new TabelaRegrasDMS();
            return tabelaPrecoOncoprod1;
        }

        List<TabelaRegrasDMS> ITabelaPrecoOncoprodRepository.ObterTodos()
        {


            DbConnection connection = this.Db.Database.Connection;
            #region query
            string sql = @"SELECT [Id]
                          ,[Infotipo]
                          ,[Subinfotipo]
                          ,[FormularioKitAdmissao]
                          ,[OutrosDocumentosControlados]
                          ,[Obrigatorio]
                          ,[Regra]
                          ,[DescricaoOutrosDocs]
                          ,[NomeFunçcao]
                          ,[TipoMedida]
                          ,[NomeUsuario]
                          ,[Data]
                          ,[CampoDaCtg]
                          ,[GrupoAutorizacoes]
                          ,[CodGrupo]
                      FROM[SistemaIndexador].[dbo].[TabelaRegrasDMS]";
            #endregion
            List<TabelaRegrasDMS> tabelaPrecoOncoprods = connection.QueryMultiple(sql).Read<TabelaRegrasDMS>().ToList();

            connection.Close();
            return tabelaPrecoOncoprods;
        }


    }
}
