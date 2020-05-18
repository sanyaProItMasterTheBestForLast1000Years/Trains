

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace trainn
{
    class Train
    {
        #region properties
        public string place { get; set; }
        public string number { get; set; }
        public string time { get; set; }
   
        #endregion

        public Train()
        {

        }
        public Train(string smth)
        {
            string[] qqq = smth.Split(' ');
            place = Validation.ValidatePlace(qqq[0]);
            number = Validation.ValidateNumber(qqq[1]);
            time = Validation.ValidateTime(qqq[2]);
            
        }
        public Train(string place, string number, string timw)
        {
            this.place = Validation.ValidatePlace(place);
            this.number =  Validation.ValidateNumber(number);
            time = Validation.ValidateTime(timw);
        }
        internal static Tuple<string, string, string> Input()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("place: ");
            string place = Console.ReadLine();
            Console.Write("number: ");
            string number = Console.ReadLine();
            Console.Write("time: ");
            string time = Console.ReadLine();

            return Tuple.Create(place, number, time);
        } // Input
        public static Train Parse(string repr)
        {
            repr = Validation.ValidationToParse(repr.Replace('\t', ' '));
            string[] repr_div = repr.Split();
            Train trn = new Train
            {
                place = Validation.ValidatePlace(repr_div[0]),
                number = Validation.ValidateNumber(repr_div[1]),
                time = Validation.ValidateTime(repr_div[2]),
            };
            return trn;
        }
       
        public override string ToString()
        {
            return $"{place} {number} {time}";
        }
    }

}





