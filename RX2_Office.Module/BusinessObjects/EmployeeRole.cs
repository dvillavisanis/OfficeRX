using System;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Base;
using System.Linq;
using System.Collections.Generic;

namespace RX2_Office.Module.BusinessObjects
{[NavigationItem("Security")]
    [ImageName("BO_Role")]
    public class EmployeeRole :  PermissionPolicyRoleBase, IPermissionPolicyRoleWithUsers {
    public EmployeeRole(Session session)
        : base(session) {
    }
    [Association("Employees-EmployeeRoles")]
    public XPCollection<Employee> Employees
    {
        get
        {
            return GetCollection<Employee>("Employees");
        }
    }
    IEnumerable<IPermissionPolicyUser> IPermissionPolicyRoleWithUsers.Users
    {
        get { return Employees.OfType<IPermissionPolicyUser>(); }
    }
}

}