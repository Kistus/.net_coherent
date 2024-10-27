using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            Point3D p1 = new Point3D(0, 0, 0, 5.5);
            Point3D p2 = new Point3D(3, 4, 5, 2.5);

            Console.WriteLine($"Distance between points: {p1.DistanceTo(p2)}");
            Console.WriteLine($"Is p1 Zero Point? {p1.IsZero()}");
        }
    }
}
