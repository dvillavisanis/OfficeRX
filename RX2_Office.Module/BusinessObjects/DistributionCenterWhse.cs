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
    [ImageName("RXwhse")]
    [NavigationItem("Inventory")]
    [DefaultProperty("Whsecode")]
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class DistributionCenterWhse : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DistributionCenterWhse(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
     
        // Fields
       
     //   private ItemPurchaseOrder _ItemPurchaseOrder;
     
        private DistributionCenter _DistributionCenter;
        private bool _Partial;
        private bool _Retail;
        private string _Name;
        private string _WhseCode;

        [Key]
        [Size(3)]
        [VisibleInListView(true)]
        public string WhseCode
        {

            get
            {
                return _WhseCode;
            }
            set
            {
                SetPropertyValue("WhseCode", ref _WhseCode, value);
            }
        }


        [Association("DistributionCenter-Whses")]

        public DistributionCenter DistributionCenter
        {
            get
            {
                return _DistributionCenter;
            }
            set
            {
                SetPropertyValue("DistributionCenter", ref _DistributionCenter, value);
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }
        [VisibleInListView(false)]
        [ToolTip("Warehouse that is available for sales")]
        public bool Retail
        {
            get
            {
                return _Retail;
            }
            set
            {
                SetPropertyValue("Retail", ref _Retail, value);
            }
        }

        [VisibleInListView(false)]
        [ToolTip("Warehouse that Contains Partial Units")]
        public bool Partial
        {
            get
            {
                return _Partial;
            }
            set
            {
                SetPropertyValue("Partial", ref _Partial, value);
            }
        }


        [Association("DistributionCenterWhse-ItemInventorys")]
        public XPCollection<ItemInventory> Inventory
        {
            get
            {
                return GetCollection<ItemInventory>("Inventory");
            }
        }
       
        [Association("DistributionCenterWhse-ItemTransaction")]
        public XPCollection<ItemTransaction> ItemTransaction
        {
            get
            {
                return GetCollection<ItemTransaction>("ItemTransaction");
            }
        }
        [Association("DistributionCenterWhse-WorkOrdersOrigWhse")]
        public XPCollection<WorkOrders> WoOriginalWhse
        {
            get
            {
                return GetCollection<WorkOrders>("WoOriginalWhse");
            }
        }

        [Association(" DistributionCenterWhse-CustomerInvoiceHistorys")]
        public XPCollection<CustomerInvoiceHistory> InvoiceHistory
        {
            get
            {
                return GetCollection<CustomerInvoiceHistory>("InvoiceHistory");
            }
        }

        [Association("DistributionCenterWhse-ItemWarehouses")]
        public XPCollection<ItemWarehouse> ItemWarehouse
        {
            get
            {
                return GetCollection<ItemWarehouse>(nameof(ItemWarehouse));
            }
        }

        [Association("DistributionCenterWhse-WorkOrdersFinishProductWhse")]
        public XPCollection<WorkOrders> FinishProductWhse
        {
            get
            {
                return GetCollection<WorkOrders>("FinishProductWhse");
            }
        }

        [Association("DistributionCenterWhse-CustomerInvoiceHistoryDetailss")]
        public XPCollection<CustomerInvoiceHistoryDetails> Invoiceitemwhse
        {
            get
            {
                return GetCollection<CustomerInvoiceHistoryDetails>("Invoiceitemwhse");
            }
        }

        [Association("DistributionCenterWhse-ItemPurchaseOrders")]
        public XPCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder> ItemPurchaseOrder
        {
            get
            {
                return GetCollection<RX2_Office.Module.BusinessObjects.ItemPurchaseOrder>("ItemPurchaseOrder");
            }
        }

        
        [Association("DistributionCenterWhse-DistributionCenterWhseBins")]
        public XPCollection<DistributionCenterWhseBins> Bins
        {
            get
            {
                return GetCollection<DistributionCenterWhseBins>("Bins");
            }
        }

        [Association("DistributionCenterWhse-ItemReceiver")]
        public XPCollection<ItemReceiver> ItemReceiver
        {
            get
            {
                return GetCollection<ItemReceiver>("ItemReceiver");
            }
        }



        [Association("DistributionCenterWhse-ShippersdefaultWhse")]
        public XPCollection<Shippers> ShippersDefaultWhse
        {
            get
            {
                return GetCollection<Shippers>("ShippersDefaultWhse");
            }
        }

        [Association("DistributionCenterWhse-SOHeaders")]
        public XPCollection<SOHeader> SOHeader
        {
            get
            {
                return GetCollection<SOHeader>("SOHeader");
            }
        }

        [Association("DistributionCenterWhse-DistributionCenters")]
        public XPCollection<DistributionCenter> defaultPowhse
           
        {
            get
            {
                return GetCollection<DistributionCenter>(nameof(defaultPowhse));
            }
        }
        [Association("DistributionCenterWhse-ItemInventoryBatchs")]
        public XPCollection<ItemInventoryBatch> ItemInventoryBatchs
        {
            get
            {
                return GetCollection<ItemInventoryBatch>(nameof(ItemInventoryBatchs));
            }
        }

        [Association("DistributionCenterWhse-ApplicationOptions")]
        public XPCollection<ApplicationOptions> ApplicationOptions
        {
            get
            {
                return GetCollection<ApplicationOptions>(nameof(ApplicationOptions));
            }
        }
    }


}
