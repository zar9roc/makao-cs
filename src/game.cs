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
        
        public Game(string nameGame, int playersNb, int cardsNb) {
            name = nameGame;
            numberOfPlayers = playersNb;
            numberOfPlayingPlayers = playersNb;
            numberOfStartingCards = cardsNb;
            talia = new Deck();
            stol = new Table();
            for(int i = 0; i < playersNb; i++) {
                gracze.Add(new player());
            }
            //TOFDOdodać przeciążenie konstruktora bez wybranej liczby talii, 
            //niech sobie sam policzy pasującą ilość

        }

        public string playGame() {
            while(numberOfPlayingPlayers >= 2) {
                if(gracze.at(currentPlayer).getStunCount()) {
                    gracze.at(currentPlayer).decreaseStunCount(); //coś mi linker szwankuje 
                    //nextPlayer();
                    continue;
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
            return "jakis tam gracz przegrał";
        }

        public int getTopCard() {
            return topCard;
        }
    }
}
