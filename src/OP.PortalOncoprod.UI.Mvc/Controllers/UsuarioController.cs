using SistemaIndexador.Application.Interfaces;
using SistemaIndexador.Application.ViewModels;
using System.Web.Mvc;
using SistemaIndexador.Infra.Data.Context;
using System.Linq;
using SistemaIndexador.Domain.Services;
using System.Security.Claims;
using System.Web;
using System.Web.Security;

namespace SistemaIndexador.UI.Mvc.Controllers
{
    public class UsuarioController : BaseController
    {
        private PortalOncoprodContext db = new PortalOncoprodContext();

        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IUsuarioTabelaRegrasDMSAppService _usuarioTabelaPrecoAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService, IUsuarioTabelaRegrasDMSAppService usuarioTabelaPrecoAppService)
        {
            _usuarioAppService = usuarioAppService;
            _usuarioTabelaPrecoAppService = usuarioTabelaPrecoAppService;
        }

        public ActionResult Login(string ReturnUrl)
        {
            var usuarioViewModel = new UsuarioViewModel
            {
                UrlRetorno = ReturnUrl
            };

            return View(usuarioViewModel);
        }

        /// <param name="login"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (PortalOncoprodContext db = new PortalOncoprodContext())
                {
                    var vLogin = db.Usuarios.Where(p => p.usuarioLogin.Equals(login.usuarioLogin)).FirstOrDefault();
                    /*Verificar se a variavel vLogin está vazia. Isso pode ocorrer caso o usuário não existe.               
                     * Caso não exista ele vai cair na condição else.*/


                    if (vLogin != null)
                    {


                        /*Código abaixo verifica se o usuário que retornou na variavel tem está 
                          ativo. Caso não esteja cai direto no else*/
                        if (Equals(vLogin.dominioId, "JSL"))
                        {
                            /*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
                             do banco. Caso não cai direto no else*/
                            if (Equals(vLogin.usuarioSenha, Utility.EncryptPassword(login.usuarioSenha)))
                            {
                                FormsAuthentication.SetAuthCookie(vLogin.usuarioLogin, false);
                                if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }

                                var identity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, vLogin.usuarioNome),
                                    new Claim("Login", vLogin.usuarioLogin)
                                }, "ApplicationCookie");

                                Request.GetOwinContext().Authentication.SignIn(identity);




                                Session["LISTA_USUARIO"]  = _usuarioTabelaPrecoAppService.ObterPorUsuarioId(vLogin.usuarioId).listaUsuarioTabela;
                                


                                /*código abaixo cria uma session para armazenar o nome do usuário*/
                                Session["USUARIO"] = vLogin;


                        //        _grupoSistemaTabService.ObterPorDescricao(vLogin.usuarioId);



                                /*retorna para a tela inicial do Home*/
                                return RedirectToAction("index", "Home");
                            }
                            /*Else responsável da validação da senha*/
                            else
                            {  /*Escreve na tela a mensagem de erro informada*/
                                ModelState.AddModelError("", "Senha informada Inválida!");
                                /*Retorna a tela de login*/
                                return View();
                            }
                        }
                        /*Else responsável por verificar se o usuário está ativo*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            ModelState.AddModelError("", "Usuário sem acesso para usar o sistema!");
                            /*Retorna a tela de login*/
                            return View();
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "Usuário informado inválido!");
                        /*Retorna a tela de login*/
                        return View();
                    }
                }
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login com as mensagem dos campos*/
            return View(login);
        }

        public ActionResult Logout()
        {
            //Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuario");
        }
    }
}
