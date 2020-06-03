using System;
using System.Linq;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using System.Collections.Generic;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Inventory")]
    
    [ImageName("UnitOfMeasure")]
    [DefaultProperty("Description")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ItemUnitOfMeasure : XPBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ItemUnitOfMeasure(Session session)
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
        private string _Description;
              private string _UnitOfMeasureCode;
        [Key]
        [Size(5)]
        public string UnitOfMeasureCode
        {
            get
            {
                return _UnitOfMeasureCode;
            }
            set
            {
                SetPropertyValue("UnitOfMeasureCode", ref _UnitOfMeasureCode, value);
            }
        }

        [Size(20)]
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
        [Association("ItemUnitOfMeasure-PlStandardUnitOfMeasure")]
        public XPCollection<ItemProductLine> PlStandardUnitOfMeasure
        {
            get
            {
                return GetCollection<ItemProductLine>("PlStandardUnitOfMeasure");
            }
        }
        [Association("ItemUnitOfMeasure-PlPurchaseUnitOfMeasure")]
        public XPCollection<ItemProductLine> PurchaseUnitOfMeasure
        {
            get
            {
                return GetCollection<ItemProductLine>("PurchaseUnitOfMeasure");
            }
        }

        [Association("ItemUnitOfMeasure-PLSalesUnitOfMeasure")]
        public XPCollection<ItemProductLine> SalesUnitOfMeasure
        {
            get
            {
                return GetCollection<ItemProductLine>("SalesUnitOfMeasure");
            }
        }


        [Association("ItemUnitOfMeasure-ItemStandardUnitOfMeasure")]
        public XPCollection<Items> ItemStandardUnitOfMeasure
        {
            get
            {
                return GetCollection<Items>("ItemStandardUnitOfMeasure");
            }
        }

        [Association("ItemUnitOfMeasure-ItemPurchaseUnitOfMeasure")]
        public XPCollection<Items> ItemPurchaseUnitOfMeasure
        {
            get
            {
                return GetCollection<Items>("ItemPurchaseUnitOfMeasure");
            }
        }


        [Association("ItemUnitOfMeasure-ItemSalesUnitOfMeasure")]
        public XPCollection<Items> ItemSalesUnitOfMeasure
        {
            get
            {
                return GetCollection<Items>("ItemSalesUnitOfMeasure");
            }
        }
        [Association("ItemUnitOfMeasure-ItemPurchaseOrderLines")]
        public XPCollection<ItemPurchaseOrderLine> ItemsPOunitofmeasure
        {
            get
            {
                return GetCollection<ItemPurchaseOrderLine>("ItemsPOunitofmeasure");
            }
        }
        [Association("ItemUnitOfMeasure-CustomerInvoiceHistoryDetailss")]
        public XPCollection<CustomerInvoiceHistoryDetails> Invoiceitemsunitofmeasure
        {
            get
            {
                return GetCollection<CustomerInvoiceHistoryDetails>("Invoiceitemsunitofmeasure");
            }
        }
        [Association("ItemUnitOfMeasure-SODetails")]
        public XPCollection<SODetails> SODetail
        {
            get
            {
                return GetCollection<SODetails>("SODetail");
            }
        }
    }
}

