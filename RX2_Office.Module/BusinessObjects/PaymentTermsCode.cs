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
using System.Drawing;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Sales")]
    
    [ImageName("TermsCode")]
    [DefaultProperty("PaymentTermCode")] 
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class PaymentTermsCode : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public PaymentTermsCode(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            this.DaysBeforeDue = 0;
            this.DiscountPercentage = 0;
            

        }
        // Fields...


        private string _PaymentTermCode;
        private int _DaysBeforeDue;
        private decimal _DiscountPercentage;
        private string _TermCodeDescription;
     
    
        
        [Size(10)]
        [Key]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        public string PaymentTermCode
        {
            get
            {
                return _PaymentTermCode;
            }
            set
            {

                SetPropertyValue("PaymentTermCode", ref _PaymentTermCode, value.ToUpper());
            }
        }
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        public string TermCodeDescription
        {
            get
            {
                return _TermCodeDescription;
            }
            set
            {
                SetPropertyValue("TermCodeDescription", ref _TermCodeDescription, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal DiscountPercentage
        {
            get
            {
                return _DiscountPercentage;
            }
            set
            {
                SetPropertyValue("DiscountPercentage", ref _DiscountPercentage,value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public int DaysBeforeDue
        {
            get
            {
                return _DaysBeforeDue;
            }
            set
            {
                SetPropertyValue("DaysBeforeDue", ref _DaysBeforeDue, value);
            }
        }

        [Association("PaymentTermsCode-Vendor")]
        public XPCollection<Vendor> Vendor
        {
            get
            {
                return GetCollection<Vendor>("Vendor");
            }
        }

        [Association("PaymentTermsCode-PurchaseOrder")]
        public XPCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder> PurchaseOrder
        {
            get
            {
                return GetCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder>("PurchaseOrder");
            }
        }
    }
}
