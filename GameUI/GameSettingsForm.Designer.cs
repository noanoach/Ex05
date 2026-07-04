namespace GameUI
{
    partial class FormGameSettings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBoxPlayer1 = new TextBox();
            checkBoxPlayer2 = new CheckBox();
            textBoxPlayer2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            numericUpDownRows = new NumericUpDown();
            label5 = new Label();
            numericUpDownCols = new NumericUpDown();
            buttonPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCols).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Player 1:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 20);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 1;
            label2.Text = "Players:";
            // 
            // textBoxPlayer1
            // 
            textBoxPlayer1.Location = new Point(110, 56);
            textBoxPlayer1.Name = "textBoxPlayer1";
            textBoxPlayer1.Size = new Size(125, 27);
            textBoxPlayer1.TabIndex = 2;
            // 
            // checkBoxPlayer2
            // 
            checkBoxPlayer2.AutoSize = true;
            checkBoxPlayer2.Location = new Point(12, 97);
            checkBoxPlayer2.Name = "checkBoxPlayer2";
            checkBoxPlayer2.Size = new Size(86, 24);
            checkBoxPlayer2.TabIndex = 3;
            checkBoxPlayer2.Text = "Player 2:";
            checkBoxPlayer2.UseVisualStyleBackColor = true;
            checkBoxPlayer2.CheckedChanged += checkBoxPlayer2_CheckedChanged;
            // 
            // textBoxPlayer2
            // 
            textBoxPlayer2.Enabled = false;
            textBoxPlayer2.Location = new Point(110, 97);
            textBoxPlayer2.Name = "textBoxPlayer2";
            textBoxPlayer2.Size = new Size(125, 27);
            textBoxPlayer2.TabIndex = 4;
            textBoxPlayer2.Text = "[Computer]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 168);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "Board Size:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 205);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 6;
            label4.Text = "Rows:";
            // 
            // numericUpDownRows
            // 
            numericUpDownRows.Location = new Point(110, 203);
            numericUpDownRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownRows.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownRows.Name = "numericUpDownRows";
            numericUpDownRows.Size = new Size(40, 27);
            numericUpDownRows.TabIndex = 7;
            numericUpDownRows.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownRows.ValueChanged += numericUpDownRows_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(195, 205);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 6;
            label5.Text = "Cols:";
            // 
            // numericUpDownCols
            // 
            numericUpDownCols.Location = new Point(251, 203);
            numericUpDownCols.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownCols.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownCols.Name = "numericUpDownCols";
            numericUpDownCols.Size = new Size(40, 27);
            numericUpDownCols.TabIndex = 7;
            numericUpDownCols.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownCols.ValueChanged += numericUpDownCols_ValueChanged;
            // 
            // buttonPlay
            // 
            buttonPlay.BackColor = SystemColors.ControlLightLight;
            buttonPlay.Location = new Point(21, 245);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(270, 29);
            buttonPlay.TabIndex = 8;
            buttonPlay.Text = "Start!";
            buttonPlay.TextAlign = ContentAlignment.BottomCenter;
            buttonPlay.UseVisualStyleBackColor = false;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // FormGameSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(325, 301);
            Controls.Add(buttonPlay);
            Controls.Add(numericUpDownCols);
            Controls.Add(numericUpDownRows);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxPlayer2);
            Controls.Add(checkBoxPlayer2);
            Controls.Add(textBoxPlayer1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormGameSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCols).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxPlayer1;
        private CheckBox checkBoxPlayer2;
        private TextBox textBoxPlayer2;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDownRows;
        private Label label5;
        private NumericUpDown numericUpDownCols;
        private Button buttonPlay;
    }
}
