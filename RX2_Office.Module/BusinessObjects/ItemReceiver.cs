using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections;
using System.ComponentModel;


namespace RX2_Office.Module.BusinessObjects
{

    [ListViewAutoFilterRowAttribute(true)]
    [ListViewFilter("All", "", "All Receivers ", "All", false)]
    [ListViewFilter("Today Receivers", "[ReceiverDate] = LocalDateTimeToday() ", "Today Receivers ", "Today's Receivers", false)]
    [ListViewFilter("Items to be Put Away ", "[ReceiverStatus] = 10 ", "Items to be putway ", "Items are not saleable until the items are putaway", true)]
    [ListViewFilter("Items Awaiting Documents ", "[ReceiverStatus] = 5 ", "Items Awaiting Documents ", "Items That need Invoices or Pedigrees", true)]
    [Appearance("VendorInvoice", AppearanceItemType = "ViewItem", TargetItems = "VendorInvoice, VendorInvoiceDueDate",
    Criteria = "VendorInvoice == null ", Context = "ListView", BackColor = "Yellow", Priority = 1)]
    [Appearance("LotExpiration", AppearanceItemType = "ViewItem", TargetItems = "LotExpiration",
    Criteria = "LotExpiration <= ADDDAYS(LocalDateTimeToday(), + 30) ", Context = "ListView", BackColor = "Orange", Priority = 1)]
    [DefaultClassOptions]
    [ImageName("Receiver")]
    [NavigationItem("Shipping")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).

    public class ItemReceiver : BaseObject, INotifyPropertyChanged
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ItemReceiver(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).

            this.ReceiverDate = DateTime.Today;
            this.User = SecuritySystem.CurrentUserName;
            this.LotExpiration = DateTime.Today;
            this.ReceiverStatus = ItemReceiverStatus.CheckIn;
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            if (propertyName == "ItemPurchaseOrder")
            {
                ItemPurchaseOrder itemPO = Session.FindObject<ItemPurchaseOrder>(new BinaryOperator(propertyName, newValue));
                if (itemPO != null)
                {
                    this.Vendor = itemPO.Vendor;

                }
            }

            if (propertyName == "ItemNumber" && this.PONumber != null && UnitCost == 0)
            {
                CriteriaOperator op = GroupOperator.Combine(GroupOperatorType.And,
                    new BinaryOperator("PurchaseOrder", this.PONumber),
                    new BinaryOperator("ItemNumber", newValue));
                ItemPurchaseOrderLine itemPOl = Session.FindObject<ItemPurchaseOrderLine>(op);
                this.UnitCost = itemPOl.UnitCost;

            }
            if (this.PONumber != null && this.ItemNumber != null)
            {
                this.ReceiverStatus = ItemReceiverStatus.WaitingDocumentation;
            }

        }

        protected override void OnDeleted()
        {
            //// Delete cascaded ItemReceiverSerialNo records
            //while (ItemReceiverSerialNo.Count > 0)
            //{
            //    ItemReceiverSerialNo.Remove(ItemReceiverSerialNo[0]);
            //}
            base.OnDeleted();
            
            
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            OldQty = Qty;
        }

        #region OnSaving
        protected override void OnSaving()
        {
            if (ReceiverStatus == ItemReceiverStatus.Completed)
            {
                AddToInventory();

            }
            base.OnSaving();
        }
        #endregion

        // Fields...

        string bCScan;
       // ReceiverPackage receiverPackageID;
        string accountingRef;
        DateTime accountingSubmittedDt;

        private DateTime _VendorInvoiceDueDate;
        private string _VendorInvoice;
        private decimal _UnitCost;
        private DistributionCenterWhse _DistributionCenterWhse;
        private DistributionCenter _DistributionCenter;
        private ItemReceiverStatus _ReceiverStatus;
        private int OldQty;
        private int _Qty;
        private Items _ItemNumber;
        private DateTime _LotExpiration;
        private string _Lot;
        private string _User;
        private Vendor _Vendor;
        private RX2_Office.Module.BusinessObjects.ItemPurchaseOrder _PONumber;
        private DateTime _ReceiverDate;
        private FileData _ReceiverDocument;
        private DistributionCenterWhseBins recieverBin;



        //[Association("ReceiverPackage-ItemReceiver")]
        //public ReceiverPackage ReceiverPackageID
        //{
        //    get => receiverPackageID;
        //    set => SetPropertyValue(nameof(ReceiverPackageID), ref receiverPackageID, value);
        //}

        [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string User
        {
            get
            {
                return _User;
            }
            set
            {
                SetPropertyValue("User", ref _User, value);
            }
        }


        [DataSourceCriteria("QtyOnPo > 0")]
        [RuleRequiredField]
        [Association("Items-ItemReceivers")]
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

        public ItemReceiverStatus ReceiverStatus
        {
            get
            {
                return _ReceiverStatus;
            }
            set
            {
                SetPropertyValue("ReceiverStatus", ref _ReceiverStatus, value);
            }
        }

        //[PoStatus] = 0 &&
        [DataSourceCriteria("PurchaseOrderLines[ItemNumber = '@This.ItemNumber']")]
        [Association("PurchaseOrder-ItemReceivers")]
        public RX2_Office.Module.BusinessObjects.ItemPurchaseOrder PONumber
        {
            get
            {
                return _PONumber;
            }
            set
            {
                SetPropertyValue("PONumber", ref _PONumber, value);
                if (!IsLoading && PONumber != null)
                {
                    this.Vendor = _PONumber.Vendor;
                    ItemPurchaseOrderLine pl = Session.FindObject<ItemPurchaseOrderLine>(new BinaryOperator("ItemNumber", _ItemNumber));

                    if (pl != null)
                    {
                        this.Qty = pl.QtyOrdered - pl.QtyReceived;
                        this.UnitCost = pl.UnitCost;
                        if ((this.Vendor.TermCode) == null || (this.Vendor.TermCode.DaysBeforeDue == 0))
                        {
                            this.VendorInvoiceDueDate = DateTime.Today.AddDays(20);
                        }
                        else
                        {
                            this.VendorInvoiceDueDate = DateTime.Today.AddDays(this.Vendor.TermCode.DaysBeforeDue);
                        }
                        this.DistributionCenter = _PONumber.DistributionCenter;
                        this.DistributionCenterWhse = _PONumber.Warehouse;



                    }
                }

            }
        }
        

        [Association("Vendor-ItemReceivers")]
        [RuleRequiredField]
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


        [RuleRequiredField]
        public DateTime ReceiverDate
        {
            get
            {
                return _ReceiverDate;
            }
            set
            {
                SetPropertyValue("ReceiverDate", ref _ReceiverDate, value);
            }
        }

        [VisibleInListView(true)]
        [RuleRequiredField("Qty Must be Greater then 0", DefaultContexts.Save, TargetCriteria = "Qty > 0")]
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




        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string VendorInvoice
        {
            get { return _VendorInvoice; }
            set
            {
                SetPropertyValue("VendorInvoice", ref _VendorInvoice, value);
            }
        }


        public DateTime VendorInvoiceDueDate
        {
            get
            {
                return _VendorInvoiceDueDate;
            }
            set
            {
                SetPropertyValue("VendorInvoiceDueDate", ref _VendorInvoiceDueDate, value);
            }
        }


        public DateTime AccountingSubmittedDt
        {
            get => accountingSubmittedDt;
            set => SetPropertyValue(nameof(AccountingSubmittedDt), ref accountingSubmittedDt, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AccountingRef
        {
            get => accountingRef;
            set => SetPropertyValue(nameof(AccountingRef), ref accountingRef, value);
        }



        [VisibleInListView(true)]
        [RuleRequiredField]
        //   [RuleCriteria("UnitCost", DefaultContexts.Save, "This.UnitCost != 0", "Unit Cost should almost always be greater then 0", SkipNullOrEmptyValues = false, ResultType = ValidationResultType.Warning)]
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
        [Size(15)]
        [RuleRequiredField("ItemReceiverLot", DefaultContexts.Save, "Provide the Lot Information if Possible", ResultType = ValidationResultType.Warning)]
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




        [VisibleInListView(true)]
        [RuleRequiredField("ItemReceiverLotExpiration", DefaultContexts.Save, "Provide the Lot Expiration Date if Possible", ResultType = ValidationResultType.Warning)]
        public DateTime LotExpiration
        {
            get
            {
                return _LotExpiration;
            }
            set
            {
                SetPropertyValue("LotExpiration", ref _LotExpiration, value);
            }
        }
        [Association("ItemReceiver-ItemInventory")]
        public XPCollection<ItemInventory> ItemInventory
        {
            get
            {
                return GetCollection<ItemInventory>("ItemInventory");
            }
        }


        [Association("ItemReceiver-ItemT3HeaderTemplates")]
        public XPCollection<ItemT3HeaderTemplate> Itemt3headerTemplate
        {
            get
            {
                return GetCollection<ItemT3HeaderTemplate>("Itemt3headerTemplate");
            }
        }

        DateTime putawayDateTime;
        public DateTime PutawayDateTime
        {
            get
            {
                return putawayDateTime;
            }
            set
            {
                SetPropertyValue("PutawayDateTime", ref putawayDateTime, value);
            }
        }

        string putAwayBy;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PutAwayBy
        {
            get
            {
                return putAwayBy;
            }
            set
            {
                SetPropertyValue("PutAwayBy", ref putAwayBy, value);
            }
        }
        
        [Size(255)]
        public string BCScan
        {
            get => bCScan;
            set => SetPropertyValue(nameof(BCScan), ref bCScan, value);
        }



        [Association("DistributionCenterWhseBin-ItemReceivers")]
        public DistributionCenterWhseBins RecieverBin
        {
            get
            {
                return recieverBin;
            }
            set
            {
                SetPropertyValue("RecieverBin", ref recieverBin, value);
            }
        }
        [Association("DistributionCenter-ItemReceiver")]
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


        [Association("DistributionCenterWhse-ItemReceiver")]
        public DistributionCenterWhse DistributionCenterWhse
        {
            get
            {
                return _DistributionCenterWhse;
            }
            set
            {
                SetPropertyValue("DistributionCenterWhse", ref _DistributionCenterWhse, value);
            }
        }

        [DevExpress.Xpo.Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        [FileTypeFilter("Document Pdf", 1, "*.pdf")]
        [FileTypeFilter("Document Word", 2, "*.DOC")]
        [FileTypeFilter("AllFiles", 3, "*.*")]

        public FileData ReceiverDocument
        {
            get { return _ReceiverDocument; }
            set { SetPropertyValue("Document", ref _ReceiverDocument, value); }
        }
        [Association("ItemReceiver-ItemReceiverSerialNo")]
        public XPCollection<ItemReceiverSerialNo> ItemReceiverSerialNo
        {
            get
            {
                return GetCollection<ItemReceiverSerialNo>(nameof(ItemReceiverSerialNo));
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
        void AddToInventory()
        {
            // first add to  itemtransaction
            ItemTransaction ItemT = new ItemTransaction(Session);
            ItemT.ItemNumber = this.ItemNumber;
            ItemT.Lot = this.Lot;
            ItemT.TransactionDate = this.ReceiverDate;
            ItemT.Qty = this.Qty;
            ItemT.UnitCost = this.UnitCost;
            ItemT.TransactionType = InventoryTransactionTypes.PO;
            ItemT.Vendor = this.Vendor;
            ItemT.RefOid = this.Oid;
            ItemT.ItemNumber.LastReceiptDate = ItemT.TransactionDate;
            ItemT.ItemNumber.LastReceiptUnitCost = ItemT.UnitCost;
            ItemT.ItemNumber.LastPurchaseFrom = this.Vendor;
            // update Item Table
            this.ItemNumber.LastReceiptDate = this.ReceiverDate;
            this.ItemNumber.LastReceiptUnitCost = this.UnitCost;
            // Update the PO

            foreach (ItemPurchaseOrderLine line in PONumber.PurchaseOrderLines)
                if (line.ItemNumber == this.ItemNumber)
                {
                    if (line.QtyOrdered >= (line.QtyReceived + this.Qty))
                    {
                        line.QtyReceived = line.QtyReceived + this.Qty;
                    }
                }
            // next  add to Inventory
            ItemInventory ItemI = new ItemInventory(Session) { ItemNumber = this.ItemNumber, ItemLot = this.Lot, ReceivedDate = this.ReceiverDate };
            Save();

        }
    }

    public enum ItemReceiverStatus
    { CheckIn = 1, WaitingDocumentation = 5, PutAway = 10, Completed = 99 }
}
