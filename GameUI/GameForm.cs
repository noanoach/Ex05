using System;
using System.Drawing;
using System.Windows.Forms;
using Logic;
using Logic.Players;

namespace GameUI
{
    public partial class FormGameBoard : Form
    {
        private const int k_ButtonSize = 58;
        private const int k_Margin = 10;
        private const int k_Gap = 6;
        private const int k_ScoreAreaHeight = 38;

        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private readonly int r_BoardSize;
        private readonly bool r_IsAgainstComputer;

        private Button[,] m_BoardButtons;
        private Label m_LabelScore;
        private GameManager m_GameManager;

        public FormGameBoard(
            string i_Player1Name,
            string i_Player2Name,
            int i_BoardSize,
            bool i_IsAgainstComputer)
        {
            InitializeComponent();

            r_Player1Name = i_Player1Name;
            r_Player2Name = i_Player2Name;
            r_BoardSize = i_BoardSize;
            r_IsAgainstComputer = i_IsAgainstComputer;

            m_GameManager = new GameManager();
            m_GameManager.InitializeGame(
                r_BoardSize,
                r_Player1Name,
                r_Player2Name,
                r_IsAgainstComputer);

            initializeGameBoard();
        }

        private void initializeGameBoard()
        {
            Text = "TicTacToeMisere";
            BackColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            createBoardButtons();
            createScoreLabel();
            adjustFormSize();
        }

        private void createBoardButtons()
        {
            m_BoardButtons = new Button[r_BoardSize, r_BoardSize];

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    Button button = new Button();

                    button.Size = new Size(k_ButtonSize, k_ButtonSize);
                    button.Location = new Point(
                        k_Margin + col * (k_ButtonSize + k_Gap),
                        k_Margin + row * (k_ButtonSize + k_Gap));

                    button.FlatStyle = FlatStyle.Standard;
                    button.UseVisualStyleBackColor = false;
                    button.BackColor = SystemColors.Control;
                    button.ForeColor = SystemColors.GrayText;
                    button.Font = new Font("Microsoft Sans Serif", 12);
                    button.Tag = new Point(row, col);
                    button.Click += boardButton_Click;

                    m_BoardButtons[row, col] = button;
                    Controls.Add(button);
                }
            }
        }

        private void createScoreLabel()
        {
            m_LabelScore = new Label();

            m_LabelScore.AutoSize = true;
            m_LabelScore.Font = new Font(Font, FontStyle.Bold);
            m_LabelScore.Text = string.Format("{0}: 0    {1}: 0", r_Player1Name, r_Player2Name);

            int boardWidth = getBoardPixelSize();

            m_LabelScore.Location = new Point(
                k_Margin + (boardWidth - m_LabelScore.PreferredWidth) / 2,
                k_Margin + boardWidth + 14);

            Controls.Add(m_LabelScore);
        }

        private void adjustFormSize()
        {
            int boardSizeInPixels = getBoardPixelSize();

            ClientSize = new Size(
                boardSizeInPixels + 2 * k_Margin,
                boardSizeInPixels + 2 * k_Margin + k_ScoreAreaHeight);
        }

        private int getBoardPixelSize()
        {
            return r_BoardSize * k_ButtonSize + (r_BoardSize - 1) * k_Gap;
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                Point point = (Point)clickedButton.Tag;
                Move move = new Move(point.X, point.Y);

                m_GameManager.PlayTurn(move);

                clickedButton.Text = m_GameManager.CurrentPlayer.Symbol.ToString();
                clickedButton.Enabled = false;

                if (m_GameManager.IsRoundOver())
                {
                    handleRoundOver();
                }
                else
                {
                    m_GameManager.SwitchTurn();
                }
            }

        }

        private void handleRoundOver()
        {
            Player winner = m_GameManager.GetRoundWinner();
            string message;

            m_GameManager.AddPointToWinner();
            updateScoreLabel();

            if (winner == null)
            {
                message = "Tie!";
            }
            else
            {
                message = string.Format("The winner is {0}!", winner.Name);
            }

            DialogResult result = MessageBox.Show(
                message + Environment.NewLine + "Would you like to play another round?",
                "A Round Ended",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                m_GameManager.StartNewRound();
                clearBoardButtons();
            }
            else
            {
                this.Close();
            }
        }

        private void updateScoreLabel()
        {
            m_LabelScore.Text = string.Format(
                "{0}: {1}    {2}: {3}",
                m_GameManager.Player1.Name,
                m_GameManager.Player1.Score,
                m_GameManager.Player2.Name,
                m_GameManager.Player2.Score);
        }

        private void clearBoardButtons()
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    m_BoardButtons[row, col].Text = string.Empty;
                    m_BoardButtons[row, col].Enabled = true;
                }
            }
        }
    }
    
}