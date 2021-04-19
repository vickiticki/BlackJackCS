using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Hand
    {
        //   - Properties: A list of individual Cards
        public List<Card> IndividualCards { get; set; } = new List<Card>();
        //   - Behaviors:
        //     - TotalValue representing the sum of the individual Cards in the list.
        //     - Add a card to the hand
        //
        //   Name      Add
        //   Input     new card
        //   Work      -- can't auto generate this!
        //   Output    void (nothing)
        public void Receive(Card newCard)
        {
            // Add this card to the hand
            IndividualCards.Add(newCard);
        }

        //     - TotalValue representing the sum of the individual Cards in the list.
        //
        //  Name        - TotalValue
        //  Input       - None 
        //  Work        - Somehow total up the value of the cards
        //  Output      - The total value (int) of the cards
        public int TotalValue()
        {
            // Work
            int handScore = 0;
            foreach (var classyCard in IndividualCards)
            {
                int classyPoints = classyCard.Value();
                handScore = handScore + classyPoints;
            }

            return handScore;
        }

        public int Size()
        {
            int handSize = IndividualCards.Count;
            return handSize;
        }
    }
    // make card class
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

        public string Description()
        {
            var newDescriptionString = $"{Rank} of {Suit}";
            return newDescriptionString;
        }

    }


    class Program
    {
        // Shuffle method
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

        // find score
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

        static Hand NewerHand(Hand aceHand)
        {

            var noAceHand = new Hand();
            foreach (var aCard in aceHand.IndividualCards)
            {
                if (aCard.Rank == "Ace")
                {
                    Console.WriteLine();
                }
                else
                {
                    noAceHand.Receive(aCard);
                }
            }
            return noAceHand;

        }
        static int AcePoint(Hand countAces)
        {
            int aceScore = 0;
            foreach (var isItAce in countAces.IndividualCards)
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
            var playGame = true;

            while (playGame == true)
            {

                Console.WriteLine("Let's Play Blackjack!!");
                // set up lists for deck, suits, and ranks
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

                var playerHand = new Hand();

                playerHand.Receive(deck[0]);
                playerHand.Receive(deck[1]);

                var dealerHand = new Hand();

                dealerHand.Receive(deck[2]);
                dealerHand.Receive(deck[3]);


                // changed hands to a class instead of list so this old code is unnecessary 
                // var handP = new List<Card>() { deck[0], deck[1] };
                // var handD = new List<Card>() { deck[2], deck[3] };
                Console.WriteLine();



                Console.WriteLine("Enter any word to play");

                var response = Console.ReadLine();

                Console.WriteLine("Your cards are:");
                foreach (var card in playerHand.IndividualCards)
                {
                    Console.WriteLine(card.Description());
                }
                var scoreA = playerHand.TotalValue();

                // not doing this today
                // 
                // if the first two cards are a pair, ask if they want to split
                // if (deck[0].Rank == deck[1].Rank)
                // {
                //     Console.Write("Do you want to split? Yes/No");
                //     var wantSplit = Console.ReadLine();

                //     // if yes split the cards
                // }

                if (scoreA > 21)
                {
                    foreach (var findAce in playerHand.IndividualCards)
                    {
                        if (findAce.Rank == "Ace")
                        {

                            var acePoints = AcePoint(playerHand);
                            var diffHand = NewerHand(playerHand);
                            var newScore = diffHand.TotalValue();



                            // score1 = newScore + acePoints;
                            scoreA = newScore + acePoints;



                        }
                    }
                }


                Console.WriteLine($"Player's Score: {scoreA}");

                Console.WriteLine();

                Console.WriteLine($"Dealer's hand:");
                Console.WriteLine($"{dealerHand.IndividualCards[0].Description()} and a hidden card");
                Console.WriteLine();
                var answer = "Play";

                var endPlayerTurn = "no";



                // Player's Turn

                var score = scoreA;

                while (score < 21 && endPlayerTurn != "yes")
                {
                    Console.Write("Hit or Stand? ");

                    answer = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if (answer == "hit" || answer == "h")
                    {
                        int newCardSpot = playerHand.Size() + dealerHand.Size();
                        var newCard = deck[newCardSpot];

                        //handP.Add(newCard);
                        playerHand.Receive(newCard);
                        Console.WriteLine(newCard.Description());

                        score = score + newCard.Value();

                        // change aces to one points if needed
                        if (score > 21)
                        {
                            foreach (var findAce in playerHand.IndividualCards)
                            {
                                if (findAce.Rank == "Ace")
                                {

                                    var acePoints = AcePoint(playerHand);
                                    var diffHand = NewerHand(playerHand);
                                    var newScore = diffHand.TotalValue();

                                    score = newScore + acePoints;

                                }
                            }
                        }


                        Console.WriteLine($"Player's score: {score}");


                    }
                    else if (answer == "stand" || answer == "s")
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Score: {score}");
                        // end turn
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

                int scoreD = dealerHand.TotalValue();
                Console.WriteLine("Dealer's Hand");


                foreach (var dealerCard in dealerHand.IndividualCards)
                {

                    Console.WriteLine(dealerCard.Description());

                }


                //add cards to dealer

                Console.WriteLine($"Dealer's Score: {scoreD}");

                if (scoreD > 21)
                {
                    foreach (var findAceD in dealerHand.IndividualCards)
                    {
                        if (findAceD.Rank == "Ace")
                        {

                            var acePointsD = AcePoint(dealerHand);
                            var diffHandD = NewerHand(dealerHand);
                            var newScoreD = diffHandD.TotalValue();

                            scoreD = newScoreD + acePointsD;


                        }
                    }
                }

                while (scoreD < 17 && score <= 21)
                {
                    Console.WriteLine();
                    int newCardSpotD = playerHand.Size() + dealerHand.Size();
                    var newCardD = deck[newCardSpotD];

                    // handD.Add(newCardD);

                    dealerHand.Receive(newCardD);
                    Console.WriteLine(newCardD.Description());
                    scoreD = scoreD + newCardD.Value();
                    // changes aces if needed
                    if (scoreD > 21)
                    {
                        foreach (var findAceD in dealerHand.IndividualCards)
                        {
                            if (findAceD.Rank == "Ace")
                            {

                                var acePointsD = AcePoint(dealerHand);
                                var diffHandD = NewerHand(dealerHand);
                                var newScoreD = diffHandD.TotalValue();

                                scoreD = newScoreD + acePointsD;


                            }
                        }
                    }
                    Console.WriteLine("Dealer's Score: " + scoreD);

                    Console.WriteLine();
                }



                Console.WriteLine();

                // dealer did NOT bust
                if (scoreD <= 21)
                {

                    // player had a higher score and didn't bust
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

                // dealer busts
                else
                {
                    Console.WriteLine("Dealer busts.");
                    Console.WriteLine("Player wins!");
                }

                Console.WriteLine();
                Console.Write("Want to play again? yes/no ");

                string anotherGame = Console.ReadLine().ToLower();

                if (anotherGame == "y" || anotherGame == "yes")
                {
                    Console.WriteLine();
                }
                else
                {
                    playGame = false;
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
