using System.IO;
using System.Collections.Generic;
using System;

namespace RegexParser_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Entity>();
            var parser = new Parser();
            using var sr = new StreamReader("Data.txt");
            string line;
            var c = 0;
            while (!string.IsNullOrEmpty(line = sr.ReadLine()))
            {
                var entity = parser.Analize(line);
                c++;
                if (entity != null)
                    Console.WriteLine(entity.ToString());
                else
                    Console.WriteLine("Line number {0} \"{1}\" wasn't recognized!\n", c, line);
            }
        }
    }
}
