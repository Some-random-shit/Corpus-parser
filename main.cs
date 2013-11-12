using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class main
    {
        public static Dictionary<string, int> stats = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string txtFolderPath = "C:/corpus";
            string[] files = Directory.GetFiles(txtFolderPath, "*", SearchOption.AllDirectories);
            int totalFiles = files.Length;

            int i = 0; double percent;
            foreach (string file in files)
            {
                i++;
                percent = i / ((double) totalFiles / 100);

                parser p = new parser(file);
                p.getStats();
                Console.Clear();
                Console.WriteLine("Progress: " + i + "/" + totalFiles + ", " + Math.Round(percent) + "%");
            }

            Console.WriteLine("\nDone");
            Console.WriteLine("Check C:\\corpus_results\\results.txt for results");
            Console.ReadKey();

            List<KeyValuePair<string, int>> sorted = stats.ToList();

            sorted.Sort((firstPair, nextPair) =>
            {
                return nextPair.Value.CompareTo(firstPair.Value);
            });

            StreamWriter resultsFile = new StreamWriter("C:/corpus_stats/results.txt");
            foreach (KeyValuePair<string, int> pair in sorted)
                resultsFile.WriteLine("{0},{1}", pair.Key, pair.Value);

            resultsFile.Close();
        }
    }
}
