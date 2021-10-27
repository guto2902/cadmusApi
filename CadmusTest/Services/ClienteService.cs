using cadmus.Models;
using cadmus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadmusTest.Services
{
    public class ClienteServiceFake : IClienteService
    {

        private readonly List<Cliente> _Clientes;

        public ClienteServiceFake()
        {
            _Clientes = new List<Cliente>() { 
            
                new Cliente{ Id=1, Email="teste@teste.com" , Aldeia="aldeia0"},
                new Cliente{ Id=2, Email="teste2@teste.com" , Aldeia="aldeia1"},
                new Cliente{ Id=3, Email="teste3@teste.com" , Aldeia="aldeia2"},
                new Cliente{ Id=4, Email="teste4@teste.com" , Aldeia="aldeia3"},
            };
        }

        public Cliente Add(Cliente newItem)
        {

            newItem.Id = _Clientes.Max(x => x.Id) + 1;

            _Clientes.Add(newItem);

            return newItem;

        }

        public IEnumerable<Cliente> GetAllItems()
        {
            return _Clientes;
        }

        public Cliente GetById(int id)
        {
            return _Clientes.FirstOrDefault(x => x.Id == id);
        }

        public bool Remove(int id)
        {
           var e = _Clientes.FirstOrDefault(x => x.Id == id);

            _Clientes.Remove(e);

            return true;

        }

        public Cliente Update(Cliente newItem)
        {
            var item = _Clientes.FirstOrDefault(x => x.Id == newItem.Id);

            _Clientes.Remove(item);

            _Clientes.Add(newItem);

            return newItem;
        }
    }
}
