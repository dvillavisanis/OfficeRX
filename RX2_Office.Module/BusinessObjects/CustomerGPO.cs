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

namespace RX2_Office.Module.BusinessObjects
{
    [NavigationItem("Sales")]
    [DefaultClassOptions]
   [ImageName("customersGPO")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class CustomerGPO : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CustomerGPO(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            
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
        //    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
        //    this.PersistentProperty = "Paid";
        //}
        // Fields...
        private State _State;
        private string _WebSiteUserPassword;
        private string _WebsiteUserName;
        private string _WebSite;
        private string _Phone;
        private string _ZipCode;
        private string _City;
        private string _Address2;
        private string _Address1;
        private string _GPOName;

        public string GPOName
        {
            get
            {
                return _GPOName;
            }
            set
            {
                SetPropertyValue("GPOName", ref _GPOName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                SetPropertyValue("Address1", ref _Address1, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                SetPropertyValue("Address2", ref _Address2, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                SetPropertyValue("City", ref _City, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("State-CustomerGPOs")]
        public State State
        {
            get
            {
                return _State;
            }
            set
            {
                SetPropertyValue("State", ref _State, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                SetPropertyValue("ZipCode", ref _ZipCode, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string WebSite
        {
            get
            {
                return _WebSite;
            }
            set
            {
                SetPropertyValue("WebSite", ref _WebSite, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string WebsiteUserName
        {
            get
            {
                return _WebsiteUserName;
            }
            set
            {
                SetPropertyValue("WebsiteUserName", ref _WebsiteUserName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string WebSiteUserPassword
        {
            get
            {
                return _WebSiteUserPassword;
            }
            set
            {
                SetPropertyValue("WebSiteUserPassword", ref _WebSiteUserPassword, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("CustomerGPO-Customers")]
        public XPCollection<Customer> Customers
        {
            get
            {
                return GetCollection<Customer>("Customers");
            }
        }
        [Association("CustomerGPO-CustomerGpoItemPricing")]
        public XPCollection<CustomerGPOItemPricing> CustomerGpoItemPricing
        {
            get
            {
                return GetCollection<CustomerGPOItemPricing>("CustomerGpoItemPricing");
            }
        }

    }
}
