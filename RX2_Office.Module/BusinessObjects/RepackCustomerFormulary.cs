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
    [NavigationItem("Repack")]

    [DefaultClassOptions]
    [XafDisplayName("Customer's Formularies")]
    [ImageName("setup1")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class RepackCustomerFormulary : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackCustomerFormulary(Session session)
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
        private bool _IsActive;
        private bool _IsNarcotic;
        private int _DeaNo;
       private string _Note;
       private string _PackageSize;
        private string _Strength;
        private string _MgfBy;
        private string _GenericName;
        private static string _TradeName;
        private string _UPC;
        private string _Barcode;
        private string _NDC;
        private static decimal _RetentionQty;
        private decimal _PackageQty;
        private decimal _UnitQty;
        private static DateTime _CreatedDate;
        private string _Description;
        private Customer _CustomerId;
        private Items _OrignalNDC;
        private decimal _FormularyKey;

        [Key]
        public decimal FormularyKey
        {
            get
            {
                return _FormularyKey;
            }
            set
            {
                SetPropertyValue("FormularyKey", ref _FormularyKey, value);
            }
        }

        [Association("Items-RepackCustomerFormularysOrignalNDC")]
        public Items OrignalNDC
        {
            get
            {
                return _OrignalNDC;
            }
            set
            {
                SetPropertyValue("OrignalNDC", ref _OrignalNDC, value);
            }
        }


        [Association("Customer-repackFormularyCustomer")]
        public Customer CustomerId
        {
            get
            {
                return _CustomerId;
            }
            set
            {
                SetPropertyValue("CustomerId", ref _CustomerId, value);
            }
        }


        [Size(128)]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                SetPropertyValue("Description", ref _Description, value);
            }
        }


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
         [VisibleInListView(false)]
        public decimal UnitQty
        {
            get
            {
                return _UnitQty;
            }
            set
            {
                SetPropertyValue("UnitQty", ref _UnitQty, value);
            }
        }
         [VisibleInListView(false)]
        public decimal PackageQty
        {
            get
            {
                return _PackageQty;
            }
            set
            {
                SetPropertyValue("PackageQty", ref _PackageQty, value);
            }
        }

         [VisibleInListView(false)]
        public decimal retentionQty
        {
            get
            {
                return _RetentionQty;
            }
            set
            {
                SetPropertyValue("retentionQty", ref _RetentionQty, value);
            }
        }
        [VisibleInListView(false)]
        [Size(25)]
        public string NDC
        {
            get
            {
                return _NDC;
            }
            set
            {
                SetPropertyValue("NDC", ref _NDC, value);
            }
        }
         [VisibleInListView(false)]
        [Size(25    )]
        public string Barcode
        {
            get
            {
                return _Barcode;
            }
            set
            {
                SetPropertyValue("Barcode", ref _Barcode, value);
            }
        }
         [VisibleInListView(false)]
        [Size(25)]
        public string UPC
        {
            get
            {
                return _UPC;
            }
            set
            {
                SetPropertyValue("UPC", ref _UPC, value);
            }
        }

        [Size(128   )]
        public string TradeName
        {
            get
            {
                return _TradeName;
            }
            set
            {
                SetPropertyValue("TradeName", ref _TradeName, value);
            }
        }
         [VisibleInListView(false)]
        [Size(128   )]
        public string GenericName
        {
            get
            {
                return _GenericName;
            }
            set
            {
                SetPropertyValue("GenericName", ref _GenericName, value);
            }
        }
         [VisibleInListView(false)]
        [Size(64)]
        public string MgfBy
        {
            get
            {
                return _MgfBy;
            }
            set
            {
                SetPropertyValue("MgfBy", ref _MgfBy, value);
            }
        }
         [VisibleInListView(false)]
        [Size(25)]
        public string Strength
        {
            get
            {
                return _Strength;
            }
            set
            {
                SetPropertyValue("Strength", ref _Strength, value);
            }
        }
         [VisibleInListView(false)]
        [Size(25)]
        public string PackageSize
        {
            get
            {
                return _PackageSize;
            }
            set
            {
                SetPropertyValue("PackageSize", ref _PackageSize, value);
            }
        }

         [VisibleInListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                SetPropertyValue("Note", ref _Note, value);
            }
        }

         [VisibleInListView(false)]
        public int DeaNo
        {
            get
            {
                return _DeaNo;
            }
            set
            {
                SetPropertyValue("DeaNo", ref _DeaNo, value);
            }
        }
         [VisibleInListView(false)]
        public bool IsNarcotic
        {
            get
            {
                return _IsNarcotic;
            }
            set
            {
                SetPropertyValue("IsNarcotic", ref _IsNarcotic, value);
            }
        }
         [VisibleInListView(false)]
        public bool isActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetPropertyValue("isActive", ref _IsActive, value);
            }
        }

    }
}

