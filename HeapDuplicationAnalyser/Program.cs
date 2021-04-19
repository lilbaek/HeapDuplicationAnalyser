using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Diagnostics.Runtime;

namespace HeapDuplicationAnalyser
{
    class Program
    {
        private static readonly Dictionary<string, int> DuplicatedInstances = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var filePath = args[0];
            if (File.Exists(filePath) == false)
            {
                Console.WriteLine($"{filePath} - does not exist.");
                return;
            }

            Console.WriteLine("Loading dump");
            using var dataTarget = DataTarget.LoadDump(filePath);
            Console.WriteLine("Dump loaded - analyzing");
            foreach (var clr in dataTarget.ClrVersions)
            {
                using var runtime = clr.CreateRuntime();
                var heap = runtime.Heap;
                foreach (var obj in heap.EnumerateObjects())
                {
                    AnalyseDuplications(obj, heap);
                }
            }

            var orderByDescending = DuplicatedInstances.OrderByDescending(x => x.Value).Take(100).ToList();
            foreach (var pair in orderByDescending)
            {
                Console.WriteLine("Times duplicated " + pair.Value + " - value: " + pair.Key);
            }
        }

        private static void AnalyseDuplications(ClrObject obj, ClrHeap heap)
        {
            if (obj.IsNull)
                return;
            if (obj.Type != heap.StringType)
                return;
            var asString = obj.AsString();
            if (string.IsNullOrEmpty(asString))
                return;
            if (!DuplicatedInstances.ContainsKey(asString))
            {
                DuplicatedInstances.Add(asString, 1);
            }
            else
            {
                var duplicatedInstance = DuplicatedInstances[asString];
                DuplicatedInstances[asString] = duplicatedInstance + 1;
            }
        }
    }
}