using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SynthesisMacro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public void Synthesis(int x1, int y1, int x2, int y2)
        {
            EventGeneration.MouseClick(EventGeneration.GetInventoryPointX(y1), EventGeneration.GetInventoryPointY(x1), MouseValue.Left, 100);
            Thread.Sleep(170);
            EventGeneration.MouseClick(slot1_x, slot1_y, MouseValue.Left, 100);
            Thread.Sleep(170);

            EventGeneration.MouseClick(EventGeneration.GetInventoryPointX(y2), EventGeneration.GetInventoryPointY(x2), MouseValue.Left, 100);
            Thread.Sleep(170);
            EventGeneration.MouseClick(slot2_x, slot2_y, MouseValue.Left, 100);
            Thread.Sleep(170);

            EventGeneration.MouseClick(enter_x, enter_y, MouseValue.Left, 100);

            Thread.Sleep(200);
            EventGeneration.KeybdEvent(0x0D, 100);
            Thread.Sleep(7000);
            EventGeneration.KeybdEvent(0x0D, 100);
            Thread.Sleep(190);
        }

        public void PotenOpen(int x,int y)
        {
            EventGeneration.MouseClick(455, 345, MouseValue.Left, 100);
            Thread.Sleep(150);
            EventGeneration.MouseClick(EventGeneration.GetInventoryPointX(y), EventGeneration.GetInventoryPointY(x), MouseValue.Left, 100);
            Thread.Sleep(200);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //Boolean[,] CheckList = new Boolean[32, 2];
            CheckBox[,] CheckBoxList = new CheckBox[32, 2];

            for(int i=0;i<32;i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    CheckBoxList[i, j] = this.Controls[String.Format("checkBox{0}", (i * 2 + j)+1)] as CheckBox;
                }
            }

            while (true)
                if (EventGeneration.GetAsyncKeyState(0x78/*VK_F9*/) == 0x8000)
                    break;

            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if(CheckBoxList[i,j].Checked==true)
                    {
                        Synthesis(i % 8, (i / 8) * 4 + (j * 2), i % 8, (i / 8) * 4 + (j * 2) + 1);
                        if (EventGeneration.GetAsyncKeyState(0x79/*VK_F10*/) == 0x8000)
                            Application.Exit();
                        //MessageBox.Show(Convert.ToString(i % 8) + "," + Convert.ToString((i / 8) * 4 + (j * 2))+"\n"+
                        //    Convert.ToString(i % 8) + "," + Convert.ToString((i / 8) * 4 + (j * 2)+1));
                    }
                }
            }
        }

        public int slot1_x
        {
            get { return Convert.ToInt32(this.Slot1_x.Text); }
        }
        public int slot1_y
        {
            get { return Convert.ToInt32(this.Slot1_y.Text); }
        }
        public int slot2_x
        {
            get { return Convert.ToInt32(this.Slot2_x.Text); }
        }
        public int slot2_y
        {
            get { return Convert.ToInt32(this.Slot2_y.Text); }
        }
        public int enter_x
        {
            get { return Convert.ToInt32(this.Enter_x.Text); }
        }
        public int enter_y
        {
            get { return Convert.ToInt32(this.Enter_y.Text); }
        }

        private void Slot1_Check_Click(object sender, EventArgs e)
        {
            for(int i=0;i<16;i++)
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = true;
            }
        }

        private void Slot1_UnCheck_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 16; i++)
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = false;
            }
        }

        private void Slot2_Check_Click(object sender, EventArgs e)
        {
            for (int i =16; i < 32; i++)
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = true;
            }
        }

        private void Slot2_UnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 16; i < 32; i++)
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = false;
            }
        }

        private void Slot3_Check_Click(object sender, EventArgs e)
        {
            for (int i = 32; i < 48; i++) 
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = true;
            }
        }

        private void Slot3_UnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 32; i < 48; i++)
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = false;
            }
        }

        private void Slot4_Check_Click(object sender, EventArgs e)
        {
            for (int i = 48; i < 64; i++) 
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = true;
            }
        }

        private void Slot4_UnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 48; i < 64; i++)
            {
                (this.Controls[String.Format("checkBox{0}", i + 1)] as CheckBox).Checked = false;
            }
        }

        private void PotenOpenButton_Click(object sender, EventArgs e)
        {
            CheckBox[,] CheckBoxList = new CheckBox[32, 2];

            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    CheckBoxList[i, j] = this.Controls[String.Format("checkBox{0}", (i * 2 + j) + 1)] as CheckBox;
                }
            }

            while (true)
                if (EventGeneration.GetAsyncKeyState(0x78/*VK_F9*/) == 0x8000)
                    break;

            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (CheckBoxList[i, j].Checked == true)
                    {
                        PotenOpen(i % 8, (i / 8) * 4 + (j * 2));
                        PotenOpen(i % 8, (i / 8) * 4 + (j * 2) + 1);
                        if (EventGeneration.GetAsyncKeyState(0x79/*VK_F10*/) == 0x8000)
                            Application.Exit();
                    }
                }
            }
        }
    }
    
}
