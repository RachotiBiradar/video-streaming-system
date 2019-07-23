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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void admin1_Load(object sender, EventArgs e) { textBox1.Hide(); }

        private void button7_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            OleDbConnection connection = new OleDbConnection(connetionString);

            string sql1 = "select id,vname,catg from media";

            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
            connection.Open();
           dt = new DataTable();

            dataadapter.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            { MessageBox.Show("PLEASE SELECT VIDEO TO DELETE"); }
            else
            {
                string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
                OleDbConnection connection = new OleDbConnection(connetionString);

                string sql2 = "delete from media where id='" + textBox1.Text + "'";
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql2, connection);
                connection.Open();
                OleDbCommand cmd = new OleDbCommand(sql2, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Deleted");

                connection.Close();
                admin2 gg = new admin2();
                gg.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin1 a = new admin1();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin2 a = new admin2();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ID"].Value.ToString();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("vname like '%{0}%'", textBox2.Text);
            dataGridView1.DataSource = dv;
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
