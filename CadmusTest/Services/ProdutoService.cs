using cadmus.Models;
using cadmus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadmusTest.Services
{
    public class ProdutoServiceFake : IProdutoService
    {

        private readonly List<Produto> _Produtos;

        public ProdutoServiceFake()
        {
            _Produtos = new List<Produto>()
            { 
                new Produto() { Id=1, Descricao="teste produto 1", Valor=9 },
                new Produto() { Id=2, Descricao="teste produto 2", Valor=5.50m, Foto="ccccccccccccccc" },
                new Produto() { Id=3, Descricao="teste produto 1", Valor=9 },
                new Produto() { Id=4, Descricao="teste produto 2", Valor=90, Foto="ccccccccccccccc" },
                new Produto() { Id=5, Descricao="teste produto 1", Valor=9 },
                new Produto() { Id=6, Descricao="teste produto 2", Valor=50, Foto="ccccccccccccccc" },
                new Produto() { Id=7, Descricao="teste produto 1", Valor=9 },
                new Produto() { Id=8, Descricao="teste produto 2", Valor=60.7m, Foto="ccccccccccccccc" },

            };
        }

        public Produto Add(Produto newItem)
        {

            newItem.Id= _Produtos.Max(x => x.Id) + 1;

            _Produtos.Add(newItem);

            return newItem;
        }

        public IEnumerable<Produto> GetAllItems()
        {
            return _Produtos;
        }

        public Produto GetById(int id)
        {
            return _Produtos.FirstOrDefault(x => x.Id == id);
        }

        public bool Remove(int id)
        {
            var e = _Produtos.FirstOrDefault(x => x.Id == id);

            _Produtos.Remove(e);

            return true;
        }

        public Produto Update(Produto newItem)
        {
            var item = _Produtos.FirstOrDefault(x => x.Id == newItem.Id);

            _Produtos.Remove(item);

            _Produtos.Add(newItem);

            return newItem;
        }
    }
}
