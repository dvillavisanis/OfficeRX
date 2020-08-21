
using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace RX2_Office.Module.BusinessObjects
{
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions]
    [ImageName("PurchaseOrder")]
    [NavigationItem("Purchasing")]
    [DefaultProperty("PurchaseOrderNumber")]
    [ListViewFilter("Open PO", "[PoStatus] = 1", "Open POs", "Po That are marked open", true)]
    [ListViewFilter("Open PO Older than 5 days", "[PoStatus] = 1 && [PODate] <= ADDDAYS(LocalDateTimeToday(), -5)", "Open POs Older than 5 days", "Po That are marked open and older than 5 days", false)]
    [ListViewFilter("Close PO", "[PoStatus] = 3", "Closed POs", "Po That are marked Closed", false)]
    [ListViewFilter("Yesterdays PO", "[PoStatus] = 2 && [PODate] >= ADDDAYS(LocalDateTimeToday(), -1) AND [PODate] < LocalDateTimeToday()", "Yesterday Open POs", "Po are open and create yesterday", false)]
    [ListViewFilter("Last 10 days PO", "[PoStatus] = 2 && [PODate] >= ADDDAYS(LocalDateTimeToday(), -10) AND [PODate] < LocalDateTimeToday()", "PO Created in the last 10 days", "PO Created in the last 10 days", false)]

    [ListViewFilter("Today PO", "[PoStatus] = 1 &&[PODate] = LocalDateTimeToday()", "Today's Open POs", "Po are open and create today", false)]
    [ListViewFilter(" All ", "")]

    [Appearance("PurchaseOrderNumber", Context = "ItemPurchaseOrder_DetailView", AppearanceItemType = "ANY", Enabled = false,Criteria ="IsNewObject(this)" ,TargetItems ="PurchaseOrderNumber")]

    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ItemPurchaseOrder : XPObject
    {

        // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).

        public ItemPurchaseOrder(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).

            //this.PurchaseOrderNumber = GetNextPONumber();
            this.PODate = DateTime.Today;
            // TimeSpan duration = new TimeSpan(72, 0, 0, 0);

            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    this.ExpectedReceiveDate = DateTime.Today.AddDays(3);
                    break;
                case DayOfWeek.Thursday:
                    this.ExpectedReceiveDate = DateTime.Today.AddDays(5);
                    break;
                case DayOfWeek.Friday:
                    this.ExpectedReceiveDate = DateTime.Today.AddDays(4);
                    break;
                case DayOfWeek.Saturday:
                    this.ExpectedReceiveDate = DateTime.Today.AddDays(4);
                    break;
                default:
                    this.ExpectedReceiveDate = DateTime.Today.AddDays(2);
                    break;
            }

            this.PoStatus = PoStatus.Open;
            this.IsPrinted = true;
            if (!(Session is NestedUnitOfWork)
               && (Session.DataLayer != null)
               && Session.IsNewObject(this)
                && (Session.ObjectLayer is SimpleObjectLayer)
  //OR
  //&& !(Session.ObjectLayer is DevExpress.ExpressApp.Security.ClientServer.SecuredSessionObjectLayer)
  && string.IsNullOrEmpty(PurchaseOrderNumber))
            {
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "PurchaseOrder");
                PurchaseOrderNumber = string.Format("{0:D6}", nextSequence);

            }

        }


        protected override void OnSaved()
        {
            int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "PurchaseOrder");
            PurchaseOrderNumber = string.Format("{0:D6}", nextSequence);
            Save();
            base.OnSaved();
        }


        public string GetNextPONumber()
        {

            //ApplicationOptions obj= View.ObjectSpace.FindObject<ApplicationOptions>(CriteriaOperator.Parse("Ref=1"));
            //int NextNumber = 0;
            //using (UnitOfWork cUow = new UnitOfWork())
            // ApplicationOptions AO =

            //    if (cUow.IsConnected)
            //    {
            //        int refid = 1;
            //        BinaryOperator BO = new BinaryOperator("Ref", refid);
            //        ApplicationOptions AO = cUow.FindObject<ApplicationOptions>(BO);
            //        if (AO != null)
            //        {
            //            NextNumber = AO.NextPONumber;
            //            AO.NextPONumber = ++NextNumber;
            //            AO.Save();
            //            Session.CommitTransaction();
            //        }
            //    }
            //}

            //    int refid = 1;
            //    BinaryOperator BO = new BinaryOperator("Ref", refid);
            //    ApplicationOptions AO = Session.FindObject<ApplicationOptions>(BO);
            //    if (AO != null)
            //    {
            //        NextNumber = AO.NextPONumber;
            //        AO.NextPONumber = ++NextNumber;

            //        AO.Save();
            //        Session.CommitTransaction();
            //    }
            //    string Ret = String.Format("{0:D8}", NextNumber);
            return "1";
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
        private string _AccountingPORefNumber;
        private string _VendorName;
        private DistributionCenterWhse _Warehouse;
        private decimal _FreightAmt;

        private PoStatus _PoStatus;
        private DistributionCenter _DistributionCenter;
        private Vendor _MasterVendor;
        private PaymentTermsCode _TermCode;
        private DateTime _ExpectedReceiveDate;
        private string _Comment;
        private bool _OnHold;
        private bool _IsPrinted;
        private string _VendorCity;
        private string _VendorZipCode;
        private State _ShipToState;
        private string _ShipToCity;
        private string _ShipToAddress3;
        private string _ShipToAddress2;
        private string _ShipToAddress;
        private string _ShipToName;
        private string _ShipZipCode;
        private State _VendorState;
        private string _VendorAddress3;
        private string _VendorAddress2;
        private string _VendorAddress;
        private DateTime _PODate;
        private string _PurchaseOrderNumber;
        private Vendor _Vendor;

        [VisibleInListView(false)]
        [RuleRequiredField]
        [Association("Vendor-PurchaseOrders")]
        [Index(1)]
        public Vendor Vendor
        {
            get
            {
                return _Vendor;
            }
            set
            {
                if (Equals(Vendor, value)) return;
                SetPropertyValue("Vendor", ref _Vendor, value);
                if (SetPropertyValue<Vendor>("Vendor", ref _MasterVendor, value))
                {
                    if (!IsLoading && Vendor != null)
                    {
                        this.VendorAddress = Vendor.Address;
                        this.VendorAddress2 = Vendor.Address2;
                        this.VendorCity = Vendor.City;
                        this.VendorState = Vendor.State;
                        this.VendorZipCode = Vendor.ZipCode;
                        this.VendorName = Vendor.VendorName;
                        this.TermCode = Vendor.TermCode;

                        // this.Save();
                    }
                }

                SetPropertyValue("Vendor", ref _Vendor, value);

            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [VisibleInLookupListView(true)]
        public PoStatus PoStatus
        {
            get
            {
                return _PoStatus;
            }
            set
            {
                SetPropertyValue("PoStatus", ref _PoStatus, value);
            }
        }


        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [RuleRequiredField]
        [Index(0)]
        public string PurchaseOrderNumber
        {
            get
            {
                return _PurchaseOrderNumber;
            }
            set
            {
                SetPropertyValue("PurchaseOrderNumber", ref _PurchaseOrderNumber, value);
            }
        }
        [Index(2)]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [RuleRequiredField]
        public DateTime PODate
        {
            get
            {
                return _PODate;
            }
            set
            {
                SetPropertyValue("PODate", ref _PODate, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string VendorAddress
        {
            get
            {
                return _VendorAddress;
            }
            set
            {
                SetPropertyValue("VendorAddress", ref _VendorAddress, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string VendorAddress2
        {
            get
            {
                return _VendorAddress2;
            }
            set
            {
                SetPropertyValue("VendorAddress2", ref _VendorAddress2, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string VendorAddress3
        {
            get
            {
                return _VendorAddress3;
            }
            set
            {
                SetPropertyValue("VendorAddress3", ref _VendorAddress3, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string VendorCity
        {
            get
            {
                return _VendorCity;
            }
            set
            {
                SetPropertyValue("City", ref _VendorCity, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("State-PurchaseOrderVendorState")]
        public State VendorState
        {
            get
            {
                return _VendorState;
            }
            set
            {
                SetPropertyValue("State", ref _VendorState, value);
            }
        }

        [VisibleInLookupListView(false)]
        [VisibleInListView(false)]
        public string VendorZipCode
        {
            get
            {
                return _VendorZipCode;
            }
            set
            {
                SetPropertyValue("ZipCode", ref _VendorZipCode, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField]
        public string ShipToName
        {
            get
            {
                return _ShipToName;
            }
            set
            {
                SetPropertyValue("ShipToName", ref _ShipToName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string ShipToAddress
        {
            get
            {
                return _ShipToAddress;
            }
            set
            {
                SetPropertyValue("ShipToAddress", ref _ShipToAddress, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string ShipToAddress2
        {
            get
            {
                return _ShipToAddress2;
            }
            set
            {
                SetPropertyValue("ShipToAddress2", ref _ShipToAddress2, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string ShipToAddress3
        {
            get
            {
                return _ShipToAddress3;
            }
            set
            {
                SetPropertyValue("ShipToAddress3", ref _ShipToAddress3, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string ShipToCity
        {
            get
            {
                return _ShipToCity;
            }
            set
            {
                SetPropertyValue("ShipToCity", ref _ShipToCity, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("State-PurchaseOrderShipState")]
        public State ShipToState
        {
            get
            {
                return _ShipToState;
            }
            set
            {
                SetPropertyValue("ShipToState", ref _ShipToState, value);
            }
        }

        [VisibleInLookupListView(false)]
        [VisibleInListView(false)]
        public string ShipZipCode
        {
            get
            {
                return _ShipZipCode;
            }
            set
            {
                SetPropertyValue("ZipCode", ref _ShipZipCode, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal FreightAmt
        {
            get
            {
                return _FreightAmt;
            }
            set
            {
                SetPropertyValue("FreightAmt", ref _FreightAmt, value);
            }
        }



        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool IsPrinted
        {
            get
            {
                return _IsPrinted;
            }
            set
            {
                SetPropertyValue("IsPrinted", ref _IsPrinted, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool OnHold
        {
            get
            {
                return _OnHold;
            }
            set
            {
                SetPropertyValue("OnHold", ref _OnHold, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                SetPropertyValue("Comment", ref _Comment, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime ExpectedReceiveDate
        {
            get
            {
                return _ExpectedReceiveDate;
            }
            set
            {
                SetPropertyValue("ExpectedReceiveDate", ref _ExpectedReceiveDate, value);
            }
        }



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string VendorName
        {
            get
            {
                return _VendorName;
            }
            set
            {
                SetPropertyValue("VendorName", ref _VendorName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("PaymentTermsCode-PurchaseOrder")]
        [RuleRequiredField]
        public PaymentTermsCode TermCode
        {
            get
            {
                return _TermCode;
            }
            set
            {
                SetPropertyValue("TermCode", ref _TermCode, value);
            }
        }
        [VisibleInListView(false)]
        [Association("PurchaseOrder-PurchaseOrderLines"), Aggregated]

        public XPCollection<ItemPurchaseOrderLine> PurchaseOrderLines
        {
            get
            {
                return GetCollection<ItemPurchaseOrderLine>("PurchaseOrderLines");
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("DistributionCenter-PurchaseOrders")]
        public DistributionCenter DistributionCenter
        {
            get
            {
                return _DistributionCenter;
            }
            set
            {
                //  if (Equals(DistributionCenter, value)) return;
                // SetPropertyValue("DistributionCenter", ref _DistributionCenter, value);
                if (SetPropertyValue("DistributionCenter", ref _DistributionCenter, value))
                {
                    if (!IsLoading && DistributionCenter != null)
                    {
                        this.ShipToAddress = DistributionCenter.Address;
                        this.ShipToAddress2 = DistributionCenter.Address2;
                        this.ShipToCity = DistributionCenter.City;
                        this.ShipToState = DistributionCenter.State;
                        this.ShipZipCode = DistributionCenter.ZipCode;
                        this.ShipToName = DistributionCenter.DCName;
                        this.Warehouse = DistributionCenter.DefaultPOWhse;
                    }
                }
            }
        }

        [Association("DistributionCenterWhse-ItemPurchaseOrders")]
        [DataSourceProperty("DistributionCenter.Warehouse")]
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

        [PersistentAlias("[<ItemPurchaseOrderLine>][PurchaseOrder == ^.Oid].Sum(QtyOrdered * UnitCost )")]
        public decimal OrderTotal
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDecimal(EvaluateAlias("OrderTotal"));
                }
                return 0;

            }
        }



        [PersistentAlias("[<ItemPurchaseOrderLine>][PurchaseOrder == ^.Oid].Sum((QtyOrdered -  QtyReceived) * UnitCost )")]
        public decimal OutstandingBalance
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDecimal(EvaluateAlias("OutstandingBalance"));
                }
                return 0;

            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(18)]
        public string AccountingPORefNumber
        {
            get
            {
                return _AccountingPORefNumber;
            }
            set
            {
                SetPropertyValue("AccountingPORefNumber", ref _AccountingPORefNumber, value);
            }
        }
        [Association("PurchaseOrder-ItemReceivers")]
        public XPCollection<ItemReceiver> ItemReceivers
        {
            get
            {
                return GetCollection<ItemReceiver>("ItemReceivers");
            }

        }
        //[Association("PurchaseOrder-ItemReceivers")]
        //public XPCollection<ItemReceiver> ItemReceivers
        //{
        //    get
        //    {
        //        return GetCollection<ItemReceiver>("ItemReceivers");
        //    }
        //}

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


        //public void UpdateOrdersTotal(bool forceChangeEvents)
        //{
        //    decimal? oldOrdersTotal = fOrdersTotal;
        //    decimal tempTotal = 0m;
        //    if (!forceChangeEvents) return;

        //    {
        //        foreach (ItemPurchaseOrderLine detail in PurchaseOrderLines)
        //            tempTotal += detail.UnitCost * detail.QtyOrdered;
        //        fOrdersTotal = tempTotal;
        //        if (forceChangeEvents)
        //            OnChanged("OrdersTotal", oldOrdersTotal, fOrdersTotal);
        //    }
        //}

        //public decimal UpdateOrderTotal()
        //{
        //    decimal? oldOrdersTotal = fOrdersTotal;
        //    decimal tempTotal = 0m;


        //    {
        //        foreach (ItemPurchaseOrderLine detail in PurchaseOrderLines)
        //            tempTotal += detail.UnitCost * detail.QtyOrdered;
        //        fOrdersTotal = tempTotal;
        //        return tempTotal;
        //    }
        //}



        [Action(PredefinedCategory.Reports, Caption = "PO Print", ToolTip = "Print PO", ImageName = "PurchaseOrder", TargetObjectsCriteria = "Not [PurchaseOrderNumber] Is NULL")]
        public void PrintPO()
        //public void PrintPO(ItemPurchaseOrder sender)
        {
             DevExpress.XtraEditors.XtraMessageBox.Show("Printing PO -"+ PurchaseOrderNumber,"Print Po" );

            string reportname = "poPrintRPT";

            IObjectSpace objectSpace = ReportDataProvider.ReportObjectSpaceProvider.CreateObjectSpace(typeof(ReportDataV2));
            IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(   new BinaryOperator("DisplayName", reportname));
            if (reportData == null)
            {

                                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to find -" + reportname);
                 throw new UserFriendlyException("Cannot find the 'Contacts Report' report.");
            }
            else
            {
                    //PrintReport(reportData);
            }
        }

        //protected abstract void PrintReport(IReportDataV2 reportData);
    }
}


