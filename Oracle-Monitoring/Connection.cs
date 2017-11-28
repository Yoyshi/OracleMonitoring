using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle_Monitoring
{
    public partial class Connection : Form
    {
        FonctionGenerale fonction = new FonctionGenerale(); 

        public Connection()
        {
            InitializeComponent();

            SQLiteDataReader reader = fonction.readConnectionString();

            if (reader["name"] != DBNull.Value)
            {
                comboBox1.Visible = true;

                while (reader != null)
                {
                    comboBox1.Items.Add(reader["name"]);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLiteDataReader reader = fonction.readConnectionString();

            if (reader["name"] != DBNull.Value)
            {
                comboBox1.Visible = true;

                while (reader != null)
                {
                    string cb = comboBox1.SelectedItem.ToString();
                    string name = reader["name"].ToString();
                    if (cb == name)
                    {
                        textBox1.Text = reader["servername"].ToString();
                        textBox2.Text = reader["port"].ToString();
                        textBox3.Text = reader["tnsname"].ToString();
                        textBox4.Text = reader["username"].ToString();
                        textBox5.Text = reader["password"].ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteDataReader reader = fonction.readConnectionString();

            if (reader == null)
            {
                string server = textBox1.Text;
                string port = textBox2.Text;
                string tns = textBox3.Text;
                string user = textBox4.Text;
                string password = textBox5.Text;

                fonction.init(server, port, tns, user, password);
                try
                {
                    fonction.addConnectionString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            else
            {
                int i = 0;
                while (reader.Read())
                {
                    if (reader["servername"] == textBox1.Text)
                    {
                        i++;
                    }
                }
                if (i != 0)
                {
                    
                }
                else
                {
                    string server = textBox1.Text;
                    string port = textBox2.Text;
                    string tns = textBox3.Text;
                    string user = textBox4.Text;
                    string password = textBox5.Text;

                    fonction.init(server, port, tns, user, password);
                    try
                    {
                        fonction.addConnectionString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
            }
        }
    }
}
