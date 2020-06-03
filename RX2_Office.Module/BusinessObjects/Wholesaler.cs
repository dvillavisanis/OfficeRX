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
    [ImageName("Wholesaler")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [ListViewFindPanel(true)]
    
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView   , false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Wholesaler : XPObject

    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Wholesaler(Session session)
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
   
        private string _Website;
        private string _Fax;
        private string _Phone;
        private string _Zip;
        private string _City;
        private string _Address3;
        private string _Address2;
        private string _Address;
        private string _Name;

        [Size(64)]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
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
        public string Address3
        {
            get
            {
                return _Address3;
            }
            set
            {
                SetPropertyValue("Address3", ref _Address3, value);
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
        [Size(20)]
        public string Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                SetPropertyValue("Zip", ref _Zip, value);
            }
        }
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [Size(20)]
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
        [Size(20)]
        public  string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                SetPropertyValue("Fax", ref _Fax, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(255)]
        public string Website
        {
        	get
        	{
        		return _Website;
        	}
        	set
        	{
        	  SetPropertyValue("Website", ref _Website, value);
        	}
        }
        [Association("Wholesaler-Customers")]
        public XPCollection<Customer> Customers {
          get {
              return GetCollection<Customer>("Customers");
            }
        }
    }
}
