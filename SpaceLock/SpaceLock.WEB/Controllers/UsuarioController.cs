using Newtonsoft.Json;
using SpaceLock.Entidades;
using SpaceLock.Repositorio.Contracts;
using SpaceLock.Repositorio.Util;
using SpaceLock.WEB.Models.Usuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SpaceLock.WEB.Controllers
{
    public class UsuarioController : Controller
    {

        private IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = repository.Find(model.Login, Criptografia.EncriptarSenhaMD5(model.Senha));
                    if (u != null)
                    {
                        UsuarioAutenticadoViewModel auth = new UsuarioAutenticadoViewModel();

                        auth.IdUsuario = u.IdUsuario;
                        auth.Nome = u.Nome;
                        auth.Login = u.Login;
                        auth.Foto = u.Foto;
                        auth.DataHoraAcesso = DateTime.Now;

                        //converter o objeto para JSON..
                        string authJSON = JsonConvert.SerializeObject(auth);

                        //criar o ticket de acesso..
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(authJSON, false, 60);

                        //gravar o ticket em cookie..
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                        Response.Cookies.Add(cookie);

                        //return Json(new { redirectTo = Url.Action("Index", "Principal", new { area = "RestrictArea" }), }, JsonRequestBehavior.AllowGet);
                        return RedirectToAction("Index", "Home",
                                                   new { area = "AreaRestrita" });
                    }
                    else
                    {
                        ViewBag.Mensagem = "Acesso negado. Usuário não encontrado.";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(UsuarioCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (repository.HasLogin(model.Login))
                    {
                        ViewBag.Mensagem = $"O login {model.Login} já foi cadastrado. Tente outro.";
                    }
                    else
                    {
                        Usuario u = new Usuario();

                        u.Nome = model.Nome;
                        u.Email = model.Email;
                        u.Login = model.Login;
                        u.Senha = Criptografia.EncriptarSenhaMD5(model.Senha);
                        u.Foto = Guid.NewGuid().ToString() + Path.GetExtension(model.Foto.FileName);
                        u.IdPerfil = 2;

                        repository.Insert(u);


                        //upload da foto..
                        string path = Server.MapPath("/images/users/");
                        model.Foto.SaveAs(path + u.Foto);

                        ViewBag.Mensagem = $"Usuário {u.Nome}, cadastrado com sucesso.";
                        ModelState.Clear(); //limpar os campos do formulário..
                        return RedirectToAction("Login", "Usuario");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = $"Ocorreu um erro:{e.Message}";
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Usuario", new { area = "" });
        }

        // GET: Usuario
        [Authorize]
        public ActionResult MeusDados()
        {
            return View();
        }
    }
}