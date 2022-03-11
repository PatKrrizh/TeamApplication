using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class User : DataObject
    {
        public User() : base() { }

        public class UserDetails
        {
            public int Id { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Date of Birth")]
            public DateTime Birthdate { get; set; }

            [Display(Name = "Membership Type")]
            public byte MembershipTypeId { get; set; }

            public bool IsSubscribed { get; set; }
        }

        //Get User By Id
        public UserDetails GetUser(int Id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("GetUser", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlParameter firstName = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(firstName);

            SqlParameter lastName = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(lastName);

            SqlParameter birthdate = new SqlParameter
            {
                ParameterName = "@Birthdate",
                SqlDbType = SqlDbType.DateTime,
                Size = 20,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(birthdate);

            SqlParameter membershipTypeId = new SqlParameter
            {
                ParameterName = "@MembershipTypeId",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(membershipTypeId);

            SqlParameter isSubscribed = new SqlParameter
            {
                ParameterName = "@IsSubscribed",
                SqlDbType = SqlDbType.Bit,
                Size = 10,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(isSubscribed);

            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();

                UserDetails userDetails = new UserDetails()
                {
                    Id = Id,
                    FirstName = cmd.Parameters["@FirstName"].Value.ToString(),
                    LastName = cmd.Parameters["@LastName"].Value.ToString(),
                    Birthdate = Convert.ToDateTime(cmd.Parameters["@Birthdate"].Value),
                    MembershipTypeId = Convert.ToByte(cmd.Parameters["@MembershipTypeId"].Value),
                    IsSubscribed = Convert.ToBoolean(cmd.Parameters["@IsSubscribed"].Value)
                };
                return userDetails;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        //Get All Users
        public /*List<UserDetails>*/ DataSet GetUsers()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Users", conn);

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

            //List<UserDetails> users = new List<UserDetails>();
            //foreach (DataRow dataRow in ds.Tables[0].Rows)
            //{
            //    UserDetails userDetails = new UserDetails
            //    {
            //        Id = Convert.ToInt32(dataRow["Id"]),
            //        FirstName = dataRow["FirstName"].ToString(),
            //        LastName = dataRow["LastName"].ToString(),
            //        Birthdate = Convert.ToDateTime(dataRow["Birthdate"]),
            //        MembershipTypeId = Convert.ToByte(dataRow["MembershipTypeId"]),
            //        IsSubscribed = Convert.ToBoolean(dataRow["IsSubscribed"])
            //    };

            //    users.Add(userDetails);
            //}

            //return users;

            return ds;

        }

        //Update User Details
        public void UpdateUser(UserDetails userDetails)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("UpdateUser", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", userDetails.Id);
            cmd.Parameters.AddWithValue("@FirstName", userDetails.FirstName);
            cmd.Parameters.AddWithValue("@LastName", userDetails.LastName);
            cmd.Parameters.AddWithValue("@Birthdate", userDetails.Birthdate);
            cmd.Parameters.AddWithValue("@MembershipTypeId", userDetails.MembershipTypeId);
            cmd.Parameters.AddWithValue("@IsSubscribed", userDetails.IsSubscribed);

            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        //Add User 
        public void AddUser(UserDetails userDetails)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("AddUser", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@FirstName", userDetails.FirstName);
            cmd.Parameters.AddWithValue("@LastName", userDetails.LastName);
            cmd.Parameters.AddWithValue("@Birthdate", userDetails.Birthdate);
            cmd.Parameters.AddWithValue("@MembershipTypeId", userDetails.MembershipTypeId);
            cmd.Parameters.AddWithValue("@IsSubscribed", userDetails.IsSubscribed);

            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        //Delete User 
        public void DeleteUser(int Id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("DeleteUser", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", Id);

            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conn.Close();
            }
        }
    }
}