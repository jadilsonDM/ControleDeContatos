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
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Criar(ContatoModel contato)
        {
            _contatosRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
