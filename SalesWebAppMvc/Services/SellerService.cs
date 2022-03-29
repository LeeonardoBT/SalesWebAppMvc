using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebAppMvc.Models;
using SalesWebAppMvc.Data;

namespace SalesWebAppMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebAppMvcContext _context;

        public SellerService(SalesWebAppMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
    }
}
