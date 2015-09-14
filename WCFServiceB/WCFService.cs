using System;
using System.ServiceModel;

//ServiceContract 属性以及 Indigo 使用的所有其他属性均在 System.ServiceModel 命名空间中定义，
//因此本例开头使用 using 语句来引用该命名空间。
namespace WCFServiceB
{
    //1.服务契约
    [ServiceContract(Namespace = "http://www.cnblogs.com/frank_xl/")]
    public interface IWCFServiceB
    {
        //操作契约
        [OperationContract(Action = "SayBye", ReplyAction = "SayByeReply")]
        string SayBye(string name);

    }
    //2.服务类，继承接口。实现服务契约定义的操作
    public class WCFServiceB : IWCFServiceB
    {
        //实现接口定义的方法
        public string SayBye(string name)
        {
            Console.WriteLine("{0}：Bye! {1},Calling at {2} ...", this, name, DateTime.Now.ToLongTimeString());
            return "Bye ! " + name;
        }
    }
}
