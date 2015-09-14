using System;
using System.ServiceModel;

//ServiceContract 属性以及 Indigo 使用的所有其他属性均在 System.ServiceModel 命名空间中定义，
//因此本例开头使用 using 语句来引用该命名空间。
namespace WCFServiceA
{
    //1.服务契约
    [ServiceContract(Namespace = "http://www.cnblogs.com/frank_xl/")]
    public interface IWCFServiceA
    {
        //操作契约
        [OperationContract(Action = "SayHello", ReplyAction = "SayHelloAReply")]
        string SayHello(string name);

    }
    //2.服务类，继承接口。实现服务契约定义的操作
    public class WCFServiceA : IWCFServiceA
    {
        //实现接口定义的方法
        public string SayHello(string name)
        {

            Console.WriteLine("{0}：Hello! {1},Calling at {2} ...", this, name, DateTime.Now.ToLongTimeString());
            return "Hello ! " + name;
        }
    }
}
