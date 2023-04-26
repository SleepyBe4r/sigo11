using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_SIGO_Web.Models;

namespace Projeto_SIGO_Web.Controllers
{
    public class ItensOrdemsController : Controller
    {
        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();

        // GET: ItensOrdems
        public ActionResult Index()
        {
            var itensOrdem = db.ItensOrdem.Include(i => i.OrdemDeServico).Include(i => i.Produto).Include(i => i.Servico);
            return View(itensOrdem.ToList());
        }

        // GET: ItensOrdems/Create
        public ActionResult Create()
        {
            ViewBag.IDOrdemDeServico = new SelectList(db.OrdemDeServico, "ID", "TipoPagamento");
            ViewBag.IDProduto = new SelectList(db.Produto, "ID", "Nome");
            ViewBag.IDServico = new SelectList(db.Servico, "ID", "Descricao");
            return View();
        }

        // POST: ItensOrdems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo,Garantia,Quantidade,Desconto,ValorTotal,Obs,Defeito,IDProduto,IDServico,IDOrdemDeServico")] ItensOrdem itensOrdem)
        {
            if (ModelState.IsValid)
            {
                db.ItensOrdem.Add(itensOrdem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOrdemDeServico = new SelectList(db.OrdemDeServico, "ID", "TipoPagamento", itensOrdem.IDOrdemDeServico);
            ViewBag.IDProduto = new SelectList(db.Produto, "ID", "Nome", itensOrdem.IDProduto);
            ViewBag.IDServico = new SelectList(db.Servico, "ID", "Descricao", itensOrdem.IDServico);
            return View(itensOrdem);
        }

        // GET: ItensOrdems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensOrdem itensOrdem = db.ItensOrdem.Find(id);
            if (itensOrdem == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOrdemDeServico = new SelectList(db.OrdemDeServico, "ID", "TipoPagamento", itensOrdem.IDOrdemDeServico);
            ViewBag.IDProduto = new SelectList(db.Produto, "ID", "Nome", itensOrdem.IDProduto);
            ViewBag.IDServico = new SelectList(db.Servico, "ID", "Descricao", itensOrdem.IDServico);
            return View(itensOrdem);
        }

        // POST: ItensOrdems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo,Garantia,Quantidade,Desconto,ValorTotal,Obs,Defeito,IDProduto,IDServico,IDOrdemDeServico")] ItensOrdem itensOrdem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itensOrdem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOrdemDeServico = new SelectList(db.OrdemDeServico, "ID", "TipoPagamento", itensOrdem.IDOrdemDeServico);
            ViewBag.IDProduto = new SelectList(db.Produto, "ID", "Nome", itensOrdem.IDProduto);
            ViewBag.IDServico = new SelectList(db.Servico, "ID", "Descricao", itensOrdem.IDServico);
            return View(itensOrdem);
        }

        // GET: ItensOrdems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensOrdem itensOrdem = db.ItensOrdem.Find(id);
            if (itensOrdem == null)
            {
                return HttpNotFound();
            }
            return View(itensOrdem);
        }

        // POST: ItensOrdems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItensOrdem itensOrdem = db.ItensOrdem.Find(id);
            db.ItensOrdem.Remove(itensOrdem);
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
