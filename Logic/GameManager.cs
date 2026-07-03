using EX02.Players;
using Logic;

namespace EX02.Logic
{
    internal class GameManager
    {
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;

        public Board Board
        {
            get { return m_Board; }
        }

        public Player Player1
        {
            get { return m_Player1; }
        }

        public Player Player2
        {
            get { return m_Player2; }
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        /// Initializes the game logic with board size and game mode.
        public void InitializeGame(int i_BoardSize, bool i_IsAgainstComputer)
        {
            m_Player1 = new Player("Player 1", eCellValue.X);

            if (i_IsAgainstComputer)
            {
                m_Player2 = new ComputerPlayer("Player 2", eCellValue.O);
            }
            else
            {
                m_Player2 = new Player("Player 2", eCellValue.O);
            }

            m_Board = new Board(i_BoardSize);
            m_CurrentPlayer = m_Player1;
        }

        /// Places the current player's symbol on the board.
        public eMoveResult PlayTurn(Move i_Move)
        {
            return m_Board.PlaceSymbol(
                i_Move.Row,
                i_Move.Col,
                m_CurrentPlayer.Symbol);
        }

        /// Returns true if the current player is the computer.
        public bool IsCurrentPlayerComputer()
        {
            return m_CurrentPlayer is ComputerPlayer;
        }

        /// Gets the computer player's next move.
        public Move GetComputerMove()
        {
            return ((ComputerPlayer)m_CurrentPlayer).ChooseMove(m_Board);
        }

        /// Switches the turn to the other player.
        public void SwitchTurn()
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
        public bool IsRoundOver()
        {
            return m_Board.HasLosingSequence(m_CurrentPlayer.Symbol)
                   || m_Board.IsFull();
        }

        /// Returns true if the current player created a losing sequence.
        public bool CurrentPlayerLost()
        {
            return m_Board.HasLosingSequence(m_CurrentPlayer.Symbol);
        }

        /// Returns the winner of the round, or null if there is a tie.
        public Player GetRoundWinner()
        {
            Player winner = null;

            if (CurrentPlayerLost())
            {
                if (m_CurrentPlayer == m_Player1)
                {
                    winner = m_Player2;
                }
                else
                {
                    winner = m_Player1;
                }
            }

            return winner;
        }

        /// Adds one point to the round winner.
        public void AddPointToWinner()
        {
            Player winner = GetRoundWinner();

            if (winner != null)
            {
                winner.AddPoint();
            }
        }

        /// Starts a new round with a cleared board.
        public void StartNewRound()
        {
            m_Board.Clear();
            m_CurrentPlayer = m_Player1;
        }
    }
}