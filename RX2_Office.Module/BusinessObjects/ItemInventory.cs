using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Inventory")]
    [ImageName("Inventory")]
    [ListViewAutoFilterRowAttribute(true)]
    [ListViewFilter(" Current Inventory", "[QtyOnHand] <> 0", "Current Inventory", "All Items In Inventory", true)]
    [ListViewFilter(" Current 17856 Inventory", "[QtyOnHand] <> 0 and [ItemNumber] like '17856%' ", "Current 17856 Inventory", "All Items In Inventory", true)]

    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]

    public class ItemInventory : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

        public ItemInventory(Session session)
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

       
        private ItemReceiver _ReceiverId;
        [Indexed("ItemLot")]
        private DistributionCenterWhseBins _Bin;
        private DistributionCenterWhse _Warehouse;
        private Items _ItemNumber;
        private DateTime _ReceivedDate;
        private double _UnitCost;
        private double _QtyReceived;
        private double _QtyOnHand;
        private DateTime _ExpirtationDate;
        private string _ItemLot;

        [RuleRequiredField]
        [Association("Items-ItemInventorys")]
        public Items ItemNumber
        {
            get
            {
                return _ItemNumber;
            }
            set
            {
                SetPropertyValue("Itemnumber", ref _ItemNumber, value);
            }
        }


        [VisibleInListView(false)]
        [Association("ItemReceiver-ItemInventory")]
        public ItemReceiver ReceiverId
        {
            get
            {
                return _ReceiverId;
            }
            set
            {
                SetPropertyValue("ReceiverId", ref _ReceiverId, value);
            }
        }


        [RuleRequiredField]
        [Association("DistributionCenterWhse-ItemInventorys")]
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
        [RuleRequiredField]
        [Size(25)]
        public string ItemLot
        {
            get
            {
                return _ItemLot;
            }
            set
            {
                SetPropertyValue("ItemLot", ref _ItemLot, value);
            }
        }


        [VisibleInListView(false)]
        [Association("DistributionCenterWhseBins-ItemInventorys")]
        public DistributionCenterWhseBins Bin
        {
            get
            {
                return _Bin;
            }
            set
            {
                SetPropertyValue("Bin", ref _Bin, value);
            }
        }


        public DateTime ExpirtationDate
        {
            get
            {
                return _ExpirtationDate;
            }
            set
            {
                SetPropertyValue("ExpirtationDate", ref _ExpirtationDate, value);
            }
        }


        [RuleRequiredField]
        public double QtyOnHand
        {
            get
            {
                return _QtyOnHand;
            }
            set
            {
                SetPropertyValue("QtyOnHand", ref _QtyOnHand, value);
            }
        }


        [VisibleInListView(false)]
        public double QtyReceived
        {
            get
            {
                return _QtyReceived;
            }
            set
            {
                SetPropertyValue("QtyReceived", ref _QtyReceived, value);
            }
        }

        public double UnitCost
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
        public DateTime ReceivedDate
        {
            get
            {
                return _ReceivedDate;
            }
            set
            {
                SetPropertyValue("ReceivedDate", ref _ReceivedDate, value);
            }
        }


        public decimal ItemEvaluation
        {
            get
            {
                return (decimal)(_UnitCost) * (decimal)(_QtyOnHand);
            }

        }
        decimal qtySold;
        public decimal QtySold
        {
            get
            {
                return qtySold;
            }
            set
            {
                SetPropertyValue(nameof(QtySold), ref qtySold, value);
            }
        }
        decimal qtyQuarantined;
        public decimal QtyQuarantined
        {
            get
            {
                return qtyQuarantined;
            }
            set
            {
                SetPropertyValue(nameof(QtyQuarantined), ref qtyQuarantined, value);
            }
        }

        [Association("ItemInventory-WorkOrders")]
        public XPCollection<WorkOrders> WorkOrders
        {
            get
            {
                return GetCollection<WorkOrders>("WorkOrders");
            }
        }

        [Association("ItemInventory-SODetails")]
        public XPCollection<SODetails> SODetails
        {
            get
            {
                return GetCollection<SODetails>(nameof(SODetails));
            }
        }

        [Association("ItemInventory-ItemTransactions")]
        public XPCollection<ItemTransaction> ItemTransactions
        {
            get
            {
                return GetCollection<ItemTransaction>(nameof(ItemTransactions));
            }
        }

        [Association("ItemInventory-ItemInventorySerialNos")]
        public XPCollection<ItemInventorySerialNo> ItemInventorySerialNos
        {
            get
            {
                return GetCollection<ItemInventorySerialNo>(nameof(ItemInventorySerialNos));
            }
        }

        [Association("ItemInventory-SOItemDistribution")]
        public XPCollection<SOItemDistibution> SOItemDistribution
        {
            get
            {
                return GetCollection<SOItemDistibution>("SOItemDistribution");
            }
        }


    }
}
