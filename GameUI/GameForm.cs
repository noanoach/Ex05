using System.Windows.Forms;

namespace GameUI
{
    public partial class FormGameBoard : Form
    {
        public FormGameBoard(
            string i_Player1Name,
            string i_Player2Name,
            int i_BoardSize,
            bool i_IsAgainstComputer)
        {
            InitializeComponent();
        }
    }
}