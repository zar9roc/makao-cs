using System;
using System.Collections.Generic;
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

        public Deck talia;
        public Table stol;
        public List<Player> gracze;
        
        public Game(string nameGame, int playersNb, int cardsNb, int decksNb, bool findeck) {
            name = nameGame;
            numberOfPlayers = playersNb;
            numberOfPlayingPlayers = playersNb;
            numberOfStartingCards = cardsNb;
            stol = new Table(); 

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

                //ogłaszanie ruchu gracza nr #
                ioSystem.ioSystem.kolejNa(currentPlayer);
                
                if(gracze[currentPlayer].StunCount) {
                    gracze[currentPlayer].decreaseStunCount();
                    nextPlayer();
                    continue;
                }
                switch(gamemode) {
                    case 0:
                    //normalny przebieg tury danego gracza
                    //gracz[i].ruszSię(); 
                    if(gracze[currentPlayer].hand.Count == 0) gracze[currentPlayer].isPlaying = false;

                    break;
                    case 1:
                        //musisz przebić leżącą kartę, albo pobrać (wiele) kart
                        int lastcard = topCard;
                        //gracz[i].przebijaj(); 
                        if(lastcard == topCard) {
                            //chargestack =0, gracz.dajkarty(charge)
                        } 
                        //czy gracz nie wygrał (może dać to na sam koniec?)
                    break;
                    case 2:
                    {
                        
                    }
                        //musisz wyłożyć żądany kolor, (tryb Asowy)
                    //if(gracz[i].ruszSię(kolor)) {
                    //    gamemode == 0 //ruszsię zwraca prawdę, gdy gracz coś położył, 
                    //                      przez co mechanika asa już niepotrzebna
                    //}
                    break;
                    case 3:
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
                    case 4:
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
                currentPlayer = nextPlayer(currentPlayer);
                
            }
            //sprawdz ktory gracz nie wygrał
            return "zadengracz";
        }

        private int nextPlayer(int round) {
            if(++round == numberOfPlayers) roun = 0;
            while(!gracze[currentPlayer].isPlaying) {
                if(++round == numberOfPlayers) round = 0;
            }
            return round;
        }

        public int getTopCard() {
            return topCard;
        }
    }
}
