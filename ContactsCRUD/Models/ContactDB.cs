using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ContactsCRUD.Models
{
    public class ContactDB
    {
        readonly string connectStr = "Data Source=DANIIL;Initial Catalog=ContactsDB;Integrated Security=True";
        public List<Contact> ListAll()
        {
            var contacts = new List<Contact>();
            using(var conn = new SqlConnection(connectStr))
            {
                conn.Open();
                var cmd = new SqlCommand("select * from Contacts", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        Id = reader.GetInt64(0),
                        Name = reader.GetString(1),
                        MobilePhone = reader.GetString(2),
                        JobTitle = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4).ToShortDateString()
                    });
                }
            }
            return contacts;
        }

        public int Add(Contact contact)
        {
            int item;
            using(var conn = new SqlConnection(connectStr))
            {
                conn.Open();
                string sqlQuery = "insert into Contacts (Name, MobilePhone, JobTitle, BirthDate) values (@Name, @MobilePhone, @JobTitle, @BirthDate)";
                using (var cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", contact.Name);
                    cmd.Parameters.AddWithValue("@MobilePhone", contact.MobilePhone);
                    cmd.Parameters.AddWithValue("@JobTitle", contact.JobTitle);
                    cmd.Parameters.AddWithValue("@BirthDate", contact.BirthDate);
                    item = cmd.ExecuteNonQuery();
                };
            }
            return item;
        }

        public int Update(Contact contact)
        {
            int item;
            using (var conn = new SqlConnection(connectStr))
            {
                conn.Open();
                string sqlQuery = "update Contacts set Name = @Name, MobilePhone = @MobilePhone, JobTitle = @JobTitle, BirthDate = @BirthDate where Id = @Id";
                using (var cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", contact.Name);
                    cmd.Parameters.AddWithValue("@MobilePhone", contact.MobilePhone);
                    cmd.Parameters.AddWithValue("@JobTitle", contact.JobTitle);
                    cmd.Parameters.AddWithValue("@BirthDate", contact.BirthDate);
                    cmd.Parameters.AddWithValue("@Id", contact.Id);
                    item = cmd.ExecuteNonQuery();
                };
            }
            return item;
        }


        public int Delete(long Id)
        {
            int item;
            using (var conn = new SqlConnection(connectStr))
            {
                conn.Open();
                string sqlQuery = "delete Contacts where Id = @Id";
                using (var cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    item = cmd.ExecuteNonQuery();
                };
            }
            return item;
        }

    }
}