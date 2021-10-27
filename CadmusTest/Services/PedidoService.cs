using cadmus.Models;
using cadmus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadmusTest.Services
{
    public class PedidoServiceFake : IPedidoService
    {

        private readonly List<Pedido> _Pedidos;

        public PedidoServiceFake()
        {
            _Pedidos = new List<Pedido>() { 
            new Pedido{  Numero=1, ClienteId=1,  Data=DateTime.Now, Desconto=5.5m }
            };
        }

        public Pedido Add(Pedido newItem)
        {

            newItem.Numero = _Pedidos.Max(x => x.Numero) + 1;

            _Pedidos.Add(newItem);

            return newItem;
           
        }

        public IEnumerable<Pedido> GetAllItems()
        {
            return _Pedidos;
            
        }

        public Pedido GetById(int id)
        {
            return _Pedidos.FirstOrDefault(x => x.Numero == id);
        }

        public bool Remove(int id)
        {
            var e = _Pedidos.FirstOrDefault(x => x.Numero == id);

            _Pedidos.Remove(e);

            return true;
        }

        public Pedido Update(Pedido newItem)
        {
            var item = _Pedidos.FirstOrDefault(x => x.Numero == newItem.Numero);

            _Pedidos.Remove(item);

            _Pedidos.Add(newItem);

            return newItem;
        }
    }
}
