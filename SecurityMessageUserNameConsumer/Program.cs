using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityMessageUserNameConsumer.ServiceReference1;
using System.ServiceModel.Channels;

namespace SecurityMessageUserNameConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            #region custom UserName and Password
            Service1Client customclient = new Service1Client("WSHttpBinding_IService1");
            customclient.ClientCredentials.UserName.UserName = "admin";
            customclient.ClientCredentials.UserName.Password = "123";
            ListAllBindingElements(customclient.Endpoint.Binding);
            try
            {
                Console.WriteLine(customclient.GetData(123));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            Console.ReadLine();
            #endregion

            #region default windows UserName and Password
            //Service1Client client = new Service1Client("WSHttpBinding_IService1");
            //client.ClientCredentials.UserName.UserName = "v-tazho";
            //client.ClientCredentials.UserName.Password = "Edward0601";
            //try {
            //    Console.WriteLine(client.GetData(123));
            //}
            //catch(Exception e) {
            //    Console.WriteLine(e.InnerException);
            //}
            //Console.ReadLine();
            #endregion
        }
        public static void ListAllBindingElements(Binding binding)
        {
            int i = 0;
            foreach (var bindingElement in binding.CreateBindingElements())
            {
                Console.WriteLine("\t{0}.{1}",++i,bindingElement.GetType().FullName);
            }
        }
    }
}
