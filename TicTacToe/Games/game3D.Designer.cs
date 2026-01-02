namespace TicTacToe.Games
{
    partial class game3D
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.gameModeIndicator = new System.Windows.Forms.Label();
            this.winbox = new System.Windows.Forms.Label();
            this.rematchButton = new System.Windows.Forms.Button();
            this.scoreO = new System.Windows.Forms.Label();
            this.scoreX = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.solvedRadioButton = new System.Windows.Forms.RadioButton();
            this.randomizedRadioButton = new System.Windows.Forms.RadioButton();
            this.twoPlayersRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.gameModeIndicator);
            this.panel1.Controls.Add(this.winbox);
            this.panel1.Controls.Add(this.rematchButton);
            this.panel1.Controls.Add(this.scoreO);
            this.panel1.Controls.Add(this.scoreX);
            this.panel1.Controls.Add(this.scoreLabel);
            this.panel1.Controls.Add(this.newGameButton);
            this.panel1.Controls.Add(this.solvedRadioButton);
            this.panel1.Controls.Add(this.randomizedRadioButton);
            this.panel1.Controls.Add(this.twoPlayersRadioButton);
            this.panel1.Location = new System.Drawing.Point(1652, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 1;
            // 
            // gameModeIndicator
            // 
            this.gameModeIndicator.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameModeIndicator.ForeColor = System.Drawing.Color.Black;
            this.gameModeIndicator.Location = new System.Drawing.Point(10, 200);
            this.gameModeIndicator.Name = "gameModeIndicator";
            this.gameModeIndicator.Size = new System.Drawing.Size(180, 30);
            this.gameModeIndicator.TabIndex = 9;
            this.gameModeIndicator.Text = "two players";
            this.gameModeIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winbox
            // 
            this.winbox.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.winbox.ForeColor = System.Drawing.Color.Red;
            this.winbox.Location = new System.Drawing.Point(10, 230);
            this.winbox.Name = "winbox";
            this.winbox.Size = new System.Drawing.Size(180, 40);
            this.winbox.TabIndex = 8;
            this.winbox.Text = "X\'s turn";
            this.winbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rematchButton
            // 
            this.rematchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rematchButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.rematchButton.FlatAppearance.BorderSize = 3;
            this.rematchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rematchButton.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rematchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.rematchButton.Location = new System.Drawing.Point(10, 390);
            this.rematchButton.Name = "rematchButton";
            this.rematchButton.Size = new System.Drawing.Size(180, 50);
            this.rematchButton.TabIndex = 7;
            this.rematchButton.Text = "rematch";
            this.rematchButton.UseVisualStyleBackColor = false;
            this.rematchButton.Click += new System.EventHandler(this.rematchButton_Click);
            // 
            // scoreO
            // 
            this.scoreO.Font = new System.Drawing.Font("Showcard Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreO.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.scoreO.Location = new System.Drawing.Point(100, 330);
            this.scoreO.Name = "scoreO";
            this.scoreO.Size = new System.Drawing.Size(90, 50);
            this.scoreO.TabIndex = 6;
            this.scoreO.Text = "0";
            this.scoreO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreX
            // 
            this.scoreX.Font = new System.Drawing.Font("Showcard Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreX.ForeColor = System.Drawing.Color.Red;
            this.scoreX.Location = new System.Drawing.Point(10, 330);
            this.scoreX.Name = "scoreX";
            this.scoreX.Size = new System.Drawing.Size(90, 50);
            this.scoreX.TabIndex = 5;
            this.scoreX.Text = "0";
            this.scoreX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.Location = new System.Drawing.Point(10, 280);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(180, 60);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "score";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newGameButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.newGameButton.FlatAppearance.BorderSize = 3;
            this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameButton.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newGameButton.ForeColor = System.Drawing.SystemColors.Control;
            this.newGameButton.Location = new System.Drawing.Point(10, 120);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(180, 50);
            this.newGameButton.TabIndex = 3;
            this.newGameButton.Text = "new game";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // solvedRadioButton
            // 
            this.solvedRadioButton.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.solvedRadioButton.Location = new System.Drawing.Point(10, 76);
            this.solvedRadioButton.Name = "solvedRadioButton";
            this.solvedRadioButton.Size = new System.Drawing.Size(180, 27);
            this.solvedRadioButton.TabIndex = 2;
            this.solvedRadioButton.TabStop = true;
            this.solvedRadioButton.Text = "evaluated";
            this.solvedRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.solvedRadioButton.UseVisualStyleBackColor = true;
            // 
            // randomizedRadioButton
            // 
            this.randomizedRadioButton.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.randomizedRadioButton.Location = new System.Drawing.Point(10, 43);
            this.randomizedRadioButton.Name = "randomizedRadioButton";
            this.randomizedRadioButton.Size = new System.Drawing.Size(180, 27);
            this.randomizedRadioButton.TabIndex = 1;
            this.randomizedRadioButton.TabStop = true;
            this.randomizedRadioButton.Text = "randomized";
            this.randomizedRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.randomizedRadioButton.UseVisualStyleBackColor = true;
            // 
            // twoPlayersRadioButton
            // 
            this.twoPlayersRadioButton.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.twoPlayersRadioButton.Location = new System.Drawing.Point(10, 10);
            this.twoPlayersRadioButton.Name = "twoPlayersRadioButton";
            this.twoPlayersRadioButton.Size = new System.Drawing.Size(180, 27);
            this.twoPlayersRadioButton.TabIndex = 0;
            this.twoPlayersRadioButton.TabStop = true;
            this.twoPlayersRadioButton.Text = "Two players";
            this.twoPlayersRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.twoPlayersRadioButton.UseVisualStyleBackColor = true;
            // 
            // game3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1864, 471);
            this.Controls.Add(this.panel1);
            this.Name = "game3D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "game3D";
            this.Load += new System.EventHandler(this.game3D_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label gameModeIndicator;
        private Label winbox;
        private Button rematchButton;
        private Label scoreO;
        private Label scoreX;
        private Label scoreLabel;
        private Button newGameButton;
        private RadioButton solvedRadioButton;
        private RadioButton randomizedRadioButton;
        private RadioButton twoPlayersRadioButton;
    }
}