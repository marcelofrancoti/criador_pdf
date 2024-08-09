using System.Linq;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Infra.Data.Context;
using Dapper;
using System.Web.Security;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using SistemaIndexador.Domain.DTO;

namespace SistemaIndexador.Infra.Data.Repository
{
    public class UsuariosRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuariosRepository(PortalOncoprodContext context) 
            : base(context)
        {

        }

        public Usuario ObterPorEmail(string email)
        {
            return Buscar(u => u.usuarioEmail == email).FirstOrDefault();
        }

        public Usuario ObterPorLogin(string login, string senha)
        {

            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Usuario WITH (NOLOCK)" +
                      "WHERE (@usuarioLogin IS NULL OR usuarioLogin = @Login)" +
                      "AND (@usuarioSenha IS NULL OR usuarioSenha = @Senha)";

            var multi = cn.QueryMultiple(sql, new { Login = login, Senha = senha });
            var usuario = multi.Read();

            Usuario usuarioResult = new Usuario();

            foreach (var item in usuario)
            {
                usuarioResult.usuarioLogin = item.usuarioLogin;
                usuarioResult.usuarioSenha = item.usuarioSenha;
            }

            return usuarioResult;

            //return Buscar(u => u.usuarioLogin.Equals(login) && u.usuarioSenha.Equals(senha)).First();
        }

        public static bool AutenticarUsuario(string login, string senha)
        {

            PortalOncoprodContext Context = new PortalOncoprodContext();

             var Query = (from u in Context.Usuarios
                          where u.usuarioLogin.Equals(login)
                          && u.usuarioSenha.Equals(senha)
                          select u).SingleOrDefault();

            if(Query == null)
            {
                return false;
            }

            FormsAuthentication.SetAuthCookie(Query.usuarioLogin, false);

            return true;
        }

        public static Usuario GetUsuarioLogado()
        {
            string _Login = HttpContext.Current.User.Identity.Name;

            if(_Login == string.Empty)
            {
                return null;
            }
            else
            {
                PortalOncoprodContext Context = new PortalOncoprodContext();

                Usuario user = (from u in Context.Usuarios
                                where u.usuarioLogin.Equals(_Login)
                                select u).SingleOrDefault();

                return user;
            }

        }

        public Paged<Usuario> ObterTodos()
        {
            var cn = Db.Database.Connection;
            cn.Open();
            var sql = @"SELECT UsuarioId,usuarioNome FROM Usuario  (nolock) where usuarioTipoId in ('REP', 'GER')";


            var multi = cn.QueryMultiple(sql);
            var usuarios = multi.Read<Usuario>();
            //var total = multi.Read<int>().FirstOrDefault();


            var pagedList = new Paged<Usuario>()
            {

                List = usuarios
                //Count = total
            };
            cn.Close();
            return pagedList;
        }

        public static void Deslogar()
        {
            FormsAuthentication.SignOut();
        }

       
    }
}
