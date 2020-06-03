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

namespace RX2_Office.Module.BusinessObjects
{
    [NavigationItem("Purchasing")]
    [DefaultClassOptions]
    [DefaultProperty("VendorTypeDesc")]
    public class VendorType : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public VendorType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
    
       private string _VendorTypeDesc;
        private string _VendorTypeCode;

        [Key]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        public string VendorTypeCode
        {
            get
            {
                return _VendorTypeCode;
            }
            set
            {
                SetPropertyValue("VendorTypeCode", ref _VendorTypeCode, value);
            }
        }

        public string VendorTypeDesc
        {
            get
            {
                return _VendorTypeDesc;
            }
            set
            {
                SetPropertyValue("VendorTypeDesc", ref _VendorTypeDesc, value);
            }
        }


        [Association("VendorType-Vendor")]
        public XPCollection<Vendor> Vendor
        {
            get
            {
                return GetCollection<Vendor>("Vendor");
            }
        }

    }
}
