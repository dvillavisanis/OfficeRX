using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions, ImageName("BO_Task")]
    public class EmployeeTask : Task
    {
        public EmployeeTask(Session session)
            : base(session) { }
        private Employee owner;
        [Association("Employee-Task")]
        public Employee Owner
        {
            get { return owner; }
            set { SetPropertyValue("Owner", ref owner, value); }
        }
    }


}

