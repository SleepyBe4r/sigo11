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

namespace Projeto_SIGO_Web.Controllers
{
    public class FornecedorsController : Controller
    {
        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();

        // GET: Fornecedors
        public ActionResult Index()
        {
            return View(db.Fornecedor.ToList());
        }

        // GET: Fornecedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Telefone,CNPJ")] Fornecedor fornecedor)
        {
            FornecedorRepository objFornecedor = new FornecedorRepository();
            Validacao objVerificar = new Validacao();
            string cnpj = fornecedor.CNPJ;
            string telefone = fornecedor.Telefone;
            if (objVerificar.IsCnpj(cnpj) == false)
            {
                ModelState.AddModelError(nameof(fornecedor.CNPJ), "CNPJ inválido");
            }

            if (objVerificar.IsTelefone(telefone) == false)
            {
                ModelState.AddModelError(nameof(fornecedor.Telefone), "Telefone inválido");
            }

            if (objFornecedor.VerificarCNPJ(fornecedor) == false)
            {
                ModelState.AddModelError(nameof(fornecedor.CNPJ), "CNPJ já existe");
            }

            if (ModelState.IsValid)
            {
                db.Fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Telefone,CNPJ")] Fornecedor fornecedor)
        {
            FornecedorRepository objFornecedor = new FornecedorRepository();
            Validacao objVerificar = new Validacao();
            string cnpj = fornecedor.CNPJ;
            string telefone = fornecedor.Telefone;
            if (objVerificar.IsCnpj(cnpj) == false)
            {
                ModelState.AddModelError(nameof(fornecedor.CNPJ), "CNPJ inválido");
            }

            if (objVerificar.IsTelefone(telefone) == false)
            {
                ModelState.AddModelError(nameof(fornecedor.Telefone), "Telefone inválido");
            }

            if (objFornecedor.VerificarCNPJ(fornecedor) == false)
            {
                ModelState.AddModelError(nameof(fornecedor.CNPJ), "CNPJ já existe");
            }

            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            db.Fornecedor.Remove(fornecedor);
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
