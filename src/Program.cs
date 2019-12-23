//TODO:

//Dać możliwośc wybrania ilości graczy, startowych kart

//DALEJ NIEROZWIAZANY BUG KREOWANIA INSTANCJI KLAS Z INNYCH PLIKÓW

using System;
using makao.components;

namespace makao
{
    class Program
    {
        static void Main(string[] args)
        {
            int plnum = 4;
            int startingCards = 5;

            Game gra = new Game("gamename", plnum, startingCards);

            string przegrany = gra.playGame();
            //ew zapisanie wyników gry do jakiejś bazy danych
            //ew zamknięcie gry
        }
    }
}


