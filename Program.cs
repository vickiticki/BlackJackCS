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
    class LowCard
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
                    value = 1;
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
        static List<Card> Shuffle(List<Card> newDeck)
        {
            // numberOfCards = length of our deck
            var numberOfCards = newDeck.Count;

            // for rightIndex from numberOfCards - 1 down to 1 do:
            for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
            {
                //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);

                //   Now swap the values at rightIndex and leftIndex by doing this:
                //     leftCard = the value from deck[leftIndex]
                var leftCard = newDeck[leftIndex];
                //     rightCard = the value from deck[rightIndex]
                var rightCard = newDeck[rightIndex];
                //     deck[rightIndex] = leftCard
                newDeck[rightIndex] = leftCard;
                //     deck[leftIndex] = rightCard
                newDeck[leftIndex] = rightCard;
            }
            return newDeck;

        }
        // static int LowAceScore(List<Card> aceHand)
        // {
        //     int newScore = 0;

        //     foreach (var aCard in aceHand)
        //     {
        //         if (aCard.Rank == "Ace")
        //         {
        //             var lowCard = new LowCard { Suit = aCard.Suit, Rank = aCard.Rank };
        //             aceHand.Remove(aCard);
        //             aceHand.Add(lowCard);

        //         }
        //         int newPoints = aCard.Value();
        //         newScore = newScore + newPoints;

        //     }
        //     return newScore;

        // }
        static int FindScore(List<Card> theHand)
        {
            int someScore = 0;
            foreach (var someCard in theHand)
            {
                int somePoints = someCard.Value();
                someScore = someScore + somePoints;


            }
            return someScore;
        }
        // static int TryAgain(List<Card> aceHand)
        // {
        //     int lowScore = 0;
        //     int extraPoints = 0;
        //     foreach (var aCard in aceHand)
        //     {
        //         if (aCard.Rank == "Ace")
        //         {
        //             aceHand.Remove(aCard);
        //             extraPoints = extraPoints + 1;
        //         }

        //     }
        //     var newScore = FindScore(aceHand);
        //     lowScore = newScore + extraPoints;
        //     return lowScore;
        // }
        static List<Card> NewerHand(List<Card> aceHand)
        {

            var noAceHand = new List<Card>();
            foreach (var aCard in aceHand)
            {
                if (aCard.Rank == "Ace")
                {
                    Console.WriteLine();
                }
                else
                {
                    noAceHand.Add(aCard);
                }
            }
            return noAceHand;

        }
        static int AcePoint(List<Card> countAces)
        {
            int aceScore = 0;
            foreach (var isItAce in countAces)
            {
                if (isItAce.Rank == "Ace")
                {
                    aceScore = aceScore + 1;
                }
            }
            return aceScore;

        }
        static void Main(string[] args)
        {
            var playGame = "yes";

            while (playGame == "yes")
            {

                Console.WriteLine("Let's Play Blackjack!!");
                var startDeck = new List<Card>();

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
                        startDeck.Add(card);
                    }
                }



                var deck = Shuffle(startDeck);

                var playerHand = new List<Card>() { deck[0], deck[1] };

                var dealerHand = new List<Card>() { deck[2], deck[3] };
                Console.WriteLine();



                var scoreA = 0;

                Console.WriteLine("Enter any word to play");

                var response = Console.ReadLine();



                Console.WriteLine("Player's Hand");
                foreach (var playerCard in playerHand)
                {

                    Console.WriteLine(playerCard.Rank + " of " + playerCard.Suit);

                    // var points = playerCard.Value();
                    // scoreA = scoreA + points;

                }

                scoreA = FindScore(playerHand);

                Console.WriteLine($"Player's Score: {scoreA}");

                Console.WriteLine();

                Console.WriteLine($"Dealer's hand:");
                Console.WriteLine($"{deck[2].Rank} of {deck[2].Suit} and a hidden card");
                Console.WriteLine();
                var answer = "Play";

                var endPlayerTurn = "no";

                var score = scoreA;



                while (score < 21 && endPlayerTurn != "yes")
                {
                    Console.Write("Hit or Stand? ");

                    answer = Console.ReadLine();
                    Console.WriteLine();
                    if (answer == "Hit" || answer == "hit" || answer == "h")
                    {
                        int newCard = playerHand.Count + dealerHand.Count;
                        playerHand.Add(deck[newCard]);
                        Console.WriteLine($"{deck[newCard].Rank} of {deck[newCard].Suit}");

                        score = score + deck[newCard].Value();

                        if (score > 21)
                        {
                            foreach (var findAce in playerHand)
                            {
                                if (findAce.Rank == "Ace")
                                {

                                    var acePoints = AcePoint(playerHand);
                                    var diffHand = NewerHand(playerHand);
                                    var newScore = FindScore(diffHand);



                                    score = newScore + acePoints;

                                    //     var diffScore = TryAgain(playerHand);
                                    //     score = diffScore;

                                }
                            }
                        }


                        Console.WriteLine($"Player's score: {score}");
                        newCard++;

                    }
                    else if (answer == "Stand" || answer == "stand" || answer == "s")
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Score = {score}");
                        endPlayerTurn = "yes";
                    }
                    else { Console.WriteLine("Error. Please try again."); }


                }


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
                    Console.WriteLine("Bust.");
                }


                // Dealer's Turn


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

                //add cards to dealer



                Console.WriteLine($"Dealer's Score = {scoreD}");

                while (scoreD <= 17 && score <= 21)
                {
                    int newCardD = playerHand.Count + dealerHand.Count;
                    dealerHand.Add(deck[newCardD]);
                    Console.WriteLine($"{deck[newCardD].Rank} of {deck[newCardD].Suit}");
                    scoreD = scoreD + deck[newCardD].Value();
                    if (scoreD > 21)
                    {
                        foreach (var findAceD in dealerHand)
                        {
                            if (findAceD.Rank == "Ace")
                            {

                                var acePointsD = AcePoint(dealerHand);
                                var diffHandD = NewerHand(dealerHand);
                                var newScoreD = FindScore(diffHandD);

                                scoreD = newScoreD + acePointsD;


                            }
                        }
                    }
                    Console.WriteLine("Dealer's Score  = " + scoreD);
                }



                Console.WriteLine();

                if (scoreD <= 21)
                {

                    if (score > scoreD && score <= 21)
                    {
                        if (score == 21)
                        {
                            Console.WriteLine("Player got blackjack.");
                        }
                        Console.WriteLine("Player wins!");
                    }

                    // check for tie
                    else if (score == scoreD)
                    {

                        if (score == 21)
                        {
                            Console.WriteLine("Dealer got blackjack.");
                            Console.WriteLine("Dealer wins.");
                        }
                        else
                        {
                            Console.WriteLine("Push.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dealer wins.");
                    }
                }
                else
                {
                    Console.WriteLine("Dealer busts.");
                    Console.WriteLine("Player wins!");
                }

                Console.WriteLine();
                Console.Write("Want to play again? yes/no ");

                string anotherGame = Console.ReadLine();

                // why didn't this work??
                // anotherGame = anotherGame.ToLower;
                // anotherGame.ToLower;

                if (anotherGame == "y" || anotherGame == "yes")
                {
                    Console.WriteLine();
                }
                else
                {
                    playGame = "no";
                    Console.WriteLine();
                }

            }

            Console.WriteLine("Thanks for playing.");

            // I messed up the commit. I am confusion.




            // Console.WriteLine($"This {firstCard.Rank} of {firstCard.Suit} it is worth {firstCard.Value()} points");
            // Console.WriteLine($"This {secondCard.Rank} of {secondCard.Suit} it is worth {secondCard.Value()} points");

        }
    }
}
