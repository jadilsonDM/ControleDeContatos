using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatosRepositorio _contatosRepositorio;
        public ContatoController(IContatosRepositorio contatosRepositorio)
        {
            _contatosRepositorio = contatosRepositorio;
        }
        public IActionResult Index()
        {
           List<ContatoModel> contatos =  _contatosRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatosRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatosRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
           
            _contatosRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Criar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatosRepositorio.Adicionar(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatosRepositorio.Atualizar(contato);
                return RedirectToAction("Index");
            }
            return View("Editar", contato);
        }
    }
}
