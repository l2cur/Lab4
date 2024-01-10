using Microsoft.VisualBasic.FileIO;
using System;
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

            Car[] list = new Car[] { cr1, cr2, cr3 };
            Array.Sort(list, new CarComparer("Name"));
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i].ToString());
            }

            Array.Sort(list, new CarComparer("ProductionYear"));
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i].ToString());
            }

            Array.Sort(list, new CarComparer("MaxSpeed"));
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }

        public class CarComparer : IComparer<Car>
        {
            string option;

            public CarComparer(string option)
            {
                this.option = option;
            }

            public int Compare(Car car1, Car car2)
            {
                if (option == "Name")
                {
                    return string.Compare(car1.Name, car2.Name);
                }
                else if (option == "ProductionYear")
                {
                    return car1.ProductionYear.CompareTo(car2.ProductionYear);
                }
                else if (option == "MaxSpeed")
                {
                    return car1.MaxSpeed.CompareTo(car2.MaxSpeed);
                }

                throw new ArgumentException("Invalid option");
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