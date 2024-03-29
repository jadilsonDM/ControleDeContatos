﻿using ControleDeContatos.Models;
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

            try
            {
                _contatosRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Contato não Cadastrado, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]

        public IActionResult Criar(ContatoModel contato)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    _contatosRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Contato não Cadastrado, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
          
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatosRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Contato não Cadastrado, detalhe do erro: {erro.Message} ";
                return View("Editar", contato);
            }
        }
    }
}
