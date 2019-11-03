public class Game {
    string name;
    int numberOfPlayers;
    int numberOfPlayingPlayers;
    int numberOfStartingCards;
    int topCard;
    int penaltyStack;
    
    public Game(string nameGame, int playersNb, int cardsNb) {
        name = nameGame;
        numberOfPlayers = playersNb;
        numberOfPlayingPlayers = playersNb;
        numberOfStartingCards = cardsNb;
        topCard = 0; //= nameofdeck.takeCard();
        penaltyStack = 0;
        //TOFDOdodać przeciążenie konstruktora bez wybranej liczby talii, 
        //niech sobie sam policzy pasującą ilość
    }

    public string playGame() {
        
        return "jakis tam gracz wygral";
    }

    public int getTopCard() {
        return topCard;
    }
}