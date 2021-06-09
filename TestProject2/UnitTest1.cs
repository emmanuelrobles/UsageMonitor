using System;
using System.Threading.Tasks;
using SocketClient;
using Xunit;

namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var s = new Class1();
            await s.ConnectAsync();
            Console.WriteLine("connected");
        }
    }
}