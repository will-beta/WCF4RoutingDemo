using System;
using System.ServiceModel;

namespace WCFHost
{
    //采用自托管方式，也可以是IIS、WAS,Windows服务等用户自定义程序托管服务
   public class WCFHost
    {
        static void Main(string[] args)
        {
            Console.Title = "WCF HostA";
            //反射方式创建服务实例，
            //Using方式生命实例，可以在对象生命周期结束时候，释放非托管资源
            using (var host = new ServiceHost(typeof(WCFServiceA.WCFServiceA)))
            {
                
                ////判断是否以及打开连接，如果尚未打开，就打开侦听端口
                if (host.State !=CommunicationState.Opening)
                host.Open();
                //显示运行状态
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HostA is runing! and state is {0}",host.State);

                  //print endpoint information
                foreach (var se in host.Description.Endpoints)
                {
                    Console.WriteLine("Host is listening at {0}", se.Address.Uri.ToString());

                }
                //等待输入即停止服务
                Console.WriteLine("Press any key to exit.");
                Console.Read();
            
            
            }
        }
    }
}
