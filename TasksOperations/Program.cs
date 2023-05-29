using System.Diagnostics;

namespace TasksOperations
{
    class Program
    {
        static void Main()
        {
            WriteThreadData();
            Stopwatch stopwatch = Stopwatch.StartNew();

            //Console.WriteLine("Running methods synchronously, in one thread.");
            //MethodA();
            //MethodB();
            //MethodC();

            //Console.WriteLine("Running methods asynchronously, in multiple threads.");

            // Three approaches to create and run tasks instances
            //Task taskA = new Task(MethodA);
            //taskA.Start();
            //Task taskB = Task.Factory.StartNew(MethodB);
            //Task taskC = Task.Run(MethodC);
            //Task[] tasks = {taskA, taskB, taskC};
            //Task.WaitAll(tasks);

            Console.WriteLine("Forwarding result of one method to another");

            var invokeWWWServiceThenExecuteEmbeddedProcedureTask = Task.Factory.StartNew(InvokeWWWService)
                .ContinueWith(previousTask =>
                    ExecuteEmmbeddedProcedure(previousTask.Result));

            //invokeWWWServiceThenExecuteEmbeddedProcedureTask.Wait();

            Console.WriteLine($"Result: {invokeWWWServiceThenExecuteEmbeddedProcedureTask.Result}");

            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds:#,##0}ms.");
        }

        static void MethodA()
        {
            Console.WriteLine($"Running Method A...");
            WriteThreadData();
            Thread.Sleep(3000);
            Console.WriteLine("Method A executed.");
        }

        static void MethodB()
        {
            Console.WriteLine($"Running Method B...");
            WriteThreadData();
            Thread.Sleep(2000);
            Console.WriteLine("Method B executed.");
        }

        static void MethodC()
        {
            Console.WriteLine($"Running Method C...");
            WriteThreadData();
            Thread.Sleep(1000);
            Console.WriteLine("Method C executed.");
        }

        static void WriteThreadData()
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine($"Thread ID: {t.ManagedThreadId}, Priority: {t.Priority}, Is background: {t.IsBackground}, Name: {t.Name}");
        }

        static decimal InvokeWWWService()
        {
            Console.WriteLine("Running WWW service Invocation...");
            WriteThreadData();
            Thread.Sleep(new Random().Next(2000, 4000));
            Console.WriteLine("Finished WWW service Invocation");
            return 89.99M;
        }

        static string ExecuteEmmbeddedProcedure(decimal price)
        {
            Console.WriteLine("Running embedded procedure...");
            Thread.Sleep(new Random().Next(2000, 4000));
            Console.WriteLine("Finished embedded procedure execution");
            return $"12 products cost more thann {price:C}";
        }
    }
}