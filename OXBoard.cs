using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXGame
{
    class OXBoard
    {
        public Row[] rowarr; //array of rows for impliment the board
        public Row row; //single row

        //board builder
        
        public OXBoard(int rewLength)
        {
            row = new Row(rewLength);
            rowarr = new Row[row.rowLength];
            for (int i = 0; i < row.rowLength; i++)
                rowarr[i] = new Row(rewLength);
        }
        //board Display
        public void Display()
        {
            for (int i = 0; i < row.rowLength; ++i)
                rowarr[i].DisplayRowContents();
        }


        // choosing space in board to put X or O 
        public void Put()
        {
            string input = "";
            int rowNumber = 0;
            Console.WriteLine("Type row number from 1 to {0}", row.rowLength);
            input = Console.ReadLine();
            if (int.TryParse(input, out rowNumber))
            {
                //checking if valid space number
                if (rowNumber > row.rowLength || rowNumber < 1)
                {
                    Console.WriteLine("Invalid row number. Please try again.");
                    Put();
                    return;
                }
                //if everything ok- moving to coulmn choose
                rowarr[rowNumber - 1].RowPut(XOGame.isXTurn);
            }

            //if enterd not a number
            else
            {
                Console.WriteLine("Invalid row number. Try again.");
                Put();
                return;
            }
        }

        public string Status()
        {
            if (XOGame.numberOfTurns >= (XOGame.boardSize) * (XOGame.boardSize))
                return "Draw";
            else if (XOGame.winX == true)
            {
                XOGame.winX = false;
                return "X";
            }
            else if (XOGame.winO == true)
            {
                XOGame.winO = false;
                return "O";
            }
            return "None";

        }


    }
}
