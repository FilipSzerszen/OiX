using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OiX
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static int[,] plansza = new int[3, 3];

        public static bool czyGracz1 = true;
        public static int stan = 9;
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
            CzyœæTablicê();
        }
        public static void CzyœæTablicê()
        {
            for(int i =0; i < 3; i++)
            {
                for(int j=0; j < 3; j++)
                {
                    plansza[i, j] = 0;
                }
            }
        }

        public static int CzyWygrana()
        {
            if (plansza[0, 0] + plansza[0, 1] + plansza[0, 2] == 3 ||
                plansza[1, 0] + plansza[1, 1] + plansza[1, 2] == 3 ||
                plansza[2, 0] + plansza[2, 1] + plansza[2, 2] == 3 ||
                plansza[0, 0] + plansza[1, 0] + plansza[2, 0] == 3 ||
                plansza[0, 1] + plansza[1, 1] + plansza[2, 1] == 3 ||
                plansza[0, 2] + plansza[1, 2] + plansza[2, 2] == 3 ||
                plansza[0, 0] + plansza[1, 1] + plansza[2, 2] == 3 ||
                plansza[2, 0] + plansza[1, 1] + plansza[0, 2] == 3
                ) return 1;
            if (plansza[0, 0] + plansza[0, 1] + plansza[0, 2] == 30 ||
                plansza[1, 0] + plansza[1, 1] + plansza[1, 2] == 30 ||
                plansza[2, 0] + plansza[2, 1] + plansza[2, 2] == 30 ||
                plansza[0, 0] + plansza[1, 0] + plansza[2, 0] == 30 ||
                plansza[0, 1] + plansza[1, 1] + plansza[2, 1] == 30 ||
                plansza[0, 2] + plansza[1, 2] + plansza[2, 2] == 30 ||
                plansza[0, 0] + plansza[1, 1] + plansza[2, 2] == 30 ||
                plansza[2, 0] + plansza[1, 1] + plansza[0, 2] == 30
                ) return 2;
            if (stan == 0) return 3;
            return 0;
        }  
    }
}
