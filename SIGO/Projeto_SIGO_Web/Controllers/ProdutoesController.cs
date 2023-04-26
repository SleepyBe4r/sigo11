using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_SIGO_Web.Models;
using Projeto_SIGO_Web.ViewModel;

namespace Projeto_SIGO_Web.Controllers
{
    public class ProdutoesController : Controller
    {
        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();        

        // GET: Produtoes
        public ActionResult Index()
        {
            var produto = db.Produto.Include(p => p.Fornecedor).Include(p => p.Marca);
            return View(produto.ToList());
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            var model = new ProdutoViewModel();
            IEnumerable<SelectListItem> marcas = db.Marca.Select(m => new SelectListItem { Value = m.ID.ToString(), Text = m.Nome}).ToList();
            ViewBag.IDMarca = marcas;
            ViewBag.IDFornecedor = new SelectList(db.Fornecedor, "ID", "Nome");
            return View(model);
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel model)
        {
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            if (model.File == null || model.File.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            }
            else if (!imageTypes.Contains(model.File.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
            }

            if (ModelState.IsValid)
            {
                var produto = new Produto();
                produto.Nome = model.Nome;
                produto.Estoque = model.Estoque;
                produto.Descricao = model.Descricao;
                produto.Valor = model.Valor;
                produto.EstoqueMaximo = model.EstoqueMaximo;
                produto.EstoqueMinimo = model.EstoqueMinimo;
                produto.IDMarca = model.IDMarca;
                produto.IDFornecedor = model.IDFornecedor;

                // Salvar a imagem para a pasta e pega o caminho
                using (var binaryReader = new BinaryReader(model.File.InputStream))
                    produto.Foto = binaryReader.ReadBytes(model.File.ContentLength);

                if (ModelState.IsValid)
                {
                    db.Produto.Add(produto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            return View(model);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            var model = new ProdutoViewModel();

            model.ID = produto.ID;
            model.Nome = produto.Nome;
            model.Foto = produto.Foto;
            model.IDMarca = produto.IDMarca;
            model.IDFornecedor = produto.IDFornecedor;
            model.Estoque = produto.Estoque;
            model.EstoqueMinimo = produto.EstoqueMinimo;
            model.Descricao = produto.Descricao;
            model.EstoqueMaximo = produto.EstoqueMaximo;
            model.Valor = produto.Valor;

            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFornecedor = new SelectList(db.Fornecedor, "ID", "Nome", model.IDFornecedor);
            ViewBag.IDMarca = new SelectList(db.Marca, "ID", "Nome", model.IDMarca);
            return View(model);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel model)
        {
            var produto = new Produto();
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            if (model.File == null || model.File.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            }
            else if (!imageTypes.Contains(model.File.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
            }

            if (ModelState.IsValid)
            {
                produto.ID = model.ID;
                produto.Nome = model.Nome;
                produto.Estoque = model.Estoque;
                produto.Descricao = model.Descricao;
                produto.Valor = model.Valor;
                produto.EstoqueMaximo = model.EstoqueMaximo;
                produto.EstoqueMinimo = model.EstoqueMinimo;
                produto.IDMarca = model.IDMarca;
                produto.IDFornecedor = model.IDFornecedor;

                // Salvar a imagem para a pasta e pega o caminho
                using (var binaryReader = new BinaryReader(model.File.InputStream))
                    produto.Foto = binaryReader.ReadBytes(model.File.ContentLength);

                
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            ViewBag.IDFornecedor = new SelectList(db.Fornecedor, "ID", "Nome", model.IDFornecedor);
            ViewBag.IDMarca = new SelectList(db.Marca, "ID", "Nome", model.IDMarca);
            return View(model);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost]        
        public ActionResult Delete(int id)
        {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
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
