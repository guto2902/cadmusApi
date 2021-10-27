using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Models
{
    public partial class Pedido
    {
        public int Numero { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public decimal Valor { get; set; }

        public decimal Desconto { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        public virtual ICollection<PedidoItens> PedidoItens { get; set; }
    }
}
