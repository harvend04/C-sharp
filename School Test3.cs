using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_3
{
    internal class Program
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("| ------------------Harvend Tauries-------------------- -|");
            Console.WriteLine("| 1. Working with array of doubles                       |");
            Console.WriteLine("| 2.Working with Trignometric functions                  |");
            Console.WriteLine("| 3.Calculate Centripetal Force                          |");
            Console.WriteLine("| 4.Calculate Federal Tax                                |");
            Console.WriteLine();
            Console.WriteLine("| X.To exit the program                                  |");
            Console.WriteLine("|  ----------------------------------------------------  |");
            Console.Write("Press the letter corresponding to your choice->");
        }
        public static void DemoQuestion3()
        {
            Console.WriteLine("\n\n**********Begin Question 3 **********");

            double[] arr = GenerateDoubleArray(20);
            DisplayDoublesArray(arr);
            Console.WriteLine();
            DisplayLargeDoublesOnly(arr);
            Console.WriteLine();
            DisplayDoublesArray(arr);
            Console.WriteLine();

            Console.WriteLine("\n**********End Question 3 **********\n\n");
        }
        public static double[] GenerateDoubleArray(int len)
        {
            Random rand = new Random();
            double[] final = new double[len];
            for (int i=0; i < final.Length; i++)
            {
                final[i] = rand.NextDouble();
            }
            return final;
        }
        public static void DisplayDoublesArray(double[]arr)
        {
            foreach(double i in arr)
            {
                Console.Write($"{i:#0.0000} ");
            }
        }
        public static void DisplayLargeDoublesOnly(double[] arr)
        {
            for (int i=0; i < arr.Length; i++)
            {
                if (arr[i] > 0.75)
                {
                    Console.Write($"{arr[i]:#0.0000}, ");
                }
            }
            Console.WriteLine();
        }

        public static void DemoQuestion4()
        {
            Console.WriteLine("\n**********Begin Question 4 **********\n\n");

            string table = string.Format("  {0,5}   {1,7}  {2,7}  {3,7}", $"angle", $"inv sin", $"inv tan", $"inv cos");
            Console.WriteLine(table);
            for (double angle =0; angle <= 0.45; angle += 0.05)
            {
                InverseTrig(angle, out double sin, out double cos, out double tan);
                string table1 = string.Format(" {0,5}  {1,7}  {2,7}  {3,7}", $"{angle:0.0000}", $"{sin:0.0000}", $"{tan:0.0000}", $"{cos:0.0000}");
                Console.WriteLine(table1);
            }

            Console.WriteLine("\n**********End Question 4 **********\n\n");
        }
        public static void InverseTrig(double angle, out double sin, out double cos, out double tan)
        {
            sin = Math.Asin(angle);
            cos = Math.Acos(angle);
            tan = Math.Atan(angle);

        }
        public static void DemoQuestion5()
        {
            Console.WriteLine("\n**********Begin Question 5 **********\n\n");

            Console.WriteLine($"A mass 1.0kg moving at 2.0mps in a circle of radius of 1.0 will have a force of {CalculateKineticEnergy(1, 2, 1):#0.0}N;");
            Console.WriteLine($"A mass 6.0kg moving at 3.0mps in a circle of radius of 4.0 will have a force of {CalculateKineticEnergy(6, 3, 4):#0.0}N;");

            Console.WriteLine("\n**********End Question 5 **********\n\n");

        }
        public static double CalculateKineticEnergy(double m, double s, double r)
        {
            
            double v = Math.Pow(s, 2);
            double mv = m * v;
            double f = mv / r;
            return f;
        }
        public static void DemoQuestion6()
        {
            Console.WriteLine("\n**********Begin Question 6 **********\n\n");

            double inc = 46000;
            Console.WriteLine($"Your federal tax will be {CalculateFederalTax(inc):C2} if your income is {inc:C2}");
            inc = 75000;
            Console.WriteLine($"Your federal tax will be {CalculateFederalTax(inc):C2} if your income is {inc:C2}");
            inc = 130000;
            Console.WriteLine($"Your federal tax will be {CalculateFederalTax(inc):C2} if your income is {inc:C2}");

            Console.WriteLine("\n**********End Question 6 **********\n\n");
        }
        public static double CalculateFederalTax(double inc)
        {
            double totaltax = 0;
            double tax1=0,tax2=0,tax3=0;
            double remain;
            if (inc <= 45282)
            {
                tax1 = inc * 0.15;
            }
            else
            {
                if (inc>45282 && inc <=90563)
                {
                    tax1 = 45282 * 0.15;
                    remain = inc - 45282;
                    tax2 = remain * 0.205;
                }
                else
                {
                    tax1 = 45282 * 0.15;
                    tax2 = 45281 * 0.205;
                    remain = inc - 90563;
                    tax3 = remain * 0.33;
                }
            }
            totaltax = tax1 + tax2 + tax3;
            return totaltax;
        }
        static void Main(string[] args)
        {
            bool check= true;
            while (check == true)
            {
                DisplayMenu();
                string inp = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (inp)
                {
                    case "1":
                        DemoQuestion3();
                        break;
                    case "2":
                        DemoQuestion4();
                        break;
                    case "3":
                        DemoQuestion5();
                        break;
                    case "4":
                        DemoQuestion6();
                        break;
                    case "X":
                        DemoQuestion6();
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Error! Please type an appropiate input!");
                        break;
                }
            }
        }
    }
}
