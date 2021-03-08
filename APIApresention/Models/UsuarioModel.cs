using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIApresention.Models
{
    public class UsuarioModel
    {
        [Required(ErrorMessage = "Por favor, informe o Id.")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome .")]
        public string Nome { get; set; }
        [Required(ErrorMessage= "Por favor, informe o Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor, informe Senhar.")]
        public string Senhar { get; set; }
    }
}
