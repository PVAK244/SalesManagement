using BusinessObject;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class OrderDAO : DatabaseAcess
    {
        // Using Singleton Pattern
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderObject> GetOrderList()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new("SELECT OrderId, MemberId, OrderDate, " +
                    "RequiredDate, ShippedDate, Freight FROM [Order]", conn);
                SqlDataReader reader = command.ExecuteReader();
                var orders = new List<OrderObject>();
                while (reader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderID = reader.GetInt32(0),
                        MemberID = reader.GetInt32(1),
                        OrderDate = reader.GetDateTime(2),
                        RequiredDate = reader.GetDateTime(3),
                        ShippedDate = reader.GetDateTime(4),
                        Freight = reader.GetDecimal(5)
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

        public OrderObject GetOrderByID(int orderId)
        {
            try
            {

                OpenConnection();
                SqlCommand command = new("SELECT OrderId, MemberId, OrderDate, " +
                    $"RequiredDate, ShippedDate, Freight FROM [Order] WHERE OrderId = '{orderId}'", conn);
                SqlDataReader reader = command.ExecuteReader();
                OrderObject order = null;
                if (reader.Read())
                {
                    order = new OrderObject
                    {
                        OrderID = reader.GetInt32(0),
                        MemberID = reader.GetInt32(1),
                        OrderDate = reader.GetDateTime(2),
                        RequiredDate = reader.GetDateTime(3),
                        ShippedDate = reader.GetDateTime(4),
                        Freight = reader.GetDecimal(5)
                    };
                }
                return order;
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


        public void AddNew(OrderObject order)
        {
            try
            {
                OpenConnection();
                string sql = $"INSERT [Order] VALUES ({order.MemberID}, '{order.OrderDate}', '{order.RequiredDate}', '{order.ShippedDate}', {order.Freight})";
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

        public void Update(OrderObject order)
        {
            try
            {
                OpenConnection();
                string sql = $"UPDATE [Order] SET MemberId = '{order.MemberID}', OrderDate = '{order.OrderDate}', " +
                        $"RequiredDate = '{order.RequiredDate}', ShippedDate = '{order.ShippedDate}', Freight = {order.Freight} WHERE OrderId = '{order.OrderID}'";
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

        public void Remove(int orderId)
        {
            try
            {
                OpenConnection();
                string sql = $"DELETE [Order] WHERE OrderId = {orderId}";
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
