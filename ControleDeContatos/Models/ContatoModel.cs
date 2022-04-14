using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="digite o Nome do contato!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "digite o Email do contato!")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "digite o Celular do contato!")]
        [Phone(ErrorMessage ="Celular invalido")]
        public string Celular { get; set; }









    }
}
