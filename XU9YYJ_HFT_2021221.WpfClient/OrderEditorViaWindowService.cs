using XU9YYJ_HFT_2021221.WpfClient.BL.Interfaces;
using XU9YYJ_HFT_2021221.WpfClient.Models;

namespace XU9YYJ_HFT_2021221.WpfClient
{
    public class OrderEditorViaWindowService : IOrderEditorService
    {
        public OrderModel EditOrder(OrderModel order)
        {

                var window = new OrderEditorWindow(order);
                if (window.ShowDialog() == true)
                {
                    return window.Order;
                }
           
            return null;
        }
    }
}
