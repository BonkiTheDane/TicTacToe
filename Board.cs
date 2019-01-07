using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board
    {

        private int round = 0;
        public int Round { get => round; set => round = value; }

        public void Update(string[] posistions)
        {
            //Defining game posistion variables
            string one = "";
            string two = "";
            string three = "";
            string four = "";
            string five = "";
            string six = "";
            string seven = "";
            string eight = "";
            string nine = "";

            //Taking X and O posistions from array and defining them to a variable
            for (int x = 0; x < posistions.Length; x++)
            {
                switch (x)
                {
                    case 0:
                        one = posistions[x];
                        break;
                    case 1:
                        two = posistions[x];
                        break;
                    case 2:
                        three = posistions[x];
                        break;
                    case 3:
                        four = posistions[x];
                        break;
                    case 4:
                        five = posistions[x];
                        break;
                    case 5:
                        six = posistions[x];
                        break;
                    case 6:
                        seven = posistions[x];
                        break;
                    case 7:
                        eight = posistions[x];
                        break;
                    case 8:
                        nine = posistions[x];
                        break;
                }
            }

            //Displays board and current player X/O posistions
            Console.WriteLine(" _________________");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", seven, eight, nine);
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", four, five, six);
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", one, two, three);
            Console.WriteLine("|_____|_____|_____|");
        }


    }
}
