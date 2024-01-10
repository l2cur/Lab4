using System.Numerics;

namespace part_01
{
    class Programm
    {
        static void Main()
        {
            MyMatrix obj1 = new MyMatrix(5, 5);
            obj1.print();
            MyMatrix obj2 = new MyMatrix(5, 5);
            obj2.print();

            MyMatrix obj4 = obj1 + obj2;
            obj4.print();

            MyMatrix obj5 = obj1 - obj2;
            obj5.print();

            MyMatrix obj6 = obj1 * obj2;
            obj6.print();
        }
        public class MyMatrix
        {
            public int min { get; set; } = 0;
            public int max { get; set; } = 10;
            int row, columns;
            int[,] mas;
            public MyMatrix(int a, int b)
            {
                row = a;
                columns = b;
                Random rand = new Random();
                mas = new int[a,b];
                for (int i = 0; i<a; i++)
                {
                    for (int j = 0; j<b; j++)
                    {
                        mas[i, j] = rand.Next(min, max);
                    }
                }
            }
            public static MyMatrix operator +(MyMatrix a, MyMatrix b)
            {
                
                if (a.row != b.row || a.columns != b.columns)
                {
                    throw new ArgumentException("error argv");

                }
                MyMatrix obj = new MyMatrix(a.row, a.columns);
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        obj[i, j] = a[i, j] + b[i, j];
                    }
                }
                return obj;
            }
            public static MyMatrix operator -(MyMatrix a, MyMatrix b)
            {

                if (a.row != b.row || a.columns != b.columns)
                {
                    throw new ArgumentException("error argv");

                }
                MyMatrix obj = new MyMatrix(a.row, a.columns);
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        obj[i, j] = a[i, j] - b[i, j];
                    }
                }
                return obj;
            }
            public static MyMatrix operator *(MyMatrix a, int b)
            {
                MyMatrix obj = new MyMatrix(a.row, a.columns);
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        obj[i, j] = a[i, j] * b;
                    }
                }
                return obj;
            }
            public static MyMatrix operator /(MyMatrix a, int b)
            {
                MyMatrix obj = new MyMatrix(a.row, a.columns);
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        obj[i, j] = a[i, j] / b;
                    }
                }
                return obj;
            }
            public static MyMatrix operator *(MyMatrix a, MyMatrix b)
            {

                if (a.row != b.columns)
                {
                    throw new ArgumentException("error argv");

                }
                MyMatrix obj = new MyMatrix(a.row, b.columns);

                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        int sum = 0;
                        for (int l = 0; l < a.columns; l++)
                        {
                            sum += a[i, l] * b[l, j];
                        }
                        obj[i, j] = sum;
                    }

                }
                return obj;
            }
            public int this[int row, int columns]
            {
                get
                { 
                    return mas[row, columns]; 
                }
                set
                {
                    mas[row, columns] = value;
                }
            }
            public void print()
            {
                for (int i = 0; i < this.row; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        Console.Write($"{mas[i, j].ToString()} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}