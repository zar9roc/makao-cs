namespace makao.player {
    public class Player {
        string name;
        bool isThisBot;
        List<int> hand;
        public Player(string plName, bool bot, int startingCardAmount) {
            name = plName;
            isThisBot = bot;
            for(int i = startingCardAmount; --i >= 0;) {
                //cards.drawCard(thisPlayer) 
            }
        }
    }
}