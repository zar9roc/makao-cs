//TODO:

//Rozpatrzanie efektów położenia karty w gamemode 0
/* Rozwinięcie: 
    gamemode 1:
    gamemode 2:
    gamemode 3:
    gamemode 4:
    gamemode 5:
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
                        int input = gracze[currentPlayer].playCard(stol.TopCard);
                        if(input == -1) {
                            ioSystem.ioSystem.playerIdle(currentPlayer);
                            gracze[currentPlayer].hand.Add(talia.takeOneCard());
                            //szybkie przebicie?
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
                                    gamemode = 1;
                                } break;
                                case 2: //3
                                {
                                    gamemode = 1;
                                } break;
                                case 3: //4
                                {
                                    gamemode = 2;
                                } break;
                                case 10:
                                {
                                    gamemode = 4;
                                    //prośba o figurę
                                }
                            }
                        }
                    }
                        if(gracze[currentPlayer].hand.Count == 0) 
                            gracze[currentPlayer].isPlaying = false;
                    break;
                    case 1: //PRZEBIJANIE 2,3,K
                        //musisz przebić leżącą kartę, albo pobrać (wiele) kart
                        int lastcard = topCard;
                        //gracz[i].przebijaj(); 
                        if(lastcard == topCard) {
                            //chargestack =0, gracz.dajkarty(charge)
                        } 
                        //czy gracz nie wygrał (może dać to na sam koniec?)
                    break;
                    case 2: // PRZEBIJANIE 4
                    {
                        
                    } break;
                    case 3: // AS
                    {
                        
                    }
                        //musisz wyłożyć żądany kolor, (tryb Asowy)
                    //if(gracz[i].ruszSię(kolor)) {
                    //    gamemode == 0 //ruszsię zwraca prawdę, gdy gracz coś położył, 
                    //                      przez co mechanika asa już niepotrzebna
                    //}
                    break;
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
