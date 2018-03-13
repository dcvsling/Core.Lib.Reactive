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
            var actual = string.Empty;
            var input = Chain.From<WriteContext>();
            await input.Do(WriterHelper.WriteA)
                .Do(WriterHelper.WriteB)
                .Do(WriterHelper.WriteC)
                .Run(ctx => actual = ctx.Writer.ToString());
            input.Execute(new WriteContext());

            Assert.Equal("ABC", actual);
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
