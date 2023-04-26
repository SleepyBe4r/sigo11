using Projeto_SIGO_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_SIGO_Web.Controllers
{
    public class HomeController : Controller
    {

        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();

        // GET: HomeInicial
        public ActionResult HomeInicial()
        {
            return View();
        }

        // POST: HomeInicial
        [HttpPost]        
        public ActionResult HomeInicial(mensagem model)
        {
            var msm = new mensagem();

            msm.ID = model.ID;
            msm.Nome = model.Nome;
            msm.Email = model.Email;
            msm.Numero = model.Numero;
            msm.Mensagem1 = model.Mensagem1;


            if (ModelState.IsValid)
            {
                db.mensagem.Add(msm);
                db.SaveChanges();
                
            }
            ViewBag.mesagem = "";
            return RedirectToAction("HomeInicial");

        }

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult blockeio()
        {
            return View();
        }

        public ActionResult ProdutoServicos(string Marca)
        {
            var produto = new System.Collections.Generic.List<Projeto_SIGO_Web.Models.Produto>();

            if (Marca != null)
            {
                if (Marca.Trim() == "")
                {
                    produto = db.Produto.ToList();
                    ViewBag.mesagem = "nenhuma Marca encotrado";
                }
                else
                {
                    produto = db.Produto.Where(r => r.Marca.Nome == Marca).ToList();
                }
            }                        
            else
            {
                produto = db.Produto.ToList();
            }

            

            if(produto.Count == 0)
            {
                ViewBag.mesagem = "nenhuma Marca encotrado";                  
            }
            
                        
            return View(produto.ToList());

        }
    }
}