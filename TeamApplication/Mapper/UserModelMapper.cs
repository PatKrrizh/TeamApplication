using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TeamApplication.Models;

namespace TeamApplication.Mapper
{
    public static class UserModelMapper
    {
        public static List<User> Map(this DataSet ds)
        {
            List<User> users = new List<User>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                User user = new User
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    FirstName = dataRow["FirstName"].ToString(),
                    LastName = dataRow["LastName"].ToString(),
                    Birthdate = Convert.ToDateTime(dataRow["Birthdate"]),
                    MembershipTypeId = Convert.ToByte(dataRow["MembershipTypeId"]),
                    IsSubscribed = Convert.ToBoolean(dataRow["IsSubscribed"])
                };

                users.Add(user);
            }

            return users;
        }
    }
}