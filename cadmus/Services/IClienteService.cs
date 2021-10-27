using cadmus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAllItems();
        Cliente Add(Cliente newItem);
        Cliente Update(Cliente newItem);
        Cliente GetById(int id);
        bool Remove(int id);
    }
}
