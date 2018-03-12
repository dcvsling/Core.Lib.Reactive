using System.IO;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Lib.Reactive.Tests
{
    public class ContextTests
    {
        [Fact]
        async public Task ContextTest()
        {
            await Chain.FromGetter(() => new WriteContext())
                .Do(WriterHelper.WriteA)
                .Do(WriterHelper.WriteB)
                .Do(WriterHelper.WriteC)
                .Run(ctx => Assert.Equal("ABC", ctx.Writer.ToString()));
        }
    }

    public class WriteContext
    {
        public TextWriter Writer { get; set; } = new StringWriter();
    }

    public static class WriterHelper
    {
        public static void WriteA(WriteContext ctx) => ctx.Writer.Write("A");
        public static void WriteB(WriteContext ctx) => ctx.Writer.Write("B");
        public static void WriteC(WriteContext ctx) => ctx.Writer.Write("C");
    }
}
