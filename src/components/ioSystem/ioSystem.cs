//import io
//static input/output class
//someone coś zrobił
//podaj ty coś
using System;
using System.Collections.Generic;

namespace makao.components.ioSystem {


    public static class ioSystem{
        //INFORMUJĄCE
        public static void kolejNa(int nr) => Console.WriteLine("Aktualnie rusza się gracz " + nr);
        public static void printCurrentPlayerHand(List<int> hand) {
            int key = 1;
            Console.WriteLine("Masz dostępne następujace karty:");
            foreach(int karta in hand) {
                Console.Write(key + ") " + toText(karta) + " # ");
                key++;
            }
        }

        //PROSZĄCE

        //BŁĘDY

        public static void formatError() {
            Console.WriteLine("Błędne wejście, spróbuj ponownie.");
        }

        //POMOCNICZE
        public static string toText(int nb) {
            int col = nb / 4;
            int fig = nb % 13;
            string cardName;
            switch(fig) {
                case 0:
                    cardName = "A";
                break;
                case 1:
                    cardName = "2";
                break;
                case 2:
                    cardName = "3";
                break;
                case 3:
                    cardName = "4";
                break;
                case 4:
                    cardName = "5";
                break;
                case 5:
                    cardName = "6";
                break;
                case 6:
                    cardName = "7";
                break;
                case 7:
                    cardName = "8";
                break;
                case 8:
                    cardName = "9";
                break;
                case 9:
                    cardName = "10";
                break;
                case 10:
                    cardName = "J";
                break;
                case 11:
                    cardName = "Q";
                break;
                case 12:
                    cardName = "K";
                break;
                default:
                    cardName = "FIGURE-";
            }
            switch(col) {
                case 0:
                    cardName += "♥"; break;
                case 1:
                    cardName += "♦"; break;
                case 2:
                    cardName += "♣"; break;
                case 3:
                    cardName += "♠"; break;
                default:
                    cardName += "-COLOR";
            }
        }
    }
}