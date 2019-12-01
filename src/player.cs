namespace makao.player {
    public class Player {
        string name;
        bool isThisBot;
        List<int> hand;
        
        int stunCount;

        public Player() : this(false) {}
        public Player(/*string plName, */ bool bot) {
            name = plName;
            isThisBot = bot;
            for(int i = startingCardAmount; --i >= 0;) {
                //cards.drawCard(thisPlayer) //wykonać w game
            }
        }

        public int getStunCount() {
            return stunCount;
        }
        public void decreaseStunCount() {
            stunCount--;
        }
    }
}