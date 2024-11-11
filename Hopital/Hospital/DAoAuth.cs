using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital
{
    class DaoAuth
    {
        public User Login(string login, string password)
        {
            User us = null;

            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = "SELECT Nom, Metier FROM authentification WHERE Login=@login AND Password=@password";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);



            command.Parameters.Add("login", SqlDbType.NVarChar).Value = login;
            command.Parameters.Add("password", SqlDbType.NVarChar).Value = password;

            connection1.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string nom = reader["Nom"].ToString();
                Metier metier = (Metier)Enum.Parse(typeof(Metier), reader["Metier"].ToString());

                switch (metier)
                {
                    case Metier.secretaire:
                        us = new Secretaire(nom, metier);
                        break;
                    default:
                        us = new Medecin(nom, metier);
                        break;
                }
            }
            else
            {
                return us;
            }
            return us;
        }
    }

  
}






