using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace part_02
{
    class Program
    {
        static void Main()
        {
            Car cr1 = new Car();
            cr1.Name = "A";
            cr1.ProductionYear = 2007;
            cr1.MaxSpeed = 210;
            Car cr2 = new Car();
            cr2.Name = "B";
            cr2.ProductionYear = 2014;
            cr2.MaxSpeed = 230;
            Car cr3 = new Car();
            cr3.Name = "C";
            cr3.ProductionYear = 2023;
            cr3.MaxSpeed = 180;
            Car cr4 = new Car();
            cr4.Name = "C";
            cr4.ProductionYear = 2007;
            cr4.MaxSpeed = 180;
            Car cr5 = new Car();
            cr5.Name = "C";
            cr5.ProductionYear = 2023;
            cr5.MaxSpeed = 190;

            Car[] list = new Car[] { cr1, cr2, cr3, cr4, cr5 };
            CarsCatalog ct = new CarsCatalog(list);

           

            foreach (Car var in ct)
            {
                Console.Write($"{var.ToString()} ");
            }
            Console.WriteLine();

            foreach (Car var in ct.Reverse())
            {
                Console.Write($"{var.ToString()} ");
            }
            Console.WriteLine();
            foreach (Car var in ct.ByMaxSpeed(180))
            {
                Console.Write($"{var.ToString()} ");
            }
            foreach (Car var in ct.ByYear(2023))
            {
                Console.Write($"{var.ToString()} ");
            }
        }
        public class CarsCatalog
        {
            Car[] list;

            public CarsCatalog(Car[] obj)
            {
                list = obj;
            }

            public string this[int index]
            {
                get
                {
                    string str = $"This is {list[index].Name}, and it produce in {list[index].ProductionYear}.";
                    return str;
                }
            }
            public IEnumerable<Car> ByYear(int year)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].ProductionYear == year) { yield return list[i]; };
                }
                Console.WriteLine();
            
            }
            public IEnumerable<Car> ByMaxSpeed(int speed)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].MaxSpeed == speed) { yield return list[i]; };
                }
                Console.WriteLine();
            }

            public IEnumerator<Car> GetEnumerator()
            {
                for(int i = 0; i< list.Length; i++)
                {
                    yield return list[i];
                }
            }

            public IEnumerable<Car> Reverse()
            {
                for (int i = list.Length - 1; i >=0; i--)
                {
                    yield return list[i];
                }
            }
        }

        public class Car
        {
            public string Name { get; set; }
            public int ProductionYear { get; set; }
            public double MaxSpeed { get; set; }

            public override string ToString() => $"{Name}, {ProductionYear}, {MaxSpeed}";
        }
    }
}