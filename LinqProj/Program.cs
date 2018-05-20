using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqProj
{
    internal static class Program
    {
        
        public static void Main(string[] args)
        {
           
            while (true)
            {
                Console.Write("\nSelect task('q' to exit):\n1 - LinqBegin16\n2 - LinqBegin17\n3 - " +
                              "LinqBegin18\n4 - LinqBegin19\n5 - LinqBegin20\n6 - LinqBegin44\n7 - LinqBegin45\n> ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": LinqBegin16();
                        break;
                    case "2": LinqBegin17();
                        break;
                    case "3": LinqBegin18();
                        break;
                    case "4": LinqBegin19();
                        break;
                    case "5": LinqBegin20();
                        break;
                    case "6": LinqBegin44();
                        break;
                    case "7": LinqBegin45();
                        break;
                    case "q": Console.Write("Exiting...");
                        return;
                    default: Console.WriteLine("BAD INPUT! PLEASE RETRY!");
                        continue;
                }
                Console.WriteLine("Result is successfuly written to the file.");
            }
                
        }

        private static IEnumerable<int> ConvertToInts(string data)
        {
            return data.Split(',').Select(int.Parse).ToArray();
        }
        

        private static void LinqBegin16()
        {
            var arr = ConvertToInts(FileManager.Parse("../16.txt"));
            var res = arr.Where(i => i > 0);
            FileManager.SaveToFile("../16res.txt", res);
        }
        
        private static void LinqBegin17()
        {
            var arr = ConvertToInts(FileManager.Parse("../17.txt"));
            var res = arr.Where(i => i % 2 != 0).Distinct();
            FileManager.SaveToFile("../17res.txt", res);
        }
        
        private static void LinqBegin18()
        {
            var arr = ConvertToInts(FileManager.Parse("../18.txt")); 
            var res = arr.Where(i => (i > 0 && (i.ToString().Length == 2 && i.ToString()[0] != '0'))).OrderBy(i => i);
            FileManager.SaveToFile("../18res.txt", res);
        }
        
        private static void LinqBegin19()
        {
            var arr = FileManager.Parse("../19.txt").Split(','); 
            var res = arr.OrderBy(i => i.Length).ThenBy(i => i);
            FileManager.SaveToFile("../19res.txt", res);
        }

        private static void LinqBegin20()
        {
            var arr = ConvertToInts(FileManager.Parse("../20.txt"));
            var d = 3;
            var res = arr.SkipWhile(i => i <= d).Where(i => (i > 0 && i % 2 != 0)).Reverse();
            FileManager.SaveToFile("../20res.txt", res);
        }

        private static void LinqBegin44()
        {
            var A = ConvertToInts(FileManager.Parse("../44_1.txt"));
            var B = ConvertToInts(FileManager.Parse("../44_2.txt"));
            var K1 = 3;
            var K2 = 5;
            var res = A.Where(i => i > K1).Concat(B.Where(i => i < K2)).OrderBy(i => i);
            FileManager.SaveToFile("../44res.txt", res);
        }

        private static void LinqBegin45()
        {
            var A = FileManager.Parse("../45_1.txt").Split(',');
            var B = FileManager.Parse("../45_2.txt").Split(',');
            var L1 = 5;
            var L2 = 4;
            var res = A.Where(i => i.Length == L1).Concat(B.Where(i => i.Length == L2)).OrderByDescending(i => i);
            FileManager.SaveToFile("../45res.txt", res);
        }
    }
}

