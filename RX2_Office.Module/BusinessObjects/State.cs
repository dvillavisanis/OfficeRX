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
    [ImageName("States")]
    [NavigationItem("Options")]
    
    [DefaultProperty("StateCode")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None ) ]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class  State : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public State(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        bool isVAWD;
        bool requiresStateControlLicenseToShipInto;
        bool requiresStateLicenseToShipInto;
        private string _StateCode;
        private string _StateName;

        // Fields...
        // Fields...

        [Key]
        [Size(2)]
        [VisibleInListView(true)]
        public string StateCode
        {

            get
            {
                return _StateCode;
            }
            set
            {
                SetPropertyValue("StateCode", ref _StateCode, value.ToUpper());
            }
        }

        public string StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                SetPropertyValue("StateName", ref _StateName, value);
            }
        }

        public bool RequiresStateLicenseToShipInto
        {
            get => requiresStateLicenseToShipInto;
            set => SetPropertyValue(nameof(RequiresStateLicenseToShipInto), ref requiresStateLicenseToShipInto, value);
        }

        public bool RequiresStateControlLicenseToShipInto
        {
            get => requiresStateControlLicenseToShipInto;
            set => SetPropertyValue(nameof(RequiresStateControlLicenseToShipInto), ref requiresStateControlLicenseToShipInto, value);
        }
        

        public bool IsVAWD
        {
            get => isVAWD;
            set => SetPropertyValue(nameof(IsVAWD), ref isVAWD, value);
        }


        [Association("State-CustomersBill")]
        public XPCollection<Customer> Customers
        {
            get
            {
                return GetCollection<Customer>("Customers");
            }
        }

        [Association("State-CustomersShip")]
        public XPCollection<Customer> Customershipstate

        {
            get
            {
                return GetCollection<Customer>("Customershipstate");
            }
        }
        [Association("State-CustomerContacts")]
        public XPCollection<CustomerContact> CustomerContacts
        {
            get
            {
                return GetCollection<CustomerContact>("CustomerContacts");
            }
        }
        [Association("State-CustomerGPOs")]
        public XPCollection<CustomerGPO> CustomerGPOs
        {
            get
            {
                return GetCollection<CustomerGPO>("CustomerGPOs");
            }
        }
        [Association("State-DistributionCenter")]
        public XPCollection<DistributionCenter> DCState
        {
            get
            {
                return GetCollection<DistributionCenter>("DCState");
            }
        }
        
        
        [Association("State-PurchaseOrderShipState")]
        public XPCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder> PurchaseOrderShipState
        {
            get
            {
                return GetCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder>("PurchaseOrderShipState");
            }
        }
       
        [Association("State-PurchaseOrderVendorState")]
        public XPCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder> PurchaseOrderVendorState
        {
            get
            {
                return GetCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder>("PurchaseOrderVendorState");
            }
        }
        [Association("State-Manufacturers")]
        public XPCollection<Manufacturer> Manufacturers
        {
            get
            {
                return GetCollection<Manufacturer>("Manufacturers");
            }
        }
       
        [Association("State-Vendor")]
        public XPCollection<Vendor> VendorState
        {
            get
            {
                return GetCollection<Vendor>("VendorState");
            }
        }
        [Association("State-VendorContact")]
        public XPCollection<VendorContact> VendorContactState
        {
            get
            {
                return GetCollection<VendorContact>("VendorContactState");
            }
        }
        [Association("State-SOBillToState")]
        public XPCollection<SOHeader> SOBillToState
        {
            get
            {
                return GetCollection<SOHeader>("SOBillToState");
            }
        }
        [Association("State-SOShipToState")]
        public XPCollection<SOHeader> SOShipToState
        {
            get
            {
                return GetCollection<SOHeader>("SOShipToState");
            }
        }
        [Association("State-RepackPackagers")]
        public XPCollection<RepackPackager> PackagerState
        {
            get
            {
                return GetCollection<RepackPackager>("PackagerState");
            }
        }
        [Association("State-DistributionCenterLicenses")]
        public XPCollection<DistributionCenterLicenses> DistributionCenterLicense
        {
            get
            {
                return GetCollection<DistributionCenterLicenses>("DistributionCenterLicense");
            }
        }

        [Association("State-RepackDistributors")]
        public XPCollection<RepackDistributor> RepackDistributors
        {
            get
            {
                return GetCollection<RepackDistributor>(nameof(RepackDistributors));
            }
        }

    }
}
