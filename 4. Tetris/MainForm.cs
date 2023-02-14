using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// https://www.sejuku.net/blog/33865 >> 配列のお勉強


namespace tetris
{
    public partial class MainForm : Form
    {
        private Label[, ] mass;
        private Label game_inform = new Label();
        private Control control = new Control();

        public MainForm()
        {
            control.init();

            InitializeComponent();
            AdditionalInitializeComponent();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            control.switch_game_over = false;
            control.init();
            inform_game();
            update_mass();
            label_ScoreV.Text = control.score.ToString();
        }

        private void update_mass()
        {
            int width = control.width;
            int length = control.length;
            for (int i = 0; i < length; i++) for (int j = 0; j < width; j++) put_mass_color(i, j);
        }

        private void AdditionalInitializeComponent()
        {
            int width = control.width;
            int length = control.length;
            int massSize = control.massSize;
            int[] anchor = control.anchor;

            mass = new Label[length, width];
            for(int i=0; i<length; i++)
            {
                for(int j=0; j<width; j++)
                {
                    mass[i, j] = new Label();
                    mass[i, j].Location = new Point(anchor[0] + j * (massSize + 1), anchor[1] + i * (massSize + 1));
                    mass[i, j].Size = new Size(massSize, massSize);
                    put_mass_color(i, j);
                    this.Controls.Add(mass[i, j]);
                }
            }

            game_inform.Location = new Point(500, 350);
            game_inform.Size = new Size(200, 50);
            game_inform.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(game_inform);
            inform_game();

            label_ScoreV.Text = control.score.ToString();
            label_BestV.Text = control.bestScore.ToString();
        }

        private void clear_label_key()
        {
            label_A.BackColor = Color.Silver;
            label_D.BackColor = Color.Silver;
            label_S.BackColor = Color.Silver;
            label_W.BackColor = Color.Silver;
        }

        private void inform_game()
        {
            if (control.score >= 0)   { game_inform.BackColor = Color.Transparent; game_inform.Text = "Lv. 1"; }
            if (control.score >= 100) { game_inform.BackColor = Color.Transparent; game_inform.Text = "Lv. 2"; }
            if (control.score >= 200) { game_inform.BackColor = Color.Transparent; game_inform.Text = "Lv. 3"; }
            if (control.score >= 300) { game_inform.BackColor = Color.Transparent; game_inform.Text = "Lv. 4"; }
            if (control.score >= 400) { game_inform.BackColor = Color.Transparent; game_inform.Text = "Lv. 5"; }
            if (control.switch_game_over) { game_inform.BackColor = Color.Red; game_inform.Text = "Game Over !!"; }
        }

        private void put_mass_color(int i, int j)
        {
            if (control.massData[i, j] == 0 && i < control.death_range) mass[i, j].BackColor = Color.LemonChiffon;
            if (control.massData[i, j] == 0 && i >= control.death_range) mass[i, j].BackColor = Color.Aquamarine;
            if (control.massData[i, j] == 1) mass[i, j].BackColor = Color.Red;
            if (control.massData[i, j] == 2) mass[i, j].BackColor = Color.Green;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            clear_label_key();

            switch (e.KeyData)
            {
                case Keys.A:
                    control.shift = "A";
                    label_A.BackColor = Color.SpringGreen;
                    label_Message.Text = "Shift left";
                    break;
                case Keys.D:
                    control.shift = "D";
                    label_D.BackColor = Color.SpringGreen;
                    label_Message.Text = "Shift right";
                    break;
                case Keys.W:
                    control.shift = "W";
                    label_W.BackColor = Color.SpringGreen;
                    label_Message.Text = "Shift rotate";
                    break;
                case Keys.S:
                    control.shift = "S";
                    label_S.BackColor = Color.SpringGreen;
                    label_Message.Text = "Shift down";
                    break;
            }
            control.update_massData();
            update_mass();
            inform_game();
            label_ScoreV.Text = control.score.ToString();
            label_BestV.Text = control.bestScore.ToString();
        }
    }
}
