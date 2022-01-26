using OneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.Repositories
{
    public class CourierRepository : ICourierRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourierRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool IsCourierCheck(int courierId)
        {
            return _appDbContext.Couriers.Any(c => c.Id == courierId);
        }
    }
}
