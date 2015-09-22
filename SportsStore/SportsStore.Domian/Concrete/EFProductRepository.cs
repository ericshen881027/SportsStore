using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext _dbContext = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return _dbContext.Products; }
        }
    }
}