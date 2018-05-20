using System;
using System.Collections.Generic;

namespace LinqProj
{
    internal static class FileManager
    {
        public static string Parse(string filename)
        {
            string data;
            try
            {
                data = System.IO.File.ReadAllText($"../{filename}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return data;
        }

        public static void SaveToFile(string filename, IEnumerable<string> data)
        {
            System.IO.File.WriteAllText($"../{filename}", string.Join(",", data));
        }
        
        public static void SaveToFile(string filename, IEnumerable<int> data)
        {
            System.IO.File.WriteAllText($"../{filename}", string.Join(",", data));
        }
    }
}