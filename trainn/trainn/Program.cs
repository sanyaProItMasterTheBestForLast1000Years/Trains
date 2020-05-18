
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
namespace trainn
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TrainCollection<Train>.ReadFromFile();
                Console.Clear();
                ConditionsMenu();
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Console.ReadLine();
        }


        #region Menu and conditions
        static void ConditionsMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('-', 30) + "\tM\te\tn\tu\t" + new string('-', 30));
            Console.Write("Possible options:\nOutput datas(1)\nSort datas(2)\nFind by criteria(3)\nWork with file( add(4),remove(5),edit(6) )\nExit(0)\n\nYour choise: ");
            Console.ResetColor();
        }

        static void Menu()
        {
            bool result = true;
            while (result)
            {
                int choise = Validation.Converter();
                switch (choise)
                {
                    case 1:
                        {
                            Console.Clear();
                            foreach (var item in TrainCollection<Train>.collection)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(item);
                                Console.ResetColor();
                            }
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("The possible properties for sorting: ");
                            PropertyInfo[] propertyInfos = typeof(Train).GetProperties();
                            foreach (PropertyInfo propertyInfo in propertyInfos)
                            {
                                Console.Write(propertyInfo.Name + " ");
                            }
                            Console.Write("Your choise: ");
                            string property = Console.ReadLine();
                            TrainCollection<Train>.Sort(property);//
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            TrainCollection<Train>.Find();//
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            var tuple = Train.Input();
                            TrainCollection<Train>.Add(new Train(tuple.Item2, tuple.Item1, tuple.Item3));//
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }

                    case 5:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Input the substring you want to remove: ");
                            string substring = Console.ReadLine();
                            TrainCollection<Train>.Remove(substring);//
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }

                    case 6:
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Input the substring you want to edit: ");
                            string substring = Console.ReadLine();
                            var tuple = Train.Input();
                            TrainCollection<Train>.Edit(substring, new Train(tuple.Item2, tuple.Item1, tuple.Item3));
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("I'm sorry...");
                            Console.ResetColor();
                            result = false;
                            break;
                        }
                }
            }
        }
        #endregion
    }
}