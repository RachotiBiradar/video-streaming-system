using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace dbms
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            Regex MY_EXP = new Regex("^1bm\\d{2}cs\\d{3}$");
            Match nmat = MY_EXP.Match(textBox7.Text);
            if (nmat.Success)
            {
                label8.Text = "valid";
            }
            else
            {
                label8.Text = "invalid";
            }


        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            Regex MY_EXP2 = new Regex("\\d{10}$");
            Match nmat = MY_EXP2.Match(textBox2.Text);
            if (nmat.Success)
            {
                label9.Text = "Valid";
            }
            else
            {
                label9.Text = "invalid";
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
            textBox4.MaxLength = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label8.Text == "invalid" && label9.Text == "invalid"&&label11.Text=="usertaken") {
                Form4 form4=new Form4();
                MessageBox.Show("eNTER AGAIN");
                this.Hide();
                form4.Show();
            
            }
            else
            {
                string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
                string sql1 = "Insert into register VALUES ('" + textBox1.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox5.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "' )";
                OleDbConnection connection = new OleDbConnection(connetionString);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                dataadapter.InsertCommand = new OleDbCommand(sql1, connection);
                connection.Open();
                dataadapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Row(s) Inserted !! ");
                connection.Close();
            }
        }

        

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            OleDbConnection connection = new OleDbConnection(connetionString);
            String sql2 = "SELECT count(*) FROM register where username='"+textBox3.Text+"'";
            OleDbCommand command = new OleDbCommand(sql2, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            reader.Read();

            if (reader[0].ToString() == "1") { label11.Text = "usertaken"; }
            else { label11.Text = ""; }
           

        }

        
        

        
    }
}
