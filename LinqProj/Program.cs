using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqProj
{
    
    internal class Program
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
            }
        }

        private static void LinqBegin16()
        {
            int[] arr = { 1, 5, -3, -6, 7, -12, 5, 10 };
            IEnumerable<int> res = arr.Where(i => i > 0);
            foreach (var elem in res)
            {
                Console.Write($"{elem} ");
            }
        }
        
        private static void LinqBegin17()
        {
            int[] arr = { 1, 2, 5, 2, 5, 9 ,2, 1 };
            IEnumerable<int> res = arr.Where(i => i % 2 != 0).Distinct();
            foreach (var elem in res)
            {
                Console.Write($"{elem} ");
            }
        }
        
        private static void LinqBegin18()
        {
            int[] arr = { 1, 51, 12, -3, -6, 7, -12, 52, 71, 10 };
            var res = arr.Where(i => (i > 0 && (i.ToString().Length == 2 && i.ToString()[0] != '0'))).OrderBy(i => i);
            foreach (var elem in res)
            {
                Console.Write($"{elem} ");
            }
        }
        
        private static void LinqBegin19()
        {
            string[] arr = { "lpkas", "erhc", "rexmac", "orncs", "abcw", "poqwnmv", "yiv", "z" };
            var res = arr.OrderBy(i => i.Length).ThenBy(i => i);
            foreach (var elem in res)
            {
                Console.Write($"{elem} ");
            }
        }

        private static void LinqBegin20()
        {
            int[] arr = { 1, 5, 13, -3, -6, 7, -12, 5, 10 };
            var d = 3;
            var res = arr.SkipWhile(i => i <= d).Where(i => (i > 0 && i % 2 != 0)).Reverse();
            foreach (var elem in res)
            {
                Console.Write($"{elem} ");
            }
        }

        private static void LinqBegin44()
        {
            int[] A = { 1, 5, 13, -3, -6, 7, -12, 5, 10 };
            int[] B = { 5, -1, 3, -23, 68, 17, 2, -5, 9 };
            int K1 = 3;
            int K2 = 5;
            var res = A.Where(i => i > K1).Concat(B.Where(i => i < K2)).OrderBy(i => i);
            foreach (var elem in res)
            {
                Console.Write($"{elem} ");
            }
        }

        private static void LinqBegin45()
        {
            string[] A = { "lpkas", "erh5c", "2rexmac", "orncs", "12ab5cw", "po523qwnmv", "yiv", "z" };
            string[] B = { "wefg", "4tfb", "45y6mac", "ys245orncs", "a35w", "i35or4mv", "yv92", "10asz2g5" };
            var L1 = 5;
            var L2 = 4;
            var res = A.Where(i => i.Length == L1).Concat(B.Where(i => i.Length == L2)).OrderByDescending(i => i);
            foreach (var elem in res)
            {
                Console.Write($"{elem} ");
            }
        }
    }
}

