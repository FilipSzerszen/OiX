using System;
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

            Program.stan -= 1;
            int numerPrzycisku=int.Parse(((Button)sender).Name.ToString().Replace("button", ""));
            _=Program.czyGracz1? Program.plansza[(numerPrzycisku - 1) % 3, (numerPrzycisku - 1) / 3]=1 :
                Program.plansza[(numerPrzycisku - 1) % 3, (numerPrzycisku - 1) / 3] = 10;
            Program.czyGracz1 ^= true;

            if (Program.CzyWygrana() != 0)
            {
                if (Program.CzyWygrana() == 3) MessageBox.Show("Remis!", "Wynik gry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Wygrał gracz: " + Program.CzyWygrana(), "Wynik gry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Program.StartGry();
                Program.stan = 9;
            }
        }
    }
}
