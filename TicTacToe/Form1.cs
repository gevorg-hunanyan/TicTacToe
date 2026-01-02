using TicTacToe.Games;

namespace TicTacToe
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void classicGameButton_Click(object sender, EventArgs e)
        {
            int gameMode;
            if (twoPlayersRadio.Checked) gameMode = 0;
            else if (randomizedRadio.Checked) gameMode = 1;
            else gameMode = 2;
            classicGame cl = new classicGame(gameMode);
            cl.ShowDialog();
        }

        private void connect4Button_Click(object sender, EventArgs e)
        {
            int gameMode;
            if (twoPlayersRadio.Checked) gameMode = 0;
            else if (randomizedRadio.Checked) gameMode = 1;
            else gameMode = 2;
            connect4 c4 = new connect4(gameMode);
            c4.ShowDialog();
        }

        private void gameButton7x7_Click(object sender, EventArgs e)
        {
            int gameMode;
            if (twoPlayersRadio.Checked) gameMode = 0;
            else if (randomizedRadio.Checked) gameMode = 1;
            else gameMode = 2;
            game7x7 game7 = new game7x7(gameMode);
            game7.ShowDialog();
        }

        private void gameButton3D_Click(object sender, EventArgs e)
        {
            int gameMode;
            if (twoPlayersRadio.Checked) gameMode = 0;
            else if (randomizedRadio.Checked) gameMode = 1;
            else gameMode = 2;
            game3D game3d = new game3D(gameMode);
            game3d.ShowDialog();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void twoPlayersRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (twoPlayersRadio.Checked) twoPlayersRadio.BackgroundImage = global::TicTacToe.Properties.Resources.circle;
            else twoPlayersRadio.BackgroundImage = null;
        }

        private void randomizedRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (randomizedRadio.Checked) randomizedRadio.BackgroundImage = global::TicTacToe.Properties.Resources.circle;
            else randomizedRadio.BackgroundImage = null;
        }

        private void solvedRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (solvedRadio.Checked) solvedRadio.BackgroundImage = global::TicTacToe.Properties.Resources.circle;
            else solvedRadio.BackgroundImage = null;
        }

        private void Launcher_Load(object sender, EventArgs e)
        {

        }
    }
}