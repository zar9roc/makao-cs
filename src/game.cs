using System;
namespace makao.game {
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

            //TOFDOdodać przeciążenie konstruktora bez wybranej liczby talii, 
            //niech sobie sam policzy pasującą ilość
        }
        public Game(string nameGame, int playersNb, int cardsNb) {
            Game(nameGame, playersNb, cardsNb, playersNb % 4);
        }
        public Game(int playersNb, int cardsNb, int decksNb) : this("Gra_"+playersNb+cardsNb,playersNb,cardsNb, decksNb){

        }


        public string playGame() {
            while(numberOfPlayingPlayers >= 2) {
                //ogłaszanie ruchu gracza nr #
                if(gracze.at(currentPlayer).getStunCount()) {
                    gracze.at(currentPlayer).decreaseStunCount(); //coś mi linker szwankuje 
                    //nextPlayer();
                    continue;
                }
                switch(gamemode) {
                    case 0:

                        break;
                    case 1:
                        
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;

                }
                if(gamemode == 0) { //taa, mogę to zrobić switch:case
                    //normalny przebieg tury danego gracza
                    //gracz[i].ruszSię(); //albo i nie, kiedy ma kolejkę
                } else if (gamemode == 1) {
                    //musisz przebić leżącą kartę, albo się poddać
                    //gracz[i].przebijaj(); //chyba że śpi to nie przebija
                } else if (gamemode == 2) {
                    //musisz wyłożyć żądany kolor, (tryb Asowy)
                    //if(gracz[i].ruszSię(kolor)) {
                    //    gamemode == 0 //ruszsię zwraca prawdę, gdy gracz coś położył, 
                    //                      przez co mechanika asa już niepotrzebna
                    //}
                } else if (gamemode == 3) {
                    //tutaj powinien być własny while(loop) żeby nie gubić kolejki graczy
                    //tryb jopkowy handlowy
                } else if (gamemode == 4) {
                    //tutaj też własny loop
                    //tryb jopkowy egzekucyjny
                }
                //if (player[i].cards == 0) player win, numberofplayingplayers--
                //nextPlayer();
            }
            return "zadengracz";
        }

        public int getTopCard() {
            return topCard;
        }
    }
}
