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
    public class CarrosController : Controller
    {
        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();

        // GET: Carros
        public ActionResult Index()
        {
            var carroAtual = db.CarroAtual.Include(c => c.Cliente);
            return View(carroAtual.ToList());
        }       

        // GET: Carros/Create
        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.Cliente, "ID", "Nome");
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Marca,Modelo,Ano,Valvulas,Versao,Placa,IDCliente")] CarroAtual carroAtual)
        {
            Validacao objVerificar = new Validacao();
            string versao = carroAtual.Versao;

            if (objVerificar.IsVersao(versao) == false)
            {
                ModelState.AddModelError(nameof(carroAtual.Versao), "Versão inválido");
            }

            if (ModelState.IsValid)
            {
                db.CarroAtual.Add(carroAtual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.Cliente, "ID", "Nome", carroAtual.IDCliente);
            return View(carroAtual);
        }

        // GET: Carros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarroAtual carroAtual = db.CarroAtual.Find(id);
            if (carroAtual == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.Cliente, "ID", "Nome", carroAtual.IDCliente);
            return View(carroAtual);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Marca,Modelo,Ano,Valvulas,Versao,Placa,IDCliente")] CarroAtual carroAtual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carroAtual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.Cliente, "ID", "Nome", carroAtual.IDCliente);
            return View(carroAtual);
        }

        // GET: Carros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarroAtual carroAtual = db.CarroAtual.Find(id);
            if (carroAtual == null)
            {
                return HttpNotFound();
            }
            return View(carroAtual);
        }

        // POST: Carros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            CarroAtual carroAtual = db.CarroAtual.Find(id);
            db.CarroAtual.Remove(carroAtual);
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
