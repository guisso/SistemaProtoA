using System;
using System.ComponentModel.DataAnnotations;

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
                + ", Credencial: " + Credencial?.Id;
        }
    }
}
