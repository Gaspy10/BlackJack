using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Game
    {
        static void Main(string[] args)
        {
            CardDeck playerDeck = new CardDeck();
            CardDeck computerDeck = new CardDeck();

            playerDeck.addRandomCard();
            playerDeck.addRandomCard();

            computerDeck.addRandomCard();

            readDecks(playerDeck, computerDeck);

            Console.WriteLine("Do you want to take another card? (y/n)");
            while (Console.ReadLine() == "y")
            {
                computerDeck.addRandomCard();
                readDecks(playerDeck, computerDeck);

                if(computerDeck.countCards() < 17)
                {
                    computerDeck.addRandomCard();
                    Console.WriteLine("Computer takes another card.");
                }
                else
                {
                    Console.WriteLine("Computer does not want to take another card.");
                }
                Console.WriteLine("Do you want to take another card? (y/n)");
            }

            if(playerDeck.countCards() > 21)
            {
                Console.WriteLine("You lost!");
            }
            else if(computerDeck.countCards() > 21)
            {
                Console.WriteLine("You won!");
            }
            else if(playerDeck.countCards() > computerDeck.countCards())
            {
                Console.WriteLine("You won!");
            }
            else if(playerDeck.countCards() < computerDeck.countCards())
            {
                Console.WriteLine("You lost!");
            }
            else
            {
                Console.WriteLine("It´s a tie!");
            }
        }

        private static void readDecks(CardDeck playerDeck, CardDeck computerDeck)
        {
            Console.WriteLine();
            Console.WriteLine("Player´s card: ");
            playerDeck.readCards();
            Console.WriteLine("Computer´s card: ");
            computerDeck.readCards();
            Console.WriteLine();
        }
    }
}
