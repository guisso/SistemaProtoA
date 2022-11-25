using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProtoA
{
    //[Table("tbl_test")]
    internal class Test
    {
        public Int64 Id { get; set; }
        public Byte SignedByte { get; set; }
        public UInt16 UnsignedInt16 { get; set; }
        public UInt32 UnsignedInt32 { get; set; }
        public UInt64 UnsignedInt64 { get; set; }
        public Int16 SignedInt16 { get; set; }
        public Int32 SignedInt32 { get; set; }
        public Int64 SignedInt64 { get; set; }
        public Double SignedDouble { get; set; }
        public Single SignedSingle { get; set; }
        public DateTime DataHora { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        //[Column(TypeName = "numeric(7,5)")]
        public Decimal Pagamento { get; set; }

    }
}
