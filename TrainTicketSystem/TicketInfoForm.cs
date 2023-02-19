using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTicketSystem
{
    public partial class TicketInfoForm : Form
    {
        int ticketId;

        public TicketInfoForm(int ticketId)
        {
            DatabaseHandler db = new DatabaseHandler();
            InitializeComponent();
            this.ticketId = ticketId;
            Tickets t=db.getTicketsById(ticketId);
            routeLabel.Text= "Járat: "+db.getRouteById(t.id_route);
            nameLabel.Text = "Név: " + t.buyerName;
            fcNumLabel.Text = "Első osztályú helyek: " + t.firstClassTickets;
            scNumlabel.Text = "Másod osztályú helyek: " + t.secondClassTickets;
            priceLabel.Text = "Jegy ár: " + t.price + " Ft";

            if (t.coupon == 0) 
            {
                couponLabel.Text = "Nem használtak kupont!";
            }
            else
            {
                couponLabel.Text = "Használtak kupont!";
            }

            if (t.fullTicket)
            {
                stopLabel.Text = "Végig utaznak!";
            }
            else
            {
                stopLabel.Text = "Nem utaznak végig!";
            }

            var seats=db.getTicketSeats(ticketId);
            string str = "Űlőhelyek kódja:";
            foreach (var s in seats)
            {
                str += " " + s;
            }
            seatsLabel.Text = str;
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

        private void TicketInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
