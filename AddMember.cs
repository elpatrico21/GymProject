using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gym
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }


        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-O86GKRV;Initial Catalog=GymDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || AmountTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Brakujace dane");
            }
            else
            {


                try
                
                {
                    Con.Open();
                    string query = "insert into Member values('" + NameTb.Text + "','" + PhoneTb.Text + "', '" + GenderCb.SelectedItem.ToString() + "'," + AgeTb.Text + "," + AmountTb.Text + ", '" + TimingCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dodano nowego czlonka");

                    Con.Close();
                    NameTb.Text = "";
                    AmountTb.Text = "";
                    AgeTb.Text = "";
                    AmountTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.Text = "";
                    TimingCb.Text = "";

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                }
        }

        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            AmountTb.Text = "";
            AgeTb.Text = "";
            AmountTb.Text = "";
            PhoneTb.Text = "";
            GenderCb.Text = "";
            TimingCb.Text = "";

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void TimingCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
