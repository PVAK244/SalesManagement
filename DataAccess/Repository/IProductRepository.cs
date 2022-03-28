using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();
        ProductObject GetProductByID(int productId);
        void InsertProduct(ProductObject product);
        void DeleteProduct(int productId);
        void UpdateProduct(ProductObject product);
    }
}
