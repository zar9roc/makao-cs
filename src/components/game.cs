//TODO:

/*
    gamemodeKey request (A, J)    
*/

//sensowne ustawienie warunku sprawdzającego czy gracz wygrał
//prywatna metoda sprawdzająca który gracz przegrał


using System;
using System.Collections.Generic;
using System.Linq;

using makao.components.ioSystem;
using makao.components.cards;
using makao.components.player;

/*enum game{
    T_NORMALNY = 0,
    T_POBRANIOWY,
    T_BLOKUJACY,
    T_ASOWY,
    T_J_HANDLOWY,
    T_J_EGZEKUCYJNY

}*/


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
        
        public Game(string nameGame, int playersNb, int cardsNb) {
            name = nameGame;
            numberOfPlayers = playersNb;
            numberOfPlayingPlayers = playersNb;
            numberOfStartingCards = cardsNb;
            stol = new Table(); //else finTable
            gracze = new List<Player>();
            jCheck = new List<bool>();

            //if(findeck )talia = new finDeck(decksNb); 
            /*else*/ talia = new Deck();
            
            for(int i = 1; i <= playersNb; i++) {
                Player gracz = new Player(i);
                gracze.Add(gracz);
                gracze[i - 1].hand = talia.takeCard(cardsNb);
                jCheck.Add(false);
            }
        }
        /*public Game(string nameGame, int playersNb, int cardsNb) {
            Game(nameGame, playersNb, cardsNb, playersNb % 4);
        } 
        public Game(int playersNb, int cardsNb, int decksNb) : this("Gra_"+playersNb+cardsNb,playersNb,cardsNb, decksNb){
        } */


        public string playGame() {
            while(numberOfPlayingPlayers >= 2) {

                ioSystem.ioSystem.kolejNa(currentPlayer);
                
                if(gracze[currentPlayer].stunCount > 0) {
                    gracze[currentPlayer].decreaseStunCount();
                    ioSystem.ioSystem.playerFrozen(currentPlayer,gracze[currentPlayer].stunCount);
                    nextPlayer(currentPlayer);
                    continue;
                }
                switch(gamemode) {
                    case 0:
                    {
                        int playerInput = gracze[currentPlayer].playCard(stol.TopCard, 0);
                        if(playerInput == -1) {
                            ioSystem.ioSystem.playerIdle(currentPlayer);
                            gracze[currentPlayer].hand.Add(talia.takeOneCard());
                            //szybkie przebicie? --GUI
                        } else {
                            stol.TopCard = playerInput; 

                            switch(playerInput % 13) {
                                case 0: //AS
                                {
                                    gamemode = 3;
                                    playerInput = gracze[currentPlayer].requestColor();
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
                                    gamemodeKey = gracze[currentPlayer].requestFigure();
                                    ioSystem.ioSystem.figRequested(currentPlayer,gamemodeKey,false);
                                } break;
                                case 12:
                                {
                                    penaltyStack = 5;
                                    gamemode = 1;
                                } break;
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
                            List<int> penaltyCards = talia.takeCard(penaltyStack);
                            gracze[currentPlayer].hand.Concat(penaltyCards);
                            penaltyStack = 0;
                            gamemode = 0;
                        } else if(input == 11) {
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
                        int playerInput = gracze[currentPlayer].playCard(stol.TopCard, 2);
                        if(playerInput == -1) {
                            gracze[currentPlayer].stunCount = penaltyStack;
                            penaltyStack = 0;
                            gamemode = 0;
                        } else if(playerInput == 11) {
                            penaltyStack = 0;
                            gamemode = 0;
                        } else if(playerInput % 13 == 3) penaltyStack++;
                        //else IO -> coś poszło nie tak
                    } break;
                    case 3: // AS
                    {
                        int playerInput = gracze[currentPlayer].playCard(gamemodeKey, 0);
                        if(playerInput != -1) {
                            gamemode = 0;
                            stol.TopCard = playerInput;
                        } else gracze[currentPlayer].hand.Add(talia.takeOneCard());
                    } break;
                    case 4: // J HANDLOWY
                    {
                        int whileCount = numberOfPlayingPlayers;
                        int yCurrentPlayer = currentPlayer;
                        int playerInput;
                        while (whileCount > 0) {
                            playerInput = gracze[yCurrentPlayer].playCard(gamemodeKey,gamemode);
                            if(playerInput != -1) {
                                stol.TopCard = playerInput;
                                ioSystem.ioSystem.playerMove(yCurrentPlayer,playerInput);
                            }
                            if(playerInput % 13 == gamemodeKey) {
                                whileCount = numberOfPlayingPlayers;
                                jCheck[yCurrentPlayer] = true;
                                gamemode = 5; //ustalona figura żądania
                            } else if (playerInput % 13 == 10) {
                                whileCount = numberOfPlayingPlayers;
                                gamemodeKey = gracze[yCurrentPlayer].requestFigure();
                                ioSystem.ioSystem.figRequested(yCurrentPlayer,gamemodeKey,true);
                            } else whileCount--;
                            
                            yCurrentPlayer = nextPlayer(yCurrentPlayer);
                        }
                        gamemode = 0;
                    }
                    break;
                    case 5: //J EGZEKUCYJNY
                    {
                        int whileCount = numberOfPlayingPlayers;
                        int yCurrentPlayer = currentPlayer;
                        
                        while(whileCount > 0) {
                            if(!jCheck[yCurrentPlayer]) 
                                gracze[yCurrentPlayer].hand.Concat(talia.takeCard(2));
                            else jCheck[yCurrentPlayer] = false;
                            whileCount--;
                        }
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
            if(++round == numberOfPlayers) round = 0;
            while(!gracze[currentPlayer].isPlaying) {
                if(++round == numberOfPlayers) round = 0;
            }
            return round;
        }
    }
}
