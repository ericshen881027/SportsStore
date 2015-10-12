using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var cartLine = _lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
            if (cartLine == null)
            {
                _lineCollection.Add(new CartLine {Product = product, Quantity = quantity});
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.Quantity*e.Product.Price);
        }

        public void Clean()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> CartLines
        {
            get { return _lineCollection; }
        } 
    }
}