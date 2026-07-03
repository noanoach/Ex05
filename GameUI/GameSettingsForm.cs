using System;
using System.Windows.Forms;

namespace GameUI
{
    public partial class FormGameSettings : Form
    {
        private const int k_MinBoardSize = 4;
        private const int k_MaxBoardSize = 10;
        private const string k_ComputerName = "Computer";

        public FormGameSettings()
        {
            InitializeComponent();
            initializeFormDefaults();
        }

        private void initializeFormDefaults()
        {
            numericUpDownRows.Minimum = k_MinBoardSize;
            numericUpDownRows.Maximum = k_MaxBoardSize;
            numericUpDownRows.Value = k_MinBoardSize;

            numericUpDownCols.Minimum = k_MinBoardSize;
            numericUpDownCols.Maximum = k_MaxBoardSize;
            numericUpDownCols.Value = k_MinBoardSize;

            checkBoxPlayer2.Checked = false;
            textBoxPlayer2.Text = k_ComputerName;
            textBoxPlayer2.Enabled = false;
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            bool isSecondPlayerHuman = checkBoxPlayer2.Checked;

            textBoxPlayer2.Enabled = isSecondPlayerHuman;

            if (isSecondPlayerHuman)
            {
                textBoxPlayer2.Text = string.Empty;
                textBoxPlayer2.Focus();
            }
            else
            {
                textBoxPlayer2.Text = k_ComputerName;
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            string player1Name = getPlayer1Name();
            string player2Name = getPlayer2Name();
            int boardSize = (int)numericUpDownRows.Value;
            bool isAgainstComputer = !checkBoxPlayer2.Checked;

            FormGameBoard gameBoardForm = new FormGameBoard(
                player1Name,
                player2Name,
                boardSize,
                isAgainstComputer);

            Hide();
            gameBoardForm.ShowDialog();
            Close();
        }

        private string getPlayer1Name()
        {
            string playerName = textBoxPlayer1.Text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Player 1";
            }

            return playerName;
        }

        private string getPlayer2Name()
        {
            string playerName;

            if (checkBoxPlayer2.Checked)
            {
                playerName = textBoxPlayer2.Text.Trim();

                if (string.IsNullOrEmpty(playerName))
                {
                    playerName = "Player 2";
                }
            }
            else
            {
                playerName = k_ComputerName;
            }

            return playerName;
        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Text = "Players:";
        }

        private void buttonPlay_Click_1(object sender, EventArgs e)
        {

        }
    }
}