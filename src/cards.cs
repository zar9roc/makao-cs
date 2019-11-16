namespace makao.cards {
    public class Deck {
        List<int> deck = new List<int>();
        
        virtual public Deck(int amoutOfDecks) {
            //populateDeck(amountOfDecks)
        }
        public List<int> takeCard(int amount) {
            List<int> zbior = new List<int>();
            Random rnd = new Random();
            int deckSize = deck.size() - 1; //tylko jedno odwołanie
            
            for(int i = amount; --i >= 0;) {
                int r = rnd.Next(0,deckSize);
                zbior.Add(r);
                deck.RemoveAt(r);
                deckSize--;
            }

            return zbior;
        }
        private returnCardsToDeck() {
            //takeCardsFromTable();
            
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
        protected List<int> returnCards() {
            int topCard = stos[stos.size() - 1];
            stos.RemoveAt(stos.size() - 1);
            List<int> cardsToReturn = stos;
            stos.Clear();
            stos.Add(topCard);
        }

    }
}