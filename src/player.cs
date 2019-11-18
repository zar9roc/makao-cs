namespace makao.player {
    public class Player {
        string name;
        bool isThisBot;
        List<int> hand;
        
        int stunCount;
        public Player(/*string plName, */bool bot, int startingCardAmount) {
            name = plName;
            isThisBot = bot;
            for(int i = startingCardAmount; --i >= 0;) {
                //cards.drawCard(thisPlayer) 
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