using cadmus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Services
{
    public class ClienteService : IClienteService
    {
        public Cliente Add(Cliente newItem)
        {
            using(CadmusContext db=new CadmusContext())
            {
                db.Clientes.Add(newItem);
                db.SaveChanges();

                return newItem;
            }
        }

        public IEnumerable<Cliente> GetAllItems()
        {
            using (CadmusContext db = new CadmusContext())
            {
                var itens = db.Clientes;

                return itens;
            }
        }

        public Cliente GetById(int id)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var itens = db.Clientes.FirstOrDefault(x=>x.Id==id);

                return itens;
            }
        }

        public bool Remove(int id)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var item = db.Clientes.FirstOrDefault(x => x.Id == id);

                db.Clientes.Remove(item);

                db.SaveChanges();

                return true;
            }
        }

        public Cliente Update(Cliente newItem)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var item = db.Clientes.FirstOrDefault(x => x.Id == newItem.Id);

                item = newItem;

                db.SaveChanges();

                return item;
            }
        }
    }
}
