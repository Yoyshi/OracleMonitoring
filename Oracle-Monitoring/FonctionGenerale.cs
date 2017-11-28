﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public FonctionGenerale(string server, string port, string tns, string user, string password)
        {
            //A la création de l'objet, check si fichier sqlite existe 
            //Si il n'existe pas
            if (!System.IO.File.Exists(appPath))
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
                sql = sql + "'" + servername + "',";
                sql = sql + "'" + port + "',";
                sql = sql + "'" + tnsname + "',";
                sql = sql + "'" + username + "',";
                sql = sql + "'" + password + "')";

                SQLiteCommand commande = new SQLiteCommand(sql, sqlite2 = new SQLiteConnection("Data Source=" + appPath));
                commande.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SQLiteDataReader readConnectionString()
        {
            string sql = "select * from connection order by name desc";
            SQLiteCommand commande = new SQLiteCommand(sql, sqlite2 = new SQLiteConnection("Data Source=" + appPath));

            SQLiteDataReader reader = commande.ExecuteReader();
            return reader;
        }

    }
}