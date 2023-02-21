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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        //bejelentkezés
        private void loginBt_Click(object sender, EventArgs e)
        {
            string username=userNameTb.Text,password=passwordTb.Text;

            if (username=="vasarlo" && password=="vasarlo1")
            {
                TicketBuyerForm ticketBuyerForm= new TicketBuyerForm();
                ticketBuyerForm.Show();
                this.Close();

            }
            else if (username == "admin" && password == "admin1")
            {
                AdministratorForm administratorForm = new AdministratorForm();
                administratorForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ilyen felhasználó nem létezik!");
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

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

    }
}
