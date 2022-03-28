using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ProductObject> GetProducts() 
            => ProductDAO.Instance.GetProductList();
        public ProductObject GetProductByID(int productId) 
            => ProductDAO.Instance.GetProductById(productId);
        public void InsertProduct(ProductObject product) 
            => ProductDAO.Instance.AddNew(product);
        public void DeleteProduct(int productId)
            => ProductDAO.Instance.Remove(productId);
        public void UpdateProduct(ProductObject product)
            => ProductDAO.Instance.Update(product);
    }
}
