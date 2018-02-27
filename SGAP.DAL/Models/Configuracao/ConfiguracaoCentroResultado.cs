using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAP.DAL.Models.Configuracao
{
    [Table("TBL_CONFIG_CR")]
    public class ConfiguracaoCentroResultado
    {
        [Key, Column("iCodConfigCentroCusto")]
        public int iCodConfigCentroCusto { get; set; }

        [Column("iNumCentroResultado"), Required]
        public string iNumCentroResultado { get; set; }

        [Column("strDescricao"), Required]
        public string strDescricao { get; set; }
    }
}

