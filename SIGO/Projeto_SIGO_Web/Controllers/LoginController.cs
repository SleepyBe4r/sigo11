using Projeto_SIGO_Web.Models;
using Projeto_SIGO_Web.Repositories;
using Projeto_SIGO_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_SIGO_Web.Controllers
{

    public class LoginController : Controller
    {
        private Projeto_SIGOEntities db = new Projeto_SIGOEntities();

        public ActionResult SelecionaCidade(string UF)
        {            
            
            var cidades = db.Cidade.Where(c => c.EstadoId.ToString() == UF).ToList();

            List<LoginViewModel> lista = new List<LoginViewModel>();

            foreach (var linha in cidades)
            {
                lista.Add(new LoginViewModel
                {
                    CidadeId = linha.CidadeId,
                    Nome_Cidade = linha.Nome
                });
            }
            return Json(lista, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult Cadastro_Login()
        {
            ViewBag.EstadoId = new SelectList(db.Estado, "EstadoId", "Sigla");
            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro_Login(LoginViewModel model)
        {            
            
            var objlogin = new Login();
            var objcliente = new Cliente();
            var objendereco = new Endereco();
            var objcarro = new CarroAtual();


            if (ModelState.IsValid)
            {
                objendereco.IDCidade = model.CidadeId;
                objendereco.Rua = model.Rua;
                objendereco.Numero = model.Numero;
                objendereco.Complemento = model.Complemento;
                db.Endereco.Add(objendereco);
                db.SaveChanges();
            }

            int IDEndereco = db.Endereco.Max(e => e.ID);

            if (ModelState.IsValid)
            {
                objcliente.Nome = model.Nome_Cliente;
                objcliente.Celular = model.Celular;
                objcliente.Tipo = model.Tipo;
                objcliente.CPF_CNPJ = model.CPF_CNPJ;
                objcliente.IDEndereco = IDEndereco;
                db.Cliente.Add(objcliente);
                db.SaveChanges();
            }

            int IDCliente = db.Cliente.Max(c => c.ID);

            LoginRepository objLogar = new LoginRepository();
            string senha = model.Senha;
            model.Senha = objLogar.GerarHashMd5(senha);

            if (ModelState.IsValid)
            {
                objlogin.Usuario = model.Usuario;
                objlogin.Senha = model.Senha;
                objlogin.Tipo = "C";
                objlogin.IDCliente = IDCliente;
                db.Login.Add(objlogin);
                db.SaveChanges();
            }

            if(ModelState.IsValid)
            {
                objcarro.Marca = model.Marca;
                objcarro.Modelo = model.Modelo;
                objcarro.Ano = model.Ano;
                objcarro.Valvulas = model.Valvulas;
                objcarro.Versao = model.Versao;
                objcarro.Placa = model.Placa;
                objcarro.IDCliente = IDCliente;
                db.CarroAtual.Add(objcarro);
                db.SaveChanges();
                return RedirectToAction("HomeInicial");
            }



            ViewBag.IDCidade = new SelectList(db.Endereco, "CidadeId", "Nome", objendereco.IDCidade);
            return View(objlogin);
        }

        // GET: Login
        public ActionResult Index()
        {
            Session["Id"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult Index(Login model, string submitButton)
        {
            switch (submitButton)
            {
                case "Logar":
                    if (model.Usuario != null)
                    {
                        if (model.Senha != null)
                        {
                            LoginRepository objLogar = new LoginRepository();
                            string senha = model.Senha;
                            model.Senha = objLogar.GerarHashMd5(senha);

                            Login objdados = objLogar.Login(model);

                            if (objdados.ID != 0)
                            {
                                if (objdados.Tipo == "")
                                {
                                    Session["Id"] = null;
                                    Session["Usuario"] = null;
                                    Session["Senha"] = null;
                                    return RedirectToAction("blockeio", "Home");
                                }
                                else if (objdados.Tipo == "A")
                                {
                                    Session["ID"] = objdados.ID;
                                    Session["Usuario"] = objdados.Usuario;
                                    Session["Senha"] = objdados.Senha;

                                    return RedirectToAction("Index", "Home");
                                }
                            }
                            else
                            {
                                return RedirectToAction("blockeio", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(model.Senha), "Insira a Senha");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(model.Usuario), "Insira o Usuario");

                    }
                    return View();
                case "Voltar":
                    // call another action to perform the cancellation
                    return RedirectToAction("HomeInicial", "Home");
                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return View(model);
            }
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
