using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using XU9YYJ_HFT_2021221.WpfClient.BL.Implementation;
using XU9YYJ_HFT_2021221.WpfClient.BL.Interfaces;
using XU9YYJ_HFT_2021221.WpfClient.Infrastructure;

namespace XU9YYJ_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);

            SimpleIocAsServiceLocator.Instance.Register<IOrderEditorService, OrderEditorViaWindowService>();
            SimpleIocAsServiceLocator.Instance.Register<IOrderDisplayService, OrderDisplayService>();
            SimpleIocAsServiceLocator.Instance.Register<IOrderHandlerService, OrderHandlerService>();
            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
        }
    }
}
