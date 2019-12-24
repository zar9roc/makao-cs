//TODO: scalić requestFigure i requestColor

using System;
using System.Collections.Generic;


using makao.components.ioSystem;

namespace makao.components.player {
    public class Player {
        int id;
        //string name;
        bool isThisBot;
        public bool isPlaying;
        public List<int> hand;
        public int stunCount;
        

        public Player(int i) : this(i,false) {}
        public Player(/*string plName, */int i, bool bot) {
            //name = plName;
            isThisBot = bot;
            isPlaying = true;
            id = i;
            hand = new List<int>();
        }

        public void decreaseStunCount() {
            stunCount--;
        }

        public int requestFigure() {
            ioSystem.ioSystem.jackRequest(id);
            int retCard = -2;
            while(retCard == -2) {
                try {
                    ioSystem.ioSystem.znakZachety(id);
                    retCard = Int32.Parse(Console.ReadLine());
                    retCard--; //dla gracza karta #0 jest kartą #1
                } catch(FormatException e) {
                    string errorHandling = e.Message;
                    ioSystem.ioSystem.formatError(id);
                    retCard = -2;
                }
                if(retCard >= 10 || retCard < -2 || retCard == 0 || retCard == 1 || retCard == 2) {
                    ioSystem.ioSystem.incompatibileRequest(id);
                    retCard = -2;
                }
            }
            return retCard;
        }

        public int requestColor() {
            ioSystem.ioSystem.aceRequest(id);
            int retCard = -2;
            while(retCard == -2) {
                try {
                    ioSystem.ioSystem.znakZachety(id);
                    retCard = Int32.Parse(Console.ReadLine());
                    retCard--; //dla gracza karta #0 jest kartą #1
                } catch(FormatException e) {
                    string errorHandling = e.Message;
                    ioSystem.ioSystem.formatError(id);
                    retCard = -2;
                }
                if(retCard > 3 || retCard < 0) {
                    ioSystem.ioSystem.incompatibileRequest(id);
                    retCard = -2;
                }
            }
            return retCard;
        }
        public int playCard(int topCard, int gamemode) { 
            int pCard = -2;
            do {
                if(pCard != -2) ioSystem.ioSystem.incompatibileCard(id);

                while(pCard == -2) {
                    if(gamemode == 4 || gamemode == 5) 
                        ioSystem.ioSystem.jackContinue(id,topCard,gamemode==4);

                    ioSystem.ioSystem.printCurrentPlayerHand(id,hand);
                    
                    try {
                        ioSystem.ioSystem.znakZachety(id);
                        pCard = Int32.Parse(Console.ReadLine());
                        pCard--; //dla gracza karta #0 jest kartą #1
                    } catch(FormatException e) {
                        string errorHandling = e.Message;
                        ioSystem.ioSystem.formatError(id);
                        pCard = -2;
                    }
                    
                    if(pCard >= hand.Count || pCard < -2) {
                        ioSystem.ioSystem.outOfHandRange(id);
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
            return false;
        }

        public void youGot(List<int> penaltyCards) {
            ioSystem.ioSystem.youGot(id,penaltyCards);
        }
    }

    

    /*public class Bot : Player {

    } */
}