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

    // This function should reside in your SQL-class.
    //public IEnumerable<T> ExecuteObject<T>(SqlCommand command)
    //{
    //    List<T> items = new List<T>();
    //    using (SqlDataReader reader = command.ExecuteReader())
    //    {
    //        while (reader.Read())
    //        {
    //            T item = (T)Activator.CreateInstance(typeof(T), reader.);
    //            items.Add(item);
    //        }
    //    }
    //    return items;
    //}

    public class PersonModels
    {
        public bool CreatePersonModels(string FirstName, string LastName, string Address1, string Address2, string City, string State, string Zip)
        {
            // Call CreatePerson SP in Scheduler DB

            return true;
        }

        public Person GetPerson(Int16 PersonID)
        {
            Person person = new Person();
            List<Person> items = new List<Person>();

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
                            var a = reader.GetName(0);
                            var b = reader.GetName(1);
                            var c = reader.GetName(2);
                            var d = reader.GetName(3);
                        }
                    }
                }
            }

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    con.Open();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetPerson";
                    var param = new SqlParameter("@_PersonID", PersonID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    command.Parameters.Add(param);

                    using (var da = new SqlDataAdapter())
                    {
                        da.SelectCommand = command;
                        da.Fill(table);
                        foreach (var row in table.Rows)
                        {
                            Person item = (Person)Activator.CreateInstance(typeof(Person), row);
                            items.Add(item);
                        }
                    }
                }
            }

            return items[0];
        }
    }
}