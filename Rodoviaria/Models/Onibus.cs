using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rodoviaria.Models
{
    public class Onibus
    {
        [Key]
        public Int32 IDOnibus { get; set; }

        [Required(ErrorMessage = "Digite a cor do ônibus!")]
        [MaxLength(20, ErrorMessage = "A cor deve ter no máximo {0} caracteres"), MinLength(3, ErrorMessage = "A cor deve ter no mínimo {0} caracteres")]
        public String Cor { get; set; }

        [Required(ErrorMessage = "Digite o custo por km do ônibus!")]
        [DisplayFormat(DataFormatString = "{0, N2}", ApplyFormatInEditMode = true)]
        public Decimal CustoPorKm { get; set; }
        
    }
}