using System;
using System.Collections.Generic;

namespace cards
{
    public class Table
    {
        Player house = new Player("House", 0);
        public List<Player> players = new List<Player>();
        Deck deck = new Deck();

        public Table() 
        {
        }

        private void JoinGame(Player player) {
            if (!players.Contains(player)){
                players.Add(player);
            }
            
        }

        public void PlayGame() {
            if (players.Count == 0) {
                return;
            }
            ResetPlayers();
            deck.Reset();
            deck.Shuffle();

            GetBets();

            DealCards();
            if (HouseHas21()) {
                Console.WriteLine("*** House was dealt a blackjack and immediately wins!!! ***");
                DisplayHand(house);
                return;
            }

            //Show houses top card
            DisplayHouseHand();

            APause();

            PlayersGonnaPlay();



            //House hits as needed
            HousePlays();

            //Score game and end
            Console.WriteLine("");
            
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$RESULTS$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("");


            house.score = GetHandsBestScore(house.hand);
            Console.WriteLine($"*** {house.name} is up {house.purse} FRANCO-COINS so far!!! ***");
            DisplayHand(house);
            Console.WriteLine("");

            Console.WriteLine($"*** House scored: {house.score} ***");

            
            foreach (Player player in players) {
                

                Console.WriteLine($"*** {player.name} scored: {player.score} ***");
                
                DisplayHand(player);

                if (player.score > house.score && player.score <= 21 || house.score > 21 && player.score <= 21) {
                    player.purse += player.bet;
                    house.purse -= player.bet;
                    Console.WriteLine($"*** {player.name} WON {player.bet} FRANCO-COINS and has {player.purse} FRANCO-COINS left in purse!!! ***");
                    
                }
                else {
                    player.purse -= player.bet;
                    house.purse += player.bet;
                    Console.WriteLine($"*** {player.name} LOST {player.bet} FRANCO-COINS and has {player.purse} FRANCO-COINS left in purse!!! ***");

                }

                Console.WriteLine("");
            }

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$RESULTS$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("");

            for (int i = 0; i < players.Count; i++) {
                if (players[i].purse < 1) {
                    Console.WriteLine($"*** {players[i].name} has been booted from the table for insufficient funds! ***");
                    players.RemoveAt(i);
                    
                }
            }
        }

        private void HousePlays() {
            house.score = GetHandsBestScore(house.hand);
            DisplayHand(house);
            
            APause();

            while (house.score < 17 ) {
                Card drew = house.Draw(deck.Deal());
                Console.WriteLine($"*** {house.name} had to hit and drew a {drew.name} ***");
                Console.WriteLine("");
                house.score = GetHandsBestScore(house.hand);

                DisplayHand(house);

                if (house.score > 21) {
                    Console.WriteLine($"*** {house.name} BUST!!! ***");
                    Console.WriteLine("");
                }
                Console.WriteLine("*** Press any key to continue... ***");
                Console.ReadKey(true);

            }
        }

        private void DealCards() {
            //Deal first card to everyone
            foreach (Player player in players) {
                player.Draw(deck.Deal());
            }
            house.Draw(deck.Deal());

            //Deal second card to everyone
            foreach (Player player in players) {
                player.Draw(deck.Deal());
            }
            house.Draw(deck.Deal());

        }

        private void GetBets() {
            foreach (Player player in players) {
                Console.WriteLine($"*** {player.name} has {player.purse} in purse. ***");
                Console.WriteLine($"*** How much does {player.name} want to bet? (Minimum bet of 1) ***");
                Console.WriteLine("");
                String userinput = Console.ReadLine();
                int bet;
                if (int.TryParse(userinput, out bet)) {
                    if (bet > player.purse) {
                        player.bet = player.purse;
                    } 
                    else {
                        player.bet = bet;
                    }
                } else {
                    player.bet = 1;
                }
                
                Console.WriteLine($"*** {player.name} has bet {player.bet}. ***");
                Console.WriteLine("");

            }
        }

        private bool HouseHas21() {
            if (GetHandsBestScore(house.hand) == 21) {
                return true;
            }
            return false;
        }

        private int GetHandsBestScore(List<Card> hand) {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in hand) {
                if (card.stringVal == "A") {
                    aceCount++;
                }
                total += card.blackJackVal;
            }

            while(total > 21 && aceCount > 0) {
                total -= 10;
                aceCount--;
            }

            return total;

        }

        private void DisplayHand(Player player) {
            Console.Write($"*** {player.name} has: ");
            foreach (Card card in player.hand) {
                Console.Write($"{card.name} ");
            }
            Console.WriteLine(" ***");
            Console.WriteLine("");
        }

        private void DisplayHouseHand() {
            Console.WriteLine($"*** {house.name} has one hidden card and: {house.hand[1].name} ***");
            Console.WriteLine("");

        }

        private void PlayersGonnaPlay() {
            foreach (Player player in players) {
                bool stillGoing = true;

                player.score = GetHandsBestScore(player.hand);
                DisplayHand(player);

                while(player.score < 21 && stillGoing) {


                    bool gotInput = false;

                    while (!gotInput) {
                        Console.WriteLine($"*** {player.name}, please enter 'h' to hit or 's' to stand. ***");
                        Console.WriteLine("");
                        
                        
                        ConsoleKeyInfo cki = Console.ReadKey(true);
                        //player hits
                        if (cki.KeyChar == 'h' || cki.KeyChar == 'H') {
                            gotInput = true;
                            Card drew = player.Draw(deck.Deal());
                            player.score = GetHandsBestScore(player.hand);
                            
                            
                            Console.WriteLine($"{player.name} just hit and drew a {drew.name}");
                            Console.WriteLine("");

                            DisplayHand(player);
                        } 
                        //player stands
                        else if (cki.KeyChar == 's' || cki.KeyChar == 'S') {
                            stillGoing = false;
                            gotInput = true;

                            Console.WriteLine($"{player.name} chose to STAND.");
                            Console.WriteLine("");
                        }
                        else {
                            Console.WriteLine("Invalid input");
                            Console.WriteLine("");
                            
                        }
                    

                    }

                }

                if (player.score > 21) {
                    Console.WriteLine($"{player.name} BUST!");
                    Console.WriteLine("");
                }

                Console.WriteLine($"{player.name}'s turn is over, press any key to continue...");
                Console.WriteLine("");
                Console.ReadKey(true);



            }
        }

        private void APause() {
            Console.WriteLine("*** Press any key to continue... ***");
            Console.WriteLine("");
            Console.ReadKey(true);
        }

        private void ResetPlayers() {
            foreach (Player player in players) {
                player.hand.Clear();

            }
            house.hand.Clear();
        }

        public void AddPlayer() {
            Console.WriteLine("*** Please add player name: ***");
            Console.WriteLine("");
            String name = Console.ReadLine();
            Console.WriteLine("*** Please add buy-in amount: ***");
            Console.WriteLine("");
            String userinput = Console.ReadLine();
            int buy;
            if (int.TryParse(userinput, out buy)) {
                this.JoinGame(new Player(name, buy));
            } else {
                this.JoinGame(new Player(name, 100));
            };

        }
    }
}