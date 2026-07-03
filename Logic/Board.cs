
namespace Logic
{
    internal enum eCellValue
    {
        Empty,
        X,
        O
    }
    internal class Board
    {
        private eCellValue[,] m_Cells;
        private int m_Size;

        /// Creates a square board with the given size.
        public Board(int i_Size)
        {
            m_Size = i_Size;
            m_Cells = new eCellValue[m_Size, m_Size];

            Clear();
        }

        /// Returns the board size.
        public int Size
        {
            get
            {
                return m_Size;
            }
        }

        /// Checks if a specific cell is empty.
        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            return m_Cells[i_Row, i_Col] == eCellValue.Empty;
        }

        private bool IsValidCell(int i_Row, int i_Col)
        {
            return i_Row >= 0 && i_Row < m_Size &&
                   i_Col >= 0 && i_Col < m_Size;
        }

        /// Places a symbol inside the requested cell.
        public eMoveResult PlaceSymbol(int i_Row, int i_Col, eCellValue i_Symbol)
        {
            if (!IsValidCell(i_Row, i_Col))
            {
                return eMoveResult.OutOfRange;
            }

            if (!IsCellEmpty(i_Row, i_Col))
            {
                return eMoveResult.CellTaken;
            }

            m_Cells[i_Row, i_Col] = i_Symbol;

            return eMoveResult.Success;
        }

        /// Returns the symbol stored in a cell.
        public eCellValue GetCell(int i_Row, int i_Col)
        {
            return m_Cells[i_Row, i_Col];
        }

        /// Checks whether the board is completely full.
        public bool IsFull()
        {
            for (int row = 0; row < m_Size; row++)
            {
                for (int col = 0; col < m_Size; col++)
                {
                    if (m_Cells[row, col] == eCellValue.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// Checks if the given symbol created a losing sequence.
        public bool HasLosingSequence(eCellValue i_Symbol)
        {
            bool isLosingSequence = true;

            // Check rows
            for (int row = 0; row < m_Size; row++)
            {
                isLosingSequence = true;

                for (int col = 0; col < m_Size; col++)
                {
                    if (m_Cells[row, col] != i_Symbol)
                    {
                        isLosingSequence = false;
                    }
                }

                if (isLosingSequence)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < m_Size; col++)
            {
                isLosingSequence = true;

                for (int row = 0; row < m_Size; row++)
                {
                    if (m_Cells[row, col] != i_Symbol)
                    {
                        isLosingSequence = false;
                    }
                }

                if (isLosingSequence)
                {
                    return true;
                }
            }

            // Check main diagonal
            isLosingSequence = true;

            for (int i = 0; i < m_Size; i++)
            {
                if (m_Cells[i, i] != i_Symbol)
                {
                    isLosingSequence = false;
                }
            }

            if (isLosingSequence)
            {
                return true;
            }

            // Check secondary diagonal
            isLosingSequence = true;

            for (int i = 0; i < m_Size; i++)
            {
                if (m_Cells[i, m_Size - 1 - i] != i_Symbol)
                {
                    isLosingSequence = false;
                }
            }

            return isLosingSequence;
        }

        /// Clears all cells for a new round.
        public void Clear()
        {
            for (int row = 0; row < m_Size; row++)
            {
                for (int col = 0; col < m_Size; col++)
                {
                    m_Cells[row, col] = eCellValue.Empty;
                }
            }
        }
    }

}

