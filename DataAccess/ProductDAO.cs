using System;
using BusinessObject;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class ProductDAO : DatabaseAcess
    {
        // Using Singleton Pattern
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ProductObject> GetProductList()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new("SELECT ProductId, CategoryId, ProductName, " +
                    "Weight, UnitPrice, UnitInStock FROM Product", conn);
                SqlDataReader reader = command.ExecuteReader();
                var products = new List<ProductObject>();

                while (reader.Read())
                {
                    products.Add(new ProductObject
                    {
                        ProductID = reader.GetInt32(0),
                        CategoryID = reader.GetInt32(1),
                        ProductName = reader.GetString(2),
                        Weight = reader.GetString(3),
                        UnitPrice = reader.GetDecimal(4),
                        UnitInStock = reader.GetInt32(5)
                    });
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public ProductObject GetProductById(int productId)
        {
            try
            {
                ProductObject product = null;
                OpenConnection();
                SqlCommand command = new("SELECT ProductId, CategoryId, ProductName, " +
                    $"Weight, UnitPrice, UnitInStock FROM Product WHERE ProductId = {productId}", conn);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    product = new ProductObject
                    {
                        ProductID = reader.GetInt32(0),
                        CategoryID = reader.GetInt32(1),
                        ProductName = reader.GetString(2),
                        Weight = reader.GetString(3),
                        UnitPrice = reader.GetDecimal(4),
                        UnitInStock = reader.GetInt32(5)
                    };
                }
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void AddNew(ProductObject product)
        {
            try
            {
                OpenConnection();
                string sql = $"INSERT Product VALUES ({product.CategoryID}, '{product.ProductName}', '{product.Weight}', {product.UnitPrice}, {product.UnitInStock})";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(ProductObject product)
        {
            try
            {
                OpenConnection();
                string sql = $"UPDATE Product SET CategoryId = {product.CategoryID}, ProductName = '{product.ProductName}', Weight = '{product.Weight}', UnitPrice = {product.UnitPrice}, UnitInStock = {product.UnitInStock} " +
                        $"WHERE ProductId = {product.ProductID}";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int productId)
        {
            try
            {
                OpenConnection();
                string sql = $"DELETE Product WHERE ProductId = {productId}";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
