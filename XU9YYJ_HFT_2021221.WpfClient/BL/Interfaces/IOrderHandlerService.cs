using System.Collections.Generic;
using XU9YYJ_HFT_2021221.Models.Entities;
using XU9YYJ_HFT_2021221.WpfClient.Models;

namespace XU9YYJ_HFT_2021221.WpfClient.BL.Interfaces
{
    public interface IOrderHandlerService
    {
        void AddOrder(IList<OrderModel> collection);
        void ModifyOrder(IList<OrderModel> collection, OrderModel order);
        void DeleteOrder(IList<OrderModel> collection, OrderModel order);
        void ViewOrder(OrderModel order);

        IList<OrderModel> GetAll();
        IList<ItemModel> GetAllItem();
        IList<SupplierModel> GetAllSupplier();
    }
}
