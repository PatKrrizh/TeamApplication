using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TeamApplication.Models;

namespace TeamApplication.Mapper
{
    public class MembershipTypeMapper
    {
        public static List<MembershipType> Map(DataSet ds)
        {
            List<MembershipType> membershipTypes = new List<MembershipType>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                MembershipType membershipType = new MembershipType
                {
                    Id = Convert.ToByte(dataRow["Id"]),
                    Name = dataRow["Name"].ToString(),
                };

                membershipTypes.Add(membershipType);
            }

            return membershipTypes;
        }
    }
}