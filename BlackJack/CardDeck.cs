using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class CardDeck
    {
        public List<Card> Deck { get; set; }
        public CardDeck()
        {
            Deck = new List<Card>();
        }

        internal void addRandomCard()
        {
            Random random = new Random();
            Card newCard = new Card();

            int randomNumber = random.Next(2, 14);

            if(randomNumber < 11)
            {
                newCard.Suit = randomNumber.ToString();
                newCard.Value = randomNumber;
            }
            else if(randomNumber == 11){
                newCard.Suit = "J";
                newCard.Value = 10;
            }
            else if(randomNumber == 12)
            {
                newCard.Suit = "Q";
                newCard.Value = 10;
            }
            else if(randomNumber == 13)
            {
                newCard.Suit = "K";
                newCard.Value = 10;
            }

            Deck.Add(newCard);
        }

        internal void readCards()
        {
            int i = 1;
            foreach (Card card in Deck)
            {
                Console.WriteLine($"Card number {i}: {card.Suit}. Value: {card.Value}");
                i++;
            }
        }
        internal int countCards()
        {
            int total = 0;
            foreach (Card card in Deck)
            {
                total += card.Value;
            }
            return total;
        }
    }


    //poco class 
    internal class Card
    {
        public string Suit { get; set; }
        public int Value { get; set; }
    }
}
