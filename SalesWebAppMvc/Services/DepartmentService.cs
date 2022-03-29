using SalesWebAppMvc.Data;
using SalesWebAppMvc.Models;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebAppMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebAppMvcContext _context;

        public DepartmentService(SalesWebAppMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
