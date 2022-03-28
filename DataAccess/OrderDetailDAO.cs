using System;
using BusinessObject;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class OrderDetailDAO : DatabaseAcess
    {
        //Using  Signleton pattern
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetailObject> GetOrderDetailList()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new("SELECT OrderId, ProductId, UnitPrice, " +
                    "Quantity, Discount FROM OrderDetail", conn);
                SqlDataReader reader = command.ExecuteReader();
                var orders = new List<OrderDetailObject>();

                while (reader.Read())
                {
                    orders.Add(new OrderDetailObject
                    {
                        OrderID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        UnitPrice = reader.GetDecimal(2),
                        Quantity = reader.GetInt32(3),
                        Discount = reader.GetDouble(4),
                    });
                }
                return orders;
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

        public OrderDetailObject GetOrderDetailByID(int orderId, int productId)
        {
            try
            {
                OrderDetailObject orderDetail = null;
                OpenConnection();
                SqlCommand command = new($"SELECT OrderId, ProductId, UnitPrice, Quantity, Discount FROM OrderDetail WHERE OrderId = {orderId} AND ProductId = {productId}", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    orderDetail = new OrderDetailObject
                    {
                        OrderID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        UnitPrice = reader.GetDecimal(2),
                        Quantity = reader.GetInt32(3),
                        Discount = reader.GetDouble(4),
                    };
                }
                return orderDetail;
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

        public void AddNew(OrderDetailObject orderDetail)
        {
            try
            {
                OpenConnection();
                string sql = $"INSERT Product VALUES ({orderDetail.OrderID}, {orderDetail.ProductID}, {orderDetail.UnitPrice}, {orderDetail.Quantity}, {orderDetail.Discount})";
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

        public void Update(OrderDetailObject orderDetail)
        {
            try
            {
                OpenConnection();
                string sql = $"UPDATE OrderDetail SET UnitPrice = {orderDetail.UnitPrice}, Quantity = {orderDetail.Quantity}, Discount = {orderDetail.Discount} " +
                        $"WHERE OrderId = {orderDetail.OrderID} AND ProductId = {orderDetail.ProductID}";
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

        public void Remove(int orderId, int productId)
        {
            try
            {
                OpenConnection();
                string sql = $"DELETE OrderDetail WHERE OrderId = {orderId} AND ProductId = {productId}";
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
