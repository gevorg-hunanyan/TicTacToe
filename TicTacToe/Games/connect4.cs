using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.Games
{

    public partial class connect4 : Form
    {
        Button[,] gameButtons = new Button[7, 6];
        int[,] gameData = new int[7, 6];
        int[] level = new int[7];
        bool player = true;
        int gameMode = 0;
        double scoreValueX = 0, scoreValueO = 0;

        public connect4(int gameMode)
        {
            this.gameMode = gameMode;
            InitializeComponent();
        }

        private void connect4_Load(object sender, EventArgs e)
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
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    gameButtons[i, j] = new Button();
                    gameButtons[i, j].FlatStyle = FlatStyle.Flat;
                    gameButtons[i, j].Size = new Size(100, 100);
                    gameButtons[i, j].Location = new Point(10 + 100 * i, 10 + 100 * j);
                    gameButtons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    gameButtons[i, j].TabIndex = 10 * i + j;
                    gameButtons[i, j].Click += gameButton_Click;
                    gameButtons[i, j].MouseEnter += gameButton_MouseEnter;
                    gameButtons[i, j].MouseLeave += gameButton_MouseLeave;
                    gameButtons[i, j].FlatAppearance.MouseOverBackColor = Color.Beige;
                    this.Controls.Add(gameButtons[i, j]);
                }
            }
        }

        private void gameButton_MouseEnter(object? sender, EventArgs e)
        {
            if ((bool)sender.GetType().GetProperty("Enabled").GetValue(sender))
            {
                for(int i = 0; i < 6; i++)
                {
                    gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].BackColor = Color.Beige;
                }
                if (level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10] < 6)
                    gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]].BackColor = Color.Bisque;
            }
        }

        private void gameButton_MouseLeave(object? sender, EventArgs e)
        {
            if ((bool)sender.GetType().GetProperty("Enabled").GetValue(sender))
            {
                for (int i = 0; i < 6; i++)
                {
                    gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].BackColor = SystemColors.Control;
                }
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; ++j)
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
            {
                for (int j = 0; j < 6; ++j)
                {
                    gameData[i, j] = 0;
                }
                level[i] = 0;
            }
        }

        private void rematchButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; ++j)
                {
                    gameButtons[i, j].GetType().GetProperty("BackgroundImage").SetValue(gameButtons[i, j], null);
                    gameButtons[i, j].GetType().GetProperty("Enabled").SetValue(gameButtons[i, j], true);
                }
            }
            winbox.ForeColor = Color.Red;
            winbox.Text = "X's turn";
            player = true;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; ++j)
                {
                    gameData[i, j] = 0;
                }
                level[i] = 0;
            }
        }

        private void gameButton_Click(object? sender, EventArgs e)
        {
            if (gameMode == 0)
            {
                if (level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10] == 5)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].Enabled = false;
                        gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].BackColor = SystemColors.Control;
                    }
                }
                if (player)
                {
                    gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]].BackgroundImage = TicTacToe.Properties.Resources.X;
                    gameData[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]] = 1;
                    level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]++;
                    player = false;
                    winbox.ForeColor = SystemColors.MenuHighlight;
                    winbox.Text = "O's turn";
                }
                else
                {
                    gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]].BackgroundImage = TicTacToe.Properties.Resources.O;
                    gameData[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]] = 2;
                    level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]++;
                    player = true;
                    winbox.ForeColor = Color.Red;
                    winbox.Text = "X's turn";
                }
                checkWin();
            }
            else if (gameMode == 1)
            {
                if (level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10] == 5)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].Enabled = false;
                        gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].BackColor = SystemColors.Control;
                    }
                }
                gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]].BackgroundImage = TicTacToe.Properties.Resources.X;
                gameData[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]] = 1;
                level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]++;
                player = false;

                checkWin();

                bool checker = false;
                for (int i = 0; i < 7; i++)
                {
                    if (gameButtons[i, 0].Enabled) checker = true;
                }
                if (!checker)
                {
                    return;
                }

                Random rnd = new Random();
                while (true)
                {
                    int rand1 = rnd.Next(0, 7);
                    if (level[rand1] != 6)
                    {
                        gameButtons[rand1, 5 - level[rand1]].BackgroundImage = TicTacToe.Properties.Resources.O;
                        gameData[rand1, level[rand1]] = 2;
                        level[rand1]++;
                        player = true;
                        winbox.ForeColor = Color.Red;
                        winbox.Text = "X's turn";

                        if (level[rand1] == 6)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                gameButtons[rand1, i].Enabled = false;
                                gameButtons[rand1, i].BackColor = SystemColors.Control;
                            }
                        }
                        checkWin();
                        break;
                    }
                }
            }
            else
            {
                if (level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10] == 5)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].Enabled = false;
                        gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, i].BackColor = SystemColors.Control;
                    }
                }
                gameButtons[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]].BackgroundImage = TicTacToe.Properties.Resources.X;
                gameData[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10, 5 - level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]] = 1;
                level[(int)(sender.GetType().GetProperty("TabIndex").GetValue(sender)) / 10]++;
                player = false;

                checkWin();

                bool checker = false;
                for (int i = 0; i < 7; i++)
                {
                    if (gameButtons[i, 0].Enabled) checker = true;
                }
                if (!checker)
                {
                    return;
                }

                GFGconnect4.Move bestMove = GFGconnect4.findBestMove(gameData, level);

                gameButtons[bestMove.row, 5 - level[bestMove.row]].BackgroundImage = TicTacToe.Properties.Resources.O;
                int b = (int)gameButtons[bestMove.row, 5 - level[bestMove.row]].TabIndex;
                gameData[bestMove.row, 5 - level[bestMove.row]] = 2;
                player = true;
                winbox.ForeColor = Color.Red;
                winbox.Text = "X's turn";
                gameButtons[bestMove.row, 5 - level[bestMove.row]].Enabled = false;
                level[bestMove.row]++;

                checkWin();
            }
        }

        private void checkWin()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameData[i,j] == gameData[i, j+1] && gameData[i, j] == gameData[i, j+2] && gameData[i, j] == gameData[i, j+3] && gameData[i,j] != 0)
                    {
                        if (gameData[i, j] == 1)
                        {
                            scoreValueX += 1;
                            scoreX.Text = scoreValueX.ToString();
                            winbox.ForeColor = Color.Red;
                            winbox.Text = "X wins!";
                            System.Diagnostics.Debug.WriteLine("I'm here 1");
                        }
                        else
                        {
                            scoreValueO += 1;
                            scoreO.Text = scoreValueO.ToString();
                            winbox.ForeColor = SystemColors.MenuHighlight;
                            winbox.Text = "O wins!";
                        }
                        for (int k = 0; k < 7; k++)
                            for (int h = 0; h < 6; h++)
                            {
                                gameButtons[k, h].Enabled = false;
                                gameButtons[k, h].BackColor = SystemColors.Control;
                            }
                        return;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (gameData[i, j] == gameData[i+1, j] && gameData[i, j] == gameData[i+2, j] && gameData[i, j] == gameData[i+3, j] && gameData[i, j] != 0)
                    {
                        if (gameData[i, j] == 1)
                        {
                            scoreValueX += 1;
                            scoreX.Text = scoreValueX.ToString();
                            winbox.ForeColor = Color.Red;
                            winbox.Text = "X wins!";
                            System.Diagnostics.Debug.WriteLine("I'm here 2");
                        }
                        else
                        {
                            scoreValueO += 1;
                            scoreO.Text = scoreValueO.ToString();
                            winbox.ForeColor = SystemColors.MenuHighlight;
                            winbox.Text = "O wins!";
                        }
                        for (int k = 0; k < 7; k++)
                            for (int h = 0; h < 6; h++)
                            {
                                gameButtons[k, h].Enabled = false;
                                gameButtons[k, h].BackColor = SystemColors.Control;
                            }
                        return;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameData[i, j] == gameData[i+1, j+1] && gameData[i, j] == gameData[i+2, j+2] && gameData[i, j] == gameData[i + 3, j+3] && gameData[i, j] != 0)
                    {
                        if (gameData[i, j] == 1)
                        {
                            scoreValueX += 1;
                            scoreX.Text = scoreValueX.ToString();
                            winbox.ForeColor = Color.Red;
                            winbox.Text = "X wins!";
                            System.Diagnostics.Debug.WriteLine("I'm here 2");
                        }
                        else
                        {
                            scoreValueO += 1;
                            scoreO.Text = scoreValueO.ToString();
                            winbox.ForeColor = SystemColors.MenuHighlight;
                            winbox.Text = "O wins!";
                        }
                        for (int k = 0; k < 7; k++)
                            for (int h = 0; h < 6; h++)
                            {
                                gameButtons[k, h].Enabled = false;
                                gameButtons[k, h].BackColor = SystemColors.Control;
                            }
                        return;
                    }
                }
            }
            for (int i = 3; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameData[i, j] == gameData[i-1, j+1] && gameData[i, j] == gameData[i-2, j+2] && gameData[i, j] == gameData[i-3, j+3] && gameData[i, j] != 0)
                    {
                        if (gameData[i, j] == 1)
                        {
                            scoreValueX += 1;
                            scoreX.Text = scoreValueX.ToString();
                            winbox.ForeColor = Color.Red;
                            winbox.Text = "X wins!";
                            System.Diagnostics.Debug.WriteLine("I'm here 2");
                        }
                        else
                        {
                            scoreValueO += 1;
                            scoreO.Text = scoreValueO.ToString();
                            winbox.ForeColor = SystemColors.MenuHighlight;
                            winbox.Text = "O wins!";
                        }
                        for (int k = 0; k < 7; k++)
                            for (int h = 0; h < 6; h++)
                            {
                                gameButtons[k, h].Enabled = false;
                                gameButtons[k, h].BackColor = SystemColors.Control;
                            }
                        return;
                    }
                }
            }
        }
    }
}