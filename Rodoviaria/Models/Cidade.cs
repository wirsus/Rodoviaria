using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rodoviaria.Models
{
    public class Cidade
    {
        [Key]
        public Int32 IDCidade { get; set; }

        [Required(ErrorMessage = "Informe o Estado!")]
        public String UF { get; set; }

        [Required(ErrorMessage = "Informe a cidade!")]
        [MaxLength(100, ErrorMessage = "O destino deve possuir no máximo {0} caracteres!"), MinLength(3, ErrorMessage = "O destino deve possuir no mínimo {0} caracteres!")]
        public String Nome { get; set; }

        //[Required(ErrorMessage = "Informe a distância do destino em km!")]
        [DisplayFormat(DataFormatString = "{0,N1}", ApplyFormatInEditMode = true)]
        public Int32 Distancia { get; set; }

    }
}