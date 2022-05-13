using System.Windows;
using XU9YYJ_HFT_2021221.WpfClient.Models;
using XU9YYJ_HFT_2021221.WpfClient.ViewModels;

namespace XU9YYJ_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for OrderEditorWindow.xaml
    /// </summary>
    public partial class OrderEditorWindow : Window
    {
        public OrderModel Order { get; set; }
        bool enableEdit;
        public OrderEditorWindow(OrderModel order = null, bool enableEdit = true)
        {

            InitializeComponent();
            Order = order == null ? new OrderModel() : new OrderModel(order);
            this.enableEdit = enableEdit;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var vm = (OrderEditorVM)Resources["VM"];
            vm.CurrentOrder = Order;
            vm.EditEnabled = enableEdit;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = true;
            }
            else
            {
                Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = false;
            }
            else
            {
                Close();
            }
        }
    }
}
