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
    public partial class entry1 : Form
    {
        public entry1()
        {
            InitializeComponent();
        }
        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Reg re = new Reg();
            re.Show();
            Hide();
        }

        private void entry1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            Hide();
        }
    }
}
