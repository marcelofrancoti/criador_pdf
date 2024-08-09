using OP.PortalOncoprod.Application.Interfaces;
using OP.PortalOncoprod.Domain.Interfaces.Repository;
using OP.PortalOncoprod.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUnityCadUsuarioUsuario
{
    public class Program 
    {
        public static GrupoSistemaTabelaPrecoRepository _repo;
        static void Main(string[] args)
        {

            ClassTesteSelect.obterDados();
        }
    }
}
