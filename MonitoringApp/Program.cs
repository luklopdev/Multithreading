using MonitoringLibrary;
using System.Text;

namespace MonitoringApp
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Processing...");
            //Recording.Start();

            //int[] bigArray = Enumerable.Range(1, 10_000).ToArray();
            //Thread.Sleep(new Random().Next(5, 10) * 1000);

            //Recording.Stop();

            int[] numbers = Enumerable.Range(1, 50_000).ToArray();

            Console.WriteLine($"Using string class end + operator");
            Recording.Start();
            string s = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }
            Recording.Stop();

            Console.WriteLine("Using StringBuilder class");
            Recording.Start();
            var sb = new StringBuilder();
            for(int i = 0; i < numbers.Length; i++) 
            {
                sb.Append(numbers[i]);
                sb.Append(", ");
            }
            Recording.Stop();

        }
    }
}