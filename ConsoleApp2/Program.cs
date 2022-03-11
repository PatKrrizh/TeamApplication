using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet();

            string connectionString = "server = .; Initial Catalog = TeamApplication; Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Users", conn);
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection Successfully Opened");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataSet);

                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        { 
                            Console.WriteLine(row[column]);
                        }
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
