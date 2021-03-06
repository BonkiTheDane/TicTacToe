﻿using System;
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

            //is equal to false if any game ending conditions are true
            bool gameRunning = true;

            //Only check win conditions in case atleast one round has been played
            if (round > 0)
            {
                //defines each element of list to an easily readable variable
                string one = list[0];
                string two = list[1];
                string three = list[2];
                string four = list[3];
                string five = list[4];
                string six = list[5];
                string seven = list[6];
                string eight = list[7];
                string nine = list[8];

                //used to check if board is full
                int isFull = 0;
                //Checks if any win conditions are true
                for (int x = 0; x <= 9; x++)
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

                        //Checks if the game is in a stalemate
                        case 9:
                            foreach(string str in list)
                            {
                                if (str == "X" || str == "O") isFull++;
                            }
                            if (isFull == 9) { Console.WriteLine("Stalemate"); gameRunning = false; }
                            break;
                    }

                }
            }
            return gameRunning;
        }

        //places X or O in player chosen posistion
        public static string[] Move(string[] list, Board board)
        {
            bool isTaken = true;
            int round = board.Round;
            board.Update(list);
            int chosen = 0;

            //Only two players mean that every other round it will be player 2, round 0 = player 1, round 2 = player 2.
            if (round % 2 == 0) Console.WriteLine("Player two turn - Choose your move");
            else Console.WriteLine("Player one turn - Choose your move");

            //This is repeated as long as the field chosen by a player is already taken
            do
            {
                try
                {
                    if (round % 2 == 0)
                    {
                        //userinput variable
                        chosen = Int32.Parse(Console.ReadLine()) - 1;

                        //checks if posistion is already taken
                        isTaken = IsTaken(chosen, list);
                        if (isTaken == false) list[chosen] = "O";
                        else Console.WriteLine("Square already occupied");
                    }
                    else
                    {
                        //repeat of above, but for player 2
                        chosen = Int32.Parse(Console.ReadLine()) - 1;
                        isTaken = IsTaken(chosen, list);
                        if (isTaken == false) list[chosen] = "X";
                        else Console.WriteLine("Square already occupied");
                    }
                    //if what the player has chosen is outside of list's index, it will do the catch
                } catch { Console.WriteLine("use numbers 1 to 9"); };
            } while (isTaken == true);
            return list;
        }

    }
}
