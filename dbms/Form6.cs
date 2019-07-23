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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o1 = new OpenFileDialog();
            if (o1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { textBox1.Text = o1.FileName; }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string var;
            var = comboBox1.Text;
            
            
                string connetionString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=bms;Password=bmscse;";
                string sql1 = "Insert into media VALUES ('" + textBox2.Text + "', '" + textBox1.Text + "' ,'" + textBox3.Text + "','" + textBox4.Text + "','" + var + "')";
                OleDbConnection connection = new OleDbConnection(connetionString);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                dataadapter.InsertCommand = new OleDbCommand(sql1, connection);
                connection.Open();
                dataadapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Row(s) Inserted !! ");
                connection.Close();
            


        }
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
