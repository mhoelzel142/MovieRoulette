using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MovieRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            var directory = Environment.CurrentDirectory;
            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);

            var count = files.Length;

            var targetFolder = rand.Next(0, count);

            var attr = File.GetAttributes(files[targetFolder]);

            if (attr.HasFlag(FileAttributes.Archive) || attr.HasFlag(FileAttributes.Directory))
            {
                
                Console.WriteLine(files[targetFolder]);

                ProcessStartInfo i = new ProcessStartInfo(files[targetFolder]);
                i.UseShellExecute = true;
                Process.Start(i);

            }
        }
    }
}
