using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;

namespace TrainTicketSystem
{
    public partial class AdministratorForm : Form
    {
        DatabaseHandler db = new DatabaseHandler();

        public AdministratorForm()
        {
            InitializeComponent();
            disableChecboxes();
            incomeLabel.Text = "Teljes Bevétel:";

            //todo: done jegyeket ne töltse be
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

        private void AdministratorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        //checkboxok kikapcsolása
        private void disableChecboxes()
        {
            foreach (Control c in firstClassCar.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.BackColor = Color.LightGreen;
                    cb.Enabled = false;
                }
            }
            foreach (Control c in seconcCarClass.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.BackColor = Color.LightGreen;
                    cb.Enabled = false;
                }

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
            disableChecboxes();
        }

        //vonatjárat beillesztés
        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            var l = db.getRoutes();
            for (int i = 0; i < l.Count; i++)
            {
                routes.Items.Add(l[i]);
            }
        }

        //ülések berakása
        private void routeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stations = routes.SelectedItem.ToString();
            string type = routeType.SelectedItem.ToString();
            List<int> takenSeats = new List<int>();
            takenSeats = db.getTakenSeats(db.getRouteId(stations.Split('-')[0], stations.Split('-')[1], type));
            incomeLabel.Text= "Teljes Bevétel: "+db.getTotalIncome(db.getRouteId(stations.Split('-')[0], stations.Split('-')[1], type))+" Ft";

            foreach (Control c in firstClassCar.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (takenSeats.Contains(Int32.Parse(cb.Text)))
                    {
                        cb.BackColor = Color.LightCoral;
                        cb.Enabled = true;
                    }
                    else
                    {
                        cb.BackColor = Color.LightGreen;
                        cb.Enabled = false;
                    }
                }

            }
            foreach (Control c in seconcCarClass.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (takenSeats.Contains(Int32.Parse(cb.Text)))
                    {
                        cb.BackColor = Color.LightCoral;
                        cb.Enabled = true;
                    }
                    else
                    {
                        cb.BackColor = Color.LightGreen;
                        cb.Enabled = false;
                    }

                }

            }


        }

        //részletesebben megnézi a jegyet
        private void CheckBoxClick(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            string stations = routes.SelectedItem.ToString();
            string type = routeType.SelectedItem.ToString();
            int id = db.getTicketId(db.getRouteId(stations.Split('-')[0], stations.Split('-')[1], type), Int32.Parse(c.Text));
            TicketInfoForm ticketInfoForm = new TicketInfoForm(id);
            c.Checked = false;
            ticketInfoForm.ShowDialog();
            
        }

        //updateli a jegyeket
        private void finishRoutes_Click(object sender, EventArgs e)
        {
           //todo: updateli a jegyeket
        }
    }
}
