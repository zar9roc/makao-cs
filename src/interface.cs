//import io
//static input/output class
//someone coś zrobił
//podaj ty coś
using System;
namespace makao.io {
    public static class IO{

        public static void kolejNa(int nr) {
            Console.WriteLine("Aktualnie rusza się gracz " + nr);
        }
        public static void printCurrentPlayerHand(List<int> hand) {
            int key = 1;
            Console.WriteLine("Masz dostepne nastepujace karty:");
            foreach(int karta in hand) {
                Console.Write(key + " - " + karta);
                key++;
            }
        }
    }
}