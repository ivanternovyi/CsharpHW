using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Person[] ParsePeople(string filename)
        {
            var size = System.IO.File.ReadAllLines(filename).Length;
            if (size == 0)
                throw new Exception("Empty file");
            var lines = System.IO.File.ReadAllLines(filename);
            var arrPeople = new Person[size];
            for(var i = 0; i < size; i++)
            {
                var rowData = lines[i].Split(',');
                try
                {    
                    arrPeople[i] = new Person
                    {
                        Id = int.Parse(rowData[0]),
                        Year = int.Parse(rowData[1]),
                        Month = int.Parse(rowData[2]),
                        Duration = int.Parse(rowData[3])
                    };
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Bad argument: {e}");
                    throw;
                }
            }

            return arrPeople;
        }

        public static void SaveToFile(string filename, IEnumerable<string> data)
        {
            System.IO.File.WriteAllText($"../{filename}", string.Join(",", data));
        }
        
        public static void SaveToFile(string filename, IEnumerable<int> data)
        {
            System.IO.File.WriteAllText($"../{filename}", string.Join(",", data));
        }

        public static void SaveToFileObj(string filename, string data)
        {
            System.IO.File.AppendAllText($"../{filename}", data);
        }

        public static void SaveToFileObj(string filename, Dictionary<int, int> data, string title)
        {
            System.IO.File.AppendAllText(filename, title);
            foreach (var elem in data)
            {
                System.IO.File.AppendAllText(filename, elem.Key + " -> " + elem.Value + "\n"); 
            }
        }
    }
}