using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rodoviaria.Models
{
    public class Passageiro
    {
        [Key]
        public Int32 IDPassageiro { get; set; }

        [Required(ErrorMessage = "Digite o nome do passageiro!")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo {0} caracteres"), MinLength(5, ErrorMessage = "O nome deve conter no mínimo {0} caracteres")]
        public String Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:d2}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento{ get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Range(0, 1000, ErrorMessage = "O dinheiro informado deve estar acima de {0} e abaixo {1}!")]
        public Decimal Dinheiro { get; set; }
    }
}