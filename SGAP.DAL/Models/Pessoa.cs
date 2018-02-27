using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAP.DAL.Models
{
    [Table("TBL_PESSOA")]
    public class Pessoa
    {
        [Key, Column("iCodPessoa")]
        public int iCodPessoa { get; set; }

        [Column("iCodPessoaPerfil") Required, ForeignKey("perfil")]
        public int iCodPessoaPerfil { get; set; }
        public virtual Perfil perfil { get; set; }

        [Column("strNomePessoa"), Required]
        public string strNomePessoa { get; set; }

        [Column("strUsuario"), Required]
        public string strUsuario { get; set; }

        [Column("strSenha"), Required]
        public string strSenha { get; set; }

    }
}

