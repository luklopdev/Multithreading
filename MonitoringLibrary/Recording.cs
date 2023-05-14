

using System.Diagnostics;

namespace MonitoringLibrary
{
    public static class Recording
    {
        private static Stopwatch stopwatch = new();

        private static long phisycalBytesBefore = 0;
        private static long virtualBytesBefore = 0;

        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            phisycalBytesBefore = Process.GetCurrentProcess().PeakWorkingSet64;
            virtualBytesBefore = Process.GetCurrentProcess().VirtualMemorySize64;
            stopwatch.Restart();
        }

        public static void Stop()
        {
            stopwatch.Stop();
            long phisycalBytesAfter = Process.GetCurrentProcess().PeakWorkingSet64;
            long virtualBytesAfter = Process.GetCurrentProcess().VirtualMemorySize64;

            var usedPhisycalBytes = phisycalBytesAfter - phisycalBytesBefore;
            var usedVirtualBytes = virtualBytesAfter - virtualBytesBefore;

            Console.WriteLine($"Used {usedPhisycalBytes:N0} phisycal bytes.");
            Console.WriteLine($"Used {usedVirtualBytes:N0} virtual bytes.");
            Console.WriteLine($"Elapsed {stopwatch.Elapsed}");
            Console.WriteLine($"Elapsed {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
