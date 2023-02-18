using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace TrainTicketSystem
{
    public partial class PayingForm : Form
    {
        DatabaseHandler db = new DatabaseHandler();
        int routeId;
        int firstClassNum;
        int secondClassNum;
        int price = 0;
        int coupon = 0;
        int priceBonus = 0;
        string name = "";

        List<string> seats = new List<string>();

        public PayingForm(int rid,int fcNum,int scNum,List<String> s)
        {
            InitializeComponent();
            routeId= rid;
            firstClassNum=fcNum;
            secondClassNum=scNum;
            seats = s;
            routeLabel.Text =db.getRouteById(rid);
            fcLabel.Text = "Első osztályú ülések: " + fcNum;
            scLabel.Text = "Másod osztályú ülések: " + scNum;
            changePrice();

            var stations=db.getStationsById(rid);
            for (int i = 1; i < stations.Count; i++)
            {
                stationBox.Items.Add(stations[i]);
            }


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

        private void PayingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        //név beolvasása
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            name=nameBox.Text;
        }

        //kupon akriválása
        private void couponUse_Click(object sender, EventArgs e)
        {
            if (couponBox.Text == "10")
            {
                coupon = 10;
            }
            else if (couponBox.Text == "20")
            {
                coupon = 20;
            }
            else
            {
                MessageBox.Show("Ilyen kupon nem létezik!");
                coupon = 0;
            }
            changePrice();
        }

        //Ár változtatás
        private void changePrice()
        {
            int oPrice = db.getTicketPrice(routeId, firstClassNum, secondClassNum);
            price = oPrice - (oPrice / 100 * coupon) - priceBonus;
            priceLabel.Text = "Ár: " + price + " Ft";
        }

        //jegy megvétele
        private void buyTicketBt_Click(object sender, EventArgs e)
        {
            if (stationBox.SelectedItem!=null)
            {
                bool fullT = true;
                if (priceBonus == 500) fullT = false;
                db.insertTicket(routeId, name, firstClassNum, secondClassNum, coupon, fullT, price, seats);

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hiba!\nMegálló kiválasztása kötelező!");
            }

           
        }

        //megálló kiválasztása
        private void stationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stationBox.SelectedItem.ToString().Split('.')[0] != db.getStopsById(routeId))
            {
                priceBonus = 500;
            }
            else
            {
                priceBonus = 0;
            }
            changePrice();
        }
    }
}
