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

        public int playCard(int topCard) {
            int pCard = -2;
            do {
                if(pCard != -2) ioSystem.ioSystem.incompatibileCard();

                while(pCard == -2) {
                    ioSystem.ioSystem.printCurrentPlayerHand(hand);
                    try {
                        pCard = Int32.Parse(Console.ReadLine());
                        pCard--; //dla gracza karta #0 jest kartą #1
                    } catch(FormatException e) {
                        ioSystem.ioSystem.formatError();
                        pCard = -2;
                    }
                    
                    if(pCard >= hand.Count || pCard < -2) {
                        ioSystem.ioSystem.outOfHandRange();
                        pCard = -2;
                    } 
                }

            } while (
               ((pCard / 4) == (topCard / 4))
                || ((pCard % 13) == (topCard % 13))
                || pCard == 12 //Q♥
                || pCard == -1 //PAS
                );
            if(pCard == -1) return pCard; //PAS
            int retCard = hand[pCard];
            hand.RemoveAt(pCard);
            return retCard; 
        }
    }

    public class Bot : Player {

    }
}