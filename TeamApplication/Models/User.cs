using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamApplication.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthdate { get; set; }
		public byte MembershipTypeId { get; set; }
		public bool IsSubscribed { get; set; }
	}
}