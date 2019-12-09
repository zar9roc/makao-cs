using System;
using makao.components;

namespace makao
{
    class Program
    {
        static void Main(string[] args)
        {
            int plnum = 2;
            int qdeck = 1;

            Game gra = new Game("gamename", plnum, qdeck);

            string przegrany = gra.playGame();
            //ew zapisanie wyników gry do jakiejś bazy danych
            //ew zamknięcie gry

        }
    }
}


