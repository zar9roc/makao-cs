using System;
using System.Collections.Generic;
using System.Linq;

namespace makao.components.cards {
    public class Deck {
        
        //generator liczb losowych deckInf
        
        public Deck(int amoutOfDecks) {
        }
        public List<int> takeCard(int amount) {
            uint rand = new Random();
            List<int> zbior = new List<int>();

            for(var i = amount; --i >= 0;) 
                zbior.Add(rand.Next() % 52); //żeby sie ujemne nie losowaly
            
            return zbior;
        }

        public int takeOneCard() {
            uint rand = new Random();
            return rand.Next() % 52;
        }
    }

    class finDeck : Deck {
        List<int> deck;

        public finDeck() {
            deck = new List<int>();
            //populateDeck(amountOfDecks) ??
        }
        
        public override List<int> takeCard(int amount) {
            List<int> zbior = new List<int>();
            Random rnd = new Random();
            int lastCardIndex = deck.size() - 1; 
            
            for(int i = amount; --i >= 0;) {
                int r = rnd.Next(0,lastCardIndex);
                zbior.Add(r);
                deck.RemoveAt(r);
                deckSize--;
                //stol (stół) pub. zmienna klasy od kart na stole (nie podoba mi się to rozwiązanie)
                if(deck.size() == 0) deck = stol.returnCards();
            }

            return zbior;
        }

        private override void returnCardsToDeck(List<int> returnedCards) {
            deck.Concat(returnedCards); //yeah, dziala
            /*
            A w game.cs dać:
            returnCardsToDeck(instancjaTable.returnCards());
            */
        }
    }

    public class Table {
        private int topCard;

        public Table() {
            uint rand = new Random();
            do {
                topCard = rand % 52;
            } while ((topCard % 13) <= 10 && (topCard % 13) != 0);
        }

        public int TopCard { //niewielki sens użycia
            get => topCard;
            set => topCard;
        }
    }
    public class finTable : Table { //do skończenia innym razem
        List<int> stos;
        public Table(){
            //nameOfDeck.takeCard(1);
        }
        //jakieś printy co tutaj leży może
        //albo podaj jakąś kartę wstecz 
        public void putCard(int cardId) {
            stos.Add(cardId);
            //stos.add(cardId)
            //może jakieś schodki
            //albo wcześniejsza weryfikacja (może w game) czy podana karta może być dodana
        }
        public int getTopCard() { //get/set?
            return stos[stos.size - 1];
        }
        public List<int> returnCards() { 
            int topCard = stos[stos.size() - 1];
            stos.RemoveAt(stos.size() - 1);
            List<int> cardsToReturn = stos;
            stos.Clear();
            stos.Add(topCard);
            //komunikat o zwróceniu kart do stosu
            return cardsToReturn;
        }
    }
}