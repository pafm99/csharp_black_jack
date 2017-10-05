using System;
using System.Collections.Generic;
using System.Text;

namespace cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Table table = new Table();
            Console.WriteLine("");
            Console.WriteLine("$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$");
            Console.WriteLine("$                                                                                                    $");
            Console.WriteLine("$                          Welcome to Paul's Angel's Blackjack table!                                $");
            Console.WriteLine("$                    You've come to the right place to give us your money!                           $");
            Console.WriteLine("$                                                                                                    $");
            Console.WriteLine("$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$FRANCO-COINS$$$$$$$");
            Console.WriteLine("");
            

            bool keepLooping = true;
            while (keepLooping || table.players.Count < 1)
            {
                Console.WriteLine("*** Please enter 'p' to add a new player or any other key to start the game. ***");
                Console.WriteLine("");

                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.KeyChar == 'p' || cki.KeyChar == 'P')
                {
                    table.AddPlayer();
                }
                else
                {
                    keepLooping = false;
                    if (table.players.Count < 1)
                    {
                        Console.WriteLine("*** There must be at least one person added to the game to play! ***");
                        Console.WriteLine("");
                        keepLooping = true;
                    }

                }
            }


            bool firstTime = true;
            bool gotInput = false;
            bool keepGoing = true;

            while ((!gotInput || keepGoing) && table.players.Count > 0)
            {
                if (!firstTime)
                {
                    Console.WriteLine("*** Please enter 'g' to play a game or 'q' to quit. ***");
                    Console.WriteLine("");
                     
                }
                firstTime = false;



                ConsoleKeyInfo cki = Console.ReadKey(true);
                //player hits
                if (cki.KeyChar == 'g' || cki.KeyChar == 'G')
                {
                    gotInput = true;
                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$GAME START$$$$$$$$$$$$$$$$$$$$");
                    Console.WriteLine("");

                    table.PlayGame();
                    Console.WriteLine($"There are {table.players.Count} players left");
                }
                else if (cki.KeyChar == 'q' || cki.KeyChar == 'Q')
                {
                    gotInput = true;
                    keepGoing = false;
                    Console.WriteLine("$$$ Thanks for giving us your mon... Ermmm.. thanks for playing!!! $$$");
                    Console.WriteLine("");
                    return;
                }
                else
                {
                    gotInput = false;
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("");
                }


            }

            Console.WriteLine("$$$ Thanks for giving us your mon... Ermmm.. thanks for playing!!! $$$");
            Console.WriteLine("");


        }

    }
}
