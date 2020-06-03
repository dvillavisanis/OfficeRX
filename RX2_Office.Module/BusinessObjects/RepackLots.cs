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
    [DefaultClassOptions]
    [ListViewFilter("All Open Lots", "[RepackLotStatus] < ##Enum#RX2_Office.Module.BusinessObjects.RepackStatusCodes,Completed#", "All Open Lots", "All Open Lots", true)]
    [ListViewFilter("All", "")]
    [NavigationItem("Work Order")]
    [ImageName("repack")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    [DefaultProperty("LotId")]

    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class RepackLots : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackLots(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "LotID");
            LotId = string.Format("{0:D6}", nextSequence);
            CreatedDate = DateTime.Now;
            DateInDoor = DateTime.Now;
            InTakeDt = DateTime.Now;
            RepackLotStatus = RepackStatusCodes.Intake;
            SendFile = true;
            LastDeliveryNumber = 0;



            ExpectedCompletionDt = CreatedDate.AddDays(4);
            // LotDescription = RepackItem.ItemDescription;
            LotExpirationDt = DateTime.Now.AddMonths(6);

            // RepackLotStatus =  ;


            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        protected override void OnSaved()
        {

            base.OnSaved();

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



        private int lastDeliveryNumber;
        string repakUnitSize;
        int lastSerialNumber;
        // string la;
        RepackPackager repackPackager;
        RepackItems repackItem;
        private RepackStatusCodes _RepackLotStatus;
        private Customer _CustomerId;
        private decimal _OldId;
        private string _MgfNDC;
        private static string _BulkRtnComment;
        private static decimal _BulkReturnQty;
        private DateTime _ExpectedCompletionDt;
        private DateTime _InTakeDt;
        private bool _RefrigerateAfterOpen;
        private bool _IsRefrigerated;
        private DateTime _PharmChkDt;
        private DateTime _QcEndDate;
        private DateTime _QcStartDate;
        private decimal _QCLostQty;
        private static decimal _QCIncompleteQty;
        private decimal _RetentionQty;
        private decimal _QCCount;
        private DateTime _BeyondUseDt;
        private string _Strength;
        private string _GenericName;
        private string _TradeName;
        private DateTime _MGFLotExpirationDt;
        private string _MGFLot;
        private string _Barcode;
        private string _UPC;
        private string _NDC;
        private int _PackageQty;
        private eRepackPackageType _Packagetype;
        private decimal _UnitSize;
        private decimal _BulkUnitQty;
        private DateTime _LotExpirationDt;
        private DateTime _CreatedDate;
        private DateTime _DateInDoor;
        private string _LotDescription;
        private string _CustomerPO;
        private string _LotId;
        private Boolean _sendFile;
        private string labelCaseQty;


        [RuleRequiredField()]
        [Size(25)]
        public string LotId
        {
            get
            {
                return _LotId;
            }
            set
            {
                SetPropertyValue("LotId", ref _LotId, value);
            }
        }


        [RuleRequiredField()]
        [Association("Customer-RepackLots")]
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




        /// <summary>
        /// Status of the Lot
        /// </summary>
        public RepackStatusCodes RepackLotStatus
        {
            get
            {
                return _RepackLotStatus;
            }
            set
            {
                SetPropertyValue("RepackLotStatus", ref _RepackLotStatus, value);
            }
        }


        /// <summary>
        ///  Linked to the Repack Item
        /// </summary>
        [RuleRequiredField]
        [Association("RepackItems-RepackLots")]
        public RepackItems RepackItem
        {
            get
            {
                return repackItem;
            }

            set
            {
                SetPropertyValue(nameof(RepackItem), ref repackItem, value);
                if (!IsLoading & this.CustomerId == null)
                {
                    this.CustomerId = this.repackItem.DefaultCustomer;
                }
                if (!IsLoading && LotDescription == null)
                {
                    this.LotDescription = RepackItem.ItemDescription;

                }


                if (!IsLoading)
                {
                    this.UnitSize = this.repackItem.NDC.PackageSize;
                    if (this.repackItem.NDC.BarCode.Substring(0, 5) == "17856" && this.repackItem.NDC.BarCode.Trim().Length == 11 && (this.repackItem.NDC.BarCode.Substring(9, 1) == "0"))
                    {
                        this.Barcode = this.repackItem.NDC.BarCode.Substring(0, 9) + this.repackItem.NDC.BarCode.Substring(10, 1);
                    }
                    else
                    {
                        this.Barcode = this.repackItem.NDC.BarCode;
                    }

                    if (this.repackItem.NDC.NDC.Substring(0, 5) == "17856" && this.repackItem.NDC.NDC.Trim().Length == 11 && (this.repackItem.NDC.NDC.Substring(9, 1) == "0"))
                    {
                        this.Barcode = this.repackItem.NDC.NDC.Substring(0, 9) + this.repackItem.NDC.NDC.Substring(10, 1);
                    
                    }
                    else
                    {
                        this.NDC = this.repackItem.NDC.NDC;
                    }
                    this.LabelCaseQty = this.repackItem.LabelCaseQty;

                }
            }
        }

        [RuleRequiredField]
        [VisibleInListView(false)]
        [Size(25)]
        public string CustomerPO
        {
            get
            {
                return _CustomerPO;
            }
            set
            {
                SetPropertyValue("CustomerPO", ref _CustomerPO, value);
            }
        }




        [RuleRequiredField()]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LotDescription
        {
            get
            {
                return _LotDescription;
            }
            set
            {
                SetPropertyValue("LotDescription", ref _LotDescription, value);
            }
        }


        [VisibleInListView(false)]
        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal BulkUnitQty
        {
            get
            {
                return _BulkUnitQty;
            }
            set
            {
                SetPropertyValue("unitQty", ref _BulkUnitQty, value);
            }
        }

        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        [VisibleInListView(false)]
        public decimal UnitSize
        {
            get
            {
                return _UnitSize;
            }
            set
            {
                SetPropertyValue("UnitSize", ref _UnitSize, value);
            }
        }


        [VisibleInListView(false)]
        [Size(3)]
        public eRepackPackageType PackageType
        {
            get
            {
                return _Packagetype;
            }
            set
            {
                SetPropertyValue("PackageType", ref _Packagetype, value);
            }
        }


        [RuleRequiredField()]
        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public int PackageQty
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

        [ModelDefault("EditMask", "##########")]
        [ModelDefault("DisplayFormat", "{0:##########}")]
        [RuleRequiredField()]
        [Size(11)]
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


        [VisibleInListView(false)]
        [Size(25)]
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


        [Size(25)]
        public string MgfNDC
        {
            get
            {
                return _MgfNDC;
            }
            set
            {
                SetPropertyValue("MgfNDC", ref _MgfNDC, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MGFLot
        {
            get
            {
                return _MGFLot;
            }
            set
            {
                SetPropertyValue("MGFLot", ref _MGFLot, value);
            }
        }


        public DateTime MGFLotExpirationDt
        {
            get
            {
                return _MGFLotExpirationDt;
            }
            set
            {
                SetPropertyValue("MGFLotExpirationDt", ref _MGFLotExpirationDt, value);
            }
        }


        [VisibleInListView(false)]
        [Size(254)]
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
        [Size(255)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        public DateTime CreatedDate


        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                SetPropertyValue("ReceivedDt", ref _CreatedDate, value);
            }
        }


        [RuleRequiredField()]
        [VisibleInListView(true)]
        public DateTime LotExpirationDt
        {
            get
            {
                return _LotExpirationDt;
            }
            set
            {
                SetPropertyValue("LotExpirationDt", ref _LotExpirationDt, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime BeyondUseDt
        {
            get
            {
                return _BeyondUseDt;
            }
            set
            {
                SetPropertyValue("BeyondUseDt", ref _BeyondUseDt, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime DateInDoor
        {
            get
            {
                return _DateInDoor;
            }
            set
            {
                SetPropertyValue("DateInDoor", ref _DateInDoor, value);
            }
        }



        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        [VisibleInListView(false)]
        public decimal QCCount
        {
            get
            {
                return _QCCount;
            }
            set
            {
                SetPropertyValue("QCCount", ref _QCCount, value);
            }
        }



        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        [VisibleInListView(false)]
        public decimal RetentionQty
        {
            get
            {
                return _RetentionQty;
            }
            set
            {
                SetPropertyValue("RetentionQty", ref _RetentionQty, value);
            }
        }



        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        [VisibleInListView(false)]
        public decimal QCIncompleteQty
        {
            get
            {
                return _QCIncompleteQty;
            }
            set
            {
                SetPropertyValue("QCIncompleteQty", ref _QCIncompleteQty, value);
            }
        }



        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        [VisibleInListView(false)]
        public decimal QCLostQty
        {
            get
            {
                return _QCLostQty;
            }
            set
            {
                SetPropertyValue("QCLostQty", ref _QCLostQty, value);
            }
        }


        [VisibleInListView(false)]
        public DateTime QcStartDate
        {
            get
            {
                return _QcStartDate;
            }
            set
            {
                SetPropertyValue("QcStartDate", ref _QcStartDate, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime QcEndDate
        {
            get
            {
                return _QcEndDate;
            }
            set
            {
                SetPropertyValue("QcEndDate", ref _QcEndDate, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime PharmChkDt
        {
            get
            {
                return _PharmChkDt;
            }
            set
            {
                SetPropertyValue("PharmChkDt", ref _PharmChkDt, value);
            }
        }

        [VisibleInListView(false)]
        public bool isRefrigerated
        {
            get
            {
                return _IsRefrigerated;
            }
            set
            {
                SetPropertyValue("isRefrigerated", ref _IsRefrigerated, value);
            }
        }

        [RuleRequiredField()]
        [VisibleInListView(false)]
        [Association("RepackPackager-RepackLots")]
        public RepackPackager RepackPackager
        {
            get => repackPackager;
            set => SetPropertyValue(nameof(RepackPackager), ref repackPackager, value);
        }


        [VisibleInListView(false)]
        public bool RefrigerateAfterOpen
        {
            get
            {
                return _RefrigerateAfterOpen;
            }
            set
            {
                SetPropertyValue("RefrigerateAfterOpen", ref _RefrigerateAfterOpen, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime InTakeDt
        {
            get
            {
                return _InTakeDt;
            }
            set
            {
                SetPropertyValue("InTakeDt", ref _InTakeDt, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime ExpectedCompletionDt
        {
            get
            {
                return _ExpectedCompletionDt;
            }
            set
            {
                SetPropertyValue("ExpectedCompletionDt", ref _ExpectedCompletionDt, value);
            }
        }

        [Size(10)]
        public string RepakUnitSize
        {
            get => repakUnitSize;
            set => SetPropertyValue(nameof(RepakUnitSize), ref repakUnitSize, value);
        }


        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        [VisibleInListView(false)]
        public decimal BulkReturnQty
        {
            get
            {
                return _BulkReturnQty;
            }
            set
            {
                SetPropertyValue("BulkReturnQty", ref _BulkReturnQty, value);
            }
        }

        [VisibleInListView(false)]

        public int LastDeliveryNumber
        {
            get => lastDeliveryNumber;
            set => SetPropertyValue(nameof(LastDeliveryNumber), ref lastDeliveryNumber, value);
        }

        [VisibleInListView(false)]
        public int LastSerialNumber
        {
            get => lastSerialNumber;
            set => SetPropertyValue(nameof(LastSerialNumber), ref lastSerialNumber, value);
        }


        public Boolean SendFile
        {
            get
            {
                return _sendFile;
            }
            set
            {
                SetPropertyValue("SendFile", ref _sendFile, value);
            }
        }


        [VisibleInListView(false)]
        [Size(254)]
        public string BulkRtnComment
        {
            get
            {
                return _BulkRtnComment;
            }
            set
            {
                SetPropertyValue("BulkRtnComment", ref _BulkRtnComment, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LabelCaseQty
        {
            get => labelCaseQty;
            set => SetPropertyValue(nameof(LabelCaseQty), ref labelCaseQty, value);
        }




        [Association("RepackLots-RepackLotSerialNos")]
        public XPCollection<RepackLotSerialNo> RepackLotSerialNo
        {
            get
            {
                return GetCollection<RepackLotSerialNo>(nameof(RepackLotSerialNo));
            }
        }


        [Association("RepackLots-RepackLotOperations")]
        public XPCollection<RepackLotOperations> RepackLotOperations
        {
            get
            {
                return GetCollection<RepackLotOperations>("RepackLotOperations");
            }
        }

        [VisibleInListView(false)]
        public decimal OldId
        {
            get
            {
                return _OldId;
            }
            set
            {
                SetPropertyValue("OldId", ref _OldId, value);
            }
        }

        [Association("RepackLots-RepackLotGenerates")]
        public XPCollection<RepackLotGenerate> RepackLotGenerates
        {
            get
            {
                return GetCollection<RepackLotGenerate>(nameof(RepackLotGenerates));
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
