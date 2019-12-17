//TODO:

//Rozpatrzanie efektów położenia karty w gamemode 0
/* Rozwinięcie: 
    gamemode 4: JOPEK HANDLOWY
    gamemode 5: JOPEK EGZEKUCYJNY
*/

//sensowne ustawienie warunku sprawdzającego czy gracz wygrał
//prywatna metoda sprawdzająca który gracz przegrał


using System;
using System.Collections.Generic;
using System.Linq;

using makao.components.ioSystem;
using makao.components.cards;
using makao.components.player;


namespace makao.components {
    public class Game {
        string name;
        int numberOfPlayers;
        int numberOfPlayingPlayers;
        int numberOfStartingCards;
        int topCard;
        int currentPlayer;
        int penaltyStack;
        int gamemode;
        int gamemodeKey;
        List<bool> jCheck;

        public Deck talia;
        public Table stol;
        public List<Player> gracze;
        
        public Game(string nameGame, int playersNb, int cardsNb, int decksNb, bool findeck) {
            name = nameGame;
            numberOfPlayers = playersNb;
            numberOfPlayingPlayers = playersNb;
            numberOfStartingCards = cardsNb;
            stol = new Table(); //else finTable

            if(findeck )talia = new finDeck(decksNb); 
            else talia = new Deck();
            
            for(int i = 0; i < playersNb; i++) {
                gracze.Add(new Player());
                gracze[i].hand = talia.takeCard(cardsNb);
                jCheck.Add(false);
            }
        }
        public Game(string nameGame, int playersNb, int cardsNb) {
            Game(nameGame, playersNb, cardsNb, playersNb % 4);
        }
        public Game(int playersNb, int cardsNb, int decksNb) : this("Gra_"+playersNb+cardsNb,playersNb,cardsNb, decksNb){
        }


        public string playGame() {
            while(numberOfPlayingPlayers >= 2) {

                ioSystem.ioSystem.kolejNa(currentPlayer);
                
                if(gracze[currentPlayer].StunCount) {
                    gracze[currentPlayer].decreaseStunCount();
                    nextPlayer();
                    continue;
                }
                switch(gamemode) {
                    case 0:
                    {
                        int input = gracze[currentPlayer].playCard(stol.TopCard, 0);
                        if(input == -1) {
                            ioSystem.ioSystem.playerIdle(currentPlayer);
                            gracze[currentPlayer].hand.Add(talia.takeOneCard());
                            //szybkie przebicie? --GUI
                        }
                        else {
                            stol.TopCard = input; 

                            switch(input % 13) {
                                case 0: //AS
                                {
                                    gamemode = 3;
                                    //io: podaj kolor, na który zmieniasz
                                } break;
                                case 1: //2
                                {
                                    penaltyStack = 2;
                                    gamemode = 1;
                                } break;
                                case 2: //3
                                {
                                    penaltyStack = 3;
                                    gamemode = 1;
                                } break;
                                case 3: //4
                                {
                                    penaltyStack = 1;
                                    gamemode = 2;
                                } break;
                                case 10:
                                {
                                    gamemode = 4;
                                    //prośba o figurę
                                }
                                case 12:
                                {
                                    penaltyStack = 5;
                                    gamemode = 1;
                                }
                            }
                        }
                    }
                        if(gracze[currentPlayer].hand.Count == 0) 
                            gracze[currentPlayer].isPlaying = false;
                    break;
                    case 1: //PRZEBIJANIE 2,3,K
                        //musisz przebić leżącą kartę, albo pobrać (wiele) kart
                        int input = gracze[currentPlayer].playCard(stol.TopCard, 1);
                        if(input == -1) {
                            gracze[currentPlayer].hand.Add(talia.takeCard(penaltyStack));
                            penaltyStack = 0;
                            gamemode = 0;
                        }
                        else if(input % 13 == 1) penaltyStack += 2;
                        else if(input % 13 == 2) penaltyStack += 3;
                        else if(input % 13 == 12) penaltyStack += 5;
                        //else IO -> coś poszło nie tak

                        if(input != -1) stol.TopCard = input;

                        
                        //czy gracz nie wygrał (może dać to na sam koniec?)
                    break;
                    case 2: // PRZEBIJANIE 4
                    {
                        int input = gracze[currentPlayer].playCard(stol.TopCard, 2);
                        if(input == -1) {
                            gracze[currentPlayer].StunCount = penaltyStack;
                            penaltyStack = 0;
                            gamemode = 0;
                        }
                        else if(input % 13 == 3) penaltyStack++;
                        //else IO -> coś poszło nie tak
                    } break;
                    case 3: // AS
                    {
                        int input = gracze[currentPlayer].playCard(gamemodeKey, 0);
                        if(input != -1) {
                            gamemode = 0;
                            stol.TopCard = input;
                        } else gracze[currentPlayer].hand.Add(talia.takeOneCard());
                    } break;
                    case 4: // J HANDLOWY
                    {
                        int whileCount = numberOfPlayingPlayers;
                        int yCurrentPlayer = currentPlayer;
                        while (whileCount) {
                            int lastcard = topCard;
                            //gracz rusza się wg trybu handlowego jopka
                            if(lastcard == topCard) { //TODO: Zamienić mechanikę lastCard na zwrot funkcji
                                whileCount--;
                            }
                            else whileCount = numberOfPlayingPlayers;
                            yCurrentPlayer = nextPlayer(yCurrentPlayer);
                        }
                        //tutaj powinien być własny while(loop) żeby nie gubić kolejki graczy
                    //tryb jopkowy handlowy
                        gamemode = 0;
                    }
                    break;
                    case 5: //J EGZEKUCYJNY
                    {
                        int whileCount = numberOfPlayingPlayers;
                        int yCurrentPlayer = currentPlayer;
                        //tutaj też własny loop
                    //tryb jopkowy egzekucyjny
                        gamemode = 0;
                    }
                    break;
                }

                //if (player[i].cards == 0) player win, 

                //WYDRUK INFO O RĘKACH WSZYSTKICH GRACZY
                
                currentPlayer = nextPlayer(currentPlayer);
                
            }
            //sprawdz ktory gracz przegrał
            return "zadengracz";
        }

        private int nextPlayer(int round) {
            if(++round == numberOfPlayers) roun = 0;
            while(!gracze[currentPlayer].isPlaying) {
                if(++round == numberOfPlayers) round = 0;
            }
            return round;
        }
    }
}
