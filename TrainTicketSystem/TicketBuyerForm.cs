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
        List<int> seats = new List<int>();

        public TicketBuyerForm()
        {
            InitializeComponent(); 
            disableChecboxes();

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
            disableChecboxes();

        }

        //ülés kiválasztás
        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked) {
                seats.Add(Int32.Parse(c.Text));
                if (c.Text[0] == '1' || c.Text[0] == '2' || c.Text[0] == '3' || c.Text[0] == '4' || c.Text[0] == '5') {
                    firstClassNum++;
                }
                else
                {
                    secondClassNum++;
                }
            }
            else
            {
                seats.Remove(Int32.Parse(c.Text));
                if (c.Text[0] == '1' || c.Text[0] == '2' || c.Text[0] == '3' || c.Text[0] == '4' || c.Text[0] == '5')
                {
                    firstClassNum--;
                }
                else
                {
                    secondClassNum--;
                }
            }
            Debug.WriteLine(firstClassNum+ " " + secondClassNum);

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

        //ülések berakása
        private void routeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stations = routes.SelectedItem.ToString();
            string type = routeType.SelectedItem.ToString();
            List<string> takenSeats = new List<string>();
            List<int> ts = new List<int>();
            ts = db.getTakenSeats(db.getRouteId(stations.Split('-')[0], stations.Split('-')[1], type));

            foreach (Control c in firstClassCar.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    int cbNum = Int32.Parse(cb.Text);
                    if (ts.Contains(cbNum) || ts.Contains(cbNum-1) || ts.Contains(cbNum + 1) || ts.Contains(cbNum - 10) || (ts.Contains(cbNum + 10) && cbNum+10<61)) 
                    {
                        takenSeats.Add(cb.Text);
                    } 
                }
            }
            foreach (Control c in seconcCarClass.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    int cbNum = Int32.Parse(cb.Text);
                    if (cbNum%10==3)
                    {
                        if(ts.Contains(cbNum) || ts.Contains(cbNum - 1) || ts.Contains(cbNum - 3) || ts.Contains(cbNum + 3)) 
                            takenSeats.Add(cb.Text);

                    }
                    else if (cbNum % 10 == 4)
                    {
                        if(ts.Contains(cbNum) || ts.Contains(cbNum + 1) || ts.Contains(cbNum - 3) || ts.Contains(cbNum + 3))
                            takenSeats.Add(cb.Text);

                    }
                    else if (ts.Contains(cbNum) || ts.Contains(cbNum - 1) || ts.Contains(cbNum + 1) || ts.Contains(cbNum - 3) || ts.Contains(cbNum + 3))
                    {
                        takenSeats.Add(cb.Text);
                    }
                }
            }

            foreach (Control c in firstClassCar.Controls ) 
            {
                if(c is CheckBox)
                {
                    CheckBox cb= (CheckBox)c;
                    if (takenSeats.Contains(cb.Text))
                    {
                        cb.BackColor = Color.LightCoral;
                        cb.Enabled = false;
                    }
                    else 
                    {
                        cb.BackColor = Color.LightGreen;
                        cb.Enabled = true;
                    }
                }
            
            }
            foreach (Control c in seconcCarClass.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (takenSeats.Contains(cb.Text))
                    {
                        cb.BackColor = Color.LightCoral;
                        cb.Enabled = false;
                    }
                    else
                    {
                        cb.BackColor = Color.LightGreen;
                        cb.Enabled = true;
                    }

                }

            }
        }

        //todo :done jegyek ne jelenjenek meg

        //checkboxok kikapcsolása
        private void disableChecboxes()
        {
            foreach (Control c in firstClassCar.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.BackColor = Color.LightCoral;
                    cb.Enabled = false;
                }
            }
            foreach (Control c in seconcCarClass.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.BackColor = Color.LightCoral;
                    cb.Enabled = false;
                }

            }
        }

    }
}
