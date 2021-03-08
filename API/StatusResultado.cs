using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class StatusResultado
    {
        public string Mensagem { get; set; }

        public StatusResultado(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
