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
    public class ReactiveTests
    {
        [Fact]
        async public Task Test1()
        {
            var writer = new StringWriter();
            await ReactiveExtensions.ToServiceClient(() => this)
                .Next(new StringConverter().ConvertToString)
                .Next(new CountSequence().Count)
                .Run(new Output(writer).Out);
            Assert.Equal(this.ToString().Length.ToString(), writer.ToString());
        }

        [Fact]
        async public Task Test2()
        {
            var actual = string.Empty;
            var writer = new StringWriter();
            var input = new DirectServiceChannel<string>(new Service<string>(writer.Write));
            await input.Next(new StringConverter().ConvertToString)
                .Next(new CountSequence().Count)
                .Run(x => actual = x.ToString());

            input.Execute(this.ToString());

            Assert.Equal(this.ToString().Length.ToString(), actual);
            Assert.Equal(this.ToString(), writer.ToString());
        }
    }
    
    public class StringConverter
    {
        public String ConvertToString(object obj)
            => obj.ToString();
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
