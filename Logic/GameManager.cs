using EX02.Players;
using EX02.UI;
using System;
using System.Threading;

namespace EX02.Logic
{
    internal class GameManager
    {
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private ConsoleUI m_ConsoleUI;

     
        /// Runs the entire game flow.
        public void Run()
        {
            bool shouldPlayAgain = true;

            InitializeGame();

            while (shouldPlayAgain)
            {
                PlayRound();

                m_ConsoleUI.PrintScore(m_Player1, m_Player2);

                shouldPlayAgain = m_ConsoleUI.AskPlayAgain();

                if (shouldPlayAgain)
                {
                    StartNewRound();
                }
            }
        }

        /// Initializes players and board settings.
        private void InitializeGame()
        {
            int boardSize;
            bool isAgainstComputer;

            m_ConsoleUI = new ConsoleUI();

            m_ConsoleUI.PrintWelcome();

            boardSize = m_ConsoleUI.ReadBoardSize();

            isAgainstComputer = m_ConsoleUI.ReadIsAgainstComputer();

            m_Player1 = new Player("Player 1", eCellValue.X);

            if (isAgainstComputer)
            {
                m_Player2 = new ComputerPlayer("Player 2", eCellValue.O);
            }
            else
            {
                m_Player2 = new Player("Player 2", eCellValue.O);
            }

            m_Board = new Board(boardSize);

            m_CurrentPlayer = m_Player1;
        }


        /// Runs one round of the game.
        private void PlayRound()
        {
            bool isRoundOver = false;
            eMoveResult moveResult;
            Move move;

            while (!isRoundOver)
            {
                m_ConsoleUI.PrintBoard(m_Board);

                moveResult = eMoveResult.InvalidFormat;

                while (moveResult != eMoveResult.Success)
                {
                    if (m_CurrentPlayer is ComputerPlayer)
                    {
                        Console.WriteLine("Computer is thinking...");
                        Thread.Sleep(1000);

                        move = ((ComputerPlayer)m_CurrentPlayer).ChooseMove(m_Board);
                        moveResult = PlayTurn(move);
                    }
                    else
                    {
                        move = m_ConsoleUI.ReadMove(m_CurrentPlayer);
                        moveResult = move.Result;

                        if (moveResult == eMoveResult.Success)
                        {
                            moveResult = PlayTurn(move);
                        }
                    }

                    switch (moveResult)
                    {
                        case eMoveResult.InvalidFormat:
                            m_ConsoleUI.PrintInvalidInputMessage();
                            break;

                        case eMoveResult.OutOfRange:
                            m_ConsoleUI.PrintCellOutOfRangeMessage();
                            break;

                        case eMoveResult.CellTaken:
                            m_ConsoleUI.PrintCellTakenMessage();
                            break;

                        case eMoveResult.Quit:
                            return;
                    }
                }

                isRoundOver = IsRoundOver();

                if (!isRoundOver)
                {
                    SwitchTurn();
                }
            }

            m_ConsoleUI.PrintBoard(m_Board);

            HandleRoundEnd();
        }

        /// Handles a single player turn.
        private eMoveResult PlayTurn(Move i_Move)
        {
            return m_Board.PlaceSymbol(i_Move.Row, i_Move.Col, m_CurrentPlayer.Symbol);
        }


        /// Switches the turn to the other player.
        private void SwitchTurn()
        {
            if (m_CurrentPlayer == m_Player1)
            {
                m_CurrentPlayer = m_Player2;
            }
            else
            {
                m_CurrentPlayer = m_Player1;
            }
        }

        /// Checks if the current round ended.
        private bool IsRoundOver()
        {
            return m_Board.HasLosingSequence(m_CurrentPlayer.Symbol) || m_Board.IsFull();
        }

        /// Updates scores and handles end of round.
        private void HandleRoundEnd()
        {
            if (m_Board.HasLosingSequence(m_CurrentPlayer.Symbol))
            {
                if (m_CurrentPlayer == m_Player1)
                {
                    m_Player2.AddPoint();
                    m_ConsoleUI.PrintWinner(m_Player2);
                }
                else
                {
                    m_Player1.AddPoint();
                    m_ConsoleUI.PrintWinner(m_Player1);
                }
            }
            else
            {
                m_ConsoleUI.PrintTie();
            }
        }

        /// Starts a new round with a cleared board.
        private void StartNewRound()
        {
            m_Board.Clear();
            m_CurrentPlayer = m_Player1;
        }
    }
}