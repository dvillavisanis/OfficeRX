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
   
[NavigationItem ("Repack")]
    [ImageName("setup1")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class RepackPackager :XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackPackager(Session session)
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

        // Fields...
        string siteId;
       // string zip;
        private DateTime _StateLicExpDate;
        private DateTime _RepackLicExpDate;
        private DateTime _DeaExpDate;
        private string _AccountingVendorId;
        private string _OldPackagerid;
        private string _RepackNotificationEmail;
        private string _RepackLicense;
        private string _DeaLicense;
        private string _StateLicense;
        private State _State;
        private string _Zip;
        private string _City;
        private string _Address2;
        private string _Address1;
        private string _HoldingWhse;
        private string _PackagerName;

        [Size(128)]
        public string PackagerName
        {
            get
            {
                return _PackagerName;
            }
            set
            {
                SetPropertyValue("PackagerName", ref _PackagerName, value);
            }
        }

        [Size(5)]
        public string HoldingWhse
        {
            get
            {
                return _HoldingWhse;
            }
            set
            {
                SetPropertyValue("HoldingWhse", ref _HoldingWhse, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(128)]
        public string address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                SetPropertyValue("address1", ref _Address1, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(128)]
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
        [Size(64)]
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
        [Association("State-RepackPackagers")]
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
        [Size(10)]
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
        [NonPersistent]
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CityStateZip
        {
            get => City + ", " + State.StateCode + " " + Zip;
            //  set => SetPropertyValue(nameof(Zip), ref zip, value);
        }

        [Size(15)]
        public string StateLicense
        {
            get
            {
                return _StateLicense;
            }
            set
            {
                SetPropertyValue("StateLicense", ref _StateLicense, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime StateLicExpDate
        {
            get
            {
                return _StateLicExpDate;
            }
            set
            {
                SetPropertyValue("StateLicExpDate", ref _StateLicExpDate, value);
            }
        }


        [Size(15)]
        public string DeaLicense
        {
            get
            {
                return _DeaLicense;
            }
            set
            {
                SetPropertyValue("DeaLicense", ref _DeaLicense, value);
            }
        }

        public DateTime DeaExpDate
        {
            get
            {
                return _DeaExpDate;
            }
            set
            {
                SetPropertyValue("DeaExpirationDate", ref _DeaExpDate, value);
            }
        }

        [VisibleInListView(false)]
        [Size(15)]
        public string RepackLicense
        {
            get
            {
                return _RepackLicense;
            }
            set
            {
                SetPropertyValue("RepackLicense", ref _RepackLicense, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime RepackLicExpDate
        {
            get
            {
                return _RepackLicExpDate;
            }
            set
            {
                SetPropertyValue("RepackLicExpDate", ref _RepackLicExpDate, value);
            }
        }




        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(128)]
        public string RepackNotificationEmail
        {
            get
            {
                return _RepackNotificationEmail;
            }
            set
            {
                SetPropertyValue("RepackNotificationEmail", ref _RepackNotificationEmail, value);
            }
        }


        [Size(25)]
        public string AccountingVendorId
        {
            get
            {
                return _AccountingVendorId;
            }
            set
            {
                SetPropertyValue("AccountingVendorId", ref _AccountingVendorId, value);
            }
        }

        [VisibleInListView(false)]
        [Size(100)]
        public string SiteId
        {
            get => siteId;
            set => SetPropertyValue(nameof(SiteId), ref siteId, value);
        }

        [VisibleInListView(false)]
        [Size(10)]
        public string OldPackagerid
        {
            get
            {
                return _OldPackagerid;
            }
            set
            {
                SetPropertyValue("OldPackagerid", ref _OldPackagerid, value);
            }
        }

        [Association("RepackPackager-RepackLots")]
        public XPCollection<RepackLots> RepackLots
        {
            get
            {
                return GetCollection<RepackLots>(nameof(RepackLots));
            }
        }

        [Association("RepackPackager-RepackItems")]
        public XPCollection<RepackItems> RepackItems
        {
            get
            {
                return GetCollection<RepackItems>("RepackItems");
            }
        }


        [Association("RepackPackager-WorkOrders")]
        public XPCollection<WorkOrders> Workorders
        {
            get
            {
                return GetCollection<WorkOrders>("Workorders");
            }
        }

       
    }
}
