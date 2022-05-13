using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Linq;
using XU9YYJ_HFT_2021221.Models.DTOs;
using XU9YYJ_HFT_2021221.Models.Entities;
using XU9YYJ_HFT_2021221.WpfClient.BL.Interfaces;
using XU9YYJ_HFT_2021221.WpfClient.Infrastructure;
using XU9YYJ_HFT_2021221.WpfClient.Models;

namespace XU9YYJ_HFT_2021221.WpfClient.BL.Implementation
{
    public class OrderHandlerService : IOrderHandlerService
    {

        readonly IMessenger messenger;
        readonly IOrderEditorService editorService;
        readonly IOrderDisplayService orderDisplayService;


        HttpService httpService;

        public OrderHandlerService(IMessenger messenger, IOrderEditorService editorService, IOrderDisplayService orderDisplayService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.orderDisplayService = orderDisplayService;
            httpService = new HttpService("Order", "http://localhost:55271/api/");
        }

        public void AddOrder(IList<OrderModel> collection)
        {
            OrderModel orderToEdit = null;
            bool operationFinished = false;

            do
            {
                var newOrder = editorService.EditOrder(orderToEdit);

                if (newOrder != null)
                {
                    var operationResult = httpService.Create(new OrderDTO()
                    {
                        Id = newOrder.Id,
                        ItemId = newOrder.ItemId,
                        Quantity = newOrder.Quantity,
                        UnitPrice = newOrder.UnitPrice,
                        Currency = newOrder.Currency,
                        Note = newOrder.Note,
                        Date = newOrder.Date,
                        SupplierName = newOrder.SupplierName,
                        SupplierId = newOrder.SupplierId,
                    });

                    orderToEdit = newOrder;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        RefreshCollectionFromServer(collection);

                        SendMessage("Order was added successfully.");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Order adding has been cancelled.");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }
        private void RefreshCollectionFromServer(IList<OrderModel> collection)
        {
            collection.Clear();
            var newOrders = GetAll();

            foreach (var order in newOrders)
            {
                collection.Add(order);
            }
        }

        private void SendMessage(params string[] messages)
        {
            messenger.Send(messages, "BlOperationResult");
        }
        public void DeleteOrder(IList<OrderModel> collection, OrderModel order)
        {
            if (order != null)
            {
                var operationResult = httpService.Delete(order.Id);

                if (operationResult.IsSuccess)
                {
                    RefreshCollectionFromServer(collection);
                    SendMessage("Order deletion was successful");
                }
                else
                {
                    SendMessage(operationResult.Messages.ToArray());
                }
            }
            else
            {
                SendMessage("Order deletion failed");
            }
        }

        public IList<OrderModel> GetAll()
        {

            var orders = httpService.GetAll<Order>();

            return orders.Select(x => new OrderModel(x.Id, x.ItemId, x.Quantity, x.UnitPrice, x.Currency, x.Note, x.Date, x.SupplierName, x.SupplierId)).ToList();
        }

        public IList<ItemModel> GetAllItem()
        {
            var items = new List<ItemModel>()
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

            return items;
            //var items = httpService.GetAll<Item>();

            //return items.Select(x => new ItemModel(x.Id, x.Name, x.UnitOfMeasure, x.SupplierId)).ToList();
        }

        public IList<SupplierModel> GetAllSupplier()
        {
            var suppliers = new List<SupplierModel>()
                {
                   new SupplierModel(1, "SKF", 364829187,"7400, Kaposvár, Kossuth L. utca 24." ),
                new SupplierModel(2, "Szuperszíj", 38376462, "3300, Eger, Bíboros utca 7."),
                new SupplierModel(3, "NST", 37495842, "8000, Székesfehérvár, Baross G. utca 18." ),
                new SupplierModel(4, "PowerBelt", 8745272, "2310, Szigetszentmiklós, Petőfi utca 87." ),
            };

            return suppliers;
            //var suppliers = httpService.GetAll<Supplier>();

            //return suppliers.Select(x => new SupplierModel(x.Id, x.Name, x.VATNumber, x.Address)).ToList();
        }

        public void ModifyOrder(IList<OrderModel> collection, OrderModel order)
        {
            OrderModel orderToEdit = order;
            bool operationFinished = false;

            do
            {
                var editedOrder = editorService.EditOrder(orderToEdit);

                if (editedOrder != null)
                {
                    var operationResult = httpService.Update(new OrderDTO()
                    {
                        Id = order.Id,
                        ItemId = editedOrder.ItemId,
                        Quantity = editedOrder.Quantity,
                        UnitPrice = editedOrder.UnitPrice,
                        Currency = editedOrder.Currency,
                        Note = editedOrder.Note,
                        Date = editedOrder.Date,
                        SupplierName = editedOrder.SupplierName,
                        SupplierId = editedOrder.SupplierId,

                    });

                    orderToEdit = editedOrder;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        RefreshCollectionFromServer(collection);
                        SendMessage("Order modification was successful");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Order modification has been cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        public void ViewOrder(OrderModel order)
        {
            orderDisplayService.Display(order);
        }
    }
}
