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
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions]
    [NavigationItem("Inventory")]
    [ImageName("RXCategory")]
    [DefaultProperty("Description")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView , false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ItemProductLine : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ItemProductLine(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
           // StandardUnitOfMeasure = 'Each';
            Valuation = ItemValuation.LOT;
            CommissionMethod = eCommissionMethod.None;
            NeedsTransHistory = true;




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
        private ItemUnitOfMeasure _SalesUnitOfMeasure;
        private ItemUnitOfMeasure _PurchaseUnitOfMeasure;
        private ItemUnitOfMeasure _StandardUnitOfMeasure;
             private string _MfgVarianceAdjustmentGlAccount;
        private string _PoVaranceAdjustmentGlAccount;
        private string _PurchasingClearingGlAccount;
        private string _InventoryAdustmentGlAccount;
        private string _SalesReturnGlAccount;
        private string _SalesIncomeGlAccount;
        private string _CostOfGoodsSoldGlAccount;
        private string _InventoryGlAccount;
        private decimal _CommissionRate;
        private eCommissionMethod _CommissionMethod;
        private ItemTypes _ItemType;
        private ItemValuation _Valuation;
        private string _Description;
        private string _ProductLineCode;
        private bool _NeedsTransHistory;
       
        [VisibleInListView(true)]
        [RuleRequiredField]
        [Size(10)]
        public string ProductLineCode
        {
            get
            {
                return _ProductLineCode;
            }
            set
            {
                SetPropertyValue("ProductLineCode", ref _ProductLineCode, value.ToUpper());
            }
        }

        [RuleRequiredField]
        [Size(64)]
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


        [VisibleInListView(false)]
        [RuleRequiredField]
        public ItemTypes ItemType
        {
            get
            {
                return _ItemType;
            }
            set
            {
                SetPropertyValue("ItemType", ref _ItemType, value);
            }
        }

        [VisibleInListView(false)]
        [RuleRequiredField]
        public ItemValuation Valuation
        {
            get
            {
                return _Valuation;
            }
            set
            {
                SetPropertyValue("Valuation", ref _Valuation, value);
            }
        }

        [VisibleInListView(false)]
        [Size (5)]
        [Association("ItemUnitOfMeasure-PlStandardUnitOfMeasure")]
        public ItemUnitOfMeasure StandardUnitOfMeasure
        {
            get
            {
                return _StandardUnitOfMeasure;
            }
            set
            {
                SetPropertyValue("StandardUnitOfMeasure", ref _StandardUnitOfMeasure, value);
            }
        }

        [VisibleInListView(false)]
        [Size(5)]
        [Association("ItemUnitOfMeasure-PlPurchaseUnitOfMeasure")]
        public ItemUnitOfMeasure PurchaseUnitOfMeasure
        {
            get
            {
                return _PurchaseUnitOfMeasure;
            }
            set
            {
                SetPropertyValue("PurchaseUnitOfMeasure", ref _PurchaseUnitOfMeasure, value);
            }
        }

        [VisibleInListView(false)]
        [Size(5)]
        [Association("ItemUnitOfMeasure-PLSalesUnitOfMeasure")]
        public ItemUnitOfMeasure SalesUnitOfMeasure
        {
            get
            {
                return _SalesUnitOfMeasure;
            }
            set
            {
                SetPropertyValue("SalesUnitOfMeasure", ref _SalesUnitOfMeasure, value);
            }
        }



          [VisibleInListView(false)]
        public eCommissionMethod CommissionMethod
        {
            get
            {
                return _CommissionMethod;
            }
            set
            {
                SetPropertyValue("CommissionMethod", ref _CommissionMethod, value);
            }
        }

        [VisibleInListView(false)]
        public decimal CommissionRate
        {
            get
            {
                return _CommissionRate;
            }
            set
            {
                SetPropertyValue("CommissionRate", ref _CommissionRate, value);
            }
        }

        [VisibleInListView(false)]
        [Size(20)]
        [RuleRequiredField]
        public string InventoryGlAccount
        {
            get
            {
                return _InventoryGlAccount;
            }
            set
            {
                SetPropertyValue("InventoryGlAccount", ref _InventoryGlAccount, value);
            }
        }

        [VisibleInListView(false)]
        [RuleRequiredField]
        [Size(20)]
        public string CostOfGoodsSoldGlAccount
        {
            get
            {
                return _CostOfGoodsSoldGlAccount;
            }
            set
            {
                SetPropertyValue("CostOfGoodsSoldGlAccount", ref _CostOfGoodsSoldGlAccount, value);
            }
        }

        [VisibleInListView(false)]
        [RuleRequiredField]
        [Size(20)]
        public string SalesIncomeGlAccount
        {
            get
            {
                return _SalesIncomeGlAccount;
            }
            set
            {
                SetPropertyValue("SalesIncomeGlAccount", ref _SalesIncomeGlAccount, value);
            }
        }

        [VisibleInListView(false)]
        [Size(20)]
        [RuleRequiredField]
        public string SalesReturnGlAccount
        {
            get
            {
                return _SalesReturnGlAccount;
            }
            set
            {
                SetPropertyValue("SalesReturnGlAccount", ref _SalesReturnGlAccount, value);
            }
        }

        [VisibleInListView(false)]
        [RuleRequiredField]
        [Size(20)]
        public string InventoryAdustmentGlAccount
        {
            get
            {
                return _InventoryAdustmentGlAccount;
            }
            set
            {
                SetPropertyValue("InventoryAdustmentGlAccount", ref _InventoryAdustmentGlAccount, value);
            }
        }

        [VisibleInListView(false)]
        [RuleRequiredField]
        [Size(20)]
        public string PurchasingClearingGlAccount
        {
            get
            {
                return _PurchasingClearingGlAccount;
            }
            set
            {
                SetPropertyValue("PurchasingClearingGlAccount", ref _PurchasingClearingGlAccount, value);
            }
        }


        [VisibleInListView(false)]
        [RuleRequiredField]
        [Size(20)]
        public string PoVaranceAdjustmentGlAccount
        {
            get
            {
                return _PoVaranceAdjustmentGlAccount;
            }
            set
            {
                SetPropertyValue("PoVaranceAdjustmentGlAccount", ref _PoVaranceAdjustmentGlAccount, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool NeedsTransHistory
        {
            get
            {
                return _NeedsTransHistory;
            }
            set
            {
                SetPropertyValue("NeedsTransHistory", ref _NeedsTransHistory, value);
            }
        }

        [VisibleInListView(false)]
        [RuleRequiredField]
        [Size(20)]
        public string MfgVarianceAdjustmentGlAccount
        {
            get
            {
                return _MfgVarianceAdjustmentGlAccount;
            }
            set
            {
                SetPropertyValue("MfgVarianceAdjustmentGlAccount", ref _MfgVarianceAdjustmentGlAccount, value);
            }
        }

        [VisibleInListView(false)]
       
        [Association("ItemProductLine-Items")]
        public XPCollection<Items> Item
        {
            get
            {
                return GetCollection<Items>("Item");
            }

        }
        [Association("ItemProductLine-ItemProductLineComm")]
        public XPCollection<ItemProductLineComm> ItemProductLineComm
        {
            get
            {
                return GetCollection<ItemProductLineComm>(nameof(ItemProductLineComm));
            }
        }

        [Association("ItemProductLine-CustomerInvoiceHistoryDetailss")]
        public XPCollection<CustomerInvoiceHistoryDetails> InvoiceLineProductline
        {
            get
            {
                return GetCollection<CustomerInvoiceHistoryDetails>("InvoiceLineProductline");
            }
        }
    }
}
