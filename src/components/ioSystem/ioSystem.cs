/* (c) Adam Szczepanik. See licence.txt in the root of the distribution for more information. */

//TODO:



using System;
using System.Collections.Generic;

namespace makao.components.ioSystem {


    public static class ioSystem {
        //GLOBALNE INFO

        public static void printTopCard(int topCard) {
            Console.WriteLine("Na stole leży " + toText(topCard));
        }
        public static void kolejNa(int nr) => Console.WriteLine("Aktualnie rusza się gracz " + ++nr);

        public static void playerMove(int player, int card) {
            Console.WriteLine("Gracz {0} rzuca {1}", player, toText(card));
        }

        public static void playerIdle(int nr) { 
            Console.WriteLine("Gracz {0} pomija swoją kolej i pobiera kartę.", nr);
        }

        public static void playerFrozen(int nr, int q) { 
            Console.WriteLine("Gracz {0} stoi kolejkę.", nr);
            if(q > 0) Console.WriteLine("Zostało mu jeszcze {0} kolejek", q);
            else Console.WriteLine("W następnej turze wchodzi do gry");
        }

        public static void figRequested(int player, int card, bool bid) {
            if(bid) Console.WriteLine("Gracz {0} przebija żądanie. Obowiązuje {1}.",player,toFigure(card));
            else Console.WriteLine("Gracz {0} żąda karty {1}!",player,toFigure(card));
        }

        //PRYWATNE INFO

        public static void znakZachety(int player) {
            Console.Write(pHeader(player) + "> ");
        }

        public static void printCurrentPlayerHand(int player, List<int> hand) {
            int key = 1;
            Console.WriteLine(pHeader(player) + "Masz dostępne następujace karty:");
            Console.Write(pHeader(player));
            foreach(int v in hand) {
                Console.Write(key + ") " + toText(v) + "   ");
                key++;
            }
            Console.WriteLine();
        }

        public static void aceRequest(int player) {
            
            Console.WriteLine(pHeader(player) + "Podaj kolor, na który zmieniasz:");
            
            Console.WriteLine(pHeader(player) + "1 - Serca, 2 - Dzwonki, 3 - Trefle, 4 - Piki");
        }

        public static void jackRequest(int player) {
            
            Console.WriteLine(pHeader(player) + "Podaj żądaną figurę:");
            Console.WriteLine(pHeader(player) + "Możliwe: 5, 6, 7, 8, 9, 10");
            Console.WriteLine(pHeader(player) + "0 - brak żądania");
        }
            
        public static void aceInfo(int player, int color) {
            Console.WriteLine(pHeader(player) + "As zmienia kolor na " + toColor(color));
        }
        public static void pickupInfo(int player, int charge) {
            Console.WriteLine(pHeader(player) + "Musisz przebić kartę, w przeciwnym przypadku pobierasz {0} kart.", charge);
        }

        public static void skipInfo(int player, int charge) {
            Console.WriteLine(pHeader(player) + "Musisz przebić kartę, w przeciwnym przypadku stoisz kolejek: {0}", charge);
        }
        public static void jackInfo(int player, int card, bool beatable) {
            Console.WriteLine(pHeader(player) + "Aktualnie żądany jest {0}", toFigure(card % 13));
            if(beatable) Console.WriteLine(pHeader(player) + "Możesz przebić dowolnym J!");
        }

        public static void youGot(int player, List<int> penaltyHand) {
            Console.WriteLine(pHeader(player) + "Dostałeś następujące karty: ");
            Console.Write(pHeader(player));
            foreach (int item in penaltyHand) {
                Console.Write(toText(item) + ' ');
            }
            Console.WriteLine();
        }

        //BŁĘDY

        public static void formatError(int player) {
            Console.WriteLine(pHeader(player) + "Błędne wejście, spróbuj ponownie.");
        }

        public static void outOfHandRange(int player) {
            Console.WriteLine(pHeader(player) + "Karta spoza zakresu ręki");
        }

        public static void incompatibileCard(int player) {
            Console.WriteLine(pHeader(player) + "Nie można położyć tej karty!");
        }

        public static void incompatibileRequest(int player) {
            Console.WriteLine(pHeader(player) + "Nieprawidłowy wybór, spróbuj jeszcze raz.");
        }

        //POMOCNICZE

        public static string pHeader(int player) {
            return "[Gracz " + player + "] ";
        }

        private static string toColor(int col) {
            string cardName;
            switch(col) {
                case 0:
                    cardName = "♥"; break;
                case 1:
                    cardName = "♦"; break;
                case 2:
                    cardName = "♣"; break;
                case 3:
                    cardName = "♠"; break;
                default:
                    cardName = "-COLOR"; break;
            }
            return cardName;
        }
        private static string toFigure(int fig) {
            string cardName;
            switch(fig) {
                case 0:
                    cardName = "A"; break;
                case 1:
                    cardName = "2"; break;
                case 2:
                    cardName = "3"; break;
                case 3:
                    cardName = "4"; break;
                case 4:
                    cardName = "5"; break;
                case 5:
                    cardName = "6"; break;
                case 6:
                    cardName = "7"; break;
                case 7:
                    cardName = "8"; break;
                case 8:
                    cardName = "9"; break;
                case 9:
                    cardName = "10"; break;
                case 10:
                    cardName = "J"; break;
                case 11:
                    cardName = "Q"; break;
                case 12:
                    cardName = "K"; break;
                default:
                    cardName = "FIGURE-"; break;
            }
            return cardName;
        }
        private static string toText(int nb) {
            int fig = nb % 13;
            int col = nb / 13;
            return toFigure(fig) + toColor(col);
        }
    }
}