using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OiX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartGry(object sender, EventArgs e)
        {
            Program.StartGry();
        }

        private void button_Click(object sender, EventArgs e)
        {
            _ = (Program.czyGracz1) ? ((Button)sender).Text = "X" : ((Button)sender).Text = "O";
            ((Button)sender).Enabled = false;
            Program.czyGracz1 ^= true;
            if (Program.CzyWygrana() != 0)
            {
                if (Program.CzyWygrana() == 3) MessageBox.Show("Remis!", "Wynik gry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Wygrał gracz: " + Program.CzyWygrana(), "Wynik gry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Program.StartGry();
            }

        }

    }
}
