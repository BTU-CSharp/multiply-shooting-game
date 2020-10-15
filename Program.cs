using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp123
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreeDGame threeDGame = new ThreeDGame();

            //მთავარი გამშვები მეთოდი.
            threeDGame.Battle();        

            Console.WriteLine("thats it? \nPlay again? (click 'yes')");

            string question = Console.ReadLine();


            // ამით მომხმარებლისთვის შესაძლებელი ხდება თავიდან ითამაშოს თამაში. 'yes' ღილაკზე დაჭერით.
            if (question == "yes")
            {
                threeDGame = new ThreeDGame();
                threeDGame.Battle();
            }
        }
    }

}
