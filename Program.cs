using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            string[] list = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            int round = 0;

            do
            {
                board.Round++;
                round = board.Round;
                Console.WriteLine("Playing TicTacToe");
                list = GameLogic.Move(list, board);
                Console.Clear();
            } while (GameLogic.Winner(list, round));

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}
