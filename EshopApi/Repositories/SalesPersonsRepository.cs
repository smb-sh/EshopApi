using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Repositories
{
    public class SalesPersonsRepository:ISalesPersonsRepository
    {
        private EshopApiDbContext _context;

        public SalesPersonsRepository(EshopApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _context.SalesPersons.ToList();
        }

        public async Task<SalesPerson> Add(SalesPerson sales)
        {
            await _context.SalesPersons.AddAsync(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<SalesPerson> Find(int id)
        {
            return await _context.SalesPersons.SingleOrDefaultAsync(s => s.SalesPersonsId == id);

        }

        public async Task<SalesPerson> Update(SalesPerson sales)
        {
            _context.Update(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<SalesPerson> Remove(int id)
        {
            var sales = await _context.SalesPersons.SingleAsync(s => s.SalesPersonsId == id);
            _context.SalesPersons.Remove(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.SalesPersons.AnyAsync(s => s.SalesPersonsId == id);
        }
    }
}
