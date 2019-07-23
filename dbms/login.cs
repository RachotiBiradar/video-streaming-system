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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            
            if (radioButton2.Checked == true)
            {
                String sql2 = "SELECT username FROM register where username='" + textBox1.Text + "'and pwd='" + textBox2.Text + "'";
                OleDbConnection connection = new OleDbConnection(connetionString);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql2, connection);
                connection.Open();
                DataTable dt = new DataTable();
                
                dataadapter.Fill(dt);
                connection.Close();
                



                if (dt.Rows.Count==1)
                {
                    string a = textBox1.Text.ToString();
                    user1 u = new user1(a);
                    u.Show();
                    this.Hide();
                }
                else { MessageBox.Show("Incorrect Details"); }
            }
        
        else if(radioButton1.Checked == true)
            {
                
           String sql3 = "SELECT username FROM admin where username='" + textBox1.Text + "'and pwd='" + textBox2.Text + "'";
           OleDbConnection connection = new OleDbConnection(connetionString);  
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql3, connection);
                connection.Open();
                DataTable dt = new DataTable();
                dataadapter.Fill(dt);
                connection.Close();                
                


                if (dt.Rows.Count==1)
                {
                    admin1 a = new admin1();
                a.Show();
                this.Hide();
                }
                else { MessageBox.Show("Incorrect Details"); }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 8;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            login l = new login();
            l.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
