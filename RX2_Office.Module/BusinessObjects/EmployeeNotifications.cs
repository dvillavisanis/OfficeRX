using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using RX2_Office.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class EmployeeNotifications : BaseObject, ISupportNotifications
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EmployeeNotifications(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        public int Id { get; private set; }
        public virtual MyTask MyTask { get; set; }
        public virtual DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser AssignedTo { get; set; }

        DateTime? alarmTime;
        public DateTime? AlarmTime
        {
            get
            {
                return alarmTime;
            }
            set
            {
                SetPropertyValue(nameof(AlarmTime), ref alarmTime, value);
            }
        }

        // [Browsable(false), NotMapped]
        public object UniqueId
        {
            get { return Id; }
        }
        [Browsable(false)]
        public bool IsPostponed { get; set; }
        [Browsable(false)]
        public string NotificationMessage { get { return MyTask.Subject; } }
    }

    [DefaultClassOptions]
    public class MyTask
    {
        public MyTask()
        {
            MyNotifications = new List<EmployeeNotifications>();

        }

        [Browsable(true)]
        public int Id { get; private set; }
        public string Subject { get; set; }
        [DevExpress.Xpo.Aggregated]
        public virtual IList<EmployeeNotifications> MyNotifications { get; set; }

    }
}