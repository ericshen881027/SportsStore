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

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                _dbContext.Products.Add(product);
            }
            else
            {
                var entity = _dbContext.Products.Find(product.ProductId);
                if (entity != null)
                {
                    entity.Name = product.Name;
                    entity.Price = product.Price;
                    entity.Category = product.Category;
                    entity.Description = product.Description;
                }
            }

            _dbContext.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }

            return product;
        }
    }
}