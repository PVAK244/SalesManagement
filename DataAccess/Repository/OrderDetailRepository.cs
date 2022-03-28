using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetailObject> GetOrdersDetail() 
            => OrderDetailDAO.Instance.GetOrderDetailList();
        public OrderDetailObject GetOrderDetailByID(int orderId, int productId) 
            => OrderDetailDAO.Instance.GetOrderDetailByID(orderId, productId);
        public void InsertOrderDetail(OrderDetailObject orderDetail) 
            => OrderDetailDAO.Instance.AddNew(orderDetail);
        public void DeleteOrderDetail(int orderId, int productId) 
            => OrderDetailDAO.Instance.Remove(orderId, productId);
        public void UpdateOrderDetail(OrderDetailObject orderDetail) 
            => OrderDetailDAO.Instance.Update(orderDetail);
    }
}
