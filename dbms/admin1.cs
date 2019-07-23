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
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            string var;
            var = comboBox1.Text;


            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            string sql2 = "SELECT count(*) FROM media";
            string a = CreateReader(connetionString, sql2);
            int x = int.Parse(a);
            Random rnd = new Random();
            int m= rnd.Next(1, 20);
            int b = x + m;
            string sql1 = "Insert into media VALUES ('" + b + "', '" + textBox1.Text + "' ,'" + textBox4.Text + "','" + var + "','" + textBox3.Text + "')";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
            dataadapter.InsertCommand = new OleDbCommand(sql1, connection);
            connection.Open();
            dataadapter.InsertCommand.ExecuteNonQuery();
            MessageBox.Show("SUCESS");
            connection.Close();
            admin1 y = new admin1();
            y.Show();
            this.Hide();
            
        }
        public String CreateReader(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();

                string s = reader[0].ToString();


                reader.Close();
                connection.Close();
                return s;

            }

        }


        private void button7_Click(object sender, EventArgs e)
        {

            OpenFileDialog o1 = new OpenFileDialog();
            if (o1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { textBox1.Text = o1.FileName; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            admin2 a2 = new admin2();
            a2.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            this.Hide();
        }
       

    }
}
