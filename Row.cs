using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXGame
{
    class Row
    {
        public int rowLength; // row length
        public int[] spaces; // row array

        // choosing space in row to put X or O 
        public void RowPut(bool isX)
        {
            string input;
            int spaceNumber;
            Console.WriteLine("Type column number from 1 to {0}", rowLength);
            input = Console.ReadLine();
            if (int.TryParse(input, out spaceNumber))
            {

                //checking if valid space number
                if (spaceNumber > rowLength || spaceNumber < 1)
                {
                    Console.WriteLine("Invalid space number. Please try again.");
                    RowPut(isX);
                    return;
                }

                //checking if cleer space for play
                if (spaces[spaceNumber - 1] != 0)
                {
                    Console.WriteLine("That space is occupied. Please choose another.");
                    XOGame.board.Put();
                    return;
                }

                // playing correctly- put X or O in empty space
                if (isX)
                    spaces[spaceNumber - 1] = 1;
                else
                    spaces[spaceNumber - 1] = 2;
            }
            //if enterd not a number
            else
            {
                Console.WriteLine("Invalid space number. Try again.");
                RowPut(isX);
            }
        }

        public void DisplayRowContents()
        {
            string lineToWrite = "";
            for (int i = 0; i < spaces.Length; ++i)
            {
                if (spaces[i] == 0)
                    lineToWrite += "|   |";
                else if (spaces[i] == 1)
                    lineToWrite += "| X |";
                else if (spaces[i] == 2)
                    lineToWrite += "| O |";
            }

            Console.WriteLine(lineToWrite);
        }

        public Row(int rowLength)
        {
            this.rowLength = rowLength;
            spaces = new int[rowLength];
        }


    }
}

