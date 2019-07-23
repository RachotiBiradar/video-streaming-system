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
    public partial class user1 : Form
    {
        string q; string l;
        public user1(string a)
        {q=a;
            InitializeComponent();
        }
        DataTable dt;
        private void user1_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            label3.Text = q;
           l = label3.Text.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            string subject;
            subject = comboBox1.Text;
            if (subject != null)
            {
                if (subject == "DBMS")
                {
                    string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
                    OleDbConnection connection = new OleDbConnection(connetionString);

                    string sql1 = "select id,vname from media where catg='" + subject + "'";

                    OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                    connection.Open();
                     dt = new DataTable();

                    dataadapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    connection.Close();

                }
                else if (subject == "DC")
                {
                    string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
                    OleDbConnection connection = new OleDbConnection(connetionString);

                    string sql1 = "select id,vname from media where catg='" + subject + "'";

                    OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                    connection.Open();
                     dt = new DataTable();

                    dataadapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    connection.Close();


                }
                else if (subject == "JAVA")
                {
                    string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
                    OleDbConnection connection = new OleDbConnection(connetionString);

                    string sql1 = "select id,vname from media where catg='" + subject + "'";

                    OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                    connection.Open();
                     dt = new DataTable();

                    dataadapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    connection.Close();

                }

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            { MessageBox.Show("PLEASE SELECT VIDEO"); }
            else
            {

                string s = textBox1.Text.ToString();
                media f1 = new media(s, l);
                f1.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user2 d = new user2(l);
            d.Show();
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ID"].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("vname like '%{0}%'", textBox3.Text);
            dataGridView1.DataSource = dv;
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        

        
    }
}