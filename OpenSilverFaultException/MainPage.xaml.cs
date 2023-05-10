using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilverFaultException
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var service = new ServiceReference1.Service1Client(ServiceReference1.Service1Client.EndpointConfiguration
                .BasicHttpBinding_IService1);

            try
            {
                await service.AddOrUpdateToDoAsync(null);
            }
            catch (FaultException ex)
            {
                MessageBox.Show("Message from server: " + ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("It should show the message from the server");
            }

        }
    }
}
