using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookLinq
{
    class AddressBook
    {
        public static DataTable dataTable = new DataTable();

        public static void CreateTable()
        {
            dataTable.Columns.Add("BookName", typeof(string));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("ContactType", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("Zip", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));

            dataTable.Rows.Add("AB1", "Akash", "Mane", "Friend", "Mumbai", "Mulund", "Mah", 400080, "122345", "akash@gmail.com");
            dataTable.Rows.Add("AB1", "Yash", "Mane", "Friend", "Mumbai", "Mulund", "Mah", 400080, "185345", "yash@gmail.com");
            dataTable.Rows.Add("AB2", "Tanmay", "Maity", "Professional", "Kolkatta", "Eden Gardens", "Bengal", 600080, "122744", "tanmay@gmail.com");
            dataTable.Rows.Add("AB3", "Parth", "Trivedi", "Family", "Rajkot", "Jaamnagar", "Gujarat", 600804, "928345", "parth@gmail.com");
            dataTable.Rows.Add("AB4", "Kunal", "Shetty", "Professional", "Mumbai", "Thane", "Mah", 700805, "522345", "kunal@gmail.com");

            DisplayDataTable();

        }

        public static void DisplayDataTable()
        {
            var stringTable = from product in dataTable.AsEnumerable() select product;

            foreach (var row in stringTable)
            {
                Console.WriteLine("FirstName: " + row.Field<string>("FirstName") + ", LastName: " + row.Field<string>("LastName") + ", Address: " + row.Field<string>("Address") + " , City: " + row.Field<string>("City") + " , State: " + row.Field<string>("State") + ", Zip: " + row.Field<int>("Zip") + " , PhoneNumber: " + row.Field<string>("PhoneNumber") + ", EmailID: " + row.Field<string>("EmailID"));
            }
        }

        public static void InsertColumnIntoTable()
        {
            DataRow dr = dataTable.NewRow();
            dr[0] = "AB4";
            dr[1] = "Kapil";
            dr[2] = "Sharma";
            dr[3] = "Family";
            dr[4] = "Punjab";
            dr[5] = "Jalandhar";
            dr[6] = "Pun";
            dr[7] = 968450;
            dr[8] = "854621";
            dr[9] = "kapil@gmail.com";

            dataTable.Rows.Add(dr);

            DisplayDataTable();
        }

        public static void EditContactsByName()
        {

            DataRow row = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName").Equals("Tanmay")).FirstOrDefault();

            row["City"] = "Howrah";

            DisplayDataTable();

        }

        public static void DeleteContact(string name)
        {
            name = name.ToLower();
            var deleteRow = dataTable.AsEnumerable().Where(a => a.Field<string>("FirstName").Equals(name)).FirstOrDefault();
            if (deleteRow != null)
            {
                deleteRow.Delete();
                Console.WriteLine("Contact deleted successfully");
            }
            else
            {
                Console.WriteLine("No record found");
            }
            DisplayDataTable();
        }

        public static void RetrieveContactAccordingToCity(string city)
        {
            var cityResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("City") == city);
            foreach (DataRow row in cityResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void RetrieveContactAccordingToState(string state)
        {
            var stateResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("State") == state);
            foreach (DataRow row in stateResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void GetCountByCityState()
        {
            var countByCityAndState = from row in dataTable.AsEnumerable()
                                      group row by new { City = row.Field<string>("City"), State = row.Field<string>("State") } into grp
                                      select new
                                      {
                                          City = grp.Key.City,
                                          State = grp.Key.State,
                                          Count = grp.Count()
                                      };
            foreach (var row in countByCityAndState)
            {
                Console.WriteLine(row.City + "\t" + row.State + "\t" + row.Count);
            }
        }

        public static void SortContactAlphabetically(string city)
        {
            var result = from contact in dataTable.AsEnumerable()
                         where contact.Field<string>("City") == city
                         orderby contact.Field<string>("FirstName"), contact.Field<string>("LastName")
                         select contact;
            foreach (DataRow row in result)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        
    }
}
