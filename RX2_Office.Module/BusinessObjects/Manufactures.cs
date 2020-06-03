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
    [DefaultClassOptions]
    [ImageName("manufacturer")]
    [NavigationItem("Purchasing")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Manufacturer : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Manufacturer(Session session)
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
       // string stateZip;
        private int _ReturnDaysPostExpiration;
        private int _ReturnDaysPriorExpiration;
        private string _Website;
        private string _Phone;
        private string _ZipCode;
        private string _ManufacturerName;
        private State _State;
        private string _City;
        private string _Address2;
        private string _Address;
        private string _ManfacturerCode;

        [Key]
        [Size(5)]
        public string ManfacturerCode
        {
            get
            {
                return _ManfacturerCode;
            }
            set
            {
                SetPropertyValue("ManfacturerCode", ref _ManfacturerCode, value);
            }
        }


        public string ManufacturerName
        {
            get
            {
                return _ManufacturerName;
            }
            set
            {
                SetPropertyValue("ManufacturerName", ref _ManufacturerName, value);
            }
        }

        [VisibleInListView(false)]
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
        [RuleRequiredField]
        [VisibleInListView(false)]
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

        [RuleRequiredField]
        [Size(20)]
        [Association("State-Manufacturers")]
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
        [RuleRequiredField]
        [VisibleInListView(false)]
        [Size(10)]
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
        [Size(15)]

        [NonPersistent]
        [VisibleInListView(false)]
           public string CityStateZip
        {
            
            get =>  City +", "+State.StateCode+"  " + ZipCode ;
            
        }
        [VisibleInListView(false)]
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
        [Size(255)]
        public string WebSite
        {
            get
            {
                return _Website;
            }
            set
            {
                SetPropertyValue("WebSite", ref _Website, value);
            }
        }

        [VisibleInListView(false)]
        public int ReturnDaysPriorExpiration
        {
            get
            {
                return _ReturnDaysPriorExpiration;
            }
            set
            {
                SetPropertyValue("ReturnDaysPriorExpiration", ref _ReturnDaysPriorExpiration, value);
            }
        }

        [VisibleInListView(false)]
        public int ReturnDaysPostExpiration
        {
            get
            {
                return _ReturnDaysPostExpiration;
            }
            set
            {
                SetPropertyValue("ReturnDaysPostExpiration", ref _ReturnDaysPostExpiration, value);
            }
        }

        [Association("Manufacturer-RepackItems")]
        public XPCollection<RepackItems> RepackItems
        {
            get
            {
                return GetCollection<RepackItems>(nameof(RepackItems));
            }
        }
        [Association("Manufacturer-ManufacturerNotes")]
        public XPCollection<ManufacturerNote> ManufacturerNotes
        {
            get
            {
                return GetCollection<ManufacturerNote>("ManufacturerNotes");
            }
        }
    }
}
