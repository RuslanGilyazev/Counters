using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using CountersLibrary;

namespace CountersServer {
    class Program {

        private const string PreppingServer = "Prepping CheckoutService server";
        private const string RunWithAdministrator = "Please run this app with administrator privileges. Error message:";
        private const string CheckoutService = "CheckoutService server up and running";
        private const string PressReturn = "Press Return to stop service at any point";
        public const string ServiceName = "CountersService";
        public const string ServiceUrl = "http://localhost:8000/" + ServiceName;

        static void Main(string[] args) {
            Uri uri = new Uri(ServiceUrl);

            using (ServiceHost host = new ServiceHost(typeof(CountersService), uri)) {
                Console.WriteLine(PreppingServer);

                host.AddServiceEndpoint(typeof(ICountersService), new WSHttpBinding(), ServiceName);

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior {
                    HttpGetEnabled = true,
                    MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}
                };

                host.Description.Behaviors.Add(smb);

                try {
                    host.Open();
                }
                catch (System.ServiceModel.AddressAccessDeniedException exception) {
                    Console.WriteLine(RunWithAdministrator);
                    Console.WriteLine(exception.Message);
                    Console.ReadLine();
                    return;
                }

                Console.Clear();
                Console.WriteLine(CheckoutService);
                Console.WriteLine(PressReturn);

                Console.ReadLine();
                host.Close();
            }
        }
    }
}
