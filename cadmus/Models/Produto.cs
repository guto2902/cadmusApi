using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Models
{
    public partial class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        [Range(minimum:0.1, maximum: 9999999, ErrorMessage ="Valor precisa ser maior que zero")]
        public decimal Valor { get; set; }

        public string Foto { get; set; }

    }
}
