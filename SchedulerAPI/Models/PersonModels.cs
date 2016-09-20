using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchedulerAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class PersonModels
    {
        // link to DB?


        public bool CreatePersonModels(string FirstName, string LastName, string Address1, string Address2, string City, string State, string Zip)
        {
            // Call CreatePerson SP in Scheduler DB

            return true;
        }

        public Person GetPerson(Int16 PersonID)
        {
            Person person = new Person();

            string connectionString = ConfigurationManager.ConnectionStrings["Scheduler"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetPerson";
                    var param = new SqlParameter("@_PersonID", PersonID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    command.Parameters.Add(param);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            System.Diagnostics.Debug.WriteLine("{0} {1} {2}",
                            reader.GetInt16(0), reader.GetString(1), reader.GetString(2));
                        }
                    }
                }
            }

            return person;
        }
    }
}