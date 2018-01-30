using System;

namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
           bool quit = false;
           while (!quit)
            {
                //SHOW MENU
                char choice = DisplayMenu();


                //PROCESS MENU OPTIONS
                switch (choice)
                {
                    case 'l':
                    case 'L': ListProducts(); break;
                    case 'a':
                    case 'A': AddProduct(); break;
                    case 'q':
                    case 'Q': quit = true; break;
                };
            }
        }

        //ADD A PRODUCT
        static void AddProduct()
        {
            _name = ReadString("Enter name: ", true);
            _price = ReadDecimal("Enter price: ", 0);
            _description = ReadString("Enter description (if any): ", false);
        }

        //READ STRING (FOR PRODUCT ADD)
        private static string ReadString( string message, bool isRequired )
        {
            do
            {
                Console.Write(message);
                string value = Console.ReadLine();
                    
                if (!isRequired || value != "")
                    return value;

                Console.WriteLine("You cannot leave this entry blank");
            } while (true);
        }

        //READ DECIMAL (FOR PRODUCT ADD)
        private static decimal ReadDecimal( string message, decimal minValue )
        {
            do
            {
                Console.Write(message);
                string value = Console.ReadLine();

                
                if (Decimal.TryParse(value, out decimal result))
                {
                    if (result >= minValue)
                        return result;
                };

                Console.WriteLine("Must be a number and >= {0}", minValue);
            } while (true);
        }

        //LIST PRODUCTS
        private static void ListProducts()
        {
            //CHECK FOR PRODUCT
            if (_name != null && _name != "")
            {
                Console.WriteLine(_name);
                Console.WriteLine(_price);
                Console.WriteLine(_description);
            } else
                Console.WriteLine("No products"); 
        }

        //PRODUCT DATA
        static string _name;
        static decimal _price;
        static string _description;
   
        //MENU DISPLAY
        private static char DisplayMenu()
        {
            //MENU OPTIONS
            do
            {
                Console.WriteLine("(L)ist Products");
                Console.WriteLine("(A)dd Products");
                Console.WriteLine("(Q)uit");

                string input = Console.ReadLine();

                if (input == "L" || input == "l")
                    return input[0];
                else if (input == "A" || input == "a")
                    return input[0];
                else if (input == "Q" || input == "q")
                    return input[0];
               
                Console.WriteLine("Please choose a valid option");
            } while (true);   
               
        }
        
        //OTHER
        static void PlayingWithPrimitives ()
        {
            //Primitive
            decimal unitPrice = 10.5M;

            //Real declaration
            //System.Decimal unitPrice2 = 10.5M;
            Decimal unitPrice2 = 10.5M;

            //Current time
            DateTime now = DateTime.Now;

            System.Collections.ArrayList items;
        }
        static void PlayingWithVariables ()
        {
            //single decls
            int hours = 0;
            //Don't
            //int hours;
            //hours = 0;

            double rate = 10.25;

            //Still not assigned
            //if (false)
            //    hours = 0;

            int hours2 = hours;

            //Multiple decls
            string firstName, lastName;

            //string @class;

            //single assignment
            firstName = "Bob";
            lastName = "Miller";

            //Multiple assignment
            firstName = lastName = "Sue";

            //Math ops
            int x = 0, y = 0;
            int add = x + y;
            int subtract = x - y;
            int mulitply = x * y;
            int divide = x / y;
            int modulos = x % y;

            //x = x+10;
            x += 10;
            double ceiling = Math.Ceiling(rate);
            double floor = ceiling;
        }
    }
}
