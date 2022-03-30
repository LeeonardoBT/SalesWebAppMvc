using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebAppMvc.Models;
using SalesWebAppMvc.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebAppMvc.Services.Exceptions;

namespace SalesWebAppMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebAppMvcContext _context;

        public SellerService(SalesWebAppMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
