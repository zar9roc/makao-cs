using System;
using System.Collections.Generic;


using makao.components.ioSystem;

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
        public int StunCount => stunCount; //po co mi to
        public void decreaseStunCount() {
            stunCount--;
        }

        public int playCard(List<int> hand) {
            int pCard = -2;
            while(pCard == -2) {
                ioSystem.ioSystem.printCurrentPlayerHand(hand);
                try {
                    pCard = Int32.Parse(Console.ReadLine());
                } catch(FormatException e) {
                    //blabla, wpisales glupoty, sproboj jeszcze raz
                    pCard = -2;
                }
                ioSystem.ioSystem.formatError();
                if(pCard >= hand.Count || pCard < -2) pCard = -2;

            }                     
                
            return pCard;
        }
    }
}