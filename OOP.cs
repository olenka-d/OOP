using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP
{
    class Figures
    {
        protected int[] arr_sides;
        protected int perimeter = 0;
        static int count = 0;

        public Figures(params int[] arr_sides) //конструктор
        {
            this.arr_sides = new int[arr_sides.Length];
            for (int i = 0; i < arr_sides.Length; i++)
            {
                this.arr_sides[i] = arr_sides[i];
            }
            count++;
        }
        public void setSide(int i, int l)  //задає вказаній стороні за індексом нове значення довжини
        {
            if (i >= 0 && i < arr_sides.Length)
            {
                arr_sides[i] = l;
            }           
        }
        public int getSide(int i)  //повертає довжину сторони за індексом
        {
            if(i >=0 && i < arr_sides.Length)
            {
                return arr_sides[i];
            }
            return 0;
        }
        public int getPerimeter()  //рахує і повертає периметр
        {
            for(int k = 0; k < arr_sides.Length; k++)
            {
                perimeter += arr_sides[k];
            }
            return perimeter;
        }
        public static int Count()
        {
            return count;
        }
    }

    class Triangle : Figures
    {
        double[] angles = new double[3];
        double square = 0;
        static int count_tr = 0;

        public Triangle(params int[] arr_sides) : base(arr_sides) // успадкований конструктор Figures
        {
            count_tr++;
        } 
        public new void setSide(int i, int l)  //успадкований метод setSide з Figures
        {
            base.setSide(i, l);
        }
        public new int getSide(int i)   //успадкований метод getSide з Figures
        {
            return base.getSide(i);
        }
        public new int getPerimeter()   //успадкований метод Perimeter з Figures
        {
            return base.getPerimeter();
        }
        public double getSquare()   //повертає площу трикутника
        {
            double half_perimeter = getPerimeter() / 2;
            square = Math.Sqrt(half_perimeter * (half_perimeter - arr_sides[0]) *
                              (half_perimeter - arr_sides[1]) * (half_perimeter - arr_sides[2]));
            return square;
        }
        public void Angles()  //виводить масив кутів трикутника
        {
            double side_a = arr_sides[0];
            double side_b = arr_sides[1];
            double side_c = arr_sides[2];

            //теорема косинусів для знаходження кутів трикутника
            double angle_a = (Math.Pow(side_b, 2) + Math.Pow(side_c, 2) - Math.Pow(side_a, 2)) / (2 * side_b * side_c);
            double angle_b = (Math.Pow(side_a, 2) + Math.Pow(side_c, 2) - Math.Pow(side_b, 2)) / (2 * side_a * side_c);
            double angle_c = (Math.Pow(side_a, 2) + Math.Pow(side_b, 2) - Math.Pow(side_c, 2)) / (2 * side_a * side_b);

            angle_a = Math.Acos(angle_a) * 180 / Math.PI;
            angle_b = Math.Acos(angle_b) * 180 / Math.PI;
            angle_c = Math.Acos(angle_c) * 180 / Math.PI;

            angles[0] = angle_a;
            angles[1] = angle_b;
            angles[2] = angle_c;

            foreach (int i in angles)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        public static int Count_tr()
        {
            return count_tr;
        }
    }

    class Rectangle : Figures
    {
        double[] angles = new double[4] { 90, 90, 90, 90};
        double square = 0;
        double diagonal;
        static int count_rec = 0;
        public Rectangle(params int[] arr_sides) : base(arr_sides) // успадкований конструктор Figures
        {
            count_rec++;
        } 
        public new void setSide(int i, int l)  //успадкований метод setSide з Figures
        {
            base.setSide(i, l);
        }
        public new int getSide(int i)   //успадкований метод getSide з Figures
        {
            return base.getSide(i);
        }
        public new int getPerimeter()   //успадкований метод Perimeter з Figures
        {
            return base.getPerimeter();
        }
        public double getSquare()   //повертає площу чотирикутника
        {
            double half_perimeter = getPerimeter() / 2;
            square = Math.Sqrt((half_perimeter - arr_sides[0]) * (half_perimeter - arr_sides[1]) * 
                              (half_perimeter - arr_sides[2]) * (half_perimeter - arr_sides[3]));
            return square;
        }
        public double getDiagonal()  //повертає діагональ прямокутника
        {
            diagonal = Math.Sqrt(Math.Pow(arr_sides[0], 2) + Math.Pow(arr_sides[1], 2));
            return diagonal;
        }
        public void Angles()   //виводить масив кутів прямокутника
        {
            foreach (int i in angles)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        public static int Count_rec()
        {
            return count_rec;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Figures f1 = new Figures(2, 5, 3, 7);
            Figures f2 = new Figures(3, 1, 4, 9, 12);
            Console.WriteLine($"Периметр фігури f1 = {f1.getPerimeter()}");
            Console.WriteLine($"Периметр фігури f2 = {f2.getPerimeter()}");
            f1.setSide(1, 12);
            Console.WriteLine($"Периметр фігури f1 після зміни сторони = {f1.getPerimeter()}");
            int count_f = Figures.Count();
            Console.WriteLine($"Кількість створених фігур = {count_f}");

            Triangle t1 = new Triangle(3, 4, 5);
            Console.WriteLine($"Площа трикутника t1 = {t1.getSquare()}");
            Console.Write($"Кути трикутника t1 = ");
            t1.Angles();
            int count_t = Triangle.Count_tr();
            Console.WriteLine($"Кількість створених трикутників = {count_t}");

            Rectangle r1 = new Rectangle(3, 4, 3, 4);
            Rectangle r2 = new Rectangle(3, 3, 3, 3);
            Console.WriteLine($"Периметр прямокутника r1 = {r1.getPerimeter()}");
            Console.WriteLine($"Площа прямокутника r2 = {r2.getSquare()}");
            Console.WriteLine($"Діагональ прямокутника r1 = {r1.getDiagonal()}");
            int count_r = Rectangle.Count_rec();
            Console.WriteLine($"Кількість створених прямокутників = {count_r}");
            

            Console.ReadKey();
        }
    }
}
