using System;
using System.ServiceModel;
using WCFServiceA;
using WCFServiceB;

namespace WCFClient
{
    class WCFClient
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("WCF Test Client is runing! ");

            string result;

            #region 不使用配置文件的方式
            {
                var channelA = new ChannelFactory<IWCFServiceA>(new BasicHttpBinding(), "http://localhost:8001/WCFRoutingService").CreateChannel();
                result = channelA.SayHello("A");
                Console.WriteLine("Service A:{0} !", result);

                var channelB = new ChannelFactory<IWCFServiceB>(new BasicHttpBinding(), "http://localhost:8001/WCFRoutingService").CreateChannel();
                result = channelB.SayBye("B");
                Console.WriteLine("Service B:{0} !", result);
            }
            #endregion

            #region 使用配置文件的方式
            {
                var channelA = new ChannelFactory<IWCFServiceA>("WCFServiceA").CreateChannel();
                result = channelA.SayHello("A");
                Console.WriteLine("Service A:{0} !", result);

                var channelB = new ChannelFactory<IWCFServiceB>("WCFServiceB").CreateChannel();
                result = channelB.SayBye("B");
                Console.WriteLine("Service B:{0} !", result);
            }
            #endregion

            //For Debug
            Console.Read();
        }
    }
}
