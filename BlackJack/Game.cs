using Microsoft.VisualBasic;

namespace BlackJack
{
    internal class Game
    {
        public Game()
        {
        }

        static void Main(string[] args)
        {
            int[] globalCardDeck = Enumerable.Repeat(4, 12).ToArray();

            CardDeck playerDeck = new CardDeck(globalCardDeck);
            CardDeck computerDeck = new CardDeck(globalCardDeck);

            playerDeck.addRandomCard();
            playerDeck.addRandomCard();

            computerDeck.addRandomCard();

            readDecks(playerDeck, computerDeck, globalCardDeck);

            Console.WriteLine("Do you want to take another card? (y/n)");
            while (Console.ReadLine().ToLower() == "y")
            {
                Console.Clear();

                if (!isEmpty(globalCardDeck))
                {
                    playerDeck.addRandomCard();
                }
                else
                {
                    Console.WriteLine("There are no more cards in the deck.");
                    break;
                }

                if (computerDeck.countCards() < 17)
                {
                    computerDeck.addRandomCard();
                    Console.WriteLine("Computer takes another card.");
                }
                else
                {
                    Console.WriteLine("Computer does not want to take another card.");
                }

                readDecks(playerDeck, computerDeck, globalCardDeck);
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

        private static bool isEmpty(int[] globalCardDeck)
        {
            foreach (int i in globalCardDeck)
            {
                if (i != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void readDecks(CardDeck playerDeck, CardDeck computerDeck, int[] quantity)
        {
            Console.WriteLine("Cards deck: ");
            Console.WriteLine("2 3 4 5 6 7 8 9 10 J Q K");

            int i = 0;
            foreach (int item in quantity)
            {
                Console.Write($"{item} ");
                if (i == 8)
                {
                    Console.Write(" ");
                }
                i++;
            }

            Console.WriteLine();

            Console.WriteLine("\nPlayer´s card: ");
            playerDeck.readCards();

            Console.WriteLine();

            Console.WriteLine("Computer´s card: ");
            computerDeck.readCards();

            Console.WriteLine();
        }
    }
}
