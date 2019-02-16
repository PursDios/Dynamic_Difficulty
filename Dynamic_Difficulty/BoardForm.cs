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
        private List<PictureBox> pictureBoxList;
        private delegate void InvokeDelegate();

        public BoardForm()
        {
            InitializeComponent();
            pictureBoxList = new List<PictureBox>();
            AddPictureBoxes();
        }

        private void AddPictureBoxes()
        {
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
            ApplyChoice(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ApplyChoice(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ApplyChoice(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ApplyChoice(4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ApplyChoice(5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ApplyChoice(6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ApplyChoice(7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ApplyChoice(8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ApplyChoice(9);
        }

        private void ApplyChoice(int i)
        {
            if (Gameplay.getInstance().isTurnX)
            {
                if (!Gameplay.getInstance().CheckWin())
                {
                    Gameplay.getInstance().UserTakeTurn(i);
                    Gameplay.getInstance().Update();
                    Console.WriteLine("Where would you like to go (1-9)");
                }
                else
                    Console.WriteLine("Game Finished! PRESS ENTER");
            }
            if (!Gameplay.getInstance().isTurnX)
            {
                if (!Gameplay.getInstance().CheckWin())
                {
                    if (!Gameplay.getInstance().getDynamic)
                        Gameplay.getInstance().DynamicTakeTurn();
                    else
                        Gameplay.getInstance().StaticTakeTurn();
                    Gameplay.getInstance().Update();
                }
                else
                    Console.WriteLine("Game Finished! PRESS ENTER");
            }
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
                                pictureBoxList[i].ImageLocation = "x.jpeg";
                                break;
                            case 'O':
                                pictureBoxList[i].ImageLocation = "o.jpeg";
                                break;
                        }
                    }
                }
            }
        }
    }
}
