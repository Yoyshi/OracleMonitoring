using Oracle.ManagedDataAccess.Client;
using System;
using System.Data.SQLite;

namespace Oracle_Monitoring
{
    class FonctionGenerale
    {
        //Déclaration des variables de connexion à la base Oracle 
        string username;
        string password;
        string port;
        string servername;
        string tnsname;

        //Déclaration de la variable pour le chemin de l'application
        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +"/";

        //Déclaration des variables permettant le stockage des requêtes SQL et de la chaîne de connection
        string requete;
        string connection;

        SQLiteConnection sqlite2;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        public string Servername
        {
            get { return servername; }
            set { servername = value; }
        }

        public string Tnsname
        {
            get { return tnsname; }
            set { tnsname = value; }
        }

        public FonctionGenerale()
        {
            //A la création de l'objet, check si fichier sqlite existe 
            //Si il n'existe pas
            if (!System.IO.File.Exists(appPath + "Connect.sqlite"))
            {
                //Création du fichier
                SQLiteConnection.CreateFile(appPath + "Connect.sqlite");
                //Iniialisation de la connexion SQLite
                sqlite2 = new SQLiteConnection("Data Source=" + appPath + "Connect.sqlite");
                sqlite2.Open();
                //Création de la table qui vas stocker les données de connexion
                string sql = "create table connection (name varchar(20), servername varchar(50), port varchar(6), tnsname varchar(50), username varchar(100), password varchar(100))";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                command.ExecuteNonQuery();
            }
            else
            {
                //Iniialisation de la connexion SQLite
                sqlite2 = new SQLiteConnection("Data Source=" + appPath + "Connect.sqlite");
                sqlite2.Open();
            }

        }

        public void init(string server, string port, string tns, string user, string password)
        {
            this.servername = server;
            this.port = port;
            this.tnsname = tns;
            this.username = user;
            this.password = password;
        }

        public bool addConnectionString()
        {
            try
            {
                string sql = "insert into connection (name, servername, port, tnsname, username, password) VALUES(";
                sql = sql + "'" + username + "@" + servername +"',";
                sql = sql + "'" + servername + "',";
                sql = sql + "'" + port + "',";
                sql = sql + "'" + tnsname + "',";
                sql = sql + "'" + username + "',";
                sql = sql + "'" + password + "')";

                SQLiteCommand commande = new SQLiteCommand(sql, sqlite2);
                commande.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SQLiteDataAdapter readConnectionString()
        {
            string sql = "select name from connection order by name desc";
            SQLiteCommand commande = new SQLiteCommand(sql, sqlite2);

            SQLiteDataAdapter reader = new SQLiteDataAdapter(sql, sqlite2);
            return reader;
        }

        public SQLiteDataAdapter readConnectionString2()
        {
            string sql = "select * from connection order by name desc";
            SQLiteCommand commande = new SQLiteCommand(sql, sqlite2);

            SQLiteDataAdapter reader = new SQLiteDataAdapter(sql, sqlite2);
            return reader;
        }

        public OracleConnection setOracle()
        {
            OracleConnection con = new OracleConnection();

            connection = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = " + servername + ")";
            connection = connection + "(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + tnsname + ")));";
            connection = connection + "Password=" + password + ";User ID=" + username;
            con.ConnectionString = connection;
            con.Open();

            return con;
        }

    }
}
