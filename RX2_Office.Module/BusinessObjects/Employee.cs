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
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using RX2_Office.Module.BusinessObjects;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base.Security;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]

    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Employee : Person, ISecurityUser,
    IAuthenticationStandardUser, ISecurityUserWithRoles, 
    IPermissionPolicyUser, ICanInitialize
    {

        public Employee(Session session)
           : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        #region Properties
        string mobileNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MobileNumber
        {
            get
            {
                return mobileNumber;
            }
            set
            {
                SetPropertyValue(nameof(MobileNumber), ref mobileNumber, value);
            }
        }
        string phoneExt;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneExt 
        {
            get
            {
                return phoneExt;
            }
            set
            {
                SetPropertyValue(nameof(PhoneExt), ref phoneExt, value);
            }
        }

        [Association("Employee-ItemPTBs")]
        public XPCollection<ItemPTB> ItemPTB
        {
            get
            {
                return GetCollection<ItemPTB>("ItemPTB");
            }
        }


        [Association("Employee-Task")]
        public XPCollection<EmployeeTask> OwnTasks
        {
            get { return GetCollection<EmployeeTask>("OwnTasks"); }
        }
        #endregion

        DateTime startDate;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                SetPropertyValue(nameof(StartDate), ref startDate, value);
            }
        }
        DateTime terminationDate;
        public DateTime TerminationDate
        {
            get
            {
                return terminationDate;
            }
            set
            {
                SetPropertyValue(nameof(TerminationDate), ref terminationDate, value);
            }
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

        #region ICanInitialize Members
        void ICanInitialize.Initialize(IObjectSpace objectSpace, SecurityStrategyComplex security)
        {
            EmployeeRole newUserRole = (EmployeeRole)objectSpace.FindObject<EmployeeRole>(
                new BinaryOperator("Name", security.NewUserRoleName));
            if (newUserRole == null)
            {
                newUserRole = objectSpace.CreateObject<EmployeeRole>();
                newUserRole.Name = security.NewUserRoleName;
                newUserRole.IsAdministrative = true;
                newUserRole.Employees.Add(this);
            }
        }
        #endregion

        #region IPermissionPolicyUser Members
        IEnumerable<IPermissionPolicyRole> IPermissionPolicyUser.Roles
        {
            get { return EmployeeRoles.OfType<IPermissionPolicyRole>(); }
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
        #endregion





        [Association("Employee-ItemMinSetBy")]
        public XPCollection<Items> Items
        {
            get
            {
                return GetCollection<Items>("Items");
            }
        }
       
    }
}
