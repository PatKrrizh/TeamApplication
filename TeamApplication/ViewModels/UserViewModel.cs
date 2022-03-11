using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamApplication.ViewModels
{
    public class UserViewModel
    {
        public User.UserDetails User { get; set; }
        public IEnumerable<MembershipType.MembershipTypeDetails> MembershipTypes { get; set; }
    }
}