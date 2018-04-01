using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    //ADO.Net SqlConnection
    class SqlCon
    {
        static void Main(string[] args)
        {
            new SqlCon().Connecting();
        }
        public void Connecting()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("Data Source=ADMIN\\SQLEXPRESS01;Initial Catalog=Employee;Integrated Security=True");

                con.Open();
                Console.WriteLine("Connection Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Faild" + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }


    //creat table
    class SqlConn
    {
        public static void Main(string[] args)
        {
            new SqlConn().CreateTable();
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try

            {
                con = new SqlConnection("Data Source=ADMIN\\SQLEXPRESS01;Initial Catalog=Employee;Integrated Security=True");

                SqlCommand cmd = new SqlCommand("create table employee1(id int not null,name varchar(100),email varchar(50),join_date date)", con);



                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Table created Successfully");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Table Not Created" + ex);
            }

            finally
            {
                con.Close();
            }
        }
    }

    //insert data in table
    class Emp
    {
        public static void Main(string[] args)
        {
            new Emp().CreateTable();
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {

                con = new SqlConnection("Data Source=ADMIN\\SQLEXPRESS01;Initial Catalog=Employee;Integrated Security=True");

                SqlCommand cmd = new SqlCommand("insert into employee1(id, name, email, join_date)values('2', 'punu', 'pu@gmail.com', '12/03/2017')", con);
                // SqlCommand cm = new SqlCommand("delete from student where id = '101'", con);
                con.Open();

                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data Not Inserted" + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }

    //retrive table
    class Emp1
    {
        public static void Main(string[] args)
        {
            {
                new Emp1().CreateTable();
            }
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=ADMIN\\SQLEXPRESS01;Initial Catalog=Employee;Integrated Security=True");

                SqlCommand cmd = new SqlCommand("Select * from employee1", con);

                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"] + " " + sdr["join_date"]); // Displaying Record  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("faild:" + ex);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }

    //DataSet
    class Cutmes
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            var customersTable = ds.Tables.Add("Customers");
            customersTable.Columns.AddRange("FirstName", "LastName", "Id", "Address");
            customersTable.Rows.Add("purvi", "Indwar", 1, "Raipur");
            customersTable.Rows.Add("amrita", "raj", 2, "up");
            customersTable.Rows.Add("neha", "rai", 3, "bilashpur");

            Console.WriteLine(ds.ToPrettyString());
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    static class ExtensionMethods
    {
        public static string ToPrettyString(this DataSet ds)
        {
            var sb = new StringBuilder();
            foreach (var table in ds.Tables.ToList())
            {
                sb.AppendLine("--" + table.TableName + "--");
                sb.AppendLine(String.Join(" | ", table.Columns.ToList()));
                foreach (DataRow row in table.Rows)
                {
                    sb.AppendLine(String.Join(" | ", row.ItemArray));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static void AddRange(this DataColumnCollection collection, params string[] columns)
        {
            foreach (var column in columns)
            {
                collection.Add(column);
            }
        }

        public static List<DataTable> ToList(this DataTableCollection collection)
        {
            var list = new List<DataTable>();
            foreach (var table in collection)
            {
                list.Add((DataTable)table);
            }
            return list;
        }

        public static List<DataColumn> ToList(this DataColumnCollection collection)
        {
            var list = new List<DataColumn>();
            foreach (var column in collection)
            {
                list.Add((DataColumn)column);
            }
            return list;
        }
    }

    class Emp2
    {
        public static void Main(string[] args)
        {

            SqlConnection con = new SqlConnection("Data Source=ADMIN\\SQLEXPRESS01;Initial Catalog=Employee;Integrated Security=True");
            con.Open();
            string Username, Password;

            Console.WriteLine("Enter Username and Password");
            Username = Console.ReadLine();
            Password = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("insert into LoginTable_1 values('" + Username + "','" + Password + "')", con);
           int i= cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Console.WriteLine("insertion successfully");
               
            }
            con.Close();
        }
    }
}
             