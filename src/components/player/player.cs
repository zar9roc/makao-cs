//TODO

//dla playcard() dodać przeładowanie z uwzględnieniem gamemode 1-5 

using System;
using System.Collections.Generic;


using makao.components.ioSystem;

namespace makao.components.player {
    public class Player {
        //string name;
        bool isThisBot;
        bool isPlaying;
        public List<int> hand;
        int stunCount;

        public Player() : this(false) {}
        public Player(/*string plName, */ bool bot) {
            //name = plName;
            isThisBot = bot;
            isPlaying = true;
        }

        //przerobić na właściwość      
        public int StunCount => stunCount; //po co mi to
        public void decreaseStunCount() {
            stunCount--;
        }

        public int playCard(int topCard, int gamemode) { 
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

            } while (!canPut(topCard,pCard,gamemode));
            if(pCard == -1) return pCard; //PAS
            int retCard = hand[pCard];
            hand.RemoveAt(pCard);
            return retCard; 
        }

        //gamemode 0: dozwolona każda pasujaca karta
        //gamemode 1: dozwolone 2,3,K
        //gamemode 2: dozwolone 4
        //gamemode 3: ---brak---
        //gamemode 4: dozwolone $topCard,J
        //gamemode 5: dozwolone $topCard
        private bool canPut(int topCard, int pCard, int gamemode)  {
            if(gamemode == 0) 
                return ((pCard / 4) == (topCard / 4))
                || ((pCard % 13) == (topCard % 13))
                || pCard == 11 //Q♥
                || topCard == 11
                || pCard == -1;
            if(gamemode == 1) 
                return ((pCard / 4 == topCard / 4) 
                && (pCard % 13 == 1 || topCard % 13 == 2 || topCard % 13 == 12))
                || pCard % 13 == topCard % 13
                || pCard == 11 //Q♥
                || pCard == -1;
            if(gamemode == 2) 
                return pCard % 13 == 3 || pCard == 11 || pCard == -1;
            if(gamemode == 4)
                return pCard % 13 == topCard % 13
                || pCard % 13 == 10
                || pCard == -1;
            if(gamemode == 5) 
                return pCard % 13 == topCard % 13 || pCard == -1;
        }
    }

    

    public class Bot : Player {

    }
}