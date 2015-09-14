using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;

namespace RoutingService
{
    public class Router
    {
        public static void Main()
        {
            Console.Title = "WCF Routing Service";

            #region 编程式
            using (var host = new ServiceHost(typeof(System.ServiceModel.Routing.RoutingService)))
            {
                ////判断是否以及打开连接，如果尚未打开，就打开侦听端口
                if (host.State != CommunicationState.Opening)
                    host.Open();

                var rc = new RoutingConfiguration();
                var endPointA = new ServiceEndpoint(
                                ContractDescription.GetContract(typeof(IRequestReplyRouter)),
                                new WSHttpBinding(SecurityMode.None),
                                new EndpointAddress("http://localhost:9001/WCFServiceA"));
                var endPointB = new ServiceEndpoint(
                                ContractDescription.GetContract(typeof(IRequestReplyRouter)),
                                new NetTcpBinding(SecurityMode.None), 
                                new EndpointAddress("net.tcp://localhost:9002/WCFServiceB"));
                rc.FilterTable.Add(new ActionMessageFilter("SayHello"), new List<ServiceEndpoint> { endPointA });
                rc.FilterTable.Add(new ActionMessageFilter("SayBye"), new List<ServiceEndpoint> { endPointB });
                host.Extensions.Find<RoutingExtension>().ApplyConfiguration(rc);

                //显示运行状态
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Routing Service is runing! and state is {0}", host.State);
                //print endpoint information
                foreach (var se in host.Description.Endpoints)
                {
                    Console.WriteLine("Host is listening at {0}", se.Address.Uri);
                }

                //等待输入即停止服务
                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }
            #endregion

            #region 配置式
            using (var host = new ServiceHost(typeof(System.ServiceModel.Routing.RoutingService)))
            {
                ////判断是否以及打开连接，如果尚未打开，就打开侦听端口
                if (host.State != CommunicationState.Opening)
                    host.Open();

                //显示运行状态
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Routing Service is runing! and state is {0}", host.State);
                //print endpoint information
                foreach (var se in host.Description.Endpoints)
                {
                    Console.WriteLine("Host is listening at {0}", se.Address.Uri);
                }

                //等待输入即停止服务
                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }
            #endregion
        }
    }
}
