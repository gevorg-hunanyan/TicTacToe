using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TicTacToe.Games
{
    public partial class classicGame : Form
    {
        public classicGame(int gameMode)
        {
            InitializeComponent();
            this.gameMode = gameMode;
        }

        private void classicGame_Load(object sender, EventArgs e)
        {
            setButtons();
            if (gameMode == 1)
            {
                randomizedRadioButton.Checked = true;
                gameModeIndicator.Text = "randomized";
            }
            if (gameMode == 2)
            {
                solvedRadioButton.Checked = true;
                gameModeIndicator.Text = "evaluated";
            }
        }

        private void setButtons()
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    gameButtons[i, j] = new Button();
                    gameButtons[i, j].FlatStyle = FlatStyle.Flat;
                    gameButtons[i, j].Size = new Size(150, 150);
                    gameButtons[i, j].Location = new Point(10 + 150 * i, 10 + 150 * j);
                    gameButtons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    gameButtons[i, j].TabIndex = 10 * i + j;
                    gameButtons[i, j].Click += gameButton_Click;
                    this.Controls.Add(gameButtons[i, j]);
                }
            }
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (gameMode == 0)
            {
                if (player)
                {
                    button.BackgroundImage = TicTacToe.Properties.Resources.X;
                    int a = button.TabIndex;
                    gameData[a % 10, a / 10] = 1;
                    player = false;
                    winbox.ForeColor = SystemColors.MenuHighlight;
                    winbox.Text = "O's turn";
                    sender.GetType().GetProperty("Enabled").SetValue(sender, false);
                }
                else
                {
                    button.BackgroundImage = TicTacToe.Properties.Resources.O;
                    int a = button.TabIndex;
                    gameData[a % 10, a / 10] = 2;
                    player = true;
                    winbox.ForeColor = Color.Red;
                    winbox.Text = "X's turn";
                    sender.GetType().GetProperty("Enabled").SetValue(sender, false);
                }
                checkWin();
            }

            if (gameMode == 1)
            {
                // player's turn
                sender.GetType().GetProperty("BackgroundImage").SetValue(sender, TicTacToe.Properties.Resources.X);
                int a = button.TabIndex;
                gameData[a % 10, a / 10] = 1;
                player = false;
                winbox.ForeColor = SystemColors.MenuHighlight;
                winbox.Text = "O's turn";
                sender.GetType().GetProperty("Enabled").SetValue(sender, false);

                checkWin();

                // weak AI's turn
                Random rnd = new Random();
                while (true)
                {
                    // if there's an available field
                    bool check = false;
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            if (gameButtons[i, j].Enabled)
                                check = true;
                    if (!check)
                    {
                        return;
                    }

                    // making a move
                    int rand1 = rnd.Next(0, 3), rand2 = rnd.Next(0, 3);
                    if (gameButtons[rand1, rand2].Enabled)
                    {
                        gameButtons[rand1, rand2].BackgroundImage = TicTacToe.Properties.Resources.O;
                        int b = (int)gameButtons[rand1, rand2].TabIndex;
                        gameData[rand2, rand1] = 2;
                        player = true;
                        winbox.ForeColor = Color.Red;
                        winbox.Text = "X's turn";
                        gameButtons[rand1, rand2].Enabled = false;

                        checkWin();
                        break;
                    }
                }
            }

            if (gameMode == 2)
            {
                sender.GetType().GetProperty("BackgroundImage").SetValue(sender, TicTacToe.Properties.Resources.X);
                int a = button.TabIndex;
                gameData[a % 10, a / 10] = 1;
                player = false;
                winbox.ForeColor = SystemColors.MenuHighlight;
                winbox.Text = "O's turn";
                sender.GetType().GetProperty("Enabled").SetValue(sender, false);

                checkWin();
                bool check = false;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (gameButtons[i, j].Enabled)
                            check = true;
                if (!check)
                    return;

                GFG.Move bestMove = GFG.findBestMove(gameData);

                gameButtons[bestMove.col, bestMove.row].BackgroundImage = TicTacToe.Properties.Resources.O;
                int b = (int)gameButtons[bestMove.col, bestMove.row].TabIndex;
                gameData[bestMove.row, bestMove.col] = 2;
                player = true;
                winbox.ForeColor = Color.Red;
                winbox.Text = "X's turn";
                gameButtons[bestMove.col, bestMove.row].Enabled = false;

                checkWin();
            }
        }

        private void checkWin()
        {
            for (int i = 0; i < 3; ++i)
            {
                // checking columns
                if (gameData[0, i] == gameData[1, i] && gameData[1, i] == gameData[2, i] && gameData[0, i] != 0)
                {
                    if (!player)
                    {
                        scoreValueX += 1;
                        scoreX.Text = scoreValueX.ToString();
                        winbox.ForeColor = Color.Red;
                        winbox.Text = "X wins!";
                    }
                    else
                    {
                        scoreValueO += 1;
                        scoreO.Text = scoreValueO.ToString();
                        winbox.ForeColor = SystemColors.MenuHighlight;
                        winbox.Text = "O wins!";
                    }
                    for (int j = 0; j < 3; ++j)
                        for (int k = 0; k < 3; ++k)
                            gameButtons[j, k].Enabled = false;
                    return;
                }

                //checking rows
                if (gameData[i, 0] == gameData[i, 1] && gameData[i, 1] == gameData[i, 2] && gameData[i, 0] != 0)
                {
                    if (!player)
                    {
                        scoreValueX += 1;
                        scoreX.Text = scoreValueX.ToString();
                        winbox.ForeColor = Color.Red;
                        winbox.Text = "X wins!";
                    }
                    else
                    {
                        scoreValueO += 1;
                        scoreO.Text = scoreValueO.ToString();
                        winbox.ForeColor = SystemColors.MenuHighlight;
                        winbox.Text = "O wins!";
                    }
                    for (int j = 0; j < 3; ++j)
                        for (int k = 0; k < 3; ++k)
                            gameButtons[j, k].Enabled = false;
                    return;
                }
            }

            // checking diagonals
            if (gameData[0, 0] == gameData[1, 1] && gameData[1, 1] == gameData[2, 2] && gameData[0, 0] != 0)
            {
                if (!player)
                {
                    scoreValueX += 1;
                    scoreX.Text = scoreValueX.ToString();
                    winbox.ForeColor = Color.Red;
                    winbox.Text = "X wins!";
                }
                else
                {
                    scoreValueO += 1;
                    scoreO.Text = scoreValueO.ToString();
                    winbox.ForeColor = SystemColors.MenuHighlight;
                    winbox.Text = "O wins!";
                }
                for (int j = 0; j < 3; ++j)
                    for (int k = 0; k < 3; ++k)
                        gameButtons[j, k].Enabled = false;
                return;
            }
            if (gameData[2, 0] == gameData[1, 1] && gameData[1, 1] == gameData[0, 2] && gameData[2, 0] != 0)
            {
                if (!player)
                {
                    scoreValueX += 1;
                    scoreX.Text = scoreValueX.ToString();
                    winbox.ForeColor = Color.Red;
                    winbox.Text = "X wins!";
                }
                else
                {
                    scoreValueO += 1;
                    scoreO.Text = scoreValueO.ToString();
                    winbox.ForeColor = SystemColors.MenuHighlight;
                    winbox.Text = "O wins!";
                }
                for (int j = 0; j < 3; ++j)
                    for (int k = 0; k < 3; ++k)
                        gameButtons[j, k].Enabled = false;
                return;
            }

            // checking for tie
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (gameData[i, j] == 0)
                        return;
            scoreValueX += 0.5;
            scoreValueO += 0.5;
            scoreX.Text = scoreValueX.ToString();
            scoreO.Text = scoreValueO.ToString();
            winbox.ForeColor = SystemColors.ControlText;
            winbox.Text = "Tie!";
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; ++j)
                {
                    gameButtons[i, j].BackgroundImage = null; ;
                    gameButtons[i, j].Enabled = true;
                }
            }
            winbox.ForeColor = Color.Red;
            winbox.Text = "X's turn";
            player = true;

            scoreValueO = 0;
            scoreValueX = 0;
            scoreX.Text = "0";
            scoreO.Text = "0";

            if (twoPlayersRadioButton.Checked)
            {
                gameMode = 0;
                gameModeIndicator.Text = "two players";
            }
            if (randomizedRadioButton.Checked)
            {
                gameMode = 1;
                gameModeIndicator.Text = "randomized";
            }
            if (solvedRadioButton.Checked)
            {
                gameMode = 2;
                gameModeIndicator.Text = "evaluated";
            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; ++j)
                    gameData[i, j] = 0;
        }

        private void rematchButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; ++j)
                {
                    gameButtons[i, j].BackgroundImage = null;
                    gameButtons[i, j].Enabled = true;
                }
            }
            winbox.ForeColor = Color.Red;
            winbox.Text = "X's turn";
            player = true;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; ++j)
                    gameData[i, j] = 0;
        }
    }
}
