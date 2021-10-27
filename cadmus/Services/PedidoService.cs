using cadmus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Services
{
    public class PedidoService : IPedidoService
    {
        public Pedido Add(Pedido newItem)
        {
            using (CadmusContext db = new CadmusContext())
            {
                db.Pedidos.Add(newItem);
                db.SaveChanges();

                return newItem;
            }
        }

        public IEnumerable<Pedido> GetAllItems()
        {
            using (CadmusContext db = new CadmusContext())
            {
                var itens = db.Pedidos;

                return itens;
            }
        }

        public Pedido GetById(int id)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var itens = db.Pedidos.FirstOrDefault(x => x.Numero== id);

                return itens;
            }
        }

        public bool Remove(int id)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var item = db.Pedidos.FirstOrDefault(x => x.Numero == id);

                db.Pedidos.Remove(item);

                db.SaveChanges();

                return true;
            }
        }

        public Pedido Update(Pedido newItem)
        {
            using (CadmusContext db = new CadmusContext())
            {

                //todo alteração dos itens???
                var item = db.Pedidos.FirstOrDefault(x => x.Numero== newItem.Numero);

                item = newItem;

                db.SaveChanges();

                return item;
            }
        }
    }
}
