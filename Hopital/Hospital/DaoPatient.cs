using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DaoPatient
    {
        public bool EstEnregistre(int id)
        {
            bool estPresent = false;

            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

            string sql = "select COUNT(*) from patients where id=" + id;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);
            connection1.Open();
            
            int count = (int)command.ExecuteScalar();

            if (count > 0)
                estPresent = true;
            connection1.Close();
            return estPresent;
        }
        public Patient SelectByid(int id)
        {

            Patient pat = new Patient();
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

            string sql = "select * from patients where id=" + id;

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);
            connection1.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                pat = new Patient(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));

            }

            connection1.Close();

            return pat;

        }
        public List<Patient> SelectAll()
        {
            List<Patient> listp = new List<Patient>();
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = @"SELECT id, nom, prenom, age  FROM patients ";



            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);
            connection1.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Patient patient = new Patient(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3)
                               );

                listp.Add(patient);
            }
            connection1.Close();
            return listp;
        }

        public bool UpdatePhoneAdresse(Patient patient)
        {
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = "update patients SET adresse = @adresse,telephone = @telephone WHERE id = @id";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = patient.Id;
            command.Parameters.Add("adresse", SqlDbType.NVarChar).Value = patient.Adresse.ToString();
            command.Parameters.Add("telephone", SqlDbType.NVarChar).Value = patient.Telephone;
           
            connection1.Open();
            int count = command.ExecuteNonQuery();
            connection1.Close();
            return (count > 0) ? true : false;
        }

        public bool Update(Patient patient)
        {
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = "update patients SET prenom = @prenom,nom = @nom,age = @age WHERE id = @id";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = patient.Id;
            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = patient.Nom;
            command.Parameters.Add("prenom", SqlDbType.NVarChar).Value = patient.Prenom;
            command.Parameters.Add("age", SqlDbType.Int).Value = patient.Age;
            //command.Parameters.Add("telephone", SqlDbType.NVarChar).Value = patient.Telephone;
            //command.Parameters.Add("adresse", SqlDbType.NVarChar).Value = patient.Adresse;




            connection1.Open();
            int count = command.ExecuteNonQuery();
            connection1.Close();
            return (count > 0) ? true : false;
        }

        public void Insert(Patient patient)
        {
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = "insert into patients (id, nom,prenom, age) values (@id,@nom,@prenom,@age)";


            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = patient.Id;
            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = patient.Nom;
            command.Parameters.Add("prenom", SqlDbType.NVarChar).Value = patient.Prenom;
            command.Parameters.Add("age", SqlDbType.Int).Value = patient.Age;
           


            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();
        }
        public bool Delete(int id)
        {
            string connectionString = @"Data Source=GABRIEL\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";
            string sql = "delete from patients  where id =" + id;

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();
            int count = command.ExecuteNonQuery();
            connection1.Close();
            return (count > 0) ? true : false;
        }

    }
}
