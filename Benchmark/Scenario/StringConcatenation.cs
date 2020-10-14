using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Scenario
{
    [Config(typeof(Config))]
    public class StringConcatenation
    {
        private const int NumberOfLoop = 1000;
        private const string Prefix = "<";
        private const string Suffix = ">";

        [Benchmark]
        public string 文字列連結演算子()
        {
            var result = string.Empty;
            for (var i = 0; i < NumberOfLoop; i++)
            {
                result = result + Prefix + i + Suffix;
            }

            return result;
        }

        [Benchmark]
        public string String_Concat()
        {
            var result = string.Empty;
            for (var i = 0; i < NumberOfLoop; i++)
            {
                result = string.Concat(result, Prefix, i, Suffix);
            }

            return result;
        }

        [Benchmark]
        public string String_Format()
        {
            const string format = "{0}{1}{2}{3}";
            var result = string.Empty;
            for (var i = 0; i < NumberOfLoop; i++)
            {
                result = string.Format(format, result, Prefix, i, Suffix);
            }

            return result;
        }

        [Benchmark]
        public string string_interpolation()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < NumberOfLoop; i++)
            {
                stringBuilder.Append($"{Prefix}{i}{Suffix}");
            }

            return stringBuilder.ToString();
        }

        [Benchmark]
        public string StringBuilder_AppendFormat()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < NumberOfLoop; i++)
            {
                stringBuilder.AppendFormat("{0}{1}{2}", Prefix, i, Suffix);
            }

            return stringBuilder.ToString();
        }

        [Benchmark]
        public string StringBuilder_Append()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < NumberOfLoop; i++)
            {
                stringBuilder.Append(Prefix).Append(i).Append(Suffix);
            }

            return stringBuilder.ToString();
        }
    }
}