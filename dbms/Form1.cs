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
    public partial class Form1 : Form
    {
        string b;
        public Form1(string a)
        {
             b = a;
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            string sql = "SELECT vname FROM media where id='"+b+"'";
          string a=  CreateReader(connetionString, sql);
          axWindowsMediaPlayer1.URL = a;
          axWindowsMediaPlayer1.Ctlcontrols.play();

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
                return s;
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            string sql = "SELECT descr FROM media where id='" + b + "'";
            string a = CreateReader1(connetionString, sql);
            textBox1.Text = a;
           

        }
        public String CreateReader1(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();

                string s = reader[0].ToString();


                reader.Close();
                return s;

            }

        }

       
        

        

       
    }
}
