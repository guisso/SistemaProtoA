using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProtoA
{
    internal class Usuario
    {
        // [Key]
        public Int64 Id { get; set; }

        [Required]
        [StringLength(45)]
        public String Nome { get; set; }

        public Credencial Credencial { get; set; }

        public override string ToString()
        {
            return Id 
                + ", " + Nome
                + ", " + Credencial?.Email;
        }
    }
}
