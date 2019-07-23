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
    public partial class media : Form
    {string b;
    string p;
        public media(string a,string x)
        {b=a;
        p = x;
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
               string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            string sql = "SELECT path FROM media where id='"+b+"'";
          string a=  CreateReader(connetionString, sql);
          axWindowsMediaPlayer1.URL = a;
       
          string sql1= "SELECT descr FROM media where id='" + b + "'";
          string c= CreateReader1(connetionString, sql1);
          textBox1.Text = c;
          
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

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";

            string sql3 = "SELECT vname FROM media where id='" + b + "'";
            string f = CreateReader2(connetionString, sql3);
            string i = DateTime.Now.ToShortDateString();
            string j = DateTime.Now.ToShortTimeString();
            string sql2 = "Insert into vhistory  VALUES ('" + b + "', '" + f + "', '" + i + "', '" + j + "', '" + p + "')";
            OleDbConnection connection = new OleDbConnection(connetionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql2, connection);
            dataadapter.InsertCommand = new OleDbCommand(sql2, connection);
            connection.Open();
            dataadapter.InsertCommand.ExecuteNonQuery();
            connection.Close();
            user1 n = new user1(p);
            n.Show();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Hide();

          
        }


        public String CreateReader1(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();

                string d = reader[0].ToString();


                reader.Close();
                connection.Close();
                return d;

            }

        }
        public String CreateReader2(string connectionString, string queryString)
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
        }
          }

