using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AlteracaoUsuarioModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome .")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe Senhar.")]
        public string Senha { get; set; }
    }
}
