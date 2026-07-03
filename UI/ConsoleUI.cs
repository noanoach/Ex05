using System;
using EX02.Logic;
using EX02.Players;
using Ex02.ConsoleUtils;
using System.Threading;

namespace EX02.UI
{
    internal class ConsoleUI
    {
        /// Prints the welcome message.
        public void PrintWelcome()
        {
            Console.WriteLine("Welcome to Reverse Tic Tac Toe!");
            Console.WriteLine("Try NOT to create a full sequence.");
            Console.WriteLine("The first player to complete a full row loses.");
            Console.WriteLine();
        }
    
        /// Reads and validates board size input.
        public int ReadBoardSize()
        {
            int boardSize = 0;
            bool isValidInput = false;

            Console.WriteLine("Enter board size (3-9):");

            while (!isValidInput)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out boardSize))
                {
                    if (boardSize >= 3 && boardSize <= 9)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 3 and 9:");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }

            }

            return boardSize;

        }
   
        /// Asks whether the game is against another player or computer.
        public bool ReadIsAgainstComputer()
        {
            bool isValidInput = false;
            bool isAgainstComputer = false;

            Console.WriteLine("Press 1 to play against another player.");
            Console.WriteLine("Press 2 to play against the computer.");

            while (!isValidInput)
            {
                string input = Console.ReadLine();

                if (input == "1")
                {
                    isAgainstComputer = false;
                    isValidInput = true;
                }
                else if (input == "2")
                {
                    isAgainstComputer = true;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2:");
                }
            }

            return isAgainstComputer;
        }

        /// Reads a move from the current player.
        public Move ReadMove(Player i_Player)
        {
            int row;
            int col;

            Console.WriteLine(i_Player.Name + ", enter row:");

            string rowInput = Console.ReadLine().ToLower();

            if (rowInput == "q")
            {
                return new Move(eMoveResult.Quit);
            }

            if (!int.TryParse(rowInput, out row))
            {
                return new Move(eMoveResult.InvalidFormat);
            }

            Console.WriteLine(i_Player.Name + ", enter column:");

            string colInput = Console.ReadLine().ToLower();

            if (colInput == "q")
            {
                return new Move(eMoveResult.Quit);
            }

            if (!int.TryParse(colInput, out col))
            {
                return new Move(eMoveResult.InvalidFormat);
            }

            return new Move(row - 1, col - 1);
        }

        /// Prints the current board state.
        public void PrintBoard(Board i_Board)
        {
            Screen.Clear();

            int size = i_Board.Size;

            // Print column numbers
            Console.Write("  ");

            for (int col = 1; col <= size; col++)
            {
                Console.Write(" " + col);
            }

            Console.WriteLine();

            // Print all board rows
            for (int row = 0; row < size; row++)
            {
                
                Console.Write((row + 1) + " ");

                for (int col = 0; col < size; col++)
                {
                    Console.Write("|");

                    // Print cell value
                    if (i_Board.GetCell(row, col) == eCellValue.X)
                    {
                        Console.Write("X");
                    }
                    else if (i_Board.GetCell(row, col) == eCellValue.O)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write("|");

                Console.WriteLine();

                // Print separator line
                for (int i = 0; i < size; i++)
                {
                    Console.Write("==");
                }

                Console.Write("===");

                Console.WriteLine();
            }
        }
        
        /// Prints invalid input message.
        public void PrintInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        /// Prints message when selected cell is occupied.
        public void PrintCellTakenMessage()
        {
            Console.WriteLine("That cell is already taken. Please choose another one.");
        }

        /// Prints message when selected cell is outside the board.
        public void PrintCellOutOfRangeMessage()
        {
            Console.WriteLine("That cell does not exist on the board. Please choose another one.");
        }

        /// Prints the winner of the round.
        public void PrintWinner(Player i_Winner)
        {
            Console.WriteLine("Congratulations " + i_Winner.Name + "! You win this round!");
        }

        /// Prints tie message.
        public void PrintTie()
        {
            Console.WriteLine("It's a tie! No points awarded.");
        }

        /// Prints the current scores.
        public void PrintScore(Player i_Player1, Player i_Player2)
        {
            Console.WriteLine("Current Scores:");
            Console.WriteLine(i_Player1.Name + ": " + i_Player1.Score);
            Console.WriteLine(i_Player2.Name + ": " + i_Player2.Score);
        }

        /// Asks if players want another round.
        public bool AskPlayAgain()
        {
            bool isValidInput = false;
            bool playAgain = false;

            Console.WriteLine("Do you want to play another round? (y/n)");

            while (!isValidInput) 
            {

                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    playAgain = true;
                    isValidInput = true;
                }
                else if (input == "n")
                {
                    playAgain = false;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n':");
                }

            }

            return playAgain;
        }

        public void Run()
        {
            GameManager gameManager = new GameManager();
            bool shouldPlayAgain = true;
            int boardSize;
            bool isAgainstComputer;

            PrintWelcome();

            boardSize = ReadBoardSize();
            isAgainstComputer = ReadIsAgainstComputer();

            gameManager.InitializeGame(boardSize, isAgainstComputer);

            while (shouldPlayAgain)
            {
                playRound(gameManager);

                PrintScore(gameManager.Player1, gameManager.Player2);

                shouldPlayAgain = AskPlayAgain();

                if (shouldPlayAgain)
                {
                    gameManager.StartNewRound();
                }
            }
        }

        private void playRound(GameManager i_GameManager)
        {
            bool isRoundOver = false;
            eMoveResult moveResult;
            Move move;

            while (!isRoundOver)
            {
                PrintBoard(i_GameManager.Board);

                moveResult = eMoveResult.InvalidFormat;

                while (moveResult != eMoveResult.Success)
                {
                    if (i_GameManager.IsCurrentPlayerComputer())
                    {
                        Console.WriteLine("Computer is thinking...");
                        Thread.Sleep(1000);

                        move = i_GameManager.GetComputerMove();
                        moveResult = i_GameManager.PlayTurn(move);
                    }
                    else
                    {
                        move = ReadMove(i_GameManager.CurrentPlayer);
                        moveResult = move.Result;

                        if (moveResult == eMoveResult.Success)
                        {
                            moveResult = i_GameManager.PlayTurn(move);
                        }
                    }

                    switch (moveResult)
                    {
                        case eMoveResult.InvalidFormat:
                            PrintInvalidInputMessage();
                            break;

                        case eMoveResult.OutOfRange:
                            PrintCellOutOfRangeMessage();
                            break;

                        case eMoveResult.CellTaken:
                            PrintCellTakenMessage();
                            break;

                        case eMoveResult.Quit:
                            return;
                    }
                }

                isRoundOver = i_GameManager.IsRoundOver();

                if (!isRoundOver)
                {
                    i_GameManager.SwitchTurn();
                }
            }

            PrintBoard(i_GameManager.Board);

            handleRoundEnd(i_GameManager);
        }

        private void handleRoundEnd(GameManager i_GameManager)
        {
            Player winner;

            if (i_GameManager.CurrentPlayerLost())
            {
                winner = i_GameManager.GetRoundWinner();
                i_GameManager.AddPointToWinner();
                PrintWinner(winner);
            }
            else
            {
                PrintTie();
            }
        }
    }
}
    
