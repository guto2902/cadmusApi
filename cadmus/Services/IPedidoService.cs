using cadmus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Services
{
    public interface IPedidoService
    {
        IEnumerable<Pedido> GetAllItems();
        Pedido Add(Pedido newItem);
        Pedido Update(Pedido newItem);
        Pedido GetById(int id);
        bool Remove(int id);
    }
}
