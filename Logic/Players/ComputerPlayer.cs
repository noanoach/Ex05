using System;

namespace Logic
{
    internal class ComputerPlayer : Player
    {
        private Random m_Random;

        /// Creates a computer-controlled player.
        public ComputerPlayer(string i_Name, eCellValue i_Symbol)
            : base(i_Name, i_Symbol)
        {
            m_Random = new Random();
        }

        /// Selects a random valid move.
        public Move ChooseMove(Board i_Board)
        {
            int row;
            int col;

            do
            {
                row = m_Random.Next(i_Board.Size);
                col = m_Random.Next(i_Board.Size);
            }
            while (!i_Board.IsCellEmpty(row, col));

            return new Move(row, col);
        }
    }
}
