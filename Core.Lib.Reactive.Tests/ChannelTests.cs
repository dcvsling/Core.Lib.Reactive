using System.IO;
using System.Linq;
using System.Collections;
using System;
using Xunit;
using System.Collections.Generic;
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
            var channel = new DirectServiceChannel<string>();
            channel.Run(x => actual = x);
            channel.Execute(expect);

            Assert.Equal(expect, actual);
        }
    }
}
