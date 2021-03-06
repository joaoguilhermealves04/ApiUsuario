using System;
using System.Collections.Generic;
using System.Text;

namespace APIDamain.Entities
{
    public class Usuario : EntityBese
    {
        #region Propriedades 
        public string Nome{ get; set; }
        public string Email { get; set; }
        public string Senhar { get; set; }
     
        #endregion
      
    }
}
