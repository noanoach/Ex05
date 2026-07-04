
namespace Logic.Players
{
    public class Player
    {
        private string m_Name;
        private eCellValue m_Symbol;
        private int m_Score;

        /// Creates a new player.
        public Player(string i_Name, eCellValue i_Symbol)
        {
            m_Name = i_Name;
            m_Symbol = i_Symbol;
            m_Score = 0;
        }

        /// Returns the player's name.
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        /// Returns the player's symbol.       
        public eCellValue Symbol
        {
            get
            {
                return m_Symbol;
            }
        }
        
        /// Returns the player's score.       
        public int Score
        {
            get
            {
                return m_Score;
            }
        }
        
        /// Adds one point to the player's score.        
        public void AddPoint()
        {
            m_Score++;
        }
    }
}
