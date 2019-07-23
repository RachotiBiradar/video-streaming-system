using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace dbms
{
    public partial class user2 : Form
    {
        string h;
        public user2(string l)
        {
            h = l;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            OleDbConnection connection = new OleDbConnection(connetionString);

            string sql1 = "select vname,datee,timee from vhistory where uname='"+h+"'";

            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
            connection.Open();
            DataTable dt = new DataTable();

            dataadapter.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            user2 u = new user2(h);
            u.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            user1 u = new user1(h);
            u.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
    }
}
