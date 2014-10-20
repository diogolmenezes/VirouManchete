using System;
using System.Web.Mvc;
using VirouManchete.Entidade;
using VirouManchete.Negocio;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            // recuperando o viewdata para poder manter o modelstate mesmo após um redirect to action.
            if (TempData["ViewData"] != null)
                ViewData = (ViewDataDictionary)TempData["ViewData"];

            if(!String.IsNullOrEmpty(id))
                ViewBag.Noticia = String.Format("/noticia/ler/{0}", id);

            ViewBag.MaisVistas   = new NoticiaBusiness().ListarMaisVistas(0, 5);
            ViewBag.MaisRecentes = new NoticiaBusiness().ListarMaisRecentes(0, 5);

            return View(new Noticia() { Titulo = "Título", SubTitulo = "Subtítulo", Texto = "Texto" });
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        #region Controles
        [ChildActionOnly]
        public ActionResult CarregarAviso()
        {
            return PartialView("_aviso");
        }
        #endregion


    }
}
