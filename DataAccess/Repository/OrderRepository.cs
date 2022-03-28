using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public  class OrderRepository : IOrderRepository
    {
        public IEnumerable<OrderObject> GetOrders() 
            => OrderDAO.Instance.GetOrderList();
        public OrderObject GetOrderByID(int orderID) 
            => OrderDAO.Instance.GetOrderByID(orderID);
        public void InsertOrder(OrderObject order) 
            => OrderDAO.Instance.AddNew(order);
        public void DeleteOrder(int orderID) 
            => OrderDAO.Instance.Remove(orderID);
        public void UpdateOrder(OrderObject order) 
            => OrderDAO.Instance.Update(order);
    }
}
