using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace Core.Lib.Reactive.Tests
{
    public class NotifyTests
    {
        [Fact]
        async public Task Test1()
        {
            var logwriter = new StringWriter();
            var writer = new StringWriter();
            var actual = string.Empty;

            var notify = Chain.FromAction<string>(new Logger(logwriter).Log);

            var input = Chain.FromAction<string>(writer.Write)
                .ToNotify(notify);
            
            await input.Next(new StringConverter().ConvertToString)
                .Next(new CountSequence().Count)
                .Run(x => actual = x.ToString());

            input.Execute(this.ToString());

            Assert.Equal(this.ToString().Length.ToString(), actual);
            Assert.Equal(this.ToString(), writer.ToString());
            Assert.Equal(this.ToString(), logwriter.ToString());
        }
    }

    public class StringConverter
    {
        public String ConvertToString(object obj)
            => obj.ToString();
    }

    public class Logger
    {
        private readonly TextWriter _writer;

        public Logger(TextWriter writer)
        {
            _writer = writer;
        }
        public void Log(object obj)
        {
            _writer.Write(obj);
        }
    }

    public class CountSequence
    {
        public int Count<T>(IEnumerable<T> seq)
            => seq.Count();
    }

    public class Output
    {
        private readonly TextWriter _writer;

        public Output(TextWriter writer)
        {
            _writer = writer;
        }
        public void Out<T>(T obj)
            => _writer.Write(obj);
    }
}
