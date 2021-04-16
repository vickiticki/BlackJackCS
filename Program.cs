using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
        public string Name()
        {
            var nameOfCard = $"{Rank} of {Suit}";
            return nameOfCard;
        }
        public int Value()
        {
            int value = 0;

            switch (Rank)
            {
                case "Ace":
                    value = 11;
                    break;
                case "2":
                    value = 2;
                    break;
                case "3":
                    value = 3;
                    break;
                case "4":
                    value = 4;
                    break;
                case "5":
                    value = 5;
                    break;
                case "6":
                    value = 6;
                    break;
                case "7":
                    value = 7;
                    break;
                case "8":
                    value = 8;
                    break;
                case "9":
                    value = 9;
                    break;
                case "10":
                case "Jack":
                case "Queen":
                case "King":
                    value = 10;
                    break;
                default:
                    value = 0;
                    break;

            }
            return value;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blackjack!!");
            var deck = new List<Card>();

            var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
            var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            // Go through each suit, Clubs, Diamonds, Hearts, and Spaces, one at a time
            foreach (var suit in suits)
            {
                //     For each suit do the following
                //        Go through all the ranks, Ace, 2, 3, 4, etc.
                foreach (var rank in ranks)
                {
                    var card = new Card { Suit = suit, Rank = rank };
                    deck.Add(card);
                }
            }

            // numberOfCards = length of our deck
            var numberOfCards = deck.Count;

            // for rightIndex from numberOfCards - 1 down to 1 do:
            for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
            {
                //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);

                //   Now swap the values at rightIndex and leftIndex by doing this:
                //     leftCard = the value from deck[leftIndex]
                var leftCard = deck[leftIndex];
                //     rightCard = the value from deck[rightIndex]
                var rightCard = deck[rightIndex];
                //     deck[rightIndex] = leftCard
                deck[rightIndex] = leftCard;
                //     deck[leftIndex] = rightCard
                deck[leftIndex] = rightCard;
            }




            var playerHand = new List<Card>() { deck[0], deck[1] };

            var dealerHand = new List<Card>() { deck[2], deck[3] };
            Console.WriteLine();



            var score = 0;

            Console.WriteLine("Enter any word to play");

            var response = Console.ReadLine();



            Console.WriteLine("Player's Hand");
            foreach (var playerCard in playerHand)
            {

                Console.WriteLine(playerCard.Rank + " of " + playerCard.Suit);

                var points = playerCard.Value();
                // Console.WriteLine(points);
                score = score + points;




            }
            Console.WriteLine($"Player's Score: {score}");
            var answer = "Play";

            var endPlayerTurn = "no";


            while (score < 21 && endPlayerTurn != "yes")
            {
                Console.Write("Hit or Stand? ");
                answer = Console.ReadLine();
                if (answer == "Hit" || answer == "hit")
                {
                    int newCard = playerHand.Count + 2;
                    playerHand.Add(deck[newCard]);
                    Console.WriteLine($"{deck[newCard].Rank} of {deck[newCard].Suit}");

                    score = score + deck[newCard].Value();
                    Console.WriteLine($"Score = {score}");
                    newCard++;

                }
                else if (answer == "Stand" || answer == "stand")
                {
                    Console.WriteLine($"Score = {score}");
                    endPlayerTurn = "yes";
                }
                else { Console.WriteLine("Error. Please try again."); }
            }
            // else if (score == 21)
            // {
            //     Console.WriteLine();
            // }
            // else
            // {
            //     Console.WriteLine("blerg");
            // }

            if (score <= 21)
            {
                Console.WriteLine("Player's Turn Done.");
            }
            // else if (score == 21)
            // {
            //     Console.WriteLine("Blackjack.");
            // }
            else
            {
                Console.WriteLine("Bust. Player loses.");
            }

            Console.WriteLine();
            Console.WriteLine("Dealer's Hand");
            int scoreD = 0;


            foreach (var dealerCard in dealerHand)
            {

                Console.WriteLine(dealerCard.Rank + " of " + dealerCard.Suit);

                var pointsD = dealerCard.Value();
                // Console.WriteLine(points);
                scoreD = scoreD + pointsD;


            }
            Console.WriteLine($"Dealer's Score = {scoreD}");

            Console.WriteLine();

            if (scoreD <= 21)
            {

                if (score > scoreD && score <= 21)
                {
                    Console.WriteLine("Player wins!");
                }
                else
                {
                    Console.WriteLine("Player Loses");
                }
            }
            else
            {
                Console.WriteLine("Dealer busts. Player wins!");
            }




            // Console.WriteLine($"This {firstCard.Rank} of {firstCard.Suit} it is worth {firstCard.Value()} points");
            // Console.WriteLine($"This {secondCard.Rank} of {secondCard.Suit} it is worth {secondCard.Value()} points");

        }
    }
}
