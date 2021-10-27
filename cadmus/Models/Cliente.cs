using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Preenchimento obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public string Aldeia { get; set; }
    }
}
