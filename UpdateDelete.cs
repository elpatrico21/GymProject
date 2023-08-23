using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }



        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-O86GKRV;Initial Catalog=GymDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void populate()
        {
            Con.Open();
            string query = "select * from Member";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (MemberSDGV.SelectedRows.Count > 0)
            {
                key = Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value.ToString());
                NameTb.Text = MemberSDGV.SelectedRows[0].Cells[1].Value.ToString();
                PhoneTb.Text = MemberSDGV.SelectedRows[0].Cells[2].Value.ToString();
                AgeTb.Text = MemberSDGV.SelectedRows[0].Cells[3].Value.ToString();
                GenderCb.Text = MemberSDGV.SelectedRows[0].Cells[4].Value.ToString();
                AmountTb.Text = MemberSDGV.SelectedRows[0].Cells[5].Value.ToString();
                TimingCb.Text = MemberSDGV.SelectedRows[0].Cells[6].Value.ToString();
            }
         

            
        }

        
       

        private void button1_Click(object sender, EventArgs e)
        {

            if (MemberSDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz ktorego czlonka chcesz usunac:");
                return;
            }

            var index = new List<int>();


            foreach (DataGridViewRow element in MemberSDGV.SelectedRows)
            {

                index.Add(Convert.ToInt32(element.Cells[0].Value));
            }
            
    

                try
                {
                    Con.Open();
                    string query = "delete from Member where MId in (" + string.Join(",", index) + ");";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Czlonek zostal poprawnie usuniety");
                    Con.Close();
                    populate();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        

        private void button2_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            AgeTb.Text = "";
            PhoneTb.Text = "";
            TimingCb.Text = "";
            AmountTb.Text = "";
            GenderCb.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();

        }

        private void UpdateDelete_Load_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || AgeTb.Text == "" || AmountTb.Text == "" || GenderCb.Text == "" || TimingCb.Text == "")
            {
                MessageBox.Show("Brakuje informacji");
                return;
            }
            if(MemberSDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz wiersz");
                return;
            }

            if (MemberSDGV.SelectedRows.Count != 1)
            {
                MessageBox.Show("Mozesz wybrac tylko 1 wiersz");
                return;
            }
            try
                {


                    Con.Open();
                    string query = "update Member set MName ='" + NameTb.Text + "', MPhone = '" + PhoneTb.Text + "', MGen = '" + GenderCb.Text + "', MAge = " + AgeTb.Text + ",MAmount =" + AmountTb.Text + ", MTiming = '" + TimingCb.Text + "' where MId = " + Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value)+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Czlonek zostal poprawnie zaktualizowany");
                    Con.Close();
                    populate();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AmountTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
