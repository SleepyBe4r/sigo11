using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_SIGO_Web.Models;
using Projeto_SIGO_Web.ViewModel;

namespace Projeto_SIGO_Web.Controllers
{
    public class ClientesController : Controller
    {
        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var cliente = db.Cliente.OrderBy(reg => reg.Nome).ToList();
            return View(cliente);
        }
      
        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IDCidade = new SelectList(db.Cidade, "CidadeId", "Nome");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel model)
        {
            var endereco = new Endereco();
            var cliente = new Cliente();
            if (ModelState.IsValid)
            {
                
                endereco.Rua = model.Rua;
                endereco.Numero = model.Numero;
                endereco.Complemento = model.Complemento;
                endereco.IDCidade = model.IDCidade;
                db.Endereco.Add(endereco);
                db.SaveChanges();
            }

            if (ModelState.IsValid)
            {                
                cliente.Nome = model.Nome;
                cliente.Tipo = model.Tipo;
                cliente.Celular = model.Celular;                
                cliente.CPF_CNPJ = model.CPF_CNPJ;
                cliente.Email = model.Email;
                cliente.IDEndereco = endereco.ID;       
                
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidade, "CidadeId", "Nome");
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            ClienteViewModel objcliente = new ClienteViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            Endereco endereco = db.Endereco.Find(cliente.IDEndereco);
            var model = new ClienteViewModel();

            model.ID = (id != null) ? Convert.ToInt32(id) : 0;
            model.Nome = cliente.Nome;
            model.Celular = cliente.Celular;
            model.CPF_CNPJ = cliente.CPF_CNPJ;
            model.Email = cliente.Email;
            model.IDEndereco = (cliente.IDEndereco != null) ? Convert.ToInt32(cliente.IDEndereco) : 0 ;
            model.Tipo = cliente.Tipo;
            model.Rua = endereco.Rua;
            model.Numero = endereco.Numero;
            model.Complemento = endereco.Complemento;
            model.IDCidade = endereco.IDCidade;

            if (cliente == null)
            {
                return HttpNotFound();
            }

            var listaTipoPessoa = new List<ClienteViewModel>()
            {
                new ClienteViewModel(){Valor ="F", Tipo = "FISICA"},
                new ClienteViewModel(){Valor ="J",Tipo = "JURIDICA"}
            };

            string Opcao = cliente.Tipo;//automaticamente vai carregar e posicionar o select
            ViewBag.Tipo = new SelectList(listaTipoPessoa.AsEnumerable(), "Valor", "Tipo", Opcao);

            int? opcaoCidade = endereco.IDCidade;
            ViewBag.IDCidade = new SelectList(db.Cidade, "CidadeId", "Nome", opcaoCidade);            

            return View(model);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel model)
        {
            var endereco = new Endereco();
            var cliente = new Cliente();
            if (ModelState.IsValid)
            {
                endereco.ID = model.IDEndereco;
                endereco.Rua = model.Rua;
                endereco.Numero = model.Numero;
                endereco.Complemento = model.Complemento;
                endereco.IDCidade = model.IDCidade;
                db.Entry(endereco).State = EntityState.Modified;               
                db.SaveChanges();             
            }

            if (ModelState.IsValid)
            {               
                cliente.IDEndereco = endereco.ID;
                cliente.ID = model.ID;
                cliente.Nome = model.Nome;
                cliente.Tipo = model.Tipo;
                cliente.Celular = model.Celular;
                cliente.CPF_CNPJ = model.CPF_CNPJ;
                cliente.Email = model.Email;                
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            int? opcaoCidade = endereco.IDCidade;
            ViewBag.IDCidade = new SelectList(db.Cidade, "CidadeId", "Nome", opcaoCidade);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost]        
        public ActionResult Delete(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
