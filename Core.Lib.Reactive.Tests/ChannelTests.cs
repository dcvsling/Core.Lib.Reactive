using System;
using System.IO;
using Xunit;
using Core.Lib.Reactive;
using System.Threading.Tasks;

namespace Core.Lib.Api.Tests
{
    public class ChannelTests
    {
        [Fact]
        public void Test1()
        {
            var actual = string.Empty;
            var expect = "Ok";
            var channel = new DirectServiceChannel<string>(x => actual = x);
            channel.Execute(expect);

            Assert.Equal(expect, actual);
        }

        [Fact]
        async public Task Test2()
        {
            var expect = "test";
            int actual = 0;

            var writer = new StringWriter();
            var service = ((Action<string>)writer.Write).ToService();
            var input = service.ToServiceChannel();
            var channel = input.Next(x => x.Length);
            await channel.Run(i => actual = i);

            input.Execute(expect);

            Assert.Equal(expect.Length, actual);

            input.Execute(expect + expect);
            Assert.Equal(expect.Length * 2 , actual);
        }
    }
}
