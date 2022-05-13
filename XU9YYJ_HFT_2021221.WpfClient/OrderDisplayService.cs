using System.Windows;
using XU9YYJ_HFT_2021221.WpfClient.BL.Interfaces;
using XU9YYJ_HFT_2021221.WpfClient.Models;

namespace XU9YYJ_HFT_2021221.WpfClient
{
    public class OrderDisplayService : IOrderDisplayService
    {
        public void Display(OrderModel order)
        {
            if (order == null)
            {
                MessageBox.Show("Please select an order.");
            }
            else
            {
                var window = new OrderEditorWindow(order, false);
                window.Show();
            }
           

        }
    }
}
