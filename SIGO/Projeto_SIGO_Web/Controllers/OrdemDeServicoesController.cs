using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_SIGO_Web.Models;
using Projeto_SIGO_Web.Repositories;
using Projeto_SIGO_Web.ViewModel;

namespace Projeto_SIGO_Web.Controllers
{
    public class OrdemDeServicoesController : Controller
    {
        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();

        public ActionResult SelecionaProdServ(string Tipo, int ID)
        {
            if (Tipo == "P")
            {
                try
                {
                    List<OrdemDeServicoViewModel> lista = new List<OrdemDeServicoViewModel>();
                    var produto = db.Produto.Where(p => p.ID.Equals(ID)).FirstOrDefault();

                    lista.Add(new OrdemDeServicoViewModel
                    {
                        ID_Produto = produto.ID,
                        Nome_Produto = produto.Nome,                        
                        Valor_Produto = produto.Valor
                    });
                    
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    List<OrdemDeServicoViewModel> lista = new List<OrdemDeServicoViewModel>();
                    var servico = db.Servico.Where(s => s.ID.Equals(ID)).FirstOrDefault();

                    lista.Add(new OrdemDeServicoViewModel
                    {
                        ID_Servico = servico.ID,
                        Descricao_Servico = servico.Descricao,
                        Valor_Servico = servico.Valor
                    });
                    throw;
                }
                

                
            }
            else if (Tipo == "S")
            {
                var servico = db.Servico.Where(p => p.ID.Equals(ID)).ToList();
                return Json(servico, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        public ActionResult CarregaProdServ(string Tipo)
        {            
            if(Tipo == "P")
            {
                List<OrdemDeServicoViewModel> lista = new List<OrdemDeServicoViewModel>();

                foreach (var linha in db.Produto)
                {
                    lista.Add(new OrdemDeServicoViewModel
                    {
                        ID_Produto = linha.ID,
                        Nome_Produto = linha.Nome                       
                    });
                }                
                return Json(lista , JsonRequestBehavior.AllowGet);
            }
            else if(Tipo == "S")
            {
                var dados = db.Servico.OrderBy(s => s.Descricao).ToList();
                return Json(dados , JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        public ActionResult CarregaCarro(int IDCliente)
        {             
            OrdemDeServicoRepository objCarrega = new OrdemDeServicoRepository();
            var carros = objCarrega.CarregaCarro(IDCliente);            


            return Json(new { carros }, JsonRequestBehavior.AllowGet);           
        }

        // GET: OrdemDeServicoes
        public ActionResult Index()
        {
            var ordemDeServico = db.OrdemDeServico.Include(o => o.CarroAtual);            
            return View(ordemDeServico.ToList());
        }


        // GET: OrdemDeServicoes/Create
        public ActionResult Create()
        {                        
            ViewBag.IDCliente = new SelectList(db.Cliente, "ID", "Nome");
            return View();
        }

        // POST: OrdemDeServicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdemDeServicoViewModel model)
        {
            var ordemDeServico = new OrdemDeServico();

            ordemDeServico.Data = DateTime.Today;
            ordemDeServico.TipoPagamento = model.TipoPagamento;
            ordemDeServico.IDCarroAtual = model.IDCarroAtual;
            if (ModelState.IsValid)
            {
                db.OrdemDeServico.Add(ordemDeServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            int IDOrdemDeServico = db.OrdemDeServico.Max(o => o.ID);



            ViewBag.IDCliente = new SelectList(db.Cliente, "ID", "Nome");
            return View(ordemDeServico);
        }

        // GET: OrdemDeServicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemDeServico ordemDeServico = db.OrdemDeServico.Find(id);
            if (ordemDeServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCarroAtual = new SelectList(db.CarroAtual, "ID", "Marca", ordemDeServico.IDCarroAtual);
            return View(ordemDeServico);
        }

        // POST: OrdemDeServicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Data,TipoPagamento,IDCarroAtual")] OrdemDeServico ordemDeServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemDeServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCarroAtual = new SelectList(db.CarroAtual, "ID", "Marca", ordemDeServico.IDCarroAtual);
            return View(ordemDeServico);
        }

        // GET: OrdemDeServicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemDeServico ordemDeServico = db.OrdemDeServico.Find(id);
            if (ordemDeServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemDeServico);
        }

        // POST: OrdemDeServicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdemDeServico ordemDeServico = db.OrdemDeServico.Find(id);
            db.OrdemDeServico.Remove(ordemDeServico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
