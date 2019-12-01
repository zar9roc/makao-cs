using System;
using makao.game;
using makao.io;
using makao.cards;
using makao.player;

namespace VSCODE
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
