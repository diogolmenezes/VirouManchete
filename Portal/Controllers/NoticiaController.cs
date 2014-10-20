using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VirouManchete.Entidade;
using VirouManchete.Negocio;

namespace VirouManchete.Portal.Controllers
{
    public class NoticiaController : Controller
    {
        public ActionResult Index()
        {
            IList<Noticia> manchetes = new List<Noticia>();

            if(Request.QueryString["t"] == "r")
                manchetes = new NoticiaBusiness().ListarMaisRecentes(0, 10);
            else
                manchetes = new NoticiaBusiness().ListarMaisVistas(0, 10);

            return View(manchetes);
        }

        public ActionResult Ler(string id)
        {
            var boNoticia = new NoticiaBusiness();

            var noticia = boNoticia.Carregar(id);
            if (noticia == null)
                return View("BadAction");

            noticia.Visualizacoes++;            
            boNoticia.Alterar(noticia);
            ViewBag.Recentes  = new NoticiaBusiness().ListarMaisRecentesPorFormato(noticia.Formato, 5);
            return View(String.Format("~/Views/Template/{0}.cshtml", noticia.Formato), noticia);             
        }

        [HttpPost]
        public ActionResult Criar(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                if (noticia.Titulo == "Título")
                    return RedirectToAction("Index", "Home");

                noticia.Ip = Request.ServerVariables["REMOTE_ADDR"];
                noticia.Imagem = FazerUpload();
                noticia.Formato = Request.Form["rdFormato"];
                noticia.Data = DateTime.Now;
                new NoticiaBusiness().Incluir(noticia);
                return RedirectToAction("Index", "Home", new { id = noticia.Id });
            }
            TempData["ViewData"] = ViewData; // armazenando o viewdata para poder manter o modelstate mesmo após um redirect to action.
            return RedirectToAction("Index", "Home", noticia);
        }

        private string FazerUpload()
        {           
            var arquivo = this.Request.Files[0];
            if (!String.IsNullOrEmpty(arquivo.FileName))
            {
                var extensao = System.IO.Path.GetExtension(arquivo.FileName).ToLower();
                string caminho = Server.MapPath("/content/img/noticias/");
                string nomeArquivo = String.Format("{0}.{1}", Guid.NewGuid().ToString().Replace("-",""), extensao);
                caminho = System.IO.Path.Combine(caminho, nomeArquivo);
                arquivo.SaveAs(caminho);
                return nomeArquivo;
            }

            return null;
        }

        public ActionResult ListarNoticias(int id)
        {
            var inicio = id;

            IList<Noticia> manchetes = new List<Noticia>();
            if (Request.QueryString["t"] == "r")
                manchetes = new NoticiaBusiness().ListarMaisRecentes(inicio, 10);
            else
                manchetes = new NoticiaBusiness().ListarMaisVistas(inicio, 10);

            return PartialView("_ListaNoticia", manchetes);
        }

    }

    public class UploadException : Exception
    {
        public UploadException(string msg)
            : base(msg)
        {
        }
    }
}
