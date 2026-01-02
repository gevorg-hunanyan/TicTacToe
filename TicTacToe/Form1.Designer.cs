namespace TicTacToe
{
    partial class Launcher
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
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.classicGameButton = new System.Windows.Forms.Button();
            this.connect4Button = new System.Windows.Forms.Button();
            this.gameButton7x7 = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.gameButton3D = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.solvedRadio = new System.Windows.Forms.RadioButton();
            this.randomizedRadio = new System.Windows.Forms.RadioButton();
            this.twoPlayersRadio = new System.Windows.Forms.RadioButton();
            this.bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bottomPanel.Controls.Add(this.aboutLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 700);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(945, 50);
            this.bottomPanel.TabIndex = 0;
            // 
            // aboutLabel
            // 
            this.aboutLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutLabel.Font = new System.Drawing.Font("Showcard Gothic", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.aboutLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.aboutLabel.Location = new System.Drawing.Point(0, 0);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(945, 50);
            this.aboutLabel.TabIndex = 0;
            this.aboutLabel.Text = "tic tac toe by Gevorg Hunanyan";
            this.aboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // classicGameButton
            // 
            this.classicGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.classicGameButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.classicGameButton.FlatAppearance.BorderSize = 5;
            this.classicGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classicGameButton.ForeColor = System.Drawing.SystemColors.Control;
            this.classicGameButton.Location = new System.Drawing.Point(280, 90);
            this.classicGameButton.Name = "classicGameButton";
            this.classicGameButton.Size = new System.Drawing.Size(385, 60);
            this.classicGameButton.TabIndex = 1;
            this.classicGameButton.Text = "classic tic tac toe";
            this.classicGameButton.UseVisualStyleBackColor = false;
            this.classicGameButton.Click += new System.EventHandler(this.classicGameButton_Click);
            // 
            // connect4Button
            // 
            this.connect4Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.connect4Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.connect4Button.FlatAppearance.BorderSize = 5;
            this.connect4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect4Button.ForeColor = System.Drawing.SystemColors.Control;
            this.connect4Button.Location = new System.Drawing.Point(280, 160);
            this.connect4Button.Name = "connect4Button";
            this.connect4Button.Size = new System.Drawing.Size(385, 60);
            this.connect4Button.TabIndex = 2;
            this.connect4Button.Text = "connect four";
            this.connect4Button.UseVisualStyleBackColor = false;
            this.connect4Button.Click += new System.EventHandler(this.connect4Button_Click);
            // 
            // gameButton7x7
            // 
            this.gameButton7x7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gameButton7x7.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.gameButton7x7.FlatAppearance.BorderSize = 5;
            this.gameButton7x7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameButton7x7.ForeColor = System.Drawing.SystemColors.Control;
            this.gameButton7x7.Location = new System.Drawing.Point(280, 230);
            this.gameButton7x7.Name = "gameButton7x7";
            this.gameButton7x7.Size = new System.Drawing.Size(385, 60);
            this.gameButton7x7.TabIndex = 3;
            this.gameButton7x7.Text = "7x7 tic tac toe";
            this.gameButton7x7.UseVisualStyleBackColor = false;
            this.gameButton7x7.Click += new System.EventHandler(this.gameButton7x7_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quitButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.quitButton.FlatAppearance.BorderSize = 5;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.quitButton.Location = new System.Drawing.Point(280, 570);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(385, 60);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // gameButton3D
            // 
            this.gameButton3D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gameButton3D.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.gameButton3D.FlatAppearance.BorderSize = 5;
            this.gameButton3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameButton3D.ForeColor = System.Drawing.SystemColors.Control;
            this.gameButton3D.Location = new System.Drawing.Point(280, 300);
            this.gameButton3D.Name = "gameButton3D";
            this.gameButton3D.Size = new System.Drawing.Size(385, 60);
            this.gameButton3D.TabIndex = 5;
            this.gameButton3D.Text = "3D tic tac toe";
            this.gameButton3D.UseVisualStyleBackColor = false;
            this.gameButton3D.Click += new System.EventHandler(this.gameButton3D_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.solvedRadio);
            this.panel1.Controls.Add(this.randomizedRadio);
            this.panel1.Controls.Add(this.twoPlayersRadio);
            this.panel1.Location = new System.Drawing.Point(280, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 140);
            this.panel1.TabIndex = 6;
            // 
            // solvedRadio
            // 
            this.solvedRadio.BackColor = System.Drawing.Color.Transparent;
            this.solvedRadio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.solvedRadio.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solvedRadio.ForeColor = System.Drawing.SystemColors.Control;
            this.solvedRadio.Location = new System.Drawing.Point(50, 90);
            this.solvedRadio.Name = "solvedRadio";
            this.solvedRadio.Size = new System.Drawing.Size(285, 40);
            this.solvedRadio.TabIndex = 2;
            this.solvedRadio.Text = "evaluated";
            this.solvedRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.solvedRadio.UseVisualStyleBackColor = false;
            this.solvedRadio.CheckedChanged += new System.EventHandler(this.solvedRadio_CheckedChanged);
            // 
            // randomizedRadio
            // 
            this.randomizedRadio.BackColor = System.Drawing.Color.Transparent;
            this.randomizedRadio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.randomizedRadio.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.randomizedRadio.ForeColor = System.Drawing.SystemColors.Control;
            this.randomizedRadio.Location = new System.Drawing.Point(50, 50);
            this.randomizedRadio.Name = "randomizedRadio";
            this.randomizedRadio.Size = new System.Drawing.Size(285, 40);
            this.randomizedRadio.TabIndex = 1;
            this.randomizedRadio.Text = "randomized";
            this.randomizedRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.randomizedRadio.UseVisualStyleBackColor = false;
            this.randomizedRadio.CheckedChanged += new System.EventHandler(this.randomizedRadio_CheckedChanged);
            // 
            // twoPlayersRadio
            // 
            this.twoPlayersRadio.BackColor = System.Drawing.Color.Transparent;
            this.twoPlayersRadio.BackgroundImage = global::TicTacToe.Properties.Resources.circle;
            this.twoPlayersRadio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.twoPlayersRadio.Checked = true;
            this.twoPlayersRadio.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.twoPlayersRadio.ForeColor = System.Drawing.SystemColors.Control;
            this.twoPlayersRadio.Location = new System.Drawing.Point(50, 10);
            this.twoPlayersRadio.Name = "twoPlayersRadio";
            this.twoPlayersRadio.Size = new System.Drawing.Size(285, 40);
            this.twoPlayersRadio.TabIndex = 0;
            this.twoPlayersRadio.TabStop = true;
            this.twoPlayersRadio.Text = "two players";
            this.twoPlayersRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.twoPlayersRadio.UseVisualStyleBackColor = false;
            this.twoPlayersRadio.CheckedChanged += new System.EventHandler(this.twoPlayersRadio_CheckedChanged);
            // 
            // Launcher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::TicTacToe.Properties.Resources.formBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(945, 750);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gameButton3D);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.gameButton7x7);
            this.Controls.Add(this.connect4Button);
            this.Controls.Add(this.classicGameButton);
            this.Controls.Add(this.bottomPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel bottomPanel;
        private Label aboutLabel;
        private Button classicGameButton;
        private Button connect4Button;
        private Button gameButton7x7;
        private Button quitButton;
        private Button gameButton3D;
        private Panel panel1;
        private RadioButton solvedRadio;
        private RadioButton randomizedRadio;
        private RadioButton twoPlayersRadio;
    }
}