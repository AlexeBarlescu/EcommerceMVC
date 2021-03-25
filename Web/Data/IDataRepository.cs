using System.Linq;
using Web.Models;

namespace Web.Data
{
    public interface IDataRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
        void SaveProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProduct(int id);
    }
}