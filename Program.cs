using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXGame
{
    class XOGame
    {
  
        public static bool isXTurn = true;
        public static OXBoard board;
        public static int numberOfTurns = 0;
        public static int boardSize;
        //for the status method
        public static bool winO = false;
        public static bool winX = false;

        static void Main(string[] args)
        {

          

            while (true)
            {
                ResetBoard();
                PlayGame();
            }

            // Reset board to a new game
            void ResetBoard()
            {
                //fot status method
                XOGame.winX = false;
                XOGame.winO = false;
                XOGame.numberOfTurns = 0;

                int temp = 0;
                string input = " ";
                Console.WriteLine("Please enter board size:\n");
                input = Console.ReadLine();
                if (int.TryParse(input, out temp))
                {
                    boardSize = int.Parse(input);


                }
                //if enterd not a number
                else
                {
                    Console.WriteLine("Invalid number. Please Try again.");
                    ResetBoard();
                    return;
                }
                
                
                    board = new OXBoard(boardSize);
                numberOfTurns = 0;
                board.Display();
            }

            void PlayGame()
            {
                while (true)
                {
                    board.Put();
                    board.Display();
                    if (CheckForWinner())
                        break;
                    isXTurn = !isXTurn; // switch turn
                    Console.WriteLine("The status is:{0}", board.Status());

                    numberOfTurns++;
                    if (numberOfTurns >= (boardSize * boardSize))
                    {
                        Console.WriteLine("game over! Try again.");
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to play again.");
                Console.ReadKey(true);
            }



             bool CheckForWinner()
            {
                if (Horizontal() || Vertical() || Diagonal())
                    return true;
                else return false;

                // checking the Horizontal chance of winning
                bool Horizontal()
                {
                    for (int i = 0; i < board.rowarr.Length; ++i)
                    {
                        bool hasWon = true;
                        bool isX = false;
                        int[] spaces = board.rowarr[i].spaces;
                        int checkHorizontal = spaces[0];
                        switch (checkHorizontal)
                        {
                            case 0:
                                continue;
                            case 1:
                                isX = true;
                                break;
                            case 2:
                                isX = false;
                                break;
                        }
                        for (int j = 0; j < spaces.Length; ++j)
                        {
                            if (spaces[j] != checkHorizontal)
                            {
                                hasWon = false;
                                break;
                            }
                        }
                        if (hasWon)
                        {
                            DisplayWinnerMessage(isX);
                            return true;
                        }
                    }
                    return false;
                }

                // checking the Vertical chance of winning
                bool Vertical()
                {
                    bool hasWon = true;
                    bool isX = false;
                    int[] spaces = board.rowarr[0].spaces;
                    for (int i = 0; i < board.row.rowLength; ++i)
                    {
                        hasWon = true;
                        int checkVertical = spaces[i];
                        switch (checkVertical)
                        {
                            case 0:
                                continue;
                            case 1:
                                isX = true;
                                break;
                            case 2:
                                isX = false;
                                break;
                        }
                        for (int j = 0; j < board.row.rowLength; ++j)
                        {
                            if (board.rowarr[j].spaces[i] != checkVertical)
                            {
                                hasWon = false;
                                break;
                            }
                        }
                        if (hasWon)
                        {
                            DisplayWinnerMessage(isX);
                            return true;
                        }
                    }
                    return false;
                }

                // checking the Diagonal chance of winning
                bool Diagonal()
                {
                    bool hasWon = true;
                    bool isX = false;

                    // checking the left-to-right Diagonal chance of winning
                    int firstSpace = board.rowarr[0].spaces[0];
                    switch (firstSpace)
                    {
                        case 0:
                            hasWon = false;
                            break;
                        case 1:
                            isX = true;
                            break;
                        case 2:
                            isX = false;
                            break;
                    }
                    for (int i = 0; i < board.row.rowLength; ++i)
                    {
                        if (board.rowarr[i].spaces[i] != firstSpace)
                        {
                            hasWon = false;
                            break;
                        }
                    }
                    if (hasWon)
                    {
                        DisplayWinnerMessage(isX);
                        return true;
                    }

                    // checking the left-to-right Diagonal chance of winning
                    hasWon = true;
                    int endTopRowSpace = board.rowarr[0].spaces[board.row.rowLength-1];
                    switch (endTopRowSpace)
                    {
                        case 0:
                            hasWon = false;
                            break;
                        case 1:
                            isX = true;
                            break;
                        case 2:
                            isX = false;
                            break;
                    }
                    for (int i = 0; i < board.row.rowLength; ++i)
                    {
                        if (board.rowarr[i].spaces[board.row.rowLength - 1 - i] != endTopRowSpace)
                        {
                            hasWon = false;
                            break;
                        }
                    }
                    if (hasWon)
                    {
                        DisplayWinnerMessage(isX);
                        return true;
                    }
                    return false;
                }
                void DisplayWinnerMessage(bool isX)
                {
                    string winnerIs = "";
                    if (isX)
                    {
                        //winX = true;
                        winnerIs = " X Player";
                    }
                    else
                    {
                        //winO = true;
                        winnerIs = " O Player";
                    }
                    Console.WriteLine("The winner is " + winnerIs);
                }
            }



        }






    }
    
}
