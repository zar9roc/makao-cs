using System;
using System.Collections.Generic;

namespace makao.components.player {
    public class Player {
        string name;
        bool isThisBot;
        bool isPlaying;
        public List<int> hand;
        int stunCount;

        public Player() : this(false) {}
        public Player(/*string plName, */ bool bot) {
            name = plName;
            isThisBot = bot;
            isPlaying = true;
            for(int i = startingCardAmount; --i >= 0;) {
                //cards.drawCard(thisPlayer) //wykonać w game
                
            }
        }

        //przerobić na właściwość        
        public int StunCount => stunCount;
        public void decreaseStunCount() {
            stunCount--;
        }

        public int playCard() {
            int pCard = -1;
            //wydrukuj dostępne karty
            //cin << jedna karta
            //jezeli nie da sie polozyc powtorz
            return pCard;
        }
    }
}