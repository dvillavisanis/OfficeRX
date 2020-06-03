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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("RepackItems")]
    [NavigationItem("Work Order")]
    [DefaultProperty("ItemNumber")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [ListViewFilter("Active ", "[Active] = 1  ", "Active Repack Items ", "Active Repack Item", false, Index = 0)]
    [ListViewFilter("Non Active ", " ! [Active]   ", "Non Active Repack Items ", "Non Active Repack Item", true, Index = 0)]
    [ListViewFilter("Active At Or Below Reorder ", "ReorderPoint > ItemQtyOnHand && [Active]  ", "At or below reorder Point ", "At or below Reorder", false, Index = 1)]
    [ListViewFilter("All  ", "", "All", "All Repack Item", true, Index = 99)]
        
    [Appearance("LabelLocked", Criteria = "LabelStatus = 99", Enabled = false, TargetItems = "NDCLabelName;NDCLabelDescription;NDCLabelSize;NDCLabelSize;NDCLabelContains;NDCLabelStorage;LabelDispensingInfo;LabelSizeStrength;LabelFullSSCC;LabelPartialSSCC;LabelPalletCaseQty")]
    [Appearance("*", AppearanceItemType = "ViewItem", TargetItems = "*",
     Criteria = "ReorderPoint > ItemQtyOnHand ", Context = "ListView", FontColor = "Red", Priority = 1)]

    public class RepackItems : XPBaseObject
    {
        // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

        // [VisibleInListView(false)]
        //public string date1;
        public RepackItems(Session session)
            : base(session)
        {
            //date1 = Convert.ToString(DateTime.Now.AddMonths(-1).Month.ToString());

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        protected override void OnLoading()
        {
            base.OnLoading();
            if (nDCLabelDescription == null)

            {
                if (NDC != null)
                {

                    NDCLabelDescription = NDC.ItemDescription;
                }
            }
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            //if (nDCLabelDescription == null)
            //{ NDCLabelDescription = NDC.ItemDescription;
            //    this.Save();
            //}

            if (NDCLabelStorage == null)
            {
                NDCLabelStorage = "**** Keep this and all Medication out of the reach of children";
                this.Save();
            }
        }
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch ((propertyName))
            {
                case "NDC":

                    nDCLabelDescription = NDC.ItemDescription;

                    break;
                default:
                    break;

            }



        }

        //private string _PersistentProperty;
        // [XafDisplayName("My display name"), ToolTip("My hint message")]
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

        RepackLabelStatus labelStatus;
        string senderLocationSGIN;
        string destinationLocation;
        string sSCC_EXT_DIGIT;
        string gS1CompanyPrefix;
        static string receiverLocation;
        string receiverOwnerId;
        string senderOwner;
        string bTPalletLabelTemplate;
        bool hazardous;
        string partialPalletSSCC;
        string palletSSCC;
        string defaultSGLN;
        string labelShipToLine2;
        string labelShipToLine1;
        string labelPartialSSCC;
        int labelPalletCaseQty;
        string labelFullSSCC;
        string bTShippingLabelTemplate;
        string shipperGtin;
        string nDCLabelName;
        string labelCaseQty;
        string gtin;
        Manufacturer manufacturer;
        string labelDispensingInfo;
        RepackDistributor repackDistributor;
        eSerialTypes serialType;
        Customer defaultCustomer;
        private Items _OriginalNDC;
        private Items _NDC;
        string nDCLabelStorage;
        string nDCLabelContains;
        string nDCLabelSize;
        string nDCLabelDescription;
        string bTDefualtTemplate;
        string labelSizeStrength;


        [Key]
        [Association("Items-RepackItems")]
        [VisibleInListView(true)]
        public Items NDC
        {
            get
            {
                return _NDC;
            }
            set
            {
                SetPropertyValue("ItemNumber", ref _NDC, value);
            }
        }

        [NonPersistent]
        public string ItemNumber
        {

            get
            {
                if (NDC is null)
                {
                    return "";
                }
                else
                    return NDC.AccountingNumber;


            }

        }

        [NonPersistent]
        public string ItemDescription
        {
            get
            {
                if (NDC is null)
                {
                    return "";
                }
                else
                    return NDC.ItemDescription;



            }


        }



        [NonPersistent]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal ItemQtyOnHand
        {
            get
            {
                if (NDC is null)
                {
                    return 0;
                }
                else
                    return NDC.QtyOnHand;
            }


        }



        [NonPersistent]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public Decimal ItemQtyWo
        {
            get
            {
                if (NDC is null)
                {
                    return 0;
                }
                else
                    return NDC.QtyOnWo;
            }


        }
        [VisibleInListView(false)]
        [NonPersistent]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public double ReorderPoint
        {
            get
            {
                if (NDC is null)
                {
                    return 0;
                }
                else
                    return NDC.ReorderPoint;
            }
        }
        [VisibleInListView(false)]
        public bool Hazardous
        {
            get => hazardous;
            set => SetPropertyValue(nameof(Hazardous), ref hazardous, value);
        }




        [VisibleInListView(false)]
        public eSerialTypes SerialType
        {
            get => serialType;
            set => SetPropertyValue(nameof(SerialType), ref serialType, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Gtin
        {
            get => gtin;
            set => SetPropertyValue(nameof(Gtin), ref gtin, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ShipperGtin
        {
            get => shipperGtin;
            set => SetPropertyValue(nameof(ShipperGtin), ref shipperGtin, value);
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PalletSSCC
        {
            get => palletSSCC;
            set => SetPropertyValue(nameof(PalletSSCC), ref palletSSCC, value);
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PartialPalletSSCC
        {
            get => partialPalletSSCC;
            set => SetPropertyValue(nameof(PartialPalletSSCC), ref partialPalletSSCC, value);
        }

        [VisibleInListView(false)]
        [Association("Items-RepackItemsOriginal")]
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

        [VisibleInListView(false)]
        [NonPersistent]
        public string OriginalItemNumber
        {
            get
            {
                return OriginalNDC.AccountingNumber;
            }

        }

        [VisibleInListView(false)]
        [NonPersistent]

        public string OriginalNDCDescription
        {
            get
            {
                return OriginalNDC.ItemDescription;
            }

        }

        [NonPersistent]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public Decimal OriginalQtyOnHand
        {
            get
            {
                if (OriginalNDC is null)
                {
                    return 0;
                }
                else
                    return OriginalNDC.QtyOnHand;
            }


        }


        [NonPersistent]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public Double OriginalQtyOnPO
        {
            get
            {
                if (OriginalNDC is null)
                {
                    return 0;
                }
                else
                    return OriginalNDC.QtyOnPo;
            }

        }


        bool active;
        [VisibleInListView(false)]
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                SetPropertyValue(nameof(Active), ref active, value);
            }
        }


        [VisibleInListView(false)]
        [PersistentAlias("[<CustomerInvoiceHistoryDetails>][IsThisMonth(InvoiceNumber.InvoiceDate) and ItemNumber =^.NDC].Sum(QtyShipped)")]
        public double CurrentMonth
        {
            get
            {
                if (NDC != null)
                {
                    return Convert.ToDouble(EvaluateAlias("CurrentMonth"));
                }
                return 0;

            }
        }


        



        [VisibleInListView(false)]
        [Size(100)]
        public string NDCLabelName
        {
            get => nDCLabelName;
            set => SetPropertyValue(nameof(NDCLabelName), ref nDCLabelName, value);
        }

        [VisibleInListView(false)]
        [Size(300)]
        public string NDCLabelDescription
        {
            get => nDCLabelDescription;
            set => SetPropertyValue(nameof(NDCLabelDescription), ref nDCLabelDescription, value);
        }



        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NDCLabelSize
        {
            get => nDCLabelSize;
            set => SetPropertyValue(nameof(NDCLabelSize), ref nDCLabelSize, value);
        }

        [VisibleInListView(false)]
        [Size(300)]
        public string NDCLabelContains
        {
            get => nDCLabelContains;
            set => SetPropertyValue(nameof(NDCLabelContains), ref nDCLabelContains, value);
        }


                [VisibleInListView(false)]
        [Size(300)]
        public string NDCLabelStorage
        {
            get => nDCLabelStorage;
            set => SetPropertyValue(nameof(NDCLabelStorage), ref nDCLabelStorage, value);
        }


        [VisibleInListView(false)]
        [Size(300)]
        public string LabelDispensingInfo
        {
            get => labelDispensingInfo;
            set => SetPropertyValue(nameof(LabelDispensingInfo), ref labelDispensingInfo, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LabelSizeStrength
        {
            get => labelSizeStrength;
            set => SetPropertyValue(nameof(LabelSizeStrength), ref labelSizeStrength, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LabelFullSSCC
        {
            get => labelFullSSCC;
            set => SetPropertyValue(nameof(LabelFullSSCC), ref labelFullSSCC, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LabelPartialSSCC
        {
            get => labelPartialSSCC;
            set => SetPropertyValue(nameof(LabelPartialSSCC), ref labelPartialSSCC, value);
        }

        [VisibleInListView(false)]
        public int LabelPalletCaseQty
        {
            get => labelPalletCaseQty;
            set => SetPropertyValue(nameof(LabelPalletCaseQty), ref labelPalletCaseQty, value);
        }

        [Appearance("enableLabelStatus",Criteria = "!IsCurrentUserInRole('RepackItemLabelAdmin')  ", Enabled = false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public RepackLabelStatus LabelStatus
        {
            get => labelStatus;
            set => SetPropertyValue(nameof(LabelStatus), ref labelStatus, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LabelShipToLine1
        {
            get => labelShipToLine1;
            set => SetPropertyValue(nameof(LabelShipToLine1), ref labelShipToLine1, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LabelShipToLine2
        {
            get => labelShipToLine2;
            set => SetPropertyValue(nameof(LabelShipToLine2), ref labelShipToLine2, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DefaultSGLN
        {
            get => defaultSGLN;
            set => SetPropertyValue(nameof(DefaultSGLN), ref defaultSGLN, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BTDefualtTemplate
        {
            get => bTDefualtTemplate;
            set => SetPropertyValue(nameof(BTDefualtTemplate), ref bTDefualtTemplate, value);
        }


        [Size(20)]
        public string DestinationLocation
        {
            get => destinationLocation;
            set => SetPropertyValue(nameof(DestinationLocation), ref destinationLocation, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BTPalletLabelTemplate
        {
            get => bTPalletLabelTemplate;
            set => SetPropertyValue(nameof(BTPalletLabelTemplate), ref bTPalletLabelTemplate, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BTShippingLabelTemplate
        {
            get => bTShippingLabelTemplate;
            set => SetPropertyValue(nameof(BTShippingLabelTemplate), ref bTShippingLabelTemplate, value);
        }

        [VisibleInListView(false)]
        RepackPackager defaultRepackager;
        [Association("RepackPackager-RepackItems")]
        public RepackPackager DefaultRepackager
        {
            get
            {
                return defaultRepackager;
            }
            set
            {
                SetPropertyValue(nameof(DefaultRepackager), ref defaultRepackager, value);
            }
        }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LabelCaseQty
        {
            get => labelCaseQty;
            set => SetPropertyValue(nameof(LabelCaseQty), ref labelCaseQty, value);
        }

        // [DataSourceProperty("")]
        // [DataSourceCriteria("")]
        // [DataSourceCriteriaProperty("")]

        [ImageEditor]
        [Delayed(), VisibleInListViewAttribute(true)]
        public byte[] LabelImage
        {
            get { return GetDelayedPropertyValue<byte[]>("LabelImage"); }
            set { SetDelayedPropertyValue<byte[]>("LabelImage", value); }
        }

        [Association("Customer-RepackItems")]
        public Customer DefaultCustomer
        {
            get => defaultCustomer;
            set => SetPropertyValue(nameof(DefaultCustomer), ref defaultCustomer, value);
        }

        [VisibleInListView(false)]
        [Size(25)]
        public string SenderOwnerId
        {
            get => senderOwner;
            set => SetPropertyValue(nameof(SenderOwnerId), ref senderOwner, value);
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ReceiverOwnerId
        {
            get => receiverOwnerId;
            set => SetPropertyValue(nameof(ReceiverOwnerId), ref receiverOwnerId, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GS1CompanyPrefix
        {
            get => gS1CompanyPrefix;
            set => SetPropertyValue(nameof(GS1CompanyPrefix), ref gS1CompanyPrefix, value);
        }


        [Size(1)]
        public string SSCC_EXT_DIGIT
        {
            get => sSCC_EXT_DIGIT;
            set => SetPropertyValue(nameof(SSCC_EXT_DIGIT), ref sSCC_EXT_DIGIT, value);
        }

        [VisibleInListView(false)]
        [Size(25)]
        public string ReceiverLocation
        {
            get => receiverLocation;
            set => SetPropertyValue(nameof(ReceiverLocation), ref receiverLocation, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SenderLocationSGIN
        {
            get => senderLocationSGIN;
            set => SetPropertyValue(nameof(SenderLocationSGIN), ref senderLocationSGIN, value);
        }



        [NonPersistent]
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DeaClassEnum DEACLASS
        {
            get => this.NDC.DeaClass;

        }

        [Association("Manufacturer-RepackItems")]
        public Manufacturer Manufacturer
        {

            get => manufacturer;
            set => SetPropertyValue(nameof(Manufacturer), ref manufacturer, value);
        }

        [Association("RepackDistributor-RepackItems")]
        public RepackDistributor RepackDistributor
        {
            get => repackDistributor;
            set => SetPropertyValue(nameof(RepackDistributor), ref repackDistributor, value);
        }


        [Association("RepackItems-RepackLots")]
        public XPCollection<RepackLots> RepackLots
        {
            get
            {
                return GetCollection<RepackLots>(nameof(RepackLots));
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


        //[XafDisplayName("[Convert.ToString(DateTime.Now.AddMonths(-1).Month.ToString())]")]
        [PersistentAlias("[<CustomerInvoiceHistoryDetails>][IsLastMonth(InvoiceNumber.InvoiceDate) and ItemNumber =^.NDC].Sum(QtyShipped)")]
        public double LastMonthSales
        {
            get
            {
                if (NDC != null)
                {
                    return Convert.ToDouble(EvaluateAlias("LastMonthSales"));
                }
                return 0;

            }
        }

    }
}

