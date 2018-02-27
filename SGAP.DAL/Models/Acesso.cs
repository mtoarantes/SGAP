using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAP.DAL.Models
{
    [Table("TBL_ACESSO")]
    public class Acesso
    {
        [Key, Column("iCodAcesso")]
        public int iCodAcesso { get; set; }

        [Column("strDescricao"), Required]
        public string strDescricao { get; set; }
    }
}
