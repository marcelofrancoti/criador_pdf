using OP.PortalOncoprod.Domain.Entities;
using OP.PortalOncoprod.Domain.Interfaces.Repository;
using OP.PortalOncoprod.Infra.Data.Context;
using OP.PortalOncoprod.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUnityCadUsuarioUsuario
{
    public class ClassTesteSelect : Repository<GrupoSistemaTabelaPreco>
    {

        public ClassTesteSelect(PortalOncoprodContext context) : base(context)
        {

        }


        public static void obterDados()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=D:\Labs\CursoMvcSetembro\src\EP.CursoMvc.UI.Mvc\App_Data\CursoMvcDb.mdf;Initial Catalog=CursoMvcDb;Integrated Security=True");
                con.Open();

                command.Connection = con;

                var sql = "SELECT grupoId ,nomeGrupo ,elemento FROM KsGrupoSistemaTabelaPreco ";

                command.CommandText = sql;
                var sqlTeste = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                var teste = ex;
                throw;
            }
          



        }
    }
}
