using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Models
{
    public partial class PedidoItens
    {
        public int Id { get; set; }
        
        public int NumeroPedido { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal Valor { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorTotal { get; set; }

    }
}
