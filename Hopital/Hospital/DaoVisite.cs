using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DaoVisite
    {
        public void Insert(Visite v)
        {
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

            string sql = "insert into Visites values ( @idpatient, @date, @medecin, @num_salle, @tarif)";

            
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("id", SqlDbType.Int).Value = v.Id;
            command.Parameters.Add("idpatient", SqlDbType.Int).Value = v.Idpatient;
            command.Parameters.Add("date", SqlDbType.DateTime).Value = v.Date;
            command.Parameters.Add("medecin", SqlDbType.NVarChar).Value = v.Medecin;
            command.Parameters.Add("num_salle", SqlDbType.Int).Value = v.Numerosalle;
            command.Parameters.Add("tarif", SqlDbType.Int).Value = v.Tarif;


            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();
        }
        public bool Delete(int id)
        {
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = $"Delete from Visites where id={id}";
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);
            connection1.Open();
            int count = command.ExecuteNonQuery();
            connection1.Close();
            return (count > 0) ? true : false;
        }

        public bool Update(Visite v)
        {
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = "update visites set idpatient=@idpatient, medecin=@medecin, num_salle=@num_salle, tarif=@tarif where id=@id";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = v.Id;
            command.Parameters.Add("idpatient", SqlDbType.Int).Value = v.Idpatient;
            command.Parameters.Add("medecin", SqlDbType.NVarChar).Value = v.Medecin;
            command.Parameters.Add("num_salle", SqlDbType.Int).Value = v.Numerosalle;
            command.Parameters.Add("tarif", SqlDbType.Int).Value = v.Tarif;


            connection1.Open();
            int count = command.ExecuteNonQuery();
            connection1.Close();
            return (count > 0) ? true : false;
        }
        public List<Visite> SelectAll()
        {
            List<Visite> list = new List<Visite>();
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

            string sql = "Select * from Visites";
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);
            connection1.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Visite p = new Visite(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
                list.Add(p);
            }

            connection1.Close();
            return list;
        }
        public List<Visite> SelectbyId(int id)
        {
            List<Visite> list = new List<Visite>();
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

            string sql = "Select * from Visites where id=" + id;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);
            connection1.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                Visite p = new Visite(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
                list.Add(p);
            }

            connection1.Close();
            return list;
        }
        public List<Visite> SelectByIdpatient(int idpatient)
        {
            List<Visite> lv = new List<Visite>();
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = "Select * from Visites where idpatient=" + idpatient;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);
            connection1.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                 Visite v = new Visite(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
                lv.Add(v);
            }

            connection1.Close();
            return lv;
        }
    }
}
