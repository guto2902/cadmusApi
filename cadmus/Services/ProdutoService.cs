using cadmus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Services
{
    public class ProdutoService : IProdutoService
    {
        public Produto Add(Produto newItem)
        {
            using (CadmusContext db = new CadmusContext())
            {
                db.Produtos.Add(newItem);
                db.SaveChanges();

                return newItem;
            }
        }

        public IEnumerable<Produto> GetAllItems()
        {
            using (CadmusContext db = new CadmusContext())
            {
                var itens = db.Produtos;

                return itens;
            }
        }

        public Produto GetById(int id)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var itens = db.Produtos.FirstOrDefault(x => x.Id == id);

                return itens;
            }
        }

        public bool Remove(int id)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var item = db.Produtos.FirstOrDefault(x => x.Id == id);

                db.Produtos.Remove(item);

                db.SaveChanges();

                return true;
            }
        }

        public Produto Update(Produto newItem)
        {
            using (CadmusContext db = new CadmusContext())
            {
                var item = db.Produtos.FirstOrDefault(x => x.Id == newItem.Id);

                item = newItem;

                db.SaveChanges();

                return item;
            }
        }
    }
}
