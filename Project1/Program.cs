using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            String response = "y";

            while (response == "y")
            {
                Game theGame = new Game();
                theGame.Play();

                Console.Write("Play Again (y/n)? ");
                response = Console.ReadLine();
            }
        }
    }
}
