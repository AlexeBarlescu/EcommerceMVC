using System.Linq;
using Web.Models;

namespace Web.Data
{
    public class EfDataRepository: IDataRepository
    {
        private readonly AppContext _ctx;

        public EfDataRepository(AppContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Product> Products => _ctx.Products;
        
        public IQueryable<Order> Orders => _ctx.Orders;
        
        public void SaveOrder(Order order)
        {
            _ctx.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
            {
                _ctx.Orders.Add(order);
            }

            _ctx.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                _ctx.Products.Add(product);
            }
            _ctx.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _ctx.Products.Remove(product);
            _ctx.SaveChanges();
        }

        public Product GetProduct(int id) => _ctx.Products.FirstOrDefault(p => p.ProductId == id);
    }
}