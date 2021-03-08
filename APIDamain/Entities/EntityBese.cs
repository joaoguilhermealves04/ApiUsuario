using System;
using System.Collections.Generic;
using System.Text;

namespace APIDomain.Entities
{
    public class EntityBese
    {
        
        #region Propriedades 
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        #endregion
        #region Construtor
        public EntityBese()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
        #endregion
    }
}
