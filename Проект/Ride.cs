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
    public partial class Ride : Form
    {
        public Ride()
        {
            InitializeComponent();
        }
        int Roadhours = 0, Roadmins = 0, Roadseconds = 0;
        double movesum = 0, gensum = 0;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            movesum = 8 * (60 * Roadhours + Roadmins);
            gensum = movesum;
            End a = new End( gensum);
            a.Show();
            this.Hide();
        }

        private void Ride_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Roadseconds = Roadseconds + 1;
            if (Roadseconds == 60)
            {
                Roadmins = Roadmins + 1;
                Roadseconds = 0;
            }
            if (Roadmins == 60)
            {
                Roadhours = Roadhours + 1;
                Roadmins = 0;
            }
            if (Roadhours < 10) l1.Text = "0" + Convert.ToString(Roadhours);
            else l1.Text = Convert.ToString(Roadhours);
            if (Roadmins < 10) l2.Text = "0" + Convert.ToString(Roadmins);
            else l2.Text = Convert.ToString(Roadmins);
            if (Roadseconds < 10) l3.Text = "0" + Convert.ToString(Roadseconds);
            else l3.Text = Convert.ToString(Roadseconds);
        }
    }
 }

