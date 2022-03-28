using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailObject> GetOrdersDetail();
        OrderDetailObject GetOrderDetailByID(int orderId, int productId);
        void InsertOrderDetail(OrderDetailObject orderDetail);
        void DeleteOrderDetail(int orderId, int productId);
        void UpdateOrderDetail(OrderDetailObject orderDetail);
    }
}
