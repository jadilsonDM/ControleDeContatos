using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface IContatosRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel cotato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
