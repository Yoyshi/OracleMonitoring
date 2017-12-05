using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Oracle_Monitoring
{
    public partial class Connection : Form
    {
        FonctionGenerale fonction = new FonctionGenerale(); 

        public Connection()
        {
            InitializeComponent();

            SQLiteDataAdapter reader = fonction.readConnectionString();

            if (reader != null)
            {
                comboBox1.Visible = true;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                reader.Fill(ds);
                dt = ds.Tables[0];

                comboBox1.DisplayMember = "name";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*SQLiteDataAdapter reader = fonction.readConnectionString2();

            if (reader != null)
            {
                comboBox1.Visible = true;

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                reader.Fill(ds);
                dt = ds.Tables[0];

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

            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*SQLiteDataReader reader = fonction.readConnectionString();

            string server;
            string port;
            string tns;
            string user;
            string password;

            if (reader == null)
            {
                server = textBox1.Text;
                port = textBox2.Text;
                tns = textBox3.Text;
                user = textBox4.Text;
                password = textBox5.Text;

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
                    string name = Convert.ToString(reader["servername"]);
                    MessageBox.Show(name);
                    if (name = textBox1.Text)
                    {
                        i++;
                        if(i == 1)
                        {
                            server = textBox1.Text;
                            port = textBox2.Text;
                            tns = textBox3.Text;
                            user = textBox4.Text;
                            password = textBox5.Text;

                            fonction.init(server, port, tns, user, password);
                        }
                    }
                }
                if (i == 0)
                {
                    server = textBox1.Text;
                    port = textBox2.Text;
                    tns = textBox3.Text;
                    user = textBox4.Text;
                    password = textBox5.Text;

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

                try
                {
                    OracleConnection oracle = new OracleConnection();
                    oracle = fonction.setOracle();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }*/
        }

        private void Connection_Load(object sender, EventArgs e)
        {

        }
    }
}
