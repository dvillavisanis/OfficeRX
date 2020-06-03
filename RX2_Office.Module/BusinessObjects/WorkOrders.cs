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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.SystemModule;
namespace RX2_Office.Module.BusinessObjects
{
    [Appearance("Status", AppearanceItemType = "ViewItem", Enabled = false, TargetItems = "OriginalNDC , Repackager ,OriginalLot , NewNdc ",
   Criteria = "[WoStatus] > 10 ", Context = "ListView", FontColor = "Green", Priority = 2)]


    // [ListViewFilter("All Open Workorders","[WoStatus] < 70", "All Open Workorders", "All Open Workorders", false)]

    [DefaultClassOptions]
    [NavigationItem("Work Order")]
    [ImageName("WorkOrder")]
    [DefaultProperty("OriginalNDCDesc")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    [ListViewFilter("All Open WorkOrders", "[WoStatus] < 70", "Open WorkOrders", "All workorders status < 70", true)]
    //[ListViewFilter("New", "[WoStatus] = 10", "New", "New Work orders not submitted", false)]
    //[ListViewFilter("In Receiving", "[WoStatus] = 60", "In Receiving", "Work orders with status of receiving", false)]
    //[ListViewFilter("Over Due", " [WoStatus] < 70 and [ExpectedDate] < Today()", "Over Due", "Work Orders pass the expected date", false)]
    [ListViewFilter(" All ", "", false)]
    [Appearance("ExpectedDate", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = " ExpectedDate < Today()", Context = "ListView", FontColor = "Maroon", Priority = 2)]

    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class WorkOrders : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public WorkOrders(Session session)
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
        // Fields...

        private decimal _PartialCost;
        private decimal _FullCaseCost;
        private decimal _NewUnitDoseCost;
        private RepackPackager _Repackager;

        private decimal _OldWorkorderId;
        private string _DeletedReason;
        private DateTime _DeltedDate;
        private string _DeletedBy;
        private decimal _EstimatedFullCaseCount;
        private bool _NoPartialCost;
        private string _OriginalReturnReason;
        private decimal _InvoiceAmt;
        private string _InvoiceNumber;
        private decimal _OriginalQtyReturned;
        private DateTime _RecvDate;
        private static string _RecvBy;
        private DateTime _QcDate;
        private string _QcBy;
        private string _ShipBy;
        private DateTime _ShipDate;
        private string _ShipToTracking;
        private string _Comment;
        private DateTime _SubmittedDate;
        private string _SubmittedBy;
        private string _NewNDCLot;
        private decimal _PartialCaseQty;
        private decimal _NumberOfFullCases;
        private string _OriginalLot;
        private Double _OrinalNdcCost;
        private DateTime _ExpectedDate;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private decimal _PackageQty;
        private decimal _NewNDCSize;
        private decimal _OriginalNDCSize;
        private double _OriginalQty;
        private Items _NewNdc;
        private DistributionCenterWhse _FinishProductWhse;
        private DistributionCenterWhse _DcWhse;

        private Items _OriginalNDC;
        private WorkOrderStatus _WoStatus;

        [VisibleInListView(true)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField]
        public WorkOrderStatus WoStatus
        {
            get
            {
                return _WoStatus;
            }
            set
            {
                SetPropertyValue("WoStatus", ref _WoStatus, value);
            }
        }

        [VisibleInListView(true)]
        [RuleRequiredField]
        [Association("RepackPackager-WorkOrders")]
        public RepackPackager Repackager
        {
            get
            {
                return _Repackager;
            }
            set
            {
                SetPropertyValue("Repackager", ref _Repackager, value);
            }
        }

        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [RuleRequiredField]
        [Association("Items-WorkordersOrignialNDC")]
        public Items OriginalNDC
        {
            get
            {
                return _OriginalNDC;
            }
            set
            {
                SetPropertyValue("OriginalNDC", ref _OriginalNDC, value);
            }
        }


        [VisibleInListView(true)]
        [VisibleInLookupListView(false)]
        [NonPersistent]
        public String OriginalNDCDesc
        {
            get
            {
                //if (! _OriginalNDC.Equals(null))
               // {
               //     return OriginalNDC.ItemDescription;
               // }
                return "  ";
                
            }
        }

        
        ItemInventory originalInventory;
        [Association("ItemInventory-WorkOrders")]
        [DataSourceCriteria("ItemNumber = @This.OriginalNDC ")]
        [VisibleInListView(true)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField]
         public ItemInventory OriginalInventory
        {
            get
            {
                return originalInventory;
            }

            set
            {
                if (Equals(OriginalInventory, value)) return;
                SetPropertyValue(nameof(OriginalInventory), ref originalInventory, value);

                this.OrinalNdcCost = OriginalInventory.UnitCost;
                this.OriginalQty = OriginalInventory.QtyOnHand;
                this.DcWhse = originalInventory.Warehouse;
                this.OriginalNDCSize = originalInventory.ItemNumber.PackageSize;
            }
        }


        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [RuleRequiredField]
        [Size(20)]
        public string OriginalLot
        {
            get
            {
                return _OriginalLot;
            }
            set
            {
                SetPropertyValue("OriginalLot", ref _OriginalLot, value);
            }
        }

        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [RuleRequiredField]
        [Association("DistributionCenterWhse-WorkOrdersOrigWhse")]
        public DistributionCenterWhse DcWhse
        {
            get
            {
                return _DcWhse;
            }
            set
            {
                SetPropertyValue("DcWhse", ref _DcWhse, value);
            }
        }


        [VisibleInLookupListView(false)]
        [RuleRequiredField]
        [VisibleInListView(false)]
        [Association("DistributionCenterWhse-WorkOrdersFinishProductWhse")]
        public DistributionCenterWhse FinishProductWhse
        {
            get
            {
                return _FinishProductWhse;
            }
            set
            {
                SetPropertyValue("FinishProductWhse", ref _FinishProductWhse, value);
            }
        }


        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [RuleRequiredField]
        [Association("Items-WorkOrdersNewNdc")]
        public Items NewNdc
        {
            get
            {
                return _NewNdc;
            }
            set
            {
                SetPropertyValue("NewNdc", ref _NewNdc, value);
            }
        }

        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [NonPersistent]
        public String NewNDCDesc
        {
            get
            {
                return NewNdc.ItemDescription;
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:N}")]
        public double OriginalQty
        {
            get
            {
                return _OriginalQty;
            }
            set
            {

               // if (OriginalQty <= OriginalInventory.QtyOnHand)
               // {
                    SetPropertyValue("OriginalQty", ref _OriginalQty, value);
                //}
            }
        }

        [ModelDefault("EditMask", "#,###.##")]
        [ModelDefault("DisplayFormat", "{0:N}")]
        [VisibleInListView(false)]
        public decimal EstimatedFullCaseCount
        {
            get
            {
                return _EstimatedFullCaseCount;
            }
            set
            {
                SetPropertyValue("EstimatedFullCaseCount", ref _EstimatedFullCaseCount, value);
            }
        }

        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:N}")]
        [VisibleInListView(false)]
        public decimal OriginalNDCSize
        {
            get
            {
                return _OriginalNDCSize;
            }
            set
            {
                SetPropertyValue("OriginalNDCSize", ref _OriginalNDCSize, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField]
        [ModelDefault("DisplayFormat", "{0:C}")]
        public double OrinalNdcCost
        {
            get
            {
                return _OrinalNdcCost;
            }
            set
            {
                SetPropertyValue("OrinalNdcCost", ref _OrinalNdcCost, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:N}")]

        public decimal OriginalQtyReturned
        {
            get
            {
                return _OriginalQtyReturned;
            }
            set
            {
                SetPropertyValue("OriginalQtyReturned", ref _OriginalQtyReturned, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string OriginalReturnReason
        {
            get
            {
                return _OriginalReturnReason;
            }
            set
            {
                SetPropertyValue("OriginalReturnReason", ref _OriginalReturnReason, value);
            }
        }




        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField]
        public decimal NewNDCSize
        {
            get
            {
                return _NewNDCSize;
            }
            set
            {
                SetPropertyValue("NewNDCSize", ref _NewNDCSize, value);
            }
        }



        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]

        [Size(20)]
        public string NewNDCLot
        {
            get
            {
                return _NewNDCLot;
            }
            set
            {
                SetPropertyValue("NewNDCLot", ref _NewNDCLot, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:N}")]
        public decimal PackageQty // case qty RecvFullCaseQuantity
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
        [VisibleInLookupListView(false)]
        [RuleRequiredField]
        public DateTime ExpectedDate
        {
            get
            {
                return _ExpectedDate;
            }
            set
            {
                SetPropertyValue("ExpectedDate", ref _ExpectedDate, value);
            }
        }

        
        [VisibleInListView(false)]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:N}")]
        public decimal NumberOfFullCases
        {
            get
            {
                return _NumberOfFullCases;
            }
            set
            {
                SetPropertyValue("NumberOfFullCases", ref _NumberOfFullCases, value);
            }
        }

        [VisibleInListView(false)]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:N#,###}")]
        public decimal PartialCaseQty
        {
            get
            {
                return _PartialCaseQty;
            }
            set
            {
                SetPropertyValue("PartialCaseQty", ref _PartialCaseQty, value);
            }
        }

        [VisibleInListView(false)]
        public bool NoPartialCost
        {
            get
            {
                return _NoPartialCost;
            }
            set
            {
                SetPropertyValue("NoPartialCost", ref _NoPartialCost, value);
            }
        }

        [VisibleInListView(false)]
        public decimal PartialCost
        {
            get
            {
                return _PartialCost;
            }
            set
            {
                SetPropertyValue("PartialCost", ref _PartialCost, value);
            }
        }

        [VisibleInListView(false)]
        public decimal UnitCost
        {
            get
            {
                return _NewUnitDoseCost;
            }
            set
            {
                SetPropertyValue("NewUnitDoseCost", ref _NewUnitDoseCost, value);
            }
        }
        [VisibleInListView(false)]
        public decimal FullCaseCost
        {
            get
            {
                return _FullCaseCost;
            }
            set
            {
                SetPropertyValue("FullCaseCost", ref _FullCaseCost, value);
            }
        }


        [VisibleInListView(false)]
        [Size(25)]
        [ModelDefault("AllowEdit", "False")]
        public string SubmittedBy
        {
            get
            {
                return _SubmittedBy;
            }
            set
            {
                SetPropertyValue("SubmittedBy", ref _SubmittedBy, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.Unlimited)]
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
        public DateTime SubmittedDate
        {
            get
            {
                return _SubmittedDate;
            }
            set
            {
                SetPropertyValue("SubmittedDate", ref _SubmittedDate, value);
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(25)]
        public string ShipToTracking
        {
            get
            {
                return _ShipToTracking;
            }
            set
            {
                SetPropertyValue("ShipToTracking", ref _ShipToTracking, value);
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        public DateTime ShipDate
        {
            get
            {
                return _ShipDate;
            }
            set
            {
                SetPropertyValue("ShipDate", ref _ShipDate, value);
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(18)]
        public string ShipBy
        {
            get
            {
                return _ShipBy;
            }
            set
            {
                SetPropertyValue("ShipBy", ref _ShipBy, value);
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(25)]
        public string QcBy
        {
            get
            {
                return _QcBy;
            }
            set
            {
                SetPropertyValue("QcBy", ref _QcBy, value);
            }
        }
        [VisibleInListView(false)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime QcDate
        {
            get
            {
                return _QcDate;
            }
            set
            {
                SetPropertyValue("QcDate", ref _QcDate, value);
            }
        }

        [VisibleInListView(false)]
        [Size(25)]
        [ModelDefault("AllowEdit", "False")]
        public string RecvBy
        {
            get
            {
                return _RecvBy;
            }
            set
            {
                SetPropertyValue("RecvBy", ref _RecvBy, value);
            }
        }
        [VisibleInListView(false)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime RecvDate
        {
            get
            {
                return _RecvDate;
            }
            set
            {
                SetPropertyValue("RecvDate", ref _RecvDate, value);
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(25)]
        public string InvoiceNumber
        {
            get
            {
                return _InvoiceNumber;
            }
            set
            {
                SetPropertyValue("InvoiceNumber", ref _InvoiceNumber, value);
            }
        }
        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        public decimal InvoiceAmt
        {
            get
            {
                return _InvoiceAmt;
            }
            set
            {
                SetPropertyValue("InvoiceAmt", ref _InvoiceAmt, value);
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(20)]
        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                SetPropertyValue("CreatedBy", ref _CreatedBy, value);
            }
        }
        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
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
        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(25)]
        public string DeletedBy
        {
            get
            {
                return _DeletedBy;
            }
            set
            {
                SetPropertyValue("DeletedBy", ref _DeletedBy, value);
            }
        }
        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        public DateTime DeltedDate
        {
            get
            {
                return _DeltedDate;
            }
            set
            {
                SetPropertyValue("DeltedDate", ref _DeltedDate, value);
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(254)]
        public string DeletedReason
        {
            get
            {
                return _DeletedReason;
            }
            set
            {
                SetPropertyValue("DeletedReason", ref _DeletedReason, value);
            }
        }
        [ModelDefault("DisplayFormat", "{O:).#}")]
        [VisibleInListView(false)]
        [ModelDefault("AllowEdit", "False")]
        public decimal OldWorkorderId
        {
            get
            {
                return _OldWorkorderId;
            }
            set
            {
                SetPropertyValue("OldWorkorderId", ref _OldWorkorderId, value);
            }
        }


    }
}
