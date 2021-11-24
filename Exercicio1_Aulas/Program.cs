using System;
using System.IO;
using System.Text.Json;

namespace Exercicio1Aulas
{
    public class Exercicio1
    {
        public static void Main(string[] args)
        {
            //int age;
            //double height, weight;

            //Console.WriteLine("Primeiro Nome:");
            //var fn = Console.ReadLine();
            //Console.WriteLine("Ultimo Nome:");
            //var ln = Console.ReadLine();
            //do
            //{
            //    Console.WriteLine("Idade:");
            //    var ageStr = Console.ReadLine();
            //    if (int.TryParse(ageStr, out age))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Não é um número/inteiro.");
            //    }      
            //} while (true);

            //do
            //{
            //    Console.WriteLine("Altura:");
            //    var heightStr = Console.ReadLine();
            //    heightStr = heightStr.Replace(".", ",");
            //    if (double.TryParse(heightStr, out height))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Não é um número.");
            //    }
            //} while (true);

            //do
            //{
            //    Console.WriteLine("Peso:");
            //    var weightStr = Console.ReadLine();
            //    weightStr = weightStr.Replace(".", ",");
            //    if (double.TryParse(weightStr, out weight))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Não é um número.");
            //    }
            //} while (true);

            //Utilizador user = new(fn, ln, age, height, weight);
            //Console.WriteLine(user.ToString());

            var user = Utilizador.ReadJSON();
            foreach (var u in user)
            {
                Console.WriteLine(u.ToString());
            }
        }
    }
}