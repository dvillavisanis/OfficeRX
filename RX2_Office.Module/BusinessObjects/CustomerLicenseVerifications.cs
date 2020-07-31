using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
namespace RX2_Office.Module.BusinessObjects
{
    [NavigationItem("Sales")]
    [DefaultClassOptions]
    [ImageName("CustomerLicenseVarification")]

    [ListViewFilter(" My This Week", "[VerificationDate] >= LocalDateTimeThisWeek() and [VerificationDate] <= LocalDateTimeNextWeek() and [Customer.SalesRep] = CurrentUserName()", " My This Week", "This Weeks Invoices. ", false)]
    [ListViewFilter(" My This Month", "[VerificationDate] >= LocalDateTimeThisMonth() and [VerificationDate]< LocalDateTimeNextMonth() and [Customer.SalesRep] = CurrentUserName()", " My This Month", "Thisd month Invoices. ", false)]
    [ListViewFilter(" My Yesterday's Invoices", "[VerificationDate] >=  LocalDateTimeYesterday() and [VerificationDate] < LocalDateTimeToday() and [Customer.SalesRep] = CurrentUserName()", " My Yesterday and Today", " My Only invoices from yesterday and Today.", true)]
    [ListViewFilter(" My Last Week", "[VerificationDate] >= LocalDateTimeLastWeek() and [VerificationDate] <= LocalDateTimeThisWeek() and [Customer.SalesRep] = CurrentUserName()", " My Last Week", "Last Weeks Invoices. ", false)]
    [ListViewFilter(" My Last Month", "[VerificationDate] >= LocalDateTimeLastMonth() and [VerificationDate] <= LocalDateTimeThisMonth()and [Customer.SalesRep] = CurrentUserName()", " My Last Month ", "My Last month Invoices. ", false)]

    [ListViewFilter(" All ", "")]

    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class CustomerLicenseVerifications : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CustomerLicenseVerifications(Session session)
            : base(session)
        { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            //LicenseExpirationDate = DateTime.Now;
            VerificationDate = DateTime.Now;
            VerifiedBy = SecuritySystem.CurrentUserName;
            LicenseType = 0;
            //LicenseNumber = "";
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        protected override void OnSaved()
        {
            base.OnSaved();

            if (this.LicenseType == CustomerLicenseType.Dea)
            {
                string propertyName = "Oid";

                Customer cust = Session.FindObject<Customer>(new BinaryOperator(propertyName, this.Customer));
                if (cust != null)
                {
                    cust.DeaNo = this.LicenseNumber;
                    cust.DeaExpDate = this.LicenseExpirationDate;
                    cust.DEALastVerifiedBy = SecuritySystem.CurrentUserName;
                    cust.DEALastVerifiedDate = DateTime.Now;
                    cust.Save();
                    Session.CommitTransaction();



                }
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
        //    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
        //    this.PersistentProperty = "Paid";
        //}
        // Fields...
        private CustomerLicenseType _LicenseType;
        private FileData _CustomerDocument;
        private DateTime _VerificationDate;
        private string _VerifiedBy;
        private DateTime _LicenseExpirationDate;
        private Customer _Customer;
        private string _LicenseNumber;
               
        [Size(25)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string LicenseNumber
        {
            get
            {
                return _LicenseNumber;
            }
            set
            {
                SetPropertyValue("LicenseNumber", ref _LicenseNumber, value);
            }
        }


        [RuleRequiredField(DefaultContexts.Save)]
        [Association("Customer-CustomerLicenseVerifications")]
        public Customer Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                SetPropertyValue("Customer", ref _Customer, value);
            }

        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public CustomerLicenseType LicenseType
        {
            get
            {
                return _LicenseType;
            }
            set
            {
                SetPropertyValue("LicenseType", ref _LicenseType, value);
            }
        }

        //[RuleRequiredField(DefaultContexts.Save)]
        [RuleFromBoolProperty( "EventIntervalValid1", DefaultContexts.Save,
            "The Expiration date must be greater than current date", SkipNullOrEmptyValues = false, UsedProperties = "LicenseExpirationDate")]
        public bool IsIntervalValid1 { get { return DateTime.Now <= LicenseExpirationDate; } }
        public DateTime LicenseExpirationDate
        {
            get
            {
                return _LicenseExpirationDate;
            }
            set
            {
                SetPropertyValue("LicenseExpirationDate", ref _LicenseExpirationDate, value);
            }
        }



        [RuleRequiredField(DefaultContexts.Save)]

        public string VerifiedBy
        {
            get
            {
                return _VerifiedBy;
            }
            set
            {

                SetPropertyValue("VerifiedBy", ref _VerifiedBy, value);
            }
        }

        [RuleRequiredField(DefaultContexts.Save)]
        [Indexed]
        public DateTime VerificationDate
        {
            get
            {
                return _VerificationDate;
            }
            set
            {
                SetPropertyValue("VerificationDate", ref _VerificationDate, value);
            }
        }



        [DevExpress.Xpo.Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        [FileTypeFilter("PDFFiles", 1, "*.pdf")]
        [FileTypeFilter("DocumentFiles", 2, "*.DOC")]
        [FileTypeFilter("AllFiles", 3, "*.*")]

        public FileData CustomerDocument
        {
            get { return _CustomerDocument; }
            set { SetPropertyValue("Document", ref _CustomerDocument, value); }
        }


    }
}
