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
                gracze.Add(new player());
                for(int j=0; j < cardsNb; j++) {
                    talia.drawCard(gracze[j]);
                }
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
                IO.kolejNa(currentPlayer);
                
                if(gracze[currentPlayer].getStunCount()) {
                    gracze[currentPlayer].decreaseStunCount();
                    nextPlayer();
                    continue;
                }
                switch(gamemode) {
                    case 0:
                    //normalny przebieg tury danego gracza
                    //gracz[i].ruszSię(); 

                    break;
                    case 1:
                        //musisz przebić leżącą kartę, albo się poddać
                        //gracz[i].przebijaj(); //chyba że śpi to nie przebija
                    break;
                    case 2:
                        //musisz wyłożyć żądany kolor, (tryb Asowy)
                    //if(gracz[i].ruszSię(kolor)) {
                    //    gamemode == 0 //ruszsię zwraca prawdę, gdy gracz coś położył, 
                    //                      przez co mechanika asa już niepotrzebna
                    //}
                    break;
                    case 3:
                        //tutaj powinien być własny while(loop) żeby nie gubić kolejki graczy
                    //tryb jopkowy handlowy
                    break;
                    case 4:
                        //tutaj też własny loop
                    //tryb jopkowy egzekucyjny
                    break;

                }

                //if (player[i].cards == 0) player win, 
                nextPlayer();
                
            }
            //sprawdz ktory gracz nie wygrał
            return "zadengracz";
        }

        private void nextPlayer() {
            if(++currentPlayer == numberOfPlayers) currentPlayer = 0;
            while(!gracze[currentPlayer].isPlaying) {
                if(++currentPlayer == numberOfPlayers) currentPlayer = 0;
            }
        }

        public int getTopCard() {
            return topCard;
        }
    }
}
