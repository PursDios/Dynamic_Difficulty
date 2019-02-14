using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dynamic_Difficulty
{
    public partial class BoardForm : Form
    {
        private bool valid=false;
        private List<PictureBox> pictureBoxList;
        private delegate void InvokeDelegate();

        public BoardForm()
        {
            InitializeComponent();
            pictureBoxList = new List<PictureBox>();

            pictureBoxList.Add(pictureBox1);
            pictureBoxList.Add(pictureBox2);
            pictureBoxList.Add(pictureBox3);
            pictureBoxList.Add(pictureBox4);
            pictureBoxList.Add(pictureBox5);
            pictureBoxList.Add(pictureBox6);
            pictureBoxList.Add(pictureBox7);
            pictureBoxList.Add(pictureBox8);
            pictureBoxList.Add(pictureBox9);
            pictureBoxList.Add(pictureBox10);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Gameplay.getInstance().getChoice = 1;
            valid = Gameplay.getInstance().CheckChoice();
            if (!valid)
                MessageBox.Show("Invalid Selection. This spot is already taken.");
            else
            {
                Gameplay.getInstance().ApplyChoice();

                if (Gameplay.getInstance().isTurnX)
                    pictureBox1.ImageLocation = "X.png";
                else
                    pictureBox1.ImageLocation = "O.png";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        public void UpdateBoard()
        {
            if (this.Enabled)
            {
                BeginInvoke(new InvokeDelegate(UpdateUI));
            }
        }

        private void UpdateUI()
        {
            for(int i=0; i < pictureBoxList.Count() -1; i++)
            {
                if(pictureBoxList[i].ImageLocation == "" || pictureBoxList[i].ImageLocation == null)
                {
                    if(Gameplay.getInstance().getCurrentBoard[i] == 'X' || Gameplay.getInstance().getCurrentBoard[i] == 'O')
                    {
                        switch(Gameplay.getInstance().getCurrentBoard[i])
                        {
                            case 'X':
                                pictureBoxList[i].ImageLocation = "X.png";
                                break;
                            case 'O':
                                pictureBoxList[i].ImageLocation = "O.png";
                                break;
                        }
                    }
                }
            }
        }
    }
}
