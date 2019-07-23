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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
            OleDbConnection connection = new OleDbConnection(connetionString);
           
            string sql1 = "select id,vname from media";

            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
            connection.Open();
            DataTable dt = new DataTable();

            dataadapter.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
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
        }
    }
}
