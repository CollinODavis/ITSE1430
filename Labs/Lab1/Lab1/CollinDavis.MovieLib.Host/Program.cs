/*
 * ITSE 1403
 * Collin Davis
 * LAB1
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollinDavis.MovieLib.Host
{
    class Program
    {   //variables
        static string s_title;
        static string s_genre;
        static string s_desc;
        static string s_owned;
        static decimal s_length;

        //menu
        static void Main( string[] args )
        {
            bool exit = false;
            while (!exit)
            {
                bool isEqual = exit.Equals(10);

                //menu
                char option = Menu();

                //options
                switch (Char.ToUpper(option))
                {
                    case '1': ShowMovies(); break;
                    case '2': AddMovie(); break;
                    case '3': RemoveMovie(); break;
                    case '4': exit = true; break;
                };                
            }
        }

        //remove movie
        private static void RemoveMovie()
        {
            char delChoice = DeleteMovieCheck();
            switch (Char.ToUpper(delChoice))
            {
                case 'Y':
                if (!String.IsNullOrEmpty(s_title))
                {
                    s_title = "";
                    s_desc = "";
                    s_genre = "";
                    s_owned = "";
                    s_length = 0;
                    Console.WriteLine("Movie Removed");
                } else
                    Console.WriteLine("You have nothing to remove");
                break;
                case 'N': Console.WriteLine("Deletion Cancelled"); break;
            }

        }

        //remove movie confirmation
        private static char DeleteMovieCheck()
        {
            do
            {
                Console.WriteLine("Are you sure? Y/N:");
                string delConfirm = Console.ReadLine();
                delConfirm = delConfirm.ToUpper();
                if (String.Compare(delConfirm, "Y") == 0)
                    return delConfirm[0];
                else if (delConfirm == "N")
                    return delConfirm[0];
                Console.WriteLine("You must select either (y)es or (n)o");
            } while (true);
        }

        //menu option
        private static char Menu()
        {
            do
            {
                Console.WriteLine("1:Show movie list");
                Console.WriteLine("2:Add a movie");
                Console.WriteLine("3:Remove movie");
                Console.WriteLine("4:Exit");

                string select = Console.ReadLine();
                if (String.Compare(select, "1") == 0)
                    return select[0];
                else if (select == "2")
                    return select[0];
                else if (select == "3")
                    return select[0];
                else if (select == "4")
                    return select[0];
                Console.WriteLine("Invalid Selection");
            } while (true);
        }

        //shows added movies (if any)
        private static void ShowMovies()
        {
            if (!String.IsNullOrEmpty(s_title))
            {
                    Console.WriteLine("TITLE: " + s_title);
                    Console.WriteLine("GENRE: " + s_genre);
                    Console.WriteLine("LENGTH:" + s_length);
                    Console.WriteLine("OWNED: " + s_owned);
                if (!String.IsNullOrEmpty(s_desc))
                    Console.WriteLine("DESCRIPTION: " + s_desc);
            } else
                Console.WriteLine("You have no movies");
        }

        //add movie
        private static void AddMovie()
        {
            s_title = UserInput("Enter the movie name: ", true);
            s_genre = UserInput("Enter genre: ", true);
            s_desc = UserInput("(Optional) Enter a description: ", false);
            s_length = NumberInput("Enter the movie length in minutes: ", 0);
            s_owned = CheckOwn("Do you own this movie? Y/N: ", true);
        }
 
        //check ownership (only accepts y and n)
        private static string CheckOwn( string prompt, bool ownCheck )
        {
            do
            {
                Console.Write(prompt);
                string ownInput = Console.ReadLine();
                ownInput = ownInput.ToUpper();
                //check for y/n
                if (ownInput == "Y" || ownInput == "N")
                    return ownInput;
                Console.WriteLine("You must input either (y)es or (n)o");
            } while (true);
        }

        //number input (movie length)
        private static decimal NumberInput( string prompt, decimal minTime )
        {
            do
            {
                Console.Write(prompt);
                string movieFill = Console.ReadLine();

                //number convert
                if (Decimal.TryParse(movieFill, out decimal time))
                {
                    if (time > minTime)
                        return time;
                };
                string numError = String.Format("The movie length must be greater than {0}", minTime);
                Console.WriteLine(numError);
            } while (true);
        }

        //string input
        private static string UserInput( string prompt, bool optional )
        {
            do
            {
                Console.Write(prompt);
                string movieFill = Console.ReadLine();
                //check for text
                if (!optional || movieFill != "")
                    return movieFill;
                Console.WriteLine("You must fill this entry");
            } while (true);
        }
    }
}
