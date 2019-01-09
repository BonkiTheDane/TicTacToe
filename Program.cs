using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        //imported to rgister key presses
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        static void Main(string[] args)
        {
            //Runs the KeyExit command in async
            Task.Run(() => KeyExit());

            string userinput = "";

            //program loop
            while(true)
            {
                Console.WriteLine("Press esc at any time to exit");
                Console.Write("Write start to start the game: ");
                userinput = Console.ReadLine().ToLower();
                if (userinput == "start")
                {
                    Console.Clear();
                    Start();
                }
            }
        }



        static void Start()
        {
            
            Board board = new Board();
            //array (lazily named list) has a value for each posistion on the 3x3 board
            string[] list = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            int round = 0;

            //loops untill GameLogic returns that there is a winner (returns false if thats the case)
            do
            {
                board.Round++;
                round = board.Round;
                Console.WriteLine("Playing TicTacToe");
                list = GameLogic.Move(list, board);
                Console.Clear();
            } while (GameLogic.Winner(list, round));

            //Update board graphically, so players can see end results of game
            board.Update(list);
        }


        //Runs async and exits the program when escape is pressed
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
