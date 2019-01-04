using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TicTacToe
{
    static class GameLogic
    {

        private static bool IsTaken(int chosen, string[] list)
        {
            bool isTaken = true;

            string placement = list[chosen];
            if (placement == " ") isTaken = false;

            return isTaken;
        }

        public static bool Winner(string[] list, int round)
        {
            bool gameRunning = true;
            if (round > 0)
            {
                string one = list[0];
                string two = list[1];
                string three = list[2];
                string four = list[3];
                string five = list[4];
                string six = list[5];
                string seven = list[6];
                string eight = list[7];
                string nine = list[8];

                for (int x = 0; x < 8; x++)
                {
                    switch (x)
                    {
                        //first horizontal line check
                        case 1:
                            if (one == "X" && two == "X" && three == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (one == "O" && two == "O" && three == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;

                        //second horizontal line
                        case 2:
                            if (four == "X" && five == "X" && six == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (four == "O" && five == "O" && six == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;
                            
                        //third horizontal line
                        case 3:
                            if (seven == "X" && eight == "X" && nine == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (seven == "O" && eight == "O" && nine == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;
                        
                        //first vertical line
                        case 4:
                            if (one == "X" && four == "X" && seven == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (one == "O" && four == "O" && seven == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;

                        //second vertical line
                        case 5:
                            if (two == "X" && five == "X" && eight == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (two == "O" && five == "O" && eight == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;

                        //third vertical line
                        case 6:
                            if (three == "X" && six == "X" && nine == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (three == "O" && six == "O" && nine == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;

                        //top left to bottom right
                        case 7:
                            if (one == "X" && five == "X" && nine == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (one == "O" && five == "O" && nine == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;

                        //top right to bottom left
                        case 8:
                            if (three == "X" && five == "X" && seven == "X") { Console.WriteLine("Player one wins"); gameRunning = false; }
                            if (three == "O" && five == "O" && seven == "O") { Console.WriteLine("Player two wins"); gameRunning = false; }
                            break;
                    }

                }
            }
            return gameRunning;
        }

        public static string[] Move(string[] list, Board board)
        {
            bool isTaken = true;
            int round = board.Round;
            board.Update(list);
            int chosen = 0;

            if (round % 2 == 0) Console.WriteLine("Player two turn - Choose your move");
            else Console.WriteLine("Player one turn - Choose your move");


            do
            {
                try
                {
                    if (round % 2 == 0)
                    {
                        chosen = Int32.Parse(Console.ReadLine()) - 1;
                        isTaken = IsTaken(chosen, list);
                        if (isTaken == false) list[chosen] = "O";
                        else Console.WriteLine("Square already occupied");
                    }
                    else
                    {
                        chosen = Int32.Parse(Console.ReadLine()) - 1;
                        isTaken = IsTaken(chosen, list);
                        if (isTaken == false) list[chosen] = "X";
                        else Console.WriteLine("Square already occupied");
                    }
                } catch { Console.WriteLine("use numbers 1 to 9"); };
            } while (isTaken == true);
            return list;
        }

    }
}
