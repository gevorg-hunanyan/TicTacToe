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
    public partial class game3D : Form
    {
        bool player = true;
        int gameMode = 0;
        double scoreValueX = 0, scoreValueO = 0;
        Button[,,] gameButtons = new Button[4, 4, 4];
        int[,,] gameData = new int[4, 4, 4];

        public game3D(int gameMode)
        {
            this.gameMode = gameMode;
            InitializeComponent();
        }

        private void game3D_Load(object sender, EventArgs e)
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
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        gameButtons[i, j, k] = new Button();
                        gameButtons[i, j, k].FlatStyle = FlatStyle.Flat;
                        gameButtons[i, j, k].Size = new Size(100, 100);
                        gameButtons[i, j, k].Location = new Point(10 + 100 * i + 410 * k, 37 + 100 * j);
                        gameButtons[i, j, k].BackgroundImageLayout = ImageLayout.Stretch;
                        gameButtons[i, j, k].TabIndex = 100 * i + 10 * j + k;
                        gameButtons[i, j, k].Click += gameButton_Click;
                        this.Controls.Add(gameButtons[i, j, k]);
                    }
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
                    gameData[a / 100, (a / 10) % 10, a % 10] = 1;
                    player = false;
                    winbox.ForeColor = SystemColors.MenuHighlight;
                    winbox.Text = "O's turn";
                    sender.GetType().GetProperty("Enabled").SetValue(sender, false);
                }
                else
                {
                    button.BackgroundImage = TicTacToe.Properties.Resources.O;
                    int a = button.TabIndex;
                    gameData[a / 100, (a / 10) % 10, a % 10] = 2;
                    player = true;
                    winbox.ForeColor = Color.Red;
                    winbox.Text = "X's turn";
                    sender.GetType().GetProperty("Enabled").SetValue(sender, false);
                }
                checkWin();
            }

            if (gameMode == 1 || gameMode == 2)
            {
                // player's turn
                button.BackgroundImage = TicTacToe.Properties.Resources.X;
                int a = button.TabIndex;
                gameData[a / 100, (a / 10) % 10, a % 10] = 1;
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
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            for (int k = 0; k < 4; k++)
                                if (gameButtons[i, j, k].Enabled)
                                    check = true;
                    if (!check)
                    {
                        return;
                    }

                    // making a move
                    int rand1 = rnd.Next(0, 4), rand2 = rnd.Next(0, 4), rand3 = rnd.Next(0, 4);
                    if (gameButtons[rand1, rand2, rand3].Enabled)
                    {
                        gameButtons[rand1, rand2, rand3].BackgroundImage = TicTacToe.Properties.Resources.O;
                        int b = (int)gameButtons[rand1, rand2, rand3].TabIndex;
                        gameData[rand3, rand2, rand1] = 2;
                        player = true;
                        winbox.ForeColor = Color.Red;
                        winbox.Text = "X's turn";
                        gameButtons[rand1, rand2, rand3].Enabled = false;

                        checkWin();
                        break;
                    }
                }
            }

            /*if (gameMode == 2)
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
            }*/
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        gameButtons[i, j, k].BackgroundImage = null; ;
                        gameButtons[i, j, k].Enabled = true;
                    }
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

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; ++j)
                    for (int k = 0; k < 4; ++k)
                        gameData[i, j, k] = 0;
        }

        private void rematchButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        gameButtons[i, j, k].BackgroundImage = null;
                        gameButtons[i, j, k].Enabled = true;
                    }
                }
            }
            winbox.ForeColor = Color.Red;
            winbox.Text = "X's turn";
            player = true;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; ++j)
                    for (int k = 0; k < 4; ++k)
                        gameData[i, j, k] = 0;
        }

        private void winCondition(bool player)
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
            for (int a = 0; a < 4; a++)
                for (int b = 0; b < 4; b++)
                    for (int c = 0; c < 4; c++)
                        gameButtons[a, b, c].Enabled = false;
        }

        private void checkWin()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; j++)
                {
                    // checking by first coordinate
                    if (gameData[0, i, j] == gameData[1, i, j] && gameData[1, i, j] == gameData[2, i, j] && gameData[2, i, j] == gameData[3, i, j] && gameData[0, i, j] != 0)
                    {
                        winCondition(player);
                        return;
                    }
                    // checking by second coordinate
                    if (gameData[i, 0, j] == gameData[i, 1, j] && gameData[i, 1, j] == gameData[i, 2, j] && gameData[i, 2, j] == gameData[i, 3, j] && gameData[i, 0, j] != 0)
                    {
                        winCondition(player);
                        return;
                    }
                    // checking by third coordinate
                    if (gameData[i, j, 0] == gameData[i, j, 1] && gameData[i, j, 1] == gameData[i, j, 2] && gameData[i, j, 2] == gameData[i, j, 3] && gameData[i, j, 0] != 0)
                    {
                        winCondition(player);
                        return;
                    }
                }
                // checking short diagonals
                if (gameData[i,0,0] == gameData[i,1,1] && gameData[i,1,1] == gameData[i,2,2] && gameData[i,2,2] == gameData[i,3,3] && gameData[i,0,0] != 0)
                {
                    winCondition(player);
                    return;
                }
                if (gameData[i,3,0] == gameData[i,2,1] && gameData[i,2,1] == gameData[i,1,2] && gameData[i,1,2] == gameData[i,0,3] && gameData[i,3,0] != 0)
                {
                    winCondition(player);
                    return;
                }
                if (gameData[0,i,0] == gameData[1,i,1] && gameData[1,i,1] == gameData[2,i,2] && gameData[2,i,2] == gameData[3,i,3] && gameData[0,i,0] != 0)
                {
                    winCondition(player);
                    return;
                }
                if (gameData[3,i,0] == gameData[2,i,1] && gameData[2,i,1] == gameData[1,i,2] && gameData[1,i,2] == gameData[0,i,3] && gameData[3,i,0] != 0)
                {
                    winCondition(player);
                    return;
                }
                if (gameData[0,0,i] == gameData[1,1,i] && gameData[1,1,i] == gameData[2,2,i] && gameData[2,2,i] == gameData[3,3,i] && gameData[0,0,i] != 0)
                {
                    winCondition(player);
                    return;
                }
                if (gameData[3,0,i] == gameData[2,1,i] && gameData[2,1,i] == gameData[1,2,i] && gameData[1,2,i] == gameData[0,3,i] && gameData[3,0,i] != 0)
                {
                    winCondition(player);
                    return;
                }
            }
            //checking long diagonals
            if (gameData[0, 0, 0] == gameData[1, 1, 1] && gameData[1, 1, 1] == gameData[2, 2, 2] && gameData[2, 2, 2] == gameData[3, 3, 3] && gameData[0, 0, 0] != 0)
            {
                winCondition(player);
                return;
            }
            if (gameData[0, 0, 3] == gameData[1, 1, 3] && gameData[1, 1, 3] == gameData[2, 2, 1] && gameData[2, 2, 1] == gameData[3, 3, 0] && gameData[0, 0, 3] != 0)
            {
                winCondition(player);
                return;
            }
            if (gameData[0, 3, 0] == gameData[1, 2, 1] && gameData[1, 2, 1] == gameData[2, 1, 2] && gameData[2, 1, 2] == gameData[3, 0, 3] && gameData[0, 3, 0] != 0)
            {
                winCondition(player);
                return;
            }
            if (gameData[3, 0, 0] == gameData[2, 1, 1] && gameData[2, 1, 1] == gameData[1, 2, 2] && gameData[1, 2, 2] == gameData[0, 3, 3] && gameData[3, 0, 0] != 0)
            {
                winCondition(player);
                return;
            }

            // checking for tie
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        if (gameData[i, j, k] == 0)
                            return;
            scoreValueX += 0.5;
            scoreValueO += 0.5;
            scoreX.Text = scoreValueX.ToString();
            scoreO.Text = scoreValueO.ToString();
            winbox.ForeColor = SystemColors.ControlText;
            winbox.Text = "Tie!";
        }
    }
}
