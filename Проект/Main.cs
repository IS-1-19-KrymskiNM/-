using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект
{
    public partial class Main : Form
    {
        bool expectation;
        public Main()
        {
            InitializeComponent();
            guna2Panel1.MouseEnter += async (s, a) =>
             {
                 while (!expectation && guna2Panel1.Location.X < guna2Panel2.Location.X - 228)
                 {
                     expectation = true;
                     await Task.Delay(1);
                     guna2Panel1.Location = new Point(guna2Panel1.Location.X + 1, guna2Panel1.Location.Y);
                     expectation = false;
                 }
             };
            guna2Panel2.MouseEnter += async (s, a) =>
            {
                while (!expectation && guna2Panel1.Location.X < guna2Panel1.Location.X + 1)
                {
                    expectation = true;
                    await Task.Delay(1);
                    guna2Panel1.Location = new Point(guna2Panel1.Location.X - 1, guna2Panel1.Location.Y);
                    expectation = false;
                }
            };
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Cars c = new Cars();
            c.Show();
            Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Hide();
        }
    } 
}

