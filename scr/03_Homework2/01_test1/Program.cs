using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackjack
{
    //Create an enum to hold suit types
    public enum SUIT
    {
        SPADES = 1,
        CLUBS,
        DIAMONDS,
        HEARTS
    };

    //enum for card names
    public enum NAME
    {
        ACE,
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        highACE
    };

    public class Card
    {


        //card variabeles
        private int value = 0;
        private SUIT suit;
        private NAME name;
        bool isFaceUp = false;
        string location = "Deck";

        //Accessor methods for setting values
        public void SetSuit(SUIT cardSuit)
        {
            suit = cardSuit;
        }

        public void SetName(NAME cardName)
        {
            name = cardName;
        }

        public void SetValue(int cardValue)
        {
            value = cardValue;
        }

        public void SetLocation(string newLocation)
        {
            location = newLocation;
        }

        public void SetFaceUp(bool newFaceUp)
        {
            isFaceUp = newFaceUp;
        }


        //Accessor methods for retrieving values
        public SUIT GetSuit()
        {
            SUIT newSuit = suit;
            return newSuit;
        }

        public NAME GetName()
        {
            NAME newName = name;
            return newName;
        }

        public int GetValue()
        {
            int newValue = value;
            return newValue;
        }

        public string GetLocation()
        {
            return location;
        }

        public bool GetFaceUp()
        {
            return isFaceUp;
        }


        //METHODS
        public void Display()
        {
            Console.WriteLine("{0} of {1}", GetName(), GetSuit(), GetValue());
        }
    }//end Card   


    public class Deck
    {
        private Card[,] newDeck = new Card[5, 15];
        private SUIT[] suitArray = new SUIT[5];
        private NAME[] nameArray = new NAME[17];

        //METHODS
        //Create a new deck
        public void Create()
        {

            suitArray[1] = SUIT.CLUBS;
            suitArray[2] = SUIT.SPADES;
            suitArray[3] = SUIT.DIAMONDS;
            suitArray[4] = SUIT.HEARTS;

            nameArray[1] = NAME.ONE;
            nameArray[2] = NAME.TWO;
            nameArray[3] = NAME.THREE;
            nameArray[4] = NAME.FOUR;
            nameArray[5] = NAME.FIVE;
            nameArray[6] = NAME.SIX;
            nameArray[7] = NAME.SEVEN;
            nameArray[8] = NAME.EIGHT;
            nameArray[9] = NAME.NINE;
            nameArray[10] = NAME.TEN;
            nameArray[11] = NAME.JACK;
            nameArray[12] = NAME.QUEEN;
            nameArray[13] = NAME.KING;
            nameArray[14] = NAME.ACE;

            //Iterate through the deck array assigning values, suits, and names
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("\n\n\n");
                for (int j = 1; j <= 14; j++)
                {

                    newDeck[i, j] = new Card();
                    newDeck[i, j].SetSuit(suitArray[i]);
                    newDeck[i, j].SetValue(j);
                    newDeck[i, j].SetName(nameArray[j]);
                    if (j > 10)
                    {
                        newDeck[i, j].SetValue(10);
                    }

                    if (j == 14)
                    {
                        newDeck[i, j].SetValue(11);
                    }

                }

            }//end outer for loop

        }//end Create

        //Display the deck that was created so that I can make sure the creation method is working properly
        public void DisplayDeck()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("\n\n\n");
                for (int j = 1; j <= 14; j++)
                {
                    newDeck[i, j].Display();
                }
            }
        }

        //Accessor Method
        public Card[,] GetDeck()
        {
            return newDeck;
        }

    }//end Deck

    public class Player
    {

        private string gameStatus = "none";

        //METHODS

        //This checks for a bust and is separated from the CheckForWin so that it can be used
        //midgame to determine whether anyone has busted.
        public string CheckForBust(ref Deck newDeck, ref Card[] dHand, ref Card[] bHand, ref int newBalance, ref int bet, ref int bCardCount, ref int dCardCount)
        {
            int winnings = 0;

            if ((CalcHandValue(ref dHand, ref dCardCount) > 21))
            {
                Console.WriteLine("\nDEALER BUSTS.\n");
                winnings = bet * 2;
                newBalance += winnings;
                Console.WriteLine("Your new balance is {0}", newBalance);
                bet = 0;
                gameStatus = "bust";
                return gameStatus;


            }

            else if ((CalcHandValue(ref bHand, ref bCardCount) > 21))
            {
                Console.WriteLine("\nYOU BUST!");
                newBalance -= bet;
                Console.WriteLine("\nYour new balance is {0}.\n", newBalance);
                bet = 0;
                gameStatus = "bust";
                return gameStatus;

            }

            else
            {
                gameStatus = "none";
                return gameStatus;
            }



        }





        //Checks for a winner and if there is a winner then it gives the appropriate message and adjusts the balance.
        public void CheckForWin(ref Card[] bHand, ref Card[] dHand, ref int newBalance, ref int bet, ref int bCardCount, ref int dCardCount)
        {
            int winnings = 0;

            //The first two statements give preference to natural blackjacks (or 21 in the first two cards).
            if ((bCardCount < 3) & (CalcHandValue(ref bHand, ref bCardCount) == 21) & (dCardCount < 3) & (CalcHandValue(ref dHand, ref dCardCount) == 21))
            {
                Console.WriteLine("Dealer and Bettor get BLACKJACK... It's a tie!");

                Console.WriteLine("\nYour new balance is {0}.\n", newBalance);
            }

            else if ((bCardCount < 3) & (CalcHandValue(ref bHand, ref bCardCount) == 21))
            {
                Console.WriteLine("Bettor has a BLACKJACK!");
                Console.WriteLine("Bettor WINS!!!");
                winnings = (bet * 3);
                newBalance += winnings;
                Console.WriteLine("\nYour new balance is {0}.\n", newBalance);
            }

            else if ((dCardCount < 3) & (CalcHandValue(ref dHand, ref dCardCount) == 21))
            {
                Console.WriteLine("Dealer has a BLACKJACK!");
                Console.WriteLine("Dealer WINS!!!");
                newBalance -= bet;
                Console.WriteLine("\nYour new balance is {0}.\n", newBalance);
            }

            else if ((CalcHandValue(ref bHand, ref bCardCount) == (CalcHandValue(ref dHand, ref dCardCount))))
            {


                Console.WriteLine("\nIT'S A TIE!\n");
                Console.WriteLine("\nYour new balance is {0}.\n", newBalance);

            }

            else if ((CalcHandValue(ref dHand, ref dCardCount)) > (CalcHandValue(ref bHand, ref bCardCount)))
            {

                newBalance -= bet;
                Console.WriteLine("\nTHE DEALER WINS.\n");
                Console.WriteLine("\nYour new balance is {0}.\n", newBalance);

            }

            else if ((CalcHandValue(ref dHand, ref dCardCount)) < (CalcHandValue(ref bHand, ref bCardCount)))
            {

                winnings = bet * 2;
                newBalance += winnings;
                Console.WriteLine("The bet was: {0}", bet);
                Console.WriteLine("YOU WON!");
                Console.WriteLine("Your new balance is {0}", newBalance);
            }

        }

        //Take a hand and a card count, then display it
        public void DisplayHand(ref Card[] newHand, ref int cardCount)
        {

            for (int i = 0; i < cardCount; i++)
            {
                newHand[i].Display();
            }


        }


        //Takes a hand and a cardcount and determines the total value of the hand
        public int CalcHandValue(ref Card[] hand, ref int cardCount)
        {
            int handValue = 0;

            for (int i = 0; i < cardCount; i++)
            {
                //This adjusts the aces to the correct value based on the total value of the hand
                if (hand[i].GetValue() == 11)
                {
                    if (handValue > 10)
                    {
                        hand[i].SetValue(1);
                    }
                }

                handValue += hand[i].GetValue();

            }

            return handValue;

        }//end CalcHandValue



        public void DisplayBettorValue(ref Card[] bHand, Bettor newBettor, ref int cardCount)
        {
            Console.WriteLine("\nYOUR HAND VALUE IS: {0}", newBettor.CalcHandValue(ref bHand, ref cardCount));
        }

        public void DisplayDealerValue(ref Card[] dHand, Dealer newDealer, ref int cardCount)
        {
            Console.WriteLine("\nTHE DEALER'S HAND VALUE IS: {0}", newDealer.CalcHandValue(ref dHand, ref cardCount));

        }

    }

    public class Dealer : Player
    {

        Random RandomClass = new Random();

        //METHODS
        //Adds cards to the the bettor's hand by adding cards to the bHand array
        public void DealToBettor(Card[,] newDeck, ref Card[] bHand, ref int bCardCount)
        {
            bool doneDealing = false;
            do
            {
                int RandomNumberOne = RandomClass.Next(1, 4);
                int RandomNumberTwo = RandomClass.Next(1, 15);

                //I'm comparing to boolean literals again... AGGHHH!!!!
                if (newDeck[RandomNumberOne, RandomNumberTwo].GetFaceUp() == false)
                {
                    newDeck[RandomNumberOne, RandomNumberTwo].SetLocation("Bettor");
                    newDeck[RandomNumberOne, RandomNumberTwo].SetFaceUp(true);
                    bHand[bCardCount] = newDeck[RandomNumberOne, RandomNumberTwo];
                    bCardCount++;
                    doneDealing = true;

                }
            } while (!doneDealing);
        }

        //Adds cards to the the deaer's hand by adding cards to the dHand array
        public void DealToDealer(Card[,] newDeck, ref Card[] dHand, ref int dCardCount)
        {
            bool doneDealing = false;

            do
            {
                int RandomNumberOne = RandomClass.Next(1, 4);
                int RandomNumberTwo = RandomClass.Next(1, 15);

                //I'm comparing to boolean literals again... AGGHHH!!!!
                if (newDeck[RandomNumberOne, RandomNumberTwo].GetFaceUp() == false)
                {
                    newDeck[RandomNumberOne, RandomNumberTwo].SetLocation("Dealer");
                    newDeck[RandomNumberOne, RandomNumberTwo].SetFaceUp(true);
                    dHand[dCardCount] = newDeck[RandomNumberOne, RandomNumberTwo];
                    dCardCount++;
                    doneDealing = true;
                }
            } while (!doneDealing);
        }




        public void Turn(ref Deck newDeck, ref Card[] dHand, ref Card[] bHand, Bettor newBettor, Dealer newDealer, ref int balance, ref int bet, ref int bCardCount, ref int dCardCount)
        {
            bool turnOver = false;

            CheckForBust(ref newDeck, ref dHand, ref bHand, ref balance, ref bet, ref bCardCount, ref dCardCount);

            //Only continue with the dealer's turn if the bettor has not already busted
            if (CalcHandValue(ref bHand, ref bCardCount) <= 21)
            {
                //Console.WriteLine("\nTHE PLAYER HANDVALUE IS: {0}", CalcHandValue(ref bHand, ref bCardCount));
                Console.WriteLine("\n\n********** THE DEALER IS NOW ACTING **********");

                this.DealToDealer(newDeck.GetDeck(), ref dHand, ref dCardCount);
                Console.WriteLine("\nDealer's hand is now: ");
                this.DisplayHand(ref dHand, ref dCardCount);
                this.CalcHandValue(ref dHand, ref dCardCount);
                this.DisplayDealerValue(ref dHand, newDealer, ref dCardCount);
                Console.ReadLine();

                do
                {
                    if (CalcHandValue(ref dHand, ref dCardCount) < 17)
                    {
                        Console.WriteLine("\n\n********** THE DEALER HITS **********");
                        this.DealToDealer(newDeck.GetDeck(), ref dHand, ref dCardCount);
                        this.DisplayHand(ref dHand, ref dCardCount);
                        this.CalcHandValue(ref dHand, ref dCardCount);
                        this.DisplayDealerValue(ref dHand, newDealer, ref dCardCount);
                        Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("\n\n********** THE DEALER STANDS **********");
                        turnOver = true;
                    }
                } while (!turnOver);

                //if the dealer has not busted, check for a win, otherwise check for a bust
                if (CalcHandValue(ref dHand, ref dCardCount) <= 21)
                {
                    this.CheckForWin(ref bHand, ref dHand, ref balance, ref bet, ref bCardCount, ref dCardCount);
                }
                else
                {
                    CheckForBust(ref newDeck, ref dHand, ref bHand, ref balance, ref bet, ref bCardCount, ref dCardCount);
                }
            }//end Turn

        }//end if

    }




    public class Bettor : Player
    {
        //METHODS
        //Gets a bet from the bettor and makes sure it is in range
        public void GetBet(ref int balance, ref int bet)
        {
            bool betValid = false;

            do
            {
                Console.WriteLine("You have {0} dollars", balance);
                Console.WriteLine("How much would you like to bet?");
                bet = Convert.ToInt32(Console.ReadLine());
                if ((bet <= balance) & (bet > 0))
                {

                    betValid = true;
                }
                else
                {
                    betValid = false;
                }
            } while (!betValid);
        }


        public void Turn(ref Deck newDeck, ref Card[] bHand, ref Card[] dHand, Dealer newDealer, Bettor newBettor, ref int balance, ref int bet, ref int bCardCount, ref int dCardCount)
        {
            //variables
            string playerResponse = "none";
            bool turnOver = false;

            //Give the dealer one card and show it to the bettor
            newDealer.DealToDealer(newDeck.GetDeck(), ref dHand, ref dCardCount);
            Console.WriteLine("\nTHE DEALER SHOWS A:\n ");
            newDealer.DisplayHand(ref dHand, ref dCardCount);


            Console.WriteLine("\n\n---------- THE DEALER DEALS TWO CARDS TO YOU -----------");

            Console.WriteLine("\nYour bet was {0}.\n", bet);
            Console.WriteLine("\nYour hand is: ");

            //Have the dealer deal two cards to the bettor
            newDealer.DealToBettor(newDeck.GetDeck(), ref bHand, ref bCardCount);
            newDealer.DealToBettor(newDeck.GetDeck(), ref bHand, ref bCardCount);

            //Display the hand as well as the value of the hand
            this.DisplayHand(ref bHand, ref bCardCount);
            this.CalcHandValue(ref bHand, ref bCardCount);
            this.DisplayBettorValue(ref bHand, newBettor, ref bCardCount);


            do
            {
                //Only give the player the prompt if they are not already over 21
                if ((this.CalcHandValue(ref bHand, ref bCardCount) < 21))
                {
                    //Only provide the text that includes doubling down if the player has only two cards in their hand
                    if ((bCardCount < 3) & (playerResponse != "dd"))
                    {
                        Console.WriteLine("\nWould you like to Hit(h), Stand (s), Double Down (dd)?\n");
                    }
                    else
                    {
                        Console.WriteLine("\nWould you like to Hit(h) or Stand(s) ?\n");
                    }
                    playerResponse = Console.ReadLine();
                }
                else
                {
                    turnOver = true;
                }

                if (!turnOver)
                {
                    //process player response
                    switch (playerResponse)
                    {
                        case "H":
                            //This if statement prevents the player from hitting again if they are over 21
                            if (this.CalcHandValue(ref bHand, ref bCardCount) < 21)
                            {
                                newDealer.DealToBettor(newDeck.GetDeck(), ref bHand, ref bCardCount);
                                this.DisplayHand(ref bHand, ref bCardCount);
                                this.CalcHandValue(ref bHand, ref bCardCount);
                                this.DisplayBettorValue(ref bHand, newBettor, ref bCardCount);
                            }
                            else
                            {
                                //Ends the turn if the player is over 21
                                turnOver = true;
                            }
                            break;
                        case "h":
                            //This if statement prevents the player from hitting again if they are over 21
                            if (this.CalcHandValue(ref bHand, ref bCardCount) < 21)
                            {
                                newDealer.DealToBettor(newDeck.GetDeck(), ref bHand, ref bCardCount);
                                this.DisplayHand(ref bHand, ref bCardCount);
                                this.CalcHandValue(ref bHand, ref bCardCount);
                                this.DisplayBettorValue(ref bHand, newBettor, ref bCardCount);
                            }
                            else
                            {
                                //Ends the turn if the player is over 21
                                turnOver = true;
                            }
                            break;
                        case "s":
                            Console.WriteLine("\nYou have chosen to stand");
                            this.CalcHandValue(ref bHand, ref bCardCount);
                            turnOver = true;
                            this.DisplayBettorValue(ref bHand, newBettor, ref bCardCount);
                            Console.ReadLine();
                            break;
                        case "S":
                            Console.WriteLine("\nYou have chosen to stand");
                            this.CalcHandValue(ref bHand, ref bCardCount);
                            turnOver = true;
                            this.DisplayBettorValue(ref bHand, newBettor, ref bCardCount);
                            Console.ReadLine();
                            break;
                        case "dd":
                            //Only allow doubling down if the player has 2 cards
                            if (bCardCount < 3)
                            {
                                Console.WriteLine("\nYour original bet was {0}", bet);
                                Console.WriteLine("How much additional money would you like to bet? (Only up to original bet)");
                                bet += Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("You have now bet {0}", bet);
                            }
                            else
                            {
                                Console.WriteLine("Doubling down is only available when you have just two cards in your hand.");
                            }
                            break;

                        case "DD":
                            //Only allow doubling down if the player has 2 cards    
                            if (bCardCount < 3)
                            {
                                Console.WriteLine("\nYour original bet was {0}", bet);
                                Console.WriteLine("How much additional money would you like to bet? (Only up to original bet)");
                                bet += Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("You have now bet {0}", bet);
                            }
                            else
                            {
                                Console.WriteLine("Doubling down is only available when you have just two cards in your hand.");
                            }
                            break;
                        default:
                            Console.WriteLine("That is not a valid response.");
                            break;

                    }
                }

                //Continue getting player responses until the turn is over
            } while (!turnOver);

            //Remind the player of the dealer's value
            this.DisplayDealerValue(ref dHand, newDealer, ref dCardCount);

        }//end Turn


    }



    public class GameLoop
    {


        public void Run()
        {
            string playerAnswer = "none";
            int gameBalance = 250;

            do
            {


                Console.WriteLine("\n\n\n\n\nWELCOME TO ANEXA'S BLACKJACK GAME!\n");


                int bet = 0;

                //Keeps track of how many cards the dealer or bettor has
                int bCardCount = 0;
                int dCardCount = 0;

                Deck gameDeck = new Deck();
                Card[] bettorHand = new Card[12];
                Card[] dealerHand = new Card[12];
                Bettor gameBettor = new Bettor();
                Dealer gameDealer = new Dealer();

                //gameDeck.Display();
                gameDeck.Create();

                gameBettor.GetBet(ref gameBalance, ref bet);

                //Allow the bettor to go and then the dealer and pass in the game information to their turn methods
                gameBettor.Turn(ref gameDeck, ref bettorHand, ref dealerHand, gameDealer, gameBettor, ref gameBalance, ref bet, ref bCardCount, ref dCardCount);
                gameDealer.Turn(ref gameDeck, ref dealerHand, ref bettorHand, gameBettor, gameDealer, ref gameBalance, ref bet, ref bCardCount, ref dCardCount);






                Console.WriteLine("Would you like to play again? (y or n)");
                playerAnswer = Console.ReadLine();

                if (gameBalance <= 0)
                {
                    Console.WriteLine("\nYou lost all of your money!");

                    if (playerAnswer == "y")
                    {
                        Console.WriteLine("Time for a refill!");
                        gameBalance = 250;
                        Console.ReadLine();
                    }

                }


            } while (playerAnswer != "n");

        }//end Run()


        static void Main()
        {
            //Create an instance of the gameloop class and run it
            GameLoop g = new GameLoop();
            g.Run();
        }

    }//End GameLoop 
}
