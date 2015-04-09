using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public class GetIp
        {

            public static string Get_Ip()
            {

                IPAddress ip = null;

                try
                {

                    //此方法可以获取WIN7、WIN8 IP使用InterNetwork进行数据过滤

                    string HostName = Dns.GetHostName();

                    IPHostEntry IpEntry = Dns.GetHostEntry(HostName);



                    for (int i = 0; i < IpEntry.AddressList.Length; i++)
                    {

                        if (IpEntry.AddressList.AddressFamily.ToString() == "InterNetwork")
                        {

                            ip = IpEntry.AddressList;

                            break;

                        }

                    }

                }

                catch (System.Exception ex)
                {

                    Common.WriteLogContent("SysteLog", ex.Message);

                    return ex.Message;

                }

                finally
                {

                }

                return ip.ToString();



            }

        }
    }
}
