using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using XU9YYJ_HFT_2021221.WpfClient.BL.Interfaces;
using XU9YYJ_HFT_2021221.WpfClient.Models;

namespace XU9YYJ_HFT_2021221.WpfClient.ViewModels
{
    public class OrderEditorVM : ViewModelBase
    {
        private OrderModel currentOrder;

        public OrderModel CurrentOrder
        {
            get { return currentOrder; }
            set
            {
                Set(ref currentOrder, value);
                SelectedSupplier = AvailableSuppliers?.SingleOrDefault(x => x.Id == currentOrder.SupplierId);
                SelectedItem = AvailableItems?.SingleOrDefault(x => x.Id == currentOrder.ItemId);
            }
        }
        private SupplierModel selectedSupplier;

        public SupplierModel SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                Set(ref selectedSupplier, value);
                currentOrder.SupplierId = selectedSupplier?.Id ?? 0;
            }
        }
        private ItemModel selectedItem;

        public ItemModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                Set(ref selectedItem, value);
                currentOrder.ItemId = selectedItem?.Id ?? 0;
            }
        }
        public IList<SupplierModel> AvailableSuppliers { get; private set; }
        public IList<ItemModel> AvailableItems { get; private set; }
        private bool editEnabled;

        public bool EditEnabled
        {
            get { return editEnabled; }
            set
            {
                Set(ref editEnabled, value);
                RaisePropertyChanged(nameof(CancelButtonVisibility));
            }
        }
        public System.Windows.Visibility CancelButtonVisibility => EditEnabled ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        public OrderEditorVM(IOrderHandlerService orderHandlerService)
        {
            CurrentOrder = new OrderModel();
            if (IsInDesignModeStatic)
            {
                AvailableSuppliers = new List<SupplierModel>()
                {
                   new SupplierModel(1, "SKF", 364829187,"7400, Kaposvár, Kossuth L. utca 24." ),
                   new SupplierModel(2, "Szuperszíj", 38376462, "3300, Eger, Bíboros utca 7."),
                   new SupplierModel(3, "NST", 37495842, "8000, Székesfehérvár, Baross G. utca 18." ),
                   new SupplierModel(4, "PowerBelt", 8745272, "2310, Szigetszentmiklós, Petőfi utca 87." ),
                };
                AvailableItems = new List<ItemModel>()
                {
                    new ItemModel(1, "bearing 245","pc", 1),
                    new ItemModel(2, "hose 14","m", 3 ),
                    new ItemModel(3, "belt 372","m", 4 ),
                    new ItemModel (4, "belt 165", "m", 2 ),
                    new ItemModel(5, "cylinder", "pc", 1 ),
                    new ItemModel(6, "pliers", "pc", 2 ),
                    new ItemModel(7, "screwdriver", "set", 3 ),
                    new ItemModel(8, "chain","pc", 4 ),
                    new ItemModel(9, "allen key", "set", 3 ),
                };
                SelectedSupplier = AvailableSuppliers[1];
                SelectedItem = AvailableItems[1];
                CurrentOrder.Date = DateTime.Now;
                CurrentOrder.Note = "Test order";
                CurrentOrder.Quantity = 2;
                CurrentOrder.Currency = "HUF";
                CurrentOrder.SupplierName = "SKF";
                CurrentOrder.UnitPrice = 123;
                //minden megvan???
            }
            else
            {
                AvailableItems = orderHandlerService.GetAllItem();
                AvailableSuppliers = orderHandlerService.GetAllSupplier();
            }
        }
        public OrderEditorVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IOrderHandlerService>())
        {

        }
    }
}
