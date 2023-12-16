using iQuest.VendingMachine.Entities;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IProductRepository
    {
        public Product GetByColumn(int columnId);
        public IEnumerable<Product> GetAll();
    }
}
