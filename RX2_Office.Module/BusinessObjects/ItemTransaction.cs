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
    [DefaultClassOptions]
    [NavigationItem("Inventory")]

    [ImageName("Transactions")]
    [ListViewFilter("Today's Transactions ", "[TransactionDate] = LocalDateTimeToday()  ", "Today's Transactions  ", "Today's Transactions ", true)]
    [ListViewFilter("Yesterday's Transactions ", "[TransactionDate] >= LocalDateTimeYesterday() and [TransactionDate] < LocalDateTimeToday()  ", "Yesterday's Transactions ", "Yesterday's Transactions ", false)]
    [ListViewFilter("Last 30 Days", "[TransactionDate] >= ADDDAYS(LocalDateTimeToday(), -30)  ", "Last 30 Days ", "Last 30 Days ", false)]
    [ListViewFilter("Last 365 Days", "[TransactionDate] >= ADDDAYS(LocalDateTimeToday(), -365)  ", "Last 365 Days ", "Last 365 Days ", false)]

    [ListViewFilter("ALL", "")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ItemTransaction : BaseObject ,INotifyPropertyChanged
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ItemTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
       
        // Fields...
        private bool _IsDropShip;
        private System.Guid _RefOid;
        private DistributionCenterWhse _Warehouse;
        private Customer _Customer;
        private Vendor _Vendor;
        private decimal _UnitPrice;
        private decimal _UnitCost;
        private int _Qty;
        private string _Lot;
        private Items _ItemNumber;
        private DateTime _TransactionDate;
        private InventoryTransactionTypes _TransactionType;

        [Size(3)]
        [VisibleInListView(true)]
        public InventoryTransactionTypes TransactionType
        {
            get
            {
                return _TransactionType;
            }
            set
            {
                SetPropertyValue("TransactionType", ref _TransactionType, value);
            }
        }
           [VisibleInListView(true)]
        public DateTime TransactionDate
        {
            get
            {
                return _TransactionDate;
            }
            set
            {
                SetPropertyValue("TransactionDate", ref _TransactionDate, value);
            }
        }

           [VisibleInListView(true)]
        [Association("Items-Transactions")]
        public Items ItemNumber
        {
            get
            {
                return _ItemNumber;
            }
            set
            {
                SetPropertyValue("ItemNumber", ref _ItemNumber, value);
            }
        }

           [VisibleInListView(true)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Lot
        {
            get
            {
                return _Lot;
            }
            set
            {
                SetPropertyValue("Lot", ref _Lot, value);
            }
        }


           [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public System.Guid RefOid
        {
            get
            {
                return _RefOid;
            }
            set
            {
                SetPropertyValue("RefOid", ref _RefOid, value);
            }
        }
        


           [VisibleInListView(true)]
        [Association("DistributionCenterWhse-ItemTransaction")]
        public DistributionCenterWhse Warehouse
        {
            get
            {
                return _Warehouse;
            }
            set
            {
                SetPropertyValue("Warehouse", ref _Warehouse, value);
            }
        }


        [VisibleInListView(false)]
           public bool IsDropShip
           {
               get
               {
                   return _IsDropShip;
               }
               set
               {
                   SetPropertyValue("IsDropShip", ref _IsDropShip, value);
               }
           }
           [VisibleInListView(true)]
        public int Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                SetPropertyValue("Qty", ref _Qty, value);
            }
        }

           [VisibleInListView(true)]
        public decimal UnitCost
        {
            get
            {
                return _UnitCost;
            }
            set
            {
                SetPropertyValue("UnitCost", ref _UnitCost, value);
            }
        }

           [VisibleInListView(true)]
        public decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                SetPropertyValue("UnitPrice", ref _UnitPrice, value);
            }
        }


        DateTime acctProcessDt;
        public DateTime AcctProcessDt
        {
            get
            {
                return acctProcessDt;
            }
            set
            {
                SetPropertyValue("AcctProcessDt", ref acctProcessDt, value);
            }
        }


        [VisibleInListView(false)]
        [Association("Vendor-ItemTransactions")]
        public Vendor Vendor
        {
            get
            {
                return _Vendor;
            }
            set
            {
                SetPropertyValue("Vendor", ref _Vendor, value);
            }
        }
        ItemInventory inventoryOID;
        [Association("ItemInventory-ItemTransactions")]
        public ItemInventory InventoryOID
        {
            get
            {
                return inventoryOID;
            }
            set
            {
                SetPropertyValue(nameof(InventoryOID), ref inventoryOID, value);
            }
        }


        [VisibleInListView(false)]
        [Association("Customer-ItemTransaction")]
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
    }
}
