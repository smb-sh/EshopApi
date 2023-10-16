using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Models;

namespace EshopApi.Contracts
{
    public interface ISalesPersonsRepository
    {
        IEnumerable<SalesPerson> GetAll();
        Task<SalesPerson> Add(SalesPerson sales);
        Task<SalesPerson> Find(int id);
        Task<SalesPerson> Update(SalesPerson sales);
        Task<SalesPerson> Remove(int id);
        Task<bool> IsExists(int id);
    }
}
