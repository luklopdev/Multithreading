using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurements
{
    public class MeasurementString
    {
        int[] numbers;

        public MeasurementString()
        {
            numbers = Enumerable.Range(1, 20).ToArray();
        }

        [Benchmark(Baseline = true)]
        public string StringConcatTest()
        {
            string s = string.Empty;
            foreach(var number in numbers)
            {
                s += $"{number}, ";
            }

            return s;
        }

        [Benchmark]
        public string StringBuilderTest()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var number in numbers)
            {
                sb.Append(number);
                sb.Append(", ");
            }
            return sb.ToString();
        }
    }
}
