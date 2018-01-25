using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main( string[] args )
        {
            int Name;

            Console.WriteLine("enter your name: ");
            Name = int.Parse(Console.ReadLine());

            Console.WriteLine("your name is " + Name);
            Console.ReadLine();
        }
    }
}
