using System;
using System.Collections.Generic;

namespace makao.components.cards {
    public class Deck {
        
        //generator liczb losowych deckInf
        
        public Deck(int amoutOfDecks) {
        }
        public List<int> takeCard(int amount) {
            List<int> zbior = new List<int>();
            //losuj element zbioru x amount
            return zbior;
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
            deck.Concat(returnedCards); //jeżeli to zadziała... xD
            /*
            A w game.cs dać:
            returnCardsToDeck(instancjaTable.returnCards());
            */
        }
    }

    public class Table {
        List<int> stos;
        public Table(){
            //nameOfDeck.takeCard(1);
        }
        //jakieś printy co tutaj leży może
        //albo podaj jakąś kartę wstecz 
        public void putCard(int cardId) {
            //stos.add(cardId)
            //może jakieś schodki
            //albo wcześniejsza weryfikacja (może w game) czy podana karta może być dodana
        }
        public int getTopCard() {
            return stos[stos.size - 1];
        }
        public List<int> returnCards() { //dodać wyjątek gdy nie ma kart na stole -- LOL, można nie wyzwalac
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