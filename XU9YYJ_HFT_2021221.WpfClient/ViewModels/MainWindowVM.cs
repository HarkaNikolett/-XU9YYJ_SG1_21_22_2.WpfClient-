using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using XU9YYJ_HFT_2021221.WpfClient.BL.Interfaces;
using XU9YYJ_HFT_2021221.WpfClient.Models;

namespace XU9YYJ_HFT_2021221.WpfClient.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private OrderModel currentOrder;

        public OrderModel CurrentOrder
        {
            get { return currentOrder; }
            set { Set(ref currentOrder, value); }
        }
        public ObservableCollection<OrderModel> Orders { get; set; }
        public ICommand AddCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }

        public ICommand LoadCommand { get; private set; }

        readonly IOrderHandlerService orderHandlerService;
        public MainWindowVM(IOrderHandlerService orderHandlerService)
        {
            this.orderHandlerService = orderHandlerService;
            Orders = new ObservableCollection<OrderModel>();
            if (IsInDesignMode)
            {
                Orders.Add(new OrderModel(1, 1, 3, 13, "EUR", "Urgent", new DateTime(2021, 10, 16), "SKF", 1));
                Orders.Add(new OrderModel(2, 2, 4, 17, "EUR", "Urgent", new DateTime(2021, 10, 16), "NST", 3));
                Orders.Add(new OrderModel(3, 3, 9, 130, "EUR", "Urgent", new DateTime(2021, 10, 16), "Szuperszíj", 2));
                var currOrder = new OrderModel(4, 4, 13, 87, "EUR", "Urgent", new DateTime(2022, 04, 21), "PowerBelt", 4);
                Orders.Add(currOrder);
                CurrentOrder = currOrder;
            }
            LoadCommand = new RelayCommand(() =>
                {
                    var orders = this.orderHandlerService.GetAll();
                    Orders.Clear();
                    foreach (var order in orders)
                    {
                        Orders.Add(order);
                    }
                });
            AddCommand = new RelayCommand(() => this.orderHandlerService.AddOrder(Orders));
            ModifyCommand = new RelayCommand(() => this.orderHandlerService.ModifyOrder(Orders, CurrentOrder));
            DeleteCommand = new RelayCommand(() => this.orderHandlerService.DeleteOrder(Orders, CurrentOrder));
            ViewCommand = new RelayCommand(() => this.orderHandlerService.ViewOrder(CurrentOrder));
        }
        public MainWindowVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IOrderHandlerService>())
        {
        }


    }
}
