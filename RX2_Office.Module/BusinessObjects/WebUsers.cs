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
using DevExpress.ExpressApp.SystemModule;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("WebUser")]
    [NavigationItem("Sales")]
    [DefaultProperty("WebUserName")]
   // [ListViewFilter("My Customers Web Users", "[CustomersWebUser].[Customers].[SalesRep] = CurrentUserName()  ", "My Customers WebUsers ", "Web Users that belong to my customers", true)]
    [ListViewFilter("All", "")]
   
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class WebUsers      : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public WebUsers(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            UserPassword = RandomPassword.Generate();
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

        // Fields...
        private string _CreatedBy;
        private DateTime _CreatedDate;
        private string _WebUserEmail;
        private string _UserPassword;
        private string _WebUserName;

        [Key]
    [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WebUserName
        {
            get
            {
                return _WebUserName;
            }
            set
            {
                SetPropertyValue("WebUserName", ref _WebUserName, value);
            }
        }

        [RuleRequiredField]
        [PasswordPropertyText]
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
               
                SetPropertyValue("UserPassword", ref _UserPassword, value);
            }
        }

        [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WebUserEmail
        {
            get
            {
                return _WebUserEmail;
            }
            set
            {
                SetPropertyValue("WebUserEmail", ref _WebUserEmail, value);
            }
        }

        [Association("WebUsers-CustomerWebUsers")]
        public XPCollection<CustomerWebUsers> CustomersWebUser
        {
            get
            {
                return GetCollection<CustomerWebUsers>("CustomersWebUser");
            }
        }


        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                SetPropertyValue("CreatedDate", ref _CreatedDate, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                SetPropertyValue("CreatedBy", ref _CreatedBy, value);
            }
        }

    }
}