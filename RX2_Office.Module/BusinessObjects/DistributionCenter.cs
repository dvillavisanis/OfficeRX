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
    [NavigationItem("Inventory")]
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions]
    [ImageName("DistributionCenter")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
        //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class DistributionCenter :XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DistributionCenter(Session session)
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
       // private DistributionCenterWhse _DistributionCenterWhses;
       
        private bool _IsDefault;
        private string _OldFacilityId;
        private State _State;
         private DateTime _StateExpirationDt;
        private DateTime _DEAExpirationDt;
        private string _Fax;
        private string _Phone;
        private string _StateLicense;
        private string _DeaLicense;
        private string _ZipCode;
        private string _City;
        private string _Address3;
        private string _Address2;
        private string _Address;
        private string _DCName;

        public string DCName
        {
            get
            {
                return _DCName;
            }
            set
            {
                SetPropertyValue("DCName", ref _DCName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool IsDefault
        {
            get
            {
                return _IsDefault;
            }
            set
            {
                SetPropertyValue("IsDefault", ref _IsDefault, value);
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

        [Association("State-DistributionCenter")]
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

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime DEAExpirationDt
        {
            get
            {
                return _DEAExpirationDt;
            }
            set
            {
                SetPropertyValue("DEAExpirationDt", ref _DEAExpirationDt, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
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
        [VisibleInLookupListView(false)]
        public DateTime StateExpirationDt
        {
            get
            {
                return _StateExpirationDt;
            }
            set
            {
                SetPropertyValue("StateExpirationDt", ref _StateExpirationDt, value);
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
        [Size(3)]
        public string OldFacilityId
        {
            get
            {
                return _OldFacilityId;
            }
           set
           {
               SetPropertyValue("OldFacilityId", ref _OldFacilityId, value);
           }
        }

        DistributionCenterWhse defaultPOWhse;
        [Association("DistributionCenterWhse-DistributionCenters")]
        public DistributionCenterWhse DefaultPOWhse
        {
            get => defaultPOWhse;
            set => SetPropertyValue(nameof(DefaultPOWhse), ref defaultPOWhse, value);
        }



        public string DcCityStateZip
        {
            get
            {
                return String.Format("{0},{1} {2}",City,State.StateCode,ZipCode) ;
            }
           
        }


        [Association("DistributionCenter-Whses")]
        public XPCollection<DistributionCenterWhse> Warehouse
        {
            get
            {
                return GetCollection<DistributionCenterWhse>("Warehouse");
            }
        }
        [Association("DistributionCenter-PurchaseOrders")]
        public XPCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder> PurchaseOrders
        {
            get
            {
                return GetCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder>("PurchaseOrders");
            }
        }
        [Association("DistributionCenter-DistributionCenterLicenses")]
        public XPCollection<DistributionCenterLicenses> DistributionCenterLicenses
        {
            get
            {
                return GetCollection<DistributionCenterLicenses>("DistributionCenterLicenses");
            }
        }



        [Association("DistributionCenter-Shippers")]
        public XPCollection<Shippers> Shippers
        {
            get
            {
                return GetCollection<Shippers>("Shippers");
            }
        }
        [Association("DistributionCenter-ItemReceiver")]
        public XPCollection<ItemReceiver> ItemReceiver
        {
            get
            {
                return GetCollection<ItemReceiver>("ItemReceiver");
            }
        }
      
        [Association("DistributionCenter-ItemT3HeaderTemplate")]
        public XPCollection<ItemT3HeaderTemplate> ItemT3HeaderTemplate
        {
            get
            {
                return GetCollection<ItemT3HeaderTemplate>("ItemT3HeaderTemplate");
            }
        }

        
    }

}
