using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAP.DAL.Models
{
    [Table("TBL_PERFIL")]
    public class Perfil
    {
        [Key, Column("iCodPerfil")]
        public int iCodPerfil { get; set; }

        [Column("iCodAcesso") Required, ForeignKey("acesso")]
        public int iCodAcesso { get; set; }
        public virtual Acesso acesso { get; set; }

        [Column("strDescricao"), Required]
        public string strDescricao { get; set; }
    }
}
