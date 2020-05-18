using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace trainn
{
    class Validation
    {

        public static string ValidatePlace(string place)
        {
            if (!Regex.IsMatch(place, @"^[a-z]*$", RegexOptions.IgnoreCase)) throw new Exception("Wrong place");
            return place;
        }
        public static string ValidateNumber(string number)
        {
            if(!Regex.IsMatch(number,@"^[0-9]*$", RegexOptions.IgnoreCase)) throw new Exception("Wrong number");
            //if (int.TryParse(number, out int a)) throw new Exception("Wrong number");
            return number;
        }

        public static string ValidateTime(string time)
        { 
            return time;
        }

        public static string FileExistance()
        {
            Console.Write("Input the name of your file: ");
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.Write($"Wrong the path to your file ({path})\nRewrite it correctly: ");
                path = Console.ReadLine();
            }

            return path;
        }

        public static int Converter()
        {
            if (!Int32.TryParse(Console.ReadLine(), out int indexerChoise))
            {
                throw new Exception("Can't convert from string to int...");
            }
            return indexerChoise;
        }
        public static Regex stringToParse { get; private set; } = new Regex(".+[ ].+[ ].");
        public static string ValidationToParse(string strToParse)
        {
            while (!stringToParse.IsMatch(strToParse))
            {
                throw new Exception("Wrong input...");
            }
            return strToParse;
        }
    }
}
