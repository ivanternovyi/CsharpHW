using System;
using System.Collections;
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
                              "LinqBegin18\n4 - LinqBegin19\n5 - LinqBegin20\n6 - LinqBegin44\n" +
                              "7 - LinqBegin45\n8 - LinqObject\n> ");
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
                    case "8": LinqObject();
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
            var arr = ConvertToInts(FileManager.Parse("../bin/data/16.txt"));
            var res = arr.Where(i => i > 0);
            FileManager.SaveToFile("../bin/result/16res.txt", res);
        }
        
        private static void LinqBegin17()
        {
            var arr = ConvertToInts(FileManager.Parse("../bin/data/17.txt"));
            var res = arr.Where(i => i % 2 != 0).Distinct();
            FileManager.SaveToFile("../bin/result/17res.txt", res);
        }
        
        private static void LinqBegin18()
        {
            var arr = ConvertToInts(FileManager.Parse("../bin/data/18.txt")); 
            var res = arr.Where(i => (i > 0 && (i.ToString().Length == 2 && i.ToString()[0] != '0'))).OrderBy(i => i);
            FileManager.SaveToFile("../bin/result/18res.txt", res);
        }
        
        private static void LinqBegin19()
        {
            var arr = FileManager.Parse("../bin/data/19.txt").Split(','); 
            var res = arr.OrderBy(i => i.Length).ThenBy(i => i);
            FileManager.SaveToFile("../bin/result/19res.txt", res);
        }

        private static void LinqBegin20()
        {
            var arr = ConvertToInts(FileManager.Parse("../bin/data/20.txt"));
            var d = 3;
            var res = arr.SkipWhile(i => i <= d).Where(i => (i > 0 && i % 2 != 0)).Reverse();
            FileManager.SaveToFile("../bin/result/20res.txt", res);
        }

        private static void LinqBegin44()
        {
            var A = ConvertToInts(FileManager.Parse("../bin/data/44_1.txt"));
            var B = ConvertToInts(FileManager.Parse("../bin/data/44_2.txt"));
            var K1 = 3;
            var K2 = 5;
            var res = A.Where(i => i > K1).Concat(B.Where(i => i < K2)).OrderBy(i => i);
            FileManager.SaveToFile("../bin/result/44res.txt", res);
        }

        private static void LinqBegin45()
        {
            var A = FileManager.Parse("../bin/data/45_1.txt").Split(',');
            var B = FileManager.Parse("../bin/data/45_2.txt").Split(',');
            var L1 = 5;
            var L2 = 4;
            var res = A.Where(i => i.Length == L1).Concat(B.Where(i => i.Length == L2)).OrderByDescending(i => i);
            FileManager.SaveToFile("../bin/result/45res.txt", res);
        }
        
        private static Person PersonMinDuration(IEnumerable<Person> arrPeople)
        {
            return arrPeople.OrderByDescending(i => i.Duration).First();
        }
        
        private static Person PersonMaxDuration(IEnumerable<Person> arrPeople)
        {
            return arrPeople.OrderBy(i => i.Duration).First();
        }

        private static int YearWithMostDuration(IEnumerable<Person[]> arrPeopleByYear)
        {
            var arrPeopleMaxDuration = arrPeopleByYear.Select(people => new DictionaryEntry
            {
                Key = people.First().Year,
                Value = people.Sum(person => person.Duration)
            }).ToDictionary(d => d.Key, d => d.Value).OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            return (int) arrPeopleMaxDuration.First().Key;
        }
        
        private static Dictionary<int, int> DictPersonTotalDuration(IEnumerable<Person[]> arrPeopleByDuration)
        {
            var result = arrPeopleByDuration.Select(people => new DictionaryEntry()
            {
                Key = people.First().Id,
                Value = people.Sum(s => s.Duration)
            }).ToDictionary(d => d.Key, d => d.Value).OrderByDescending(i => i.Value);
            return result.ToDictionary(d => (int) d.Key, d => (int) d.Value);
        }
        
        private static Dictionary<int, int> DictPersonTotalMonth(IEnumerable<Person[]> arrPeopleMonth)
        {
            var result = arrPeopleMonth.Select(people => new DictionaryEntry()
            {
                Key = people.First().Id,
                Value = people.Sum(s => s.Month)
            }).ToDictionary(d => d.Key, d => d.Value).OrderBy(i => i.Key);
            return result.ToDictionary(d => (int) d.Key, d => (int) d.Value);
        }
        
        private static void LinqObject()
        {
            IEnumerable<Person> arrPeople = FileManager.ParsePeople("../data/obj.txt");
            var max = PersonMinDuration(arrPeople);
            FileManager.SaveToFileObj("../bin/result/obj_res.txt", $"Person with max duration: {max}\n");
            var min = PersonMaxDuration(arrPeople);
            FileManager.SaveToFileObj("../bin/result/obj_res.txt", $"Person with min duration: {min}\n");
            var arrPeopleByYear = arrPeople.GroupBy(i => i.Year).Select(i => i.ToArray());
            var yearMaxDuration = YearWithMostDuration(arrPeopleByYear);
            FileManager.SaveToFileObj("../bin/result/obj_res.txt", $"Year with most duration: {yearMaxDuration}\n");
            var arrPeopleByDuration = arrPeople.GroupBy(i => i.Id).Select(i => i.ToArray());
            var personTotalDuration = DictPersonTotalDuration(arrPeopleByDuration);
            FileManager.SaveToFileObj("../result/obj_res.txt", personTotalDuration, "\nDictionary person - total month:\n");
            var arrPeopleMonth = arrPeople.GroupBy(i => i.Id).Select(i => i.ToArray());
            var personTotalMonth = DictPersonTotalMonth(arrPeopleMonth);
            FileManager.SaveToFileObj("../result/obj_res.txt", personTotalMonth, "Dictionary person - total duration:\n");
        }
    }
}
