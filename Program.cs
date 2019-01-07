using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        static void Main(string[] args)
        {
            Task.Run(() => KeyExit());
            string userinput = "";
                do
                {
                    Console.WriteLine("Press esc at any time to exit");
                    Console.Write("Write start to start the game: ");
                    userinput = Console.ReadLine().ToLower();
                    if (userinput == "start")
                    {
                        Console.Clear();
                        Start();
                    }
                } while (true);
        }

        static void Start()
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
            board.Update(list);
        }

        static void KeyExit()
        {
            while (true)
            {
                if ((GetAsyncKeyState(0x1B) < 0))
                {
                    Environment.Exit(0);
                }
            }
        }

    }
}
