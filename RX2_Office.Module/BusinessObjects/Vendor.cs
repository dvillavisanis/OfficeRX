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
using DevExpress.Xpo.Metadata;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Vendor")]
    [NavigationItem("Purchasing")]
   
    [ListViewFilter("Active Vendors", "[IsActive] ", "Active Vendor", "Active Vendors", true)]
    [ListViewFilter("Vendors w/ Open POs", "[OrdersCount] > 0 ", "Vendor w/ Open PO", "Open PO Vendors", false)]
    [ListViewFilter("All Vendors", "")]
    [RuleCriteria("RuleCriteria for Vendor", DefaultContexts.Save, "Not IsNullOrEmpty(Trim([VendorName]))", SkipNullOrEmptyValues = false)]
    [DefaultProperty("VendorName")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Vendor : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Vendor(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            this.CreatedBy = SecuritySystem.CurrentUserName;
            this.CreatedDate = DateTime.Today;
            this.RecordManager = SecuritySystem.CurrentUserName;
            this.IsActive = true;
            
        }


        protected override void OnLoaded()
        {
            Reset();
            base.OnLoaded();
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

        DateTime addToAccountingDT;
        bool addToAccounting;
      
      //  VendorItemPricing vendorItemPricing;
        private DateTime _LastDatePurchasedFrom;
        private bool _IsActive;
        private string _Oldvendorid;
        private string _AccountingVendorNumber;
        private PaymentTermsCode _TermCode;
        private string _RecordManager;
        private string _AccountingNumber;
        private VendorType _VendorType;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private string _Password;
        private string _UserName;
        private string _WebSite;
        private string _Fax;
        private string _Phone;
        private string _ZipCode;
        private string _City;
        private string _Address3;
        private string _Address2;
        private string _Address;
        private string _VendorName;
        private State _State;

        //[RuleRequiredField("RuleRequiredField for Vendor.VendorName", DefaultContexts.Save,"A Vendor Name is Required")]
        [RuleValueComparison("", DefaultContexts.Save, ValueComparisonType.NotEquals, "")]
        public string VendorName
        {
            get
            {
                return _VendorName;
            }
            set
            {
                SetPropertyValue("VendorName", ref _VendorName, value);
            }
        }

        [Size(15)]
        public string AccountingVendorNumber
        {
            get
            {
                return _AccountingVendorNumber;
            }
            set
            {
                SetPropertyValue("AccountingVendorNumber", ref _AccountingVendorNumber, value);
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

        [Association("State-Vendor")]
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
        [ModelDefault("DisplayFormat", "0: (000)000-0000 Ext. 9999")]
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
        [ModelDefault("DisplayFormat", "0: (000)000-0000")]
        [Size(20)]
        public string Fax
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
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                SetPropertyValue("UserName", ref _UserName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                SetPropertyValue("Password", ref _Password, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
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

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]

        string dEALicenceNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DEALicenseNumber
        {
            get
            {
                return dEALicenceNumber;
            }
            set
            {
                SetPropertyValue(nameof(DEALicenseNumber), ref dEALicenceNumber, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]

        DateTime dEAExpirationDt;
        public DateTime DEAExpirationDt
        {
            get
            {
                return dEAExpirationDt;
            }
            set
            {
                SetPropertyValue(nameof(DEAExpirationDt), ref dEAExpirationDt, value);
            }
        }





        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]

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


        public DateTime LastDatePurchasedFrom
        {
            get
            {
                return _LastDatePurchasedFrom;
            }
            set
            {
                SetPropertyValue("LastDatePurchasedFrom", ref _LastDatePurchasedFrom, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string RecordManager
        {
            get
            {
                return _RecordManager;
            }
            set
            {
                SetPropertyValue("RecordManager", ref _RecordManager, value);
            }
        }



        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(10)]
        public string AccountingNumber
        {
            get
            {
                return _AccountingNumber;
            }
            set
            {
                SetPropertyValue("AccountingNumber", ref _AccountingNumber, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField("RuleRequiredField for Vendor.VendorType", DefaultContexts.Save,
      "A Vendor Type is Required")]

        [Association("VendorType-Vendor")]


        public VendorType VendorType
        {
            get
            {
                return _VendorType;
            }
            set
            {
                SetPropertyValue("VendorType", ref _VendorType, value);
            }
        }


        [Indexed]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string oldvendorid
        {
            get
            {
                return _Oldvendorid;
            }
            set
            {
                SetPropertyValue("oldvendorid", ref _Oldvendorid, value);
            }
        }

        [Association("Vendor-VendorNotes")]
        public XPCollection<VendorNote> VendorNotes
        {
            get
            {
                return GetCollection<VendorNote>("VendorNotes");
            }
        }

        [Association("Vendor-VendorContacts")]
        public XPCollection<VendorContact> VendorContacts
        {
            get
            {
                return GetCollection<VendorContact>("VendorContacts");
            }
        }
        [Association("Vendor-PurchaseOrders")]
        public XPCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder> PurchaseOrders
        {
            get
            {
                return GetCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder>("PurchaseOrders");
            }
        }

        [Association("PaymentTermsCode-Vendor")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public PaymentTermsCode TermCode
        {
            get
            {
                return _TermCode;
            }
            set
            {
                SetPropertyValue("TermCode", ref _TermCode, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetPropertyValue("IsActive", ref _IsActive, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool AddToAccounting
        {
            get => addToAccounting;
            set => SetPropertyValue(nameof(AddToAccounting), ref addToAccounting, value);
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime AddToAccountingDT
        {
            get => addToAccountingDT;
            set => SetPropertyValue(nameof(AddToAccountingDT), ref addToAccountingDT, value);
        }


        [Association("Vendor-Items")]
        public XPCollection<Items> Item
        {
            get
            {
                return GetCollection<Items>("Item");
            }
        }
        [Association("Vendor-ItemTransactions")]
        public XPCollection<ItemTransaction> ItemTransactions
        {
            get
            {
                return GetCollection<ItemTransaction>("ItemTransactions");
            }
        }


        [Association("Vendor-ItemReceivers")]
        public XPCollection<ItemReceiver> ItemReceivers
        {
            get
            {
                return GetCollection<ItemReceiver>("ItemReceivers");
            }
        }

        [Association("Vendor-LastPurchasedFrom")]
        public XPCollection<Items> LastPurchaseFrom
        {
            get
            {
                return GetCollection<Items>("LastPurchaseFrom");
            }
        }
 

        [Association("Vendor-VendorItemPricing")]
        public XPCollection< VendorItemPricing> VendorItemPricing
        {
            get
            {
                return GetCollection<VendorItemPricing>(nameof(VendorItemPricing));
            }
        }

        private int? fOrdersCount = null;
        public int? OrdersCount
        {
            get
            {
                if (!IsLoading && !IsSaving && fOrdersCount == null)
                    UpdateOrdersCount(false);
                return fOrdersCount;
            }
        }
        private void Reset()
        {
            fOrdersCount = null;
           // fOrdersTotal = null;
            //fMaximumOrder = null;
        }
        [Association("Vendor-VendorInvoices")]
        public XPCollection<VendorInvoice> VendorInvoices
        {
            get
            {
                return GetCollection<VendorInvoice>(nameof(VendorInvoices));
            }
        }

        private XPCollection<AuditDataItemPersistent> changeHistory;
        public XPCollection<AuditDataItemPersistent> ChangeHistory
        {
            get
            {
                if (changeHistory == null)
                {
                    changeHistory = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return changeHistory;
            }
        }
        public void UpdateOrdersCount(bool forceChangeEvents)
        {
            int? oldOrdersCount = fOrdersCount;
            fOrdersCount = Convert.ToInt32(Evaluate(CriteriaOperator.Parse("PurchaseOrders.Count")));
            if (forceChangeEvents)
                OnChanged("OrdersCount", oldOrdersCount, fOrdersCount);
        }


    }

}