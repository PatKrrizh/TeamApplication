using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataLayer
{
    public class MembershipType : DataObject
    {
        public class MembershipTypeDetails
        {
            public byte Id { get; set; }
            public string Name { get; set; }
        }

        public List<MembershipTypeDetails> GetMembershipTypes()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from MembershipTypes", conn);

            conn.Open();

            SqlDataAdapter sa = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            try
            {
                sa.Fill(ds);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message); ;
            }
            finally
            {
                conn.Close();
            }

            List<MembershipTypeDetails> membershipTypes = new List<MembershipTypeDetails>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                MembershipTypeDetails membershipTypeDetails = new MembershipTypeDetails
                {
                    Id = Convert.ToByte(dataRow["Id"]),
                    Name = dataRow["Name"].ToString(),
                };

                membershipTypes.Add(membershipTypeDetails);
            }

            return membershipTypes;
        }
    }
}