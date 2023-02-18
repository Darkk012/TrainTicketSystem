using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;

namespace TrainTicketSystem
{
    public partial class TicketBuyerForm : Form
    {
        DatabaseHandler db = new DatabaseHandler();
        int firstClassNum = 0;
        int secondClassNum= 0;
        List<string> seats = new List<string>();

        public TicketBuyerForm()
        {
            InitializeComponent(); 
            //to do: Kell még hogy az ülések rendesen lehesen kiválasztani(virushelyzetes dolog)





        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Az alkalmazást készitette \nBoros Benedek!");
        }

        private void kijelentkezésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();

        }

        private void TicketBuyerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        //vonatjárat beillesztés
        private void TicketBuyerForm_Load(object sender, EventArgs e)
        {
            var l = db.getRoutes();
            for (int i = 0; i < l.Count; i++)
            {
                routes.Items.Add(l[i]);
            }


        }

        //vonat tipus beillesztés
        private void routes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stations = routes.SelectedItem.ToString();
            var types = db.getRoutesType(stations.Split('-')[0], stations.Split('-')[1]);
            routeType.Items.Clear();
            for (int i = 0; i < types.Count; i++)
            {
                routeType.Items.Add(types[i]);
            }

        }

        //ülés kiválasztás
        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked) {
                seats.Add(c.Text);
                if (c.Text[0] == 'a' || c.Text[0] == 'b' || c.Text[0] == 'c' || c.Text[0] == 'd' || c.Text[0] == 'e') {
                    firstClassNum++;
                }
                else
                {
                    secondClassNum++;
                }
            }
            else
            {
                seats.Remove(c.Text);
                if (c.Text[0] == 'a' || c.Text[0] == 'b' || c.Text[0] == 'c' || c.Text[0] == 'd' || c.Text[0] == 'e')
                {
                    firstClassNum--;
                }
                else
                {
                    secondClassNum--;
                }
            }
        }

        //átküldés
        private void bookBt_Click(object sender, EventArgs e)
        {
            if (routes.SelectedItem != null && routeType.SelectedItem != null)
            {
                if (firstClassNum!=0 || secondClassNum!=0)
                {
                    string stations = routes.SelectedItem.ToString();
                    string type = routeType.SelectedItem.ToString();
                    var routeId = db.getRouteId(stations.Split('-')[0], stations.Split('-')[1], type);
                    if (routeId != -1)
                    {
                        PayingForm payingForm = new PayingForm(routeId, firstClassNum, secondClassNum, seats);
                        payingForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adatbázis hiba!");
                    }
                }
                else
                {
                    MessageBox.Show("Hiba!\nNincsen legalább egy ülés kiválasztva!");
                 }
            }
            else
            {
                MessageBox.Show("Hiba!\nNincsen vonatjárat kiválasztva!");
            }
        }
    }
}
