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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            OleDbConnection connection = new OleDbConnection(connetionString);
            if (radioButton2.Checked == true)
            {
                String sql2 = "SELECT count(*) FROM register where username='" + textBox1.Text + "'and pwd='" + textBox1.Text + "'";
                OleDbCommand command = new OleDbCommand(sql2, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();



                if (reader.Read())
                {
                    MessageBox.Show("success"); Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else { MessageBox.Show("incorrect"); }
            }
        
        else if(radioButton1.Checked == true)
            {
                String sql3 = "SELECT count(*) FROM admin where username='" + textBox1.Text + "'and pwd='" + textBox1.Text + "'";
                OleDbCommand command = new OleDbCommand(sql3, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();



                if (reader.Read()) { MessageBox.Show("success"); Form7 f7 = new Form7();
                f7.Show();
                this.Hide();
                }
                else { MessageBox.Show("incorrect"); }
            }}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 8;
        }
    }
}
