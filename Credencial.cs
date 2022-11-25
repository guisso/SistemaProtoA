using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProtoA
{
    internal class Credencial
    {
        public Int64 Id { get; set; }

        [Required]
        [StringLength(250)]
        public String Email { get; set; }

    }
}
