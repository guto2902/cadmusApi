using cadmus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetAllItems();
        Produto Add(Produto newItem);
        Produto Update(Produto newItem);
        Produto GetById(int id);
        bool Remove(int id);
    }
}
