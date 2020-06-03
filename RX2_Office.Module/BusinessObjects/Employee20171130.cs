using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using RX2_Office.Module.BusinessObjects;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Base.Security;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Task : ISupportNotifications, IXafEntityObject
    {
        // ... 
        public virtual Employee AssignedTo { get; set; }

        public DateTime? AlarmTime

        { get; set; }
        
        public bool IsPostponed
        { get; set; }

        public string NotificationMessage
        { get; set; }

        public object UniqueId
        { get; set; }



        public void OnCreated()
        {
        
        }

        public void OnLoaded()
        {
            
        }

        public void OnSaving()
        {
            
        }
    }



    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Employee : Person, ISecurityUser,
    IAuthenticationStandardUser, 
    ISecurityUserWithRoles
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Employee(Session session)
            : base(session)
        {
            Tasks = new List<Task>();
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        #region ISecurityUser Members
        private bool isActive = true;
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }
        private string userName = String.Empty;
        [RuleRequiredField("EmployeeUserNameRequired", DefaultContexts.Save)]
        [RuleUniqueValue("EmployeeUserNameIsUnique", DefaultContexts.Save,
            "The login with the entered user name was already registered within the system.")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }
        #endregion
        #region IAuthenticationStandardUser Members
        private bool changePasswordOnFirstLogon;
        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set
            {
                SetPropertyValue("ChangePasswordOnFirstLogon", ref changePasswordOnFirstLogon, value);
            }
        }
        private string storedPassword;
        [Browsable(false), Size(SizeAttribute.Unlimited), Persistent, SecurityBrowsable]
        protected string StoredPassword
        {
            get { return storedPassword; }
            set { storedPassword = value; }
        }
        public bool ComparePassword(string password)
        {
            return PasswordCryptographer.VerifyHashedPasswordDelegate(this.storedPassword, password);
        }
        public void SetPassword(string password)
        {
            this.storedPassword = PasswordCryptographer.HashPasswordDelegate(password);
            OnChanged("StoredPassword");
        }
        #endregion
        #region ISecurityUserWithRoles Members
        IList<ISecurityRole> ISecurityUserWithRoles.Roles
        {
            get
            {
                IList<ISecurityRole> result = new List<ISecurityRole>();
                foreach (EmployeeRole role in EmployeeRoles)
                {
                    result.Add(role);
                }
                return result;
            }
        }
        #endregion
        [Association("Employees-EmployeeRoles")]
        [RuleRequiredField("EmployeeRoleIsRequired", DefaultContexts.Save,
            TargetCriteria = "IsActive",
            CustomMessageTemplate = "An active employee must have at least one role assigned")]
        public XPCollection<EmployeeRole> EmployeeRoles
        {
            get
            {
                return GetCollection<EmployeeRole>("EmployeeRoles");
            }
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
        [Association("Employee-Task")]
        public XPCollection<EmployeeTask> OwnTasks
        {
            get { return GetCollection<EmployeeTask>("OwnTasks"); }
        }

        public virtual IList<Task> Tasks { get; set; }
        public object Roles { get; internal set; }
    }

}

// ... 

[DefaultClassOptions]
[ImageName("BO_Role")]
public class EmployeeRole : PermissionPolicyRoleBase, IPermissionPolicyRoleWithUsers
{
    public EmployeeRole(Session session)
        : base(session)
    {
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

[DefaultClassOptions, ImageName("BO_Task")]
public class EmployeeTask : DevExpress.Persistent.BaseImpl.Task
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