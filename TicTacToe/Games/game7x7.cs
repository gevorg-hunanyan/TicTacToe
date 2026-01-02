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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TicTacToe.Games
{
    public partial class game7x7 : Form
    {
        Button[,] gameButtons = new Button[7, 7];
        int[,] gameData = new int[7, 7];
        bool player = true;
        int gameMode = 0;
        double scoreValueX = 0, scoreValueO = 0;

        public game7x7(int gameMode)
        {
            this.gameMode = gameMode;
            InitializeComponent();
        }

        private void game7x7_Load(object sender, EventArgs e)
        {
            setButtons();
            if (gameMode == 0)
            {
                twoPlayersRadioButton.Checked = true;
                gameModeIndicator.Text = "two plaers";
            }
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
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    gameButtons[i, j] = new Button();
                    gameButtons[i, j].FlatStyle = FlatStyle.Flat;
                    gameButtons[i, j].Size = new Size(100, 100);
                    gameButtons[i, j].Location = new Point(10 + 100 * i, 10 + 100 * j);
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
                    for (int i = 0; i < 7; i++)
                        for (int j = 0; j < 7; j++)
                            if ((bool)gameButtons[i, j].GetType().GetProperty("Enabled").GetValue(gameButtons[i, j]))
                                check = true;
                    if (!check)
                    {
                        return;
                    }

                    // making a move
                    int rand1 = rnd.Next(0, 7), rand2 = rnd.Next(0, 7);
                    if ((bool)gameButtons[rand1, rand2].GetType().GetProperty("Enabled").GetValue(gameButtons[rand1, rand2]))
                    {
                        gameButtons[rand1, rand2].GetType().GetProperty("BackgroundImage").SetValue(gameButtons[rand1, rand2], TicTacToe.Properties.Resources.O);
                        int b = (int)gameButtons[rand1, rand2].GetType().GetProperty("TabIndex").GetValue(gameButtons[rand1, rand2]);
                        gameData[rand2, rand1] = 2;
                        player = true;
                        winbox.ForeColor = Color.Red;
                        winbox.Text = "X's turn";
                        gameButtons[rand1, rand2].GetType().GetProperty("Enabled").SetValue(gameButtons[rand1, rand2], false);

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
                for (int i = 0; i < 7; i++)
                    for (int j = 0; j < 7; j++)
                        if ((bool)gameButtons[i, j].GetType().GetProperty("Enabled").GetValue(gameButtons[i, j]))
                            check = true;
                if (!check)
                    return;

                GFGbig.Move bestMove = GFGbig.findBestMove(gameData);

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
            for (int i = 0; i < 7; i++)
            {
                // checking columns
                for (int j = 0; j < 4; j++)
                {
                    if (gameData[j, i] == gameData[j+1, i] && gameData[j+1, i] == gameData[j+2, i] && gameData[j + 2, i] == gameData[j + 3, i] && gameData[j, i] != 0)
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
                        for (int h = 0; h < 7; ++h)
                            for (int k = 0; k < 7; ++k)
                                gameButtons[h, k].GetType().GetProperty("Enabled").SetValue(gameButtons[h, k], false);
                        return;
                    }

                //checking rows
                    if (gameData[i, j] == gameData[i, j + 1] && gameData[i, j + 1] == gameData[i, j + 2] && gameData[i, j + 2] == gameData[i, j + 3] && gameData[i, j] != 0)
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
                        for (int h = 0; h < 7; ++h)
                            for (int k = 0; k < 7; ++k)
                                gameButtons[h, k].Enabled = false;
                        return;
                    }
                }
            }

            // checking diagonals
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameData[i, j] == gameData[i+1, j+1] && gameData[i+1, j+1] == gameData[i+2, j+2] && gameData[i+2, j+2] == gameData[i+3, j+3] && gameData[i, j] != 0)
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
                        for (int h = 0; h < 7; ++h)
                            for (int k = 0; k < 7; ++k)
                                gameButtons[h, k].GetType().GetProperty("Enabled").SetValue(gameButtons[h, k], false);
                        return;
                    }
                    if (gameData[i+3, j] == gameData[i+2, j+1] && gameData[i+3, j] == gameData[i+1, j+2] && gameData[i+3, j] == gameData[i, j+3] && gameData[i+3, j] != 0)
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
                        for (int h = 0; h < 7; ++h)
                            for (int k = 0; k < 7; ++k)
                                gameButtons[h, k].GetType().GetProperty("Enabled").SetValue(gameButtons[h, k], false);
                        return;
                    }
                }
            }

            // checking for tie
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
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
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; ++j)
                {
                    gameButtons[i, j].GetType().GetProperty("BackgroundImage").SetValue(gameButtons[i, j], null);
                    gameButtons[i, j].GetType().GetProperty("Enabled").SetValue(gameButtons[i, j], true);
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

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; ++j)
                    gameData[i, j] = 0;
        }

        private void rematchButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; ++j)
                {
                    gameButtons[i, j].GetType().GetProperty("BackgroundImage").SetValue(gameButtons[i, j], null);
                    gameButtons[i, j].GetType().GetProperty("Enabled").SetValue(gameButtons[i, j], true);
                }
            }
            winbox.ForeColor = Color.Red;
            winbox.Text = "X's turn";
            player = true;

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; ++j)
                    gameData[i, j] = 0;
        }
    }
}
