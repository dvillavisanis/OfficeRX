using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Persistent.Base.Security;

namespace RX2_Office.Module.BusinessObjects
{
    public class AuthenticationActiveDirectoryUser : IAuthenticationActiveDirectoryUser
    {
        public AuthenticationActiveDirectoryUser()
        {

        }
        string IAuthenticationActiveDirectoryUser.UserName { get; set; }
    }
}
