using Fitnes.BL.Controller;
using Fitnes.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitnes.CMD.Languages.Messenges",typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Write_Name",culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("Дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - Ввести прием пищи");
            Console.WriteLine("Q - Добавить активность");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);

                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t{item.Key} - {item.Value}");
                    }
                    break;
                case ConsoleKey.Q:
                    var exe= EnterExercise();
                    exerciseController.Add(exe.Act, exe.Begin, exe.End);
                    foreach (var item in exerciseController.Exercises)
                    {
                        Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} по {item.Finish.ToShortTimeString()}");
                    }
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            
            Console.ReadLine();
        }
        private static (DateTime Begin, DateTime End, Activity Act)EnterExercise()
        {
            Console.WriteLine("Введите название упражнения");
            var name = Console.ReadLine();
            var energy = ParseDouble("рассход энергии");
            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");
            var act = new Activity(name, energy);
            return (begin,end,act);
        }
        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, carbs);


            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
    }
}
