using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using FDBAPI;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
namespace RX2_Office.Module.BusinessObjects
{
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions]

    [ListViewFilter("All Active", "[IsActive] == True", "Active Items", "Active Items", false)]
    
    [ListViewFilter(" Items In Inventory", "[QtyOnHand] <> 0", "Items In Inventory", "Items In Inventory", false)]
    [ListViewFilter("17856 In Inventory ", "[ItemNumber] Like '17856%' and [QtyOnHand] <> 0  ", "17856 In Inventory", "17856 Items in Inventory", false)]
    [ListViewFilter("All 17856 ", "[ItemNumber] Like '17856%' ", "All 17856 ", "All Items that start with 17856", false)]

    [ListViewFilter(" Items On PO", "[QtyOnPo] > 0", "Items On PO", "Items On Po", false)]
    [ListViewFilter(" All", "")]
    [NavigationItem("Inventory")]
    [ImageName("Inventory")]
    [DefaultProperty("ItemNumber")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]


    [Appearance("ExpiredDEA1", AppearanceItemType = "ViewItem", TargetItems = "MinPrice",
    Criteria = "[MinPrice] > [StdPrice]", Context = "ListView", FontColor = "Maroon", BackColor = "Yellow", Priority = 2)]


    [Appearance("MinPriceZero", AppearanceItemType = "ViewItem", TargetItems = "MinPrice",
    Criteria = "[MinPrice] = 0", Context = "ListView", FontColor = "White", BackColor = "Red", Priority = 1)]


    [Appearance("OnHand", AppearanceItemType = "ViewItem", TargetItems = "*",
    Criteria = "[QtyOnHand] > 0", Context = "ListView", FontColor = "Green", BackColor = "White", Priority = 1)]


    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Items : XPBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).

        public Items(Session session)
            : base(session)
        {
        }
        protected Items()
        {

        }
        protected Items(Session session, DevExpress.Xpo.Metadata.XPClassInfo classInfo)
            : base(session, classInfo)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            CreatedDate = DateTime.Now;
            CreatedBy = SecuritySystem.CurrentUserName;
            IsActive = true;
            string sHasSerial = ConfigurationManager.AppSettings["Items-HasSerial"]; ;
            if (sHasSerial != null & (sHasSerial == "1" | sHasSerial.ToLower() == "true"))
            {
                HasSerial = true;
            }
            else
            {
                HasSerial = false;
            }


        }



        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}



        // Fields...


        string nDCWithDashes;
        bool isActive;
        string labelName30;
        string strengthUnit;
        eNDCFormatCode fDAFormat;
        string saleMrgFlagNote;
        bool saleMGRFlag;
        DateTime intergrationDate;
        int repPerDayAllocation;
        //VendorItemPricing vendorItemPricing;
        string nDC;
        string gtnId;
        private bool integrate;
        private string _GenericName;
        private double _QtyOnPurchaseOrder;
        private decimal _QtyBeingProduced;
        private decimal _QtyOnWo;
        private string _PackageDescription;
        private DrugFormCode _DrugFormCode;
        private bool _IsWebItem;
        private Vendor _LastPurchaseFrom;
        private decimal _LastReceiptUnitCost;
        private DateTime _LastReceiptDate;
        private DateTime _LastAccountingupdate;
        private string _GTI;
        private string _GNC;
        private string _GNC_Sequence;
        private decimal _ManfAWP;
        private decimal _AWP;
        private decimal _MinPrice;
        private decimal _StdPrice;
        private decimal _QtyOnSalesOrder;
        private string _BrandName;
        private string _AdditionalDescription;
        private string _GenericKey;
        private bool _IsRefrigerated;
        private bool _AppearsOnDailyMed;
        private bool _IsSupplement;
        private bool _HasSerial;
        private DateTime _DEARegistrationSubmittedDate;
        private DateTime _DeaRegistrationDate;
        private bool _NeedsTransHistory = true;
        private string _FormCode;
        private DeaClassEnum _DeaClass;
        private string _ProductName;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private bool _RefrigerateAfterOpening;
        private string _OriginalNDC;
        private string _Strength;
        private decimal _PackageSize;
        private string _BarCode;
        private string _AccountingNumber;
        private string _ItemDescription;
        private string _ItemNumber;
        private decimal _CommissionRate;
        private decimal _avgWeightedCost;
        private decimal _avgCost;
        private decimal _lastPurchaseCost;

        private decimal _Width;
        private decimal _Height;
        private decimal _Weight;

        private ItemTypes _ItemType;
        private eCommissionMethod _CommissionMethod;
        private ItemProductLine _ProductLine;
        private Vendor _PrimaryVendor;
        private ItemUnitOfMeasure _SalesUnitOfMeasure;
        private ItemUnitOfMeasure _PurchaseUnitOfMeasure;
        private ItemUnitOfMeasure _StandardUnitOfMeasure;

        [Key]
        [Size(20)]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [Indexed(Unique = true)]
        [RuleRequiredField()]
        public string ItemNumber
        {
            get
            {
                return _ItemNumber;
            }
            set
            {
                SetPropertyValue("ItemNumber", ref _ItemNumber, value);
                if (!IsLoading)
                {
                    if (this.BarCode == null)
                    {
                        this.BarCode = _ItemNumber == null ? null : this.ItemNumber;
                    }

                    checkPropertiesWithFDB();
                }
                //if (!IsLoading & this.AccountingNumber == null)
                //{
                //    this.AccountingNumber = _ItemNumber == null ? null : this.ItemNumber;
                //}
            }
        }

        [Indexed(Unique = false)]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [Size(254)]
        [RuleRequiredField()]
        public string ItemDescription
        {
            get
            {
                return _ItemDescription;
            }
            set
            {
                SetPropertyValue("ItemDescription", ref _ItemDescription, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]


        public string ItemNumberDescription
        {
            get
            {
                return AccountingNumber + ":  " + ItemDescription;
            }

        }


        [Size(64)]
        public string LabelName30
        {
            get => labelName30;
            set => SetPropertyValue(nameof(LabelName30), ref labelName30, value);
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField()]
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
        [Size(10)]
        [RuleRequiredField()]

        public string NDC
        {
            get => nDC;
            set => SetPropertyValue(nameof(NDC), ref nDC, value);
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AccountingNumber
        {
            get
            {
                return _AccountingNumber;
            }
            set
            {
                SetPropertyValue("AccountingNumber", ref _AccountingNumber, value);
            }
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NDCWithDashes
        {
            get => nDCWithDashes;
            set => SetPropertyValue(nameof(NDCWithDashes), ref nDCWithDashes, value);
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]

        [Size(25)]
        public string BarCode
        {
            get
            {
                return _BarCode;
            }
            set
            {
                SetPropertyValue("BarCode", ref _BarCode, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [RuleRequiredField()]
        [Size(128)]
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                SetPropertyValue("ProductName", ref _ProductName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BrandName
        {
            get
            {
                return _BrandName;
            }
            set
            {
                SetPropertyValue("BrandName", ref _BrandName, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string GNC_Sequence
        {
            get
            {
                return _GNC_Sequence;
            }
            set
            {
                SetPropertyValue("GNC_Sequence", ref _GNC_Sequence, value);
            }
        }

        [Indexed]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string GNC
        {
            get
            {
                return _GNC;
            }
            set
            {
                SetPropertyValue("GNC", ref _GNC, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(1)]
        public string GTI
        {
            get
            {
                return _GTI;
            }
            set
            {
                SetPropertyValue("GTI", ref _GTI, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(255)]
        public string AdditionalDescription
        {
            get
            {
                return _AdditionalDescription;
            }
            set
            {
                SetPropertyValue("AdditionalDescription", ref _AdditionalDescription, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(25)]
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

        [Size(10)]
        public string StrengthUnit
        {
            get => strengthUnit;
            set => SetPropertyValue(nameof(StrengthUnit), ref strengthUnit, value);
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string OriginalNDC
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
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PackageDescription
        {
            get
            {
                return _PackageDescription;
            }
            set
            {
                SetPropertyValue("PackageDescription", ref _PackageDescription, value);
            }
        }
        
        public bool IsActive
        {
            get => isActive;
            set => SetPropertyValue(nameof(IsActive), ref isActive, value);
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        bool hosptial;
        public bool Hosptial
        {
            get
            {
                return hosptial;
            }
            set
            {
                SetPropertyValue(nameof(Hosptial), ref hosptial, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool IsRefrigerated
        {
            get
            {
                return _IsRefrigerated;
            }
            set
            {
                SetPropertyValue("IsRefrigerated", ref _IsRefrigerated, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool RefrigerateAfterOpening
        {
            get
            {
                return _RefrigerateAfterOpening;
            }
            set
            {
                SetPropertyValue("RefrigerateAfterOpening", ref _RefrigerateAfterOpening, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        public decimal PackageSize
        {
            get
            {
                return _PackageSize;
            }
            set
            {
                SetPropertyValue("PackageSize", ref _PackageSize, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(50)]
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

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime CreatedDate
        {
            get
            {

                // i.LastInvoiceDate = DateTime.Now;
                return _CreatedDate;
            }
            set
            {
                SetPropertyValue("CreatedDate", ref _CreatedDate, value);
            }
        }


        [Association("ItemProductLine-Items")]
        public ItemProductLine ProductLine
        {
            get
            {
                return _ProductLine;
            }
            set
            {
                SetPropertyValue("ProductLine", ref _ProductLine, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        public decimal Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                SetPropertyValue("Weight", ref _Weight, value);
            }
        }
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal Height
        {
            get
            {
                return _Height;
            }
            set
            {
                SetPropertyValue("Height", ref _Height, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        public decimal Width
        {
            get
            {
                return _Width;
            }
            set
            {
                SetPropertyValue("Width", ref _Width, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
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
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", ".#####")]
        [ModelDefault("DisplayFormat", "{0:P}")]
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
        [Size(5)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("ItemUnitOfMeasure-ItemStandardUnitOfMeasure")]

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

        [RuleRequiredField]
        public DeaClassEnum DeaClass
        {
            get
            {
                return _DeaClass;
            }
            set
            {
                SetPropertyValue("DeaClass", ref _DeaClass, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(128)]
        public string FormCode
        {
            get
            {
                return _FormCode;
            }
            set
            {
                SetPropertyValue("FormCode", ref _FormCode, value);
            }
        }

        [Size(5)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("ItemUnitOfMeasure-ItemPurchaseUnitOfMeasure")]
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
        [VisibleInLookupListView(false)]
        public DateTime DeaRegistrationDate
        {
            get
            {
                return _DeaRegistrationDate;
            }
            set
            {
                SetPropertyValue("DeaRegistrationDate", ref _DeaRegistrationDate, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime DEARegistrationSubmittedDate
        {
            get
            {
                return _DEARegistrationSubmittedDate;
            }
            set
            {
                SetPropertyValue("DEARegistrationSubmittedDate", ref _DEARegistrationSubmittedDate, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool HasSerial
        {
            get
            {
                return _HasSerial;
            }
            set
            {
                SetPropertyValue("HasSerial", ref _HasSerial, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool IsSupplement
        {
            get
            {
                return _IsSupplement;
            }
            set
            {
                SetPropertyValue("IsSupplement", ref _IsSupplement, value);
            }
        }

        [Size(10)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("ItemUnitOfMeasure-ItemSalesUnitOfMeasure")]
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
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string GenericKey
        {
            get
            {
                return _GenericKey;
            }
            set
            {
                SetPropertyValue("GenericKey", ref _GenericKey, value);
            }
        }

        //[RuleRequiredField(CustomMessageTemplate = "Must have 10 digits")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GtnId
        {
            get => gtnId;
            set => SetPropertyValue(nameof(GtnId), ref gtnId, value);
        }

        public int RepPerDayAllocation
        {
            get => repPerDayAllocation;
            set => SetPropertyValue(nameof(RepPerDayAllocation), ref repPerDayAllocation, value);
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool AppearsOnDailyMed
        {
            get
            {
                return _AppearsOnDailyMed;
            }
            set
            {
                SetPropertyValue("AppearsOnDailyMed", ref _AppearsOnDailyMed, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public DateTime LastAccountingupdate
        {
            get
            {
                return _LastAccountingupdate;
            }
            set
            {
                SetPropertyValue("LastAccountingupdate", ref _LastAccountingupdate, value);
            }
        }


        public DateTime IntergrationDate
        {
            get => intergrationDate;
            set => SetPropertyValue(nameof(IntergrationDate), ref intergrationDate, value);
        }


        [Association("Items-Transactions")]
        public XPCollection<ItemTransaction> Transactions
        {
            get
            {
                return GetCollection<ItemTransaction>("Transactions");
            }
        }

        [Association("Items-ItemInventorys")]
        public XPCollection<ItemInventory> Inventory
        {
            get
            {
                return GetCollection<ItemInventory>("Inventory");
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("Vendor-Items")]
        public Vendor PrimaryVendor
        {
            get
            {
                return _PrimaryVendor;
            }
            set
            {
                SetPropertyValue("PrimaryVendor", ref _PrimaryVendor, value);
            }
        }
        [Association("Items-PoLines")]
        public XPCollection<ItemPurchaseOrderLine> PoLines
        {
            get
            {
                return GetCollection<ItemPurchaseOrderLine>("PoLines");
            }
        }
        [Association("Items-ItemReceivers")]
        public XPCollection<ItemReceiver> ItemReceiver
        {
            get
            {
                return GetCollection<ItemReceiver>("ItemReceiver");
            }
        }
        [Association("Items-ItemPricingGroupLists")]
        public XPCollection<ItemPricingGroupList> ItemPricingGroup
        {
            get
            {
                return GetCollection<ItemPricingGroupList>("ItemPricingGroup");
            }
        }
        [Association("Items-RepackCustomerFormularysOrignalNDC")]
        public XPCollection<RepackCustomerFormulary> CustomerFormularyItem
        {
            get
            {
                return GetCollection<RepackCustomerFormulary>("CustomerFormularyItem");
            }
        }


        [Association("Items-WorkordersOrignialNDC")]
        public XPCollection<WorkOrders> WoOriginalNDC
        {
            get
            {
                return GetCollection<WorkOrders>("WoOriginalNDC");
            }
        }

        [Association("Items-WorkOrdersNewNdc")]
        public XPCollection<WorkOrders> NewNDC
        {
            get
            {
                return GetCollection<WorkOrders>("NewNDC");
            }
        }
        [Association("Items-ItemT3HeaderTemplates")]
        public XPCollection<ItemT3HeaderTemplate> ItemT3TemplateHeader
        {
            get
            {
                return GetCollection<ItemT3HeaderTemplate>("ItemT3TemplateHeader");
            }
        }

        [Association("Items-CustomerInvoiceHistoryDetails")]
        public XPCollection<CustomerInvoiceHistoryDetails> InvoiceHistoryDetail
        {
            get
            {
                return GetCollection<CustomerInvoiceHistoryDetails>("InvoiceHistoryDetail");
            }
        }

        [Association("Items-ItemMinChangeHistorys")]
        public XPCollection<ItemMinChangeHistory> ItemMinChangeHistory
        {
            get
            {
                return GetCollection<ItemMinChangeHistory>("ItemMinChangeHistory");
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal LastPurchaseCost
        {
            get
            {
                return _lastPurchaseCost;
            }
            set
            {
                SetPropertyValue("LastPurchaseCost", ref _lastPurchaseCost, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal AvgWeightedCost
        {
            get
            {
                return _avgWeightedCost;
            }
            set
            {
                SetPropertyValue("AvgWeightedCost", ref _avgWeightedCost, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal AvgCost
        {
            get
            {
                return _avgCost;
            }
            set
            {
                SetPropertyValue("AvgCost", ref _avgCost, value);
            }
        }



        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        public decimal StdPrice
        {
            get
            {
                return _StdPrice;
            }
            set
            {
                SetPropertyValue("StdPrice", ref _StdPrice, value);
            }
        }

        [VisibleInListView(true)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        public decimal MinPrice
        {
            get
            {
                return _MinPrice;
            }
            set
            {
                SetPropertyValue("MinPrice", ref _MinPrice, value);
            }
        }

        private decimal currentPTB;
        public decimal CurrentPTB
        {
            get
            {
                return currentPTB;
            }
            set
            {
                SetPropertyValue(nameof(CurrentPTB), ref currentPTB, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        DateTime minPriceSetDate;
        public DateTime MinPriceSetDate
        {
            get
            {
                return minPriceSetDate;
            }
            set
            {
                SetPropertyValue(nameof(MinPriceSetDate), ref minPriceSetDate, value);
            }
        }



        [VisibleInLookupListView(false)]
        [VisibleInListView(false)]
        Employee setMinBy;
        [Association("Employee-ItemMinSetBy")]
        public Employee SetMinBy
        {
            get
            {
                return setMinBy;
            }
            set
            {
                SetPropertyValue("SetMinBy", ref setMinBy, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal AWP
        {
            get
            {
                return _AWP;
            }
            set
            {
                SetPropertyValue("AWP", ref _AWP, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DrugFormCode DrugFormCode
        {
            get
            {
                return _DrugFormCode;
            }
            set
            {
                SetPropertyValue("DrugFormCode", ref _DrugFormCode, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]

        public decimal ManfAWP
        {
            get
            {
                return _ManfAWP;
            }
            set
            {
                SetPropertyValue("ManfAWP", ref _ManfAWP, value);
            }
        }
        [VisibleInListView(false)]
        [ModelDefault("DisplayFormat", "{0:0}")]
        [PersistentAlias("[<ItemInventory>][ItemNumber == ^.ItemNumber].Sum(QtyOnHand )")]
        public decimal QtyOnHand
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDecimal(EvaluateAlias("QtyOnHand"));
                }
                return 0;

            }
        }

        [VisibleInListView(false)]
        Decimal qtyInCheckIn;
        public Decimal QtyInCheckIn
        {
            get
            {
                return qtyInCheckIn;
            }
            set
            {
                SetPropertyValue(nameof(QtyInCheckIn), ref qtyInCheckIn, value);
            }
        }

        [VisibleInListView(false)]
        [Indexed]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal QtyOnSalesOrder
        {
            get
            {
                return _QtyOnSalesOrder;
            }
            set
            {
                SetPropertyValue("QtyOnSalesOrder", ref _QtyOnSalesOrder, value);
            }
        }
        [VisibleInListView(false)]
        [PersistentAlias("[<ItemPurchaseOrderLine>][ItemNumber == ^.ItemNumber].Sum(QtyOrdered - QtyReceived )")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public double QtyOnPo
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDouble(EvaluateAlias("QtyOnPo"));
                }
                return 0;

            }
        }


        [VisibleInListView(false)]
        public double QtyOnPurchaseOrder
        {
            get
            {
                return _QtyOnPurchaseOrder;
            }
            set
            {
                SetPropertyValue("QtyOnPurchaseOrder", ref _QtyOnPurchaseOrder, value);
            }
        }

        [VisibleInListView(false)]
        public bool SaleMGRFlag
        {
            get => saleMGRFlag;
            set => SetPropertyValue(nameof(SaleMGRFlag), ref saleMGRFlag, value);
        }


        [VisibleInListView(false)]

        [Size(255)]
        public string SaleMrgFlagNote
        {
            get => saleMrgFlagNote;
            set => SetPropertyValue(nameof(SaleMrgFlagNote), ref saleMrgFlagNote, value);
        }


        [Indexed]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal QtyOnWo
        {
            get
            {
                return _QtyOnWo;
            }
            set
            {
                SetPropertyValue("QtyOnWo", ref _QtyOnWo, value);
            }
        }

        [Indexed]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", "#,###")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal QtyBeingProduced
        {
            get
            {
                return _QtyBeingProduced;
            }
            set
            {
                SetPropertyValue("QtyBeingProduced", ref _QtyBeingProduced, value);
            }
        }

        [Indexed]
        public bool IsWebItem
        {
            get
            {
                return _IsWebItem;
            }
            set
            {
                SetPropertyValue("IsWebItem", ref _IsWebItem, value);
            }
        }





        //[Association("Items-SODetails")]
        //public XPCollection<SODetails> SODetails
        //{
        //    get
        //    {
        //        return GetCollection<SODetails>("SODetails");
        //    }
        //}




        double reorderPoint;
        public double ReorderPoint
        {
            get
            {
                return reorderPoint;
            }
            set
            {
                SetPropertyValue(nameof(ReorderPoint), ref reorderPoint, value);
            }
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eNDCFormatCode FDAFormat
        {
            get => fDAFormat;
            set => SetPropertyValue(nameof(FDAFormat), ref fDAFormat, value);
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime LastReceiptDate
        {
            get
            {
                return _LastReceiptDate;
            }
            set
            {
                SetPropertyValue("LastReceiptDate", ref _LastReceiptDate, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public decimal LastReceiptUnitCost
        {
            get
            {
                return _LastReceiptUnitCost;
            }
            set
            {
                SetPropertyValue("LastReceiptUnitCost", ref _LastReceiptUnitCost, value);
            }
        }

        [Association("Vendor-LastPurchasedFrom")]
        public Vendor LastPurchaseFrom
        {
            get
            {
                return _LastPurchaseFrom;
            }
            set
            {
                SetPropertyValue("LastPurchaseFrom", ref _LastPurchaseFrom, value);
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
        [VisibleInLookupListView(false)]
        public bool Integrate
        {
            get
            {
                return integrate;
            }
            set
            {
                SetPropertyValue("Integrate", ref integrate, value);
            }
        }


        [Association("Items-CustomerItemPricing")]
        public XPCollection<CustomerItemPricing> CustomerItemPricing
        {
            get
            {
                return GetCollection<CustomerItemPricing>("CustomerItemPricing");
            }
        }

        [Association("Items-VendorItemPricing")]
        public XPCollection<VendorItemPricing> VendorItemPricing
        {
            get
            {
                return GetCollection<VendorItemPricing>(nameof(VendorItemPricing));
            }
        }


        [Association("Items-Request")]
        public XPCollection<ItemRequest> Request
        {
            get
            {
                return GetCollection<ItemRequest>("Request");
            }
        }
        [Association("Items-CustomerCustomUDRequests")]
        public XPCollection<CustomerCustomUDRequest> CustomerCustomUDRequest
        {
            get
            {
                return GetCollection<CustomerCustomUDRequest>("CustomerCustomUDRequest");
            }
        }

        [Association("Items-RepackItems")]
        public XPCollection<RepackItems> RepackItems
        {
            get
            {
                return GetCollection<RepackItems>("RepackItems");
            }
        }
        [Association("Items-RepackItemsOriginal")]
        public XPCollection<RepackItems> RepackItemsOriginal
        {
            get
            {
                return GetCollection<RepackItems>("RepackItemsOriginal");
            }
        }
        [Association("Items-ItemPTBs")]
        public XPCollection<ItemPTB> ItemPTBs
        {
            get
            {
                return GetCollection<ItemPTB>("ItemPTBs");
            }
        }

        [Association("Items-CustomerCarts")]
        public XPCollection<CustomerCart> CartItems
        {
            get
            {
                return GetCollection<CustomerCart>(nameof(CartItems));
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
        [Association("Items-ItemWarehouseInv")]
        public XPCollection<ItemWarehouse> ItemWarehouseInv
        {
            get
            {
                return GetCollection<ItemWarehouse>(nameof(ItemWarehouseInv));
            }
        }

        [Association("Items-CustomerGPOItemPricing")]
        public XPCollection<CustomerGPOItemPricing> CustomerGPOItemPricing
        {
            get
            {
                return GetCollection<CustomerGPOItemPricing>("CustomerGPOItemPricing");
            }
        }
        //[Action(Caption = "SAP Add", ToolTip = "Add Item To SAP", ImageName = "sap", TargetObjectsCriteria = "Not [ItemDescription] Is NULL")]
        //public void SapItemAdd()
        //{
        //    SAPb1Inventory oSapItem = new SAPb1Inventory();

        //    int ret = oSapItem.AddItem(ItemNumber, ItemDescription);


        //}



        /// <summary>
        /// NDC is a 9 digit number
        /// </summary>
        /// <param name="NDC"></param>
        /// <returns></returns>
        public Int32 AddItem(string NDC)
        {

            CriteriaOperator op = GroupOperator.Combine(GroupOperatorType.And,
                new BinaryOperator("ItemNumber", NDC),
                new BinaryOperator("NDC", NDC));
            Items item = (Items)Session.FindObject(typeof(Items), op, true);


            if (item == null)
            {

                string formattedNDCNumber;
                formattedNDCNumber = NDC;
                FDBConnector fdbConnector = new FDBConnector();

                FDBResult result = fdbConnector.GetFDBDataByNDC(formattedNDCNumber.Replace("-", string.Empty)).Result;
                if (result.ErrorCode == 0)
                {
                    // FDBRootObject _rootObject = JsonConverter.DeserializeObject<FDBRootObject>(result);
                    item.ItemDescription = result.fdbRootObject.PackagedDrug.DrugNameDesc;
                    item.NDC = result.fdbRootObject.PackagedDrug.NDC;
                    item.ItemNumber = result.fdbRootObject.PackagedDrug.NDC;
                    // item.DeaClass = result.fdbRootObject.PackagedDrug.FederalDEAClassCode.ToString();
                    Save();
                    Session.CommitTransaction();
                }
            }
            return 1;
        }
        public async void checkPropertiesWithFDB()
        {
          //  Int32 ret = -1;

            FDBConnector fdbConnector = new FDBConnector();
            string ItemNoToCheck = ItemNumber.Replace("-", string.Empty);
            FDBResult result = await fdbConnector.GetFDBDataByNDC(ItemNoToCheck);
            //FDBResult result = fdbConnector.GetFDBDataByNDC(ItemNoToCheck).Result;
            if (result.ErrorCode == 0)
            {
                if (string.IsNullOrEmpty(ItemNumber)) ItemNumber = result.fdbRootObject.PackagedDrug.NDC;
                //if (FDAFormat ==null)  FDAFormat =((eNDCFormatCode)Enum.Parse(typeof(eNDCFormatCode), result.fdbRootObject.PackagedDrug.NDCFormatCode));
                if (string.IsNullOrEmpty(AccountingNumber)) AccountingNumber = result.fdbRootObject.PackagedDrug.NDCFormatted;
                if (string.IsNullOrEmpty(ItemDescription)) ItemDescription = result.fdbRootObject.PackagedDrug.DrugNameDesc;
                if ( string.IsNullOrEmpty(Strength)) Strength = result.fdbRootObject.PackagedDrug.MedStrength.ToString();
                if (string.IsNullOrEmpty(StrengthUnit)) StrengthUnit = result.fdbRootObject.PackagedDrug.MedStrengthUnit;
                if (string.IsNullOrEmpty(GenericName)) GenericName = result.fdbRootObject.PackagedDrug.GenericMedIDDesc;
                if (string.IsNullOrEmpty(GenericKey)) GenericKey = result.fdbRootObject.PackagedDrug.GenericDrugNameID;
                if (string.IsNullOrEmpty(LabelName30)) LabelName30 = result.fdbRootObject.PackagedDrug.LabelName30;
                if (string.IsNullOrEmpty(FormCode)) FormCode = result.fdbRootObject.PackagedDrug.CMSUnitTypeCode;
                if (string.IsNullOrEmpty(NDC)) NDC = result.fdbRootObject.PackagedDrug.NDC;
                if (PackageSize == 0) PackageSize = Decimal.Parse(result.fdbRootObject.PackagedDrug.CMSUnitsPerPackage);
                // if (string.IsNullOrEmpty(StandardUnitOfMeasure)) StandardUnitOfMeasure = result.fdbRootObject.PackagedDrug.PackageSizeUnitsCodeDesc;
                if (!AppearsOnDailyMed) AppearsOnDailyMed = true;
                string storagecondition =result.fdbRootObject.PackagedDrug.StorageConditionInfo.StorageConditionCode    ;


               // ret = 1;
            }
            return;
        }



        public string GetCurrentSalesrep()
        {
            string ret;
            ret = string.Empty;
            return ret;
        }

      



    }


    [DomainComponent]
    public class ReplaceAllOrEmptyParamObj
    {
        public ReplaceAllOrEmptyParamObj()
        { ReplaceAll = true; }
        public bool ReplaceAll { get; set; }
    }

}

