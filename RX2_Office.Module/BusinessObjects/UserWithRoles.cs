using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Persistent.Base.Security;
using System.Security;

namespace RX2_Office.Module.BusinessObjects
{
    public class UserWithRoles : IUserWithRoles
    {
        public UserWithRoles()
        {

        }
        public IList<IRole> Roles { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public IList<IPermission> Permissions { get; set; }
        public void ReloadPermissions()
        {
            throw new NotImplementedException();
        }
    }
}
