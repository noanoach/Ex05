
namespace Logic
{
    internal class Move
    {
        private int m_Row;
        private int m_Col;
        private eMoveResult m_Result;

        /// Creates a move with row and column values.
        public Move(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;

            m_Result = eMoveResult.Success;
        }

        /// Creates a special move result.
        public Move(eMoveResult i_Result)
        {
            m_Result = i_Result;
        }


        /// Returns the selected row.
        public int Row
        {
            get
            {
                return m_Row;
            }
        }

        /// Returns the selected column.
        public int Col
        {
            get
            {
                return m_Col;
            }
        }

        /// Returns the move result.
        public eMoveResult Result
        {
            get
            {
                return m_Result;
            }
        }
    }
}
