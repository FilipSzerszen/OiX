using System;
using System.Linq;
using System.Windows.Forms;



namespace OiX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int[,] plansza = new int[3, 3];

        static bool czyGracz1 = true;
        static int stan;
        public static void StartGry()
        {
            var Buttons = Form1.ActiveForm.Controls.OfType<Button>();
            for (int i = 1; i < 10; i++)
            {
                var button = Buttons.Where(p => p.Name == "button" + i).FirstOrDefault();
                if (button != null)
                {
                    button.Text = default;
                    button.Enabled = true;
                }
            }
            czyGracz1 = true;
            CzyśćTablicę();
            stan = 9;
        }
        public static void CzyśćTablicę()
        {
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) plansza[i, j] = 0;
        }

        public static int CzyWygrana()
        {
            int suma = 3;
            for (int i = 1; i < 3; i++)
            {
                if (plansza[0, 0] + plansza[0, 1] + plansza[0, 2] == suma ||
                    plansza[1, 0] + plansza[1, 1] + plansza[1, 2] == suma ||
                    plansza[2, 0] + plansza[2, 1] + plansza[2, 2] == suma ||
                    plansza[0, 0] + plansza[1, 0] + plansza[2, 0] == suma ||
                    plansza[0, 1] + plansza[1, 1] + plansza[2, 1] == suma ||
                    plansza[0, 2] + plansza[1, 2] + plansza[2, 2] == suma ||
                    plansza[0, 0] + plansza[1, 1] + plansza[2, 2] == suma ||
                    plansza[2, 0] + plansza[1, 1] + plansza[0, 2] == suma
                    ) return i;
                suma *= 10;
            }
            if (stan == 0) return 3;
            return 0;
        }
        private void StartGry(object sender, EventArgs e)
        {
            StartGry();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            _ = czyGracz1 ? ((Button)sender).Text = "X" : ((Button)sender).Text = "O";
            ((Button)sender).Enabled = false;

            stan -= 1;
            int numerPrzycisku = int.Parse(((Button)sender).Name.ToString().Replace("button", ""));
            _ = czyGracz1 ? plansza[(numerPrzycisku - 1) % 3, (numerPrzycisku - 1) / 3] = 1 :
                plansza[(numerPrzycisku - 1) % 3, (numerPrzycisku - 1) / 3] = 10;
            czyGracz1 ^= true;

            if (CzyWygrana() != 0)
            {
                if (CzyWygrana() == 3) MessageBox.Show("Remis!", "Wynik gry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Wygrał gracz: " + CzyWygrana(), "Wynik gry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StartGry();
            }
        }
    }
}
