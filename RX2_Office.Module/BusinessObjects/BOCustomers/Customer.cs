using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Drawing;

namespace RX2_Office.Module.BusinessObjects

{
    [NavigationItem("Sales")]
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions]
    [ListViewFilter(" My Customers ", "[SalesRep] = CurrentUserName()  ", " My Customers ", "Customers that are mine",false, Index = 0)]
    [ListViewFilter(" My Customers who Purchase In  30 Days ", "[SalesRep] = CurrentUserName() && LastInvoiceDate >=  ADDDAYS(LocalDateTimeToday(), -30) ", " My Customers who Purchase In  30 Days ", " My Customers who Purchase In  30 Days", false, Index = 1)]
    [ListViewFilter(" My Customers who Purchase In  60 Days ", "[SalesRep] = CurrentUserName() && LastInvoiceDate >=  ADDDAYS(LocalDateTimeToday(), -60) ", " My Customers who Purchase In  60 Days ", " My Customers who Purchase In  60 Days", false, Index = 2)]
    [ListViewFilter(" My Customers who Purchase In  90 Days ", "[SalesRep] = CurrentUserName() && LastInvoiceDate >=  ADDDAYS(LocalDateTimeToday(), -90) ", " My Customers who Purchase In  90 Days ", " My Customers who Purchase In  90 Days", false, Index = 3)]
    [ListViewFilter(" My Customers who Purchase In 365 Days ", "[SalesRep] = CurrentUserName() && LastInvoiceDate >=  ADDDAYS(LocalDateTimeToday(), -365)", " My Customers who Purchase In 365 Days ", " My Customers who Purchase In 365 Days", false, Index = 4)]
    [ListViewFilter(" My Customers Not Called in 30 Days", "[SalesRep] = CurrentUserName() && (LastCallDate <=  ADDDAYS(LocalDateTimeToday(), -30)  || LastCallDate is null ) ", " My Customers Not Called in 30 Days ", " My Customers Not Called in 30 Days", false, Index = 0)]
  
    // Orxsecurity filters

    [RuleCombinationOfPropertiesIsUnique("CustomerNo unique", DefaultContexts.Save, "CustomerNo" ,"Customer No: Already Exist /r Customer No Must be Unique")]
    [ImageName("Customer")]
    [Appearance("ExpiredDEA1", AppearanceItemType = "ViewItem", TargetItems = "*",
     Criteria = "Len(DeaNo) > 8 and DeaExpDate < Today()", Context = "ListView", FontColor = "Maroon", Priority = 2)]
    [Appearance("ExpiredDEA", AppearanceItemType = "ViewItem", FontStyle = FontStyle.Strikeout, TargetItems = "DeaNo, DeaExpDate",
     Criteria = "Len(DeaNo) > 8 and DeaExpDate < Today()", Context = "ListView", FontColor = "Maroon", Priority = 2)]
    [Appearance("ActiveDEA", AppearanceItemType = "ViewItem", TargetItems = "*",
     Criteria = "Len(DeaNo) > 8 and DeaExpDate > Today()", Context = "ListView", FontColor = "ForestGreen", Priority = 1)]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Customer : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Customer(Session session)
            : base(session)
        {

           // test

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            //de here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            ApplicationOptions App = Session.FindObject<ApplicationOptions>(new BinaryOperator("Ref", "1"));

            if (App != null)
            {
                
                CreditLimit = App.DefaultSalesCreditLimit;
                this.CustomerNo = GetNextCustomerNumber();
                
            }
           //set default values

            CreditHold = false;
            string CurrentUserName = SecuritySystem.CurrentUserName;
            UnitCount = 0;
            
        }
        
        public void AddNote(Customer cust, String Note)
        {
            //IObjectSpace objectSpace = CreateObject(objectSpace);
            //CustomerNote cn = objectSpace.CreateObject<CustomerNote>();

            CustomerNote cn = new CustomerNote(Session);
            cn.Author = SecuritySystem.CurrentUserName;
            cn.Customers = cust;
            cn.NoteDate = DateTime.Now;
            cn.Text = Note;
            cn.Save();
            
        }


        [Action(Caption = "Check Data", ConfirmationMessage = "Check Data?", ImageName = "lock", AutoCommit = true, TargetObjectsCriteria = "IsCurrentUserInRole('CustomerCheckData') && CheckData = 0")]
        public void ContactLock()
        {
            
            this.CheckData = true;

        }


        [Action(Caption = "UnLock", ConfirmationMessage = "Finished Checking Data?", ImageName = "lock_off", AutoCommit = true, TargetObjectsCriteria = "IsCurrentUserInRole('CustomerCheckData') && CheckData = 1")]
        public void ContactUnLock()
        {
            this.CheckData = false;
        }





        public decimal GetCustomerItemPrice(Customer Cust, Items ItemNo)
        {
            return GetCustomerItemPrice(Cust, ItemNo, false);
        }

        public decimal GetCustomerItemPrice(Customer Cust, Items ItemNo, bool isWeb)
        {
            // 1st Check Customer Items
            // 2nd check Customer Pricing group
            // 3rd if web order check web price

            CustomerItemPricing CIP = Session.FindObject<CustomerItemPricing>(CriteriaOperator.Parse("Customer = ? and Item = ?", Cust.Oid, ItemNo.ItemNumber));
            if (CIP != null)
            { return CIP.CustomerPrice; }

            //Check for item in pricing group
            if (Cust.CustomerPricingGroup != null)
            {
                ItemPricingGroupList IPGL = Session.FindObject<ItemPricingGroupList>(CriteriaOperator.Parse("ItemPricingGroup = ? and Item = ?", Cust.CustomerPricingGroup.Oid, ItemNo.ItemNumber));
                if (IPGL != null)
                {
                    return IPGL.GroupPrice;
                }
            }
            if (isWeb)
            // get web oid
            {
                ItemPricingGroup IPG = Session.FindObject<ItemPricingGroup>(CriteriaOperator.Parse("ItemGroupCd = ? ", "WEB"));
                if (IPG != null)
                {
                    ItemPricingGroupList IPGL = Session.FindObject<ItemPricingGroupList>(CriteriaOperator.Parse("ItemPricingGroup = ? and Item = ?", Cust.CustomerPricingGroup.Oid, ItemNo.ItemNumber));
                    IPGL = Session.FindObject<ItemPricingGroupList>(CriteriaOperator.Parse("ItemPricingGroup = ? and Item = ?", IPG.Oid, ItemNo.ItemNumber));
                    if (IPGL != null)
                    {
                        return IPGL.GroupPrice;
                    }
                }
            }
            return ItemNo.StdPrice;

        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch ((propertyName))
            {
                case "BillingAddress":
                    if (ShipAddress == null)
                    {
                        ShipAddress = BillingAddress;

                    }
                    break;
                case "BillingAddress2":
                    if (ShipAddress2 == null)
                    { ShipAddress2 = BillingAddress2; }
                    break;

                case "BillingAddress3":
                    if (ShipAddress3 == null)
                    { ShipAddress3 = BillingAddress3; }
                    break;
                case "BillingCity":
                    if (ShipCity == null) { ShipCity = BillingCity; }
                    break;
                case "BillingState":
                    if (ShipState == null) { ShipState = BillingState; };
                    break;
                case "BillingZip":
                    if (ShipZip == null) { ShipZip = BillingZip; }
                    break;
                default:

                    break;
            }
        }


 
      
        bool checkData;
        string linkedIn;
        static decimal customerSalesGoal;
        double customerGpGoal;
        bool creditHold;
        DateTime sAPEditDate;
        DateTime sapEnteredDt;
        decimal commissionSplitWithPct;
        //  SalesRep commissionSplitWith;
        bool isCommissionSplit;
        bool cV;
        bool cIV;
        bool cIII;
        bool cII;
        bool cI;
        eDeaType deaType;
        string customerSGLN;
        string customerGLN;
        private bool _OnlyCustomerItems;
        private DateTime _DEALastVerifiedDate;
        private string _DEALastverifiedby;
        private ItemPricingGroup _CustomerPricingGroup;
        private string _CustomerShippingAccount;
        private DateTime _LastCallDate;
        private DateTime _LastInvoiceDate;
        private double _OrderCount;
        private CustomerIDN _IDN;
        private DateTime _LastAccountingUpdate;
        private double _SalesGoals;
        private DateTime _SalesRepAssignedDt;
        private DateTime _StateLicExpDate;
        private string _StateLicense;
        private ShippingType _ShippingType;
        private decimal _OldId;
        private Decimal _CreditLimit;
        private string _FederalTaxId;
        private DateTime _DeaExpDate;
        private decimal _Longitude;
        private decimal _Latitude;
        private InvoiceType _CustomerInvoiceType;
        private string _InvoiceFax;
        private string _InvoiceEmail;
        private string _ShippingNotes;
        private CustomerClassification _Classification;
        private CustomerGPO _CustomerGPO;
        private CustomerParentSystem _CustomerParentSystem;
        private SalesRep _SalesRep;
        private Wholesaler _Wholesaler;
        private State _ShipState;
        private State _BillingState;
        private float _LegacyId;
        private string _CreatedBy;
        private DateTime _CreatedDate;
        private string _DeaNo;
        private string _Website;
        private int _UnitCount;
        private string _Fax;
        private string _Phone;
        private string _ShipZip;
        private string _BillingZip;
        private string _ShipCity;
        private string _ShipAddress3;
        private string _ShipAddress2;
        private string _ShipAddress;
        private string _BillingCity;
        private string _BillingAddress3;
        private string _BillingAddress2;
        private string _BillingAddress;
        private string _CustomerNo;
        private string _CustomerName;
        CustomerBillingTerms _billingTerms;

        [Indexed]
        [Size(128)]
        [Index(1)]
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                SetPropertyValue("CustomerName", ref _CustomerName, value);
            }
        }
        [Indexed]
        [Index(0)]
        public string CustomerNo
        {
            get
            {
                return _CustomerNo;
            }
            set
            {
                SetPropertyValue("CustomerNo", ref _CustomerNo, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CustomerGLN
        {
            get => customerGLN;
            set => SetPropertyValue(nameof(CustomerGLN), ref customerGLN, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CustomerSGLN
        {
            get => customerSGLN;
            set => SetPropertyValue(nameof(CustomerSGLN), ref customerSGLN, value);
        }

        [VisibleInListView(false)]
        public string BillingAddress
        {
            get
            {
                return _BillingAddress;
            }
            set
            {
                SetPropertyValue("BillingAddress", ref _BillingAddress, value);
            }
        }

        [Appearance("BillingAddressisempty", Criteria = "IsNullOrEmpty(BillingAddress)", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
        public string BillingAddress2
        {
            get
            {
                return _BillingAddress2;
            }
            set
            {
                SetPropertyValue("BillingAddress2", ref _BillingAddress2, value);
            }
        }

        [Appearance("BillingAddress2isempty", Criteria = "IsNullOrEmpty(BillingAddress2)", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
        public string BillingAddress3
        {
            get
            {
                return _BillingAddress3;
            }
            set
            {
                SetPropertyValue("BillingAddress3", ref _BillingAddress3, value);
                if (!IsLoading & this.ShipAddress3 == null)
                {
                    this.ShipCity = BillingAddress3 == null ? null : this.BillingAddress3;
                }

            }
        }
        [VisibleInListView(false)]
        public string BillingCity
        {
            get
            {
                return _BillingCity;
            }
            set
            {
                SetPropertyValue("BillingCity", ref _BillingCity, value);
                if (!IsLoading & this.ShipCity == null)
                {
                    this.ShipCity = BillingCity == null ? null : this.BillingCity;
                }
            }
        }
        [VisibleInListView(false)]
        [Association("State-CustomersBill")]
        public State BillingState
        {
            get
            {
                return _BillingState;
            }
            set
            {
                SetPropertyValue("BillingState", ref _BillingState, value);
            }
        }

        [VisibleInListView(false)]
        public string BillingZip
        {
            get
            {
                return _BillingZip;
            }
            set
            {
                SetPropertyValue("BillingZip", ref _BillingZip, value);
                if (!IsLoading & this.ShipZip == null)
                {
                    this.ShipZip = BillingZip == null ? null : this.BillingZip;
                }
            }
        }
        [VisibleInListView(false)]
        public string ShipAddress
        {
            get
            {
                return _ShipAddress;
            }
            set
            {
                SetPropertyValue("ShipAddress", ref _ShipAddress, value);

            }
        }
        [Appearance("ShipAddressisempty", Criteria = "IsNullOrEmpty(ShipAddress)", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
        public string ShipAddress2
        {
            get
            {
                return _ShipAddress2;
            }
            set
            {
                SetPropertyValue("ShipAddress2", ref _ShipAddress2, value);
            }
        }

        [Appearance("ShipAddress2isempty", Criteria = "IsNullOrEmpty(ShipAddress2)", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
        public string ShipAddress3
        {
            get
            {
                return _ShipAddress3;
            }
            set
            {
                SetPropertyValue("ShipAddress3", ref _ShipAddress3, value);
            }
        }
        [VisibleInListView(false)]
        public string ShipCity
        {
            get
            {
                return _ShipCity;
            }
            set
            {
                SetPropertyValue("ShipCity", ref _ShipCity, value);
            }
        }


        [VisibleInListView(false)]
        [Association("State-CustomersShip")]
        public State ShipState
        {
            get
            {
                return _ShipState;
            }
            set
            {
                SetPropertyValue("ShipState", ref _ShipState, value);
            }
        }
        [VisibleInListView(false)]
        public string ShipZip
        {
            get
            {
                return _ShipZip;
            }
            set
            {
                SetPropertyValue("ShipZip", ref _ShipZip, value);
            }
        }
        [Index(4)]

        [Size(15)]
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        }

        [VisibleInListView(false)]
        [ModelDefault("DisplayFormat", "0:(000)000-0000")]

        [ModelDefault("EditFormat", "(999) 000-0000")]
        [Size(15)]
        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                SetPropertyValue("Fax", ref _Fax, value);
            }
        }

        [VisibleInListView(false)]
        public int UnitCount
        {
            get
            {
                return _UnitCount;
            }
            set
            {
                SetPropertyValue("BedCount", ref _UnitCount, value);
            }
        }

        bool marked;
        [VisibleInListView(false)]

        public bool Marked
        {
            get => marked;
            set => SetPropertyValue(nameof(Marked), ref marked, value);
        }


        [Size(255)]
        [VisibleInListView(false)]
        public string Website
        {
            get
            {
                return _Website;
            }
            set
            {
                SetPropertyValue("Website", ref _Website, value);
            }
        }

        [Index(2)]

        public string DeaNo
        {
            get
            {
                return _DeaNo;
            }
            set
            {
                SetPropertyValue("DeaNo", ref _DeaNo, value);
            }
        }

        [Appearance("DeaNoisempty", Criteria = "IsNullOrEmpty(DeaNo)", Enabled = false, Context = "DetailView")]

        [Index(3)]
        public DateTime DeaExpDate
        {
            get
            {
                return _DeaExpDate;
            }
            set
            {
                SetPropertyValue("DeaExpDate", ref _DeaExpDate, value);
            }
        }

        [Appearance("DeaNoisempty1", Criteria = "IsNullOrEmpty(DeaNo)", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eDeaType DeaType
        {
            get => deaType;
            set => SetPropertyValue(nameof(DeaType), ref deaType, value);
        }

        [VisibleInListView(false)]
        public bool CI
        {
            get => cI;
            set => SetPropertyValue(nameof(CI), ref cI, value);
        }
        
      
        [VisibleInListView(false)]
        public bool CII
        {
            get => cII;
            set => SetPropertyValue(nameof(CII), ref cII, value);
        }

        [VisibleInListView(false)]
        public bool CIII
        {
            get => cIII;
            set => SetPropertyValue(nameof(CIII), ref cIII, value);
        }

        [VisibleInListView(false)]
        public bool CIV
        {
            get => cIV;
            set => SetPropertyValue(nameof(CIV), ref cIV, value);
        }

        [VisibleInListView(false)]
        public bool CV
        {
            get => cV;
            set => SetPropertyValue(nameof(CV), ref cV, value);
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DEALastVerifiedBy
        {
            get
            {
                return _DEALastverifiedby;
            }
            set
            {
                SetPropertyValue("DEALastVerifiedBy", ref _DEALastverifiedby, value);
            }
        }


        [VisibleInListView(false)]
        public DateTime DEALastVerifiedDate
        {
            get
            {
                return _DEALastVerifiedDate;
            }
            set
            {
                SetPropertyValue("DEALastVerifiedDate", ref _DEALastVerifiedDate, value);
            }
        }



        [VisibleInListView(false)]
        [Size(25)]
        public string StateLicense
        {
            get
            {
                return _StateLicense;
            }
            set
            {
                SetPropertyValue("StateLicense", ref _StateLicense, value);
            }
        }

        [VisibleInListView(false)]

        public DateTime StateLicExpDate
        {
            get
            {
                return _StateLicExpDate;
            }
            set
            {
                SetPropertyValue("StateLicExpDate", ref _StateLicExpDate, value);
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
                SetPropertyValue("CreatedDate", ref _CreatedDate, value);
            }
        }

        [VisibleInListView(false)]
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
        public float LegacyId
        {
            get
            {
                return _LegacyId;
            }
            set
            {
                SetPropertyValue("OldPmasid", ref _LegacyId, value);
            }
        }

        [VisibleInListView(false)]
        [Size(255)]
        public string LinkedIn
        {
            get => linkedIn;
            set => SetPropertyValue(nameof(LinkedIn), ref linkedIn, value);
        }


        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        [DbType("decimal(18,8)")]
        [VisibleInListView(false)]
        public decimal Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                SetPropertyValue("Latitude", ref _Latitude, value);
            }
        }
        [DbType("decimal(18,8)")]
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        [VisibleInListView(false)]
        public decimal Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                SetPropertyValue("Longitude", ref _Longitude, value);
            }
        }


        [Size(20)]
        [Association("SalesRep-Customers")]
        public SalesRep SalesRep
        {
            get
            {
                return _SalesRep;
            }
            set
            {
                SetPropertyValue("SalesRep", ref _SalesRep, value);
            }
        }



        [VisibleInListView(false)]
        public DateTime SalesRepAssignedDt
        {
            get
            {
                return _SalesRepAssignedDt;
            }
            set
            {
                SetPropertyValue("SalesRepAssignedDt", ref _SalesRepAssignedDt, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]

        public DateTime LastAccountingUpdate
        {
            get
            {
                return _LastAccountingUpdate;
            }
            set
            {
                SetPropertyValue("LastAccountingUpdate", ref _LastAccountingUpdate, value);
            }
        }

        [VisibleInListView(false)]
        [Association("Wholesaler-Customers"), ExplicitLoading]
        public Wholesaler Wholesaler
        {
            get
            {
                return _Wholesaler;
            }
            set
            {
                SetPropertyValue("Wholesaler", ref _Wholesaler, value);
            }
        }



        [VisibleInListView(false)]
        [Association("ItemPricingGroup-Customers")]
        public ItemPricingGroup CustomerPricingGroup
        {
            get
            {
                return _CustomerPricingGroup;
            }
            set
            {
                SetPropertyValue("CustomerPricingGroup", ref _CustomerPricingGroup, value);
            }
        }

        [Association("Customer-CustomerNotes")]
        public XPCollection<CustomerNote> CustomerNotes
        {
            get
            {
                return GetCollection<CustomerNote>("CustomerNotes");
            }
        }
        [VisibleInListView(false)]
        public double CustomerGpGoal
        {
            get => customerGpGoal;
            set => SetPropertyValue(nameof(CustomerGpGoal), ref customerGpGoal, value);
        }

        [VisibleInListView(false)]
        public decimal CustomerSalesGoal
        {
            get => customerSalesGoal;
            set => SetPropertyValue(nameof(CustomerSalesGoal), ref customerSalesGoal, value);
        }

        [Association("Customer-CustomerContacts")]
        public XPCollection<CustomerContact> CustomerContacts
        {
            get
            {
                return GetCollection<CustomerContact>("CustomerContacts");
            }
        }

        [Association("Customer-MarketingGroupCustomers")]
        public XPCollection<MarketingGroupCustomers> MarketingGroups
        {
            get
            {
                return GetCollection<MarketingGroupCustomers>("MarketingGroups");
            }
        }


        [Association("Customer-SOHeaders")]
        public XPCollection<SOHeader> SalesOrder
        {
            get
            {
                return GetCollection<SOHeader>("SalesOrder");
            }
        }
        [VisibleInListView(false)]
        [Association("CustomerParentSystem-Customers")]
        public CustomerParentSystem CustomerParentSystem
        {
            get
            {
                return _CustomerParentSystem;
            }
            set
            {
                SetPropertyValue("CustomerParentSystem", ref _CustomerParentSystem, value);
            }
        }


        [VisibleInListView(false)]
        [Association("CustomerGPO-Customers")]
        public CustomerGPO CustomerGPO
        {
            get
            {
                return _CustomerGPO;
            }
            set
            {
                SetPropertyValue("CustomerGPO", ref _CustomerGPO, value);
            }
        }

        [Association("Customer-CustomerLicenseVerifications")]
        public XPCollection<CustomerLicenseVerifications> CustomerLicenseVerifications
        {
            get
            {
                return GetCollection<CustomerLicenseVerifications>("CustomerLicenseVerifications");
            }
        }

        [VisibleInListView(false)]
        public string InvoiceFax
        {
            get
            {
                return _InvoiceFax;
            }
            set
            {
                SetPropertyValue("InvoiceFax", ref _InvoiceFax, value);
            }
        }
        [Size(32)]
        [VisibleInListView(false)]
        public string FederalTaxId
        {
            get
            {
                                
                return _FederalTaxId;
            }
            set
            {
                SetPropertyValue("FederalTaxId", ref _FederalTaxId, value);
            }
        }
        [VisibleInListView(false)]
        public InvoiceType CustomerInvoiceType
        {
            get
            {
                return _CustomerInvoiceType;
            }
            set
            {
                SetPropertyValue("CustomerInvoiceType", ref _CustomerInvoiceType, value);
            }
        }

        [VisibleInListView(false)]
        public Decimal CreditLimit
        {
            get
            {
                return _CreditLimit;
            }
            set
            {
                SetPropertyValue("CreditLimit", ref _CreditLimit, value);
            }
        }

        public bool CreditHold
        {
            get => creditHold;
            set => SetPropertyValue(nameof(CreditHold), ref creditHold, value);
        }

        [Size(255)]
        [VisibleInListView(false)]
        public string InvoiceEmail
        {

            get
            {
                return _InvoiceEmail;
            }
            set
            {
                SetPropertyValue("InvoiceEmail", ref _InvoiceEmail, value);
            }
        }



        [Size(254)]
        [VisibleInListView(false)]
        public string ShippingNotes
        {
            get
            {
                return _ShippingNotes;
            }
            set
            {
                SetPropertyValue("ShippingNotes", ref _ShippingNotes, value);
            }
        }


        [VisibleInListView(false)]
        public double SalesGoals
        {
            get
            {
                return _SalesGoals;
            }
            set
            {
                SetPropertyValue("SalesGoals", ref _SalesGoals, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsCommissionSplit
        {
            get => isCommissionSplit;
            set => SetPropertyValue(nameof(IsCommissionSplit), ref isCommissionSplit, value);
        }

        //[VisibleInListView(false)]
        //[Association("SalesRep-CustomersSRSplit")]
        //public SalesRep CommissionSplitWith
        //{
        //    get => commissionSplitWith;
        //    set => SetPropertyValue(nameof(CommissionSplitWith), ref commissionSplitWith, value);
        //}


        [VisibleInListView(false)]
        public decimal CommissionSplitWithPct
        {
            get => commissionSplitWithPct;
            set => SetPropertyValue(nameof(CommissionSplitWithPct), ref commissionSplitWithPct, value);
        }



        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CustomerShippingAccount
        {
            get
            {
                return _CustomerShippingAccount;
            }
            set
            {
                SetPropertyValue("CustomerShippingAccount", ref _CustomerShippingAccount, value);
            }
        }


        // old id for import
        [VisibleInListView(false)]
        [ModelDefault("DisplayFormat", "{0:F0}")]
        [VisibleInDetailView(false)]
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

        [VisibleInListView(false)]
        public bool CheckData
        {
            get => checkData;
            set => SetPropertyValue(nameof(CheckData), ref checkData, value);
        }


        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public bool OnlyCustomerItems
        {
            get
            {
                return _OnlyCustomerItems;
            }
            set
            {
                SetPropertyValue("OnlyCustomerItems", ref _OnlyCustomerItems, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime SapEnteredDt
        {
            get => sapEnteredDt;
            set => SetPropertyValue(nameof(SapEnteredDt), ref sapEnteredDt, value);
        }


        [VisibleInListView(false)]
        public DateTime SAPEditDate
        {
            get => sAPEditDate;
            set => SetPropertyValue(nameof(SAPEditDate), ref sAPEditDate, value);
        }


        [VisibleInListView(false)]
        [Association("ShippingType-Customers")]
        public ShippingType ShippingType
        {
            get
            {
                return _ShippingType;
            }
            set
            {
                SetPropertyValue("ShippingType", ref _ShippingType, value);
            }
        }


        [Association("CustomerClassification-Customers")]
        public CustomerClassification Classification
        {
            get
            {
                return _Classification;
            }
            set
            {
                SetPropertyValue("Classification", ref _Classification, value);
            }
        }
        [Association("Customer-CustomerInvoiceHistorys")]
        public XPCollection<CustomerInvoiceHistory> CustomerInvoiceHistory
        {
            get
            {
                return GetCollection<CustomerInvoiceHistory>("CustomerInvoiceHistory");
            }
        }


        [Association("Customer-repackFormularyCustomer")]
        public XPCollection<RepackCustomerFormulary> repackFormularyCustomer
        {
            get
            {
                return GetCollection<RepackCustomerFormulary>("repackFormularyCustomer");
            }
        }

        [Association("Customer-RepackLots")]
        public XPCollection<RepackLots> RepackLots
        {
            get
            {
                return GetCollection<RepackLots>("RepackLots");
            }
        }

        [Association("Customer-ItemTransaction")]
        public XPCollection<ItemTransaction> ItemTransaction
        {
            get
            {
                return GetCollection<ItemTransaction>("ItemTransaction");
            }
        }

        [Association("Customer-CustomerInvoicePayments")]
        public XPCollection<CustomerInvoicePayments> CustomerInvoicePayments
        {
            get
            {
                return GetCollection<CustomerInvoicePayments>("CustomerInvoicePayments");
            }
        }

        [VisibleInListView(false)]
        [Association("CustomerIDN-Customers")]
        public CustomerIDN IDN
        {
            get
            {
                return _IDN;
            }
            set
            {
                SetPropertyValue("IDN", ref _IDN, value);
            }
        }

        [VisibleInListView(false)]

        [Association("CustomerBillingTerms-Customer")]
        public CustomerBillingTerms BillingTerms
        {
            get
            {
                return _billingTerms;
            }
            set
            {
                SetPropertyValue(nameof(BillingTerms), ref _billingTerms, value);
            }
        }


        [DataSourceCriteria("Oid != '1'")]
        [Association("Customer-RepackItems" )]
        public XPCollection<RepackItems> RepackItems
        {
            get
            {
                return GetCollection<RepackItems>(nameof(RepackItems));
            }
        }
       


        //[PersistentAlias("[<CustomerInvoiceHistoryDetails>][InvoiceNumber.CustomerID == ^.Oid and IsThisMonth(InvoiceNumber.InvoiceDate)].Sum(QtyShipped * UnitPrice )")]
        //public decimal ThisMonthsSales
        //{
        //    get
        //    {
        //        if (!IsLoading)
        //        {
        //            return Convert.ToDecimal(EvaluateAlias("ThisMonthsSales"));
        //        }
        //        return 0;

        //    }
        //}


        //[PersistentAlias("[<CustomerInvoiceHistoryDetails>][InvoiceNumber.CustomerID == ^.Oid and IsThisMonth(InvoiceNumber.InvoiceDate)].Sum(QtyShipped * (UnitPrice - UnitCost) )")]
        //public decimal ThisMonthsGP
        //{
        //    get
        //    {
        //        if (!IsLoading)
        //        {
        //            return Convert.ToDecimal(EvaluateAlias("ThisMonthsGP"));
        //        }
        //        return 0;

        //    }
        //}

        //[PersistentAlias("[<CustomerInvoiceHistoryDetails>][InvoiceNumber.CustomerID == ^.Oid and IsThisYear(InvoiceNumber.InvoiceDate)].Sum(QtyShipped * UnitPrice )")]
        //public decimal ThisYearSales
        //{
        //    get
        //    {
        //        if (!IsLoading)
        //        {
        //            return Convert.ToDecimal(EvaluateAlias("ThisYearSales"));
        //        }
        //        return 0;

        //    }
        //}


        //[PersistentAlias("[<CustomerInvoiceHistoryDetails>][InvoiceNumber.CustomerID == ^.Oid and IsThisYear(InvoiceNumber.InvoiceDate)].Sum(QtyShipped * (UnitPrice - UnitCost) )")]
        //public decimal ThisYearGP
        //{
        //    get
        //    {
        //        if (!IsLoading)
        //        {
        //            return Convert.ToDecimal(EvaluateAlias("ThisYearGP"));
        //        }
        //        return 0;

        //    }
        //}



        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [NonPersistent]
        public string UserCurrent
        {
            get { return (SecuritySystem.CurrentUserName.Trim().ToUpper()); }
        }
        [Association("Customer-CustomerCarts")]
        public XPCollection<CustomerCart> CustomerCart
        {
            get
            {
                return GetCollection<CustomerCart>(nameof(CustomerCart));
            }
        }

        [Association("Customer-Requests")]
        public XPCollection<ItemRequest> Requests
        {
            get
            {
                return GetCollection<ItemRequest>("Requests");
            }
        }
        [Association("Customer-CustomerCDR")]
        public XPCollection<CustomerCDR> CustomerCDR
        {
            get
            {
                return GetCollection<CustomerCDR>("CustomerCDR");
            }
        }


        [Association("Customer-CustomerRelease")]
        public XPCollection<CustomerRelease> CustomerRelease
        {
            get
            {
                return GetCollection<CustomerRelease>("CustomerRelease");
            }
        }

        // calculated take a long time
        //public DateTime LastInvoiceDate
        //{
        //    get
        //    {
        //        _LastInvoiceDate = Convert.ToDateTime(Session.Evaluate<Customer>(CriteriaOperator.Parse("CustomerInvoiceHistory.max(InvoiceDate)"),CriteriaOperator.Parse("Oid=?", Oid)));


        //        return _LastInvoiceDate;
        //    }

        //}


        public DateTime LastInvoiceDate
        {
            /// <summary>
            /// Dan this is it
            /// </summary>

            get
            {
                return _LastInvoiceDate;
            }
            set
            {
                SetPropertyValue("LastInvoiceDate", ref _LastInvoiceDate, value);
            }
        }


        public DateTime LastCallDate
        {
            get
            {
                return _LastCallDate;
            }
            set
            {
                SetPropertyValue("LastCallDate", ref _LastCallDate, value);
            }
        }



        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public double OrderCount
        {
            get
            {
                _OrderCount = Convert.ToInt32(Session.Evaluate<Customer>(CriteriaOperator.Parse("CustomerInvoiceHistory.Count"),
      CriteriaOperator.Parse("Oid=?", Oid)));

                return _OrderCount;
            }

        }


        //[Action(Caption = "Sales Order2", ToolTip = "New Sales Order1", ImageName = "order-add", TargetObjectsCriteria = "Not [CustomerNo] Is NULL")]
        //public void CreateNewSalesOrder(Customer sender, PopupWindowShowActionExecuteEventArgs e)
        //{

        //    IObjectSpace newObjectSpace = Application.CreateObjectSpace();
        //    string detailViewId = Application.GetDetailViewId(typeof(Salesorder));

        //    DetailView createdView = Application.CreateDetailView(newObjectSpace, detailViewId, true);
        //    Object objectToShow = newObjectSpace.GetObject(View.CurrentObject);
        //    createdView.CurrentObject = objectToShow;


        //    createdView.ViewEditMode = ViewEditMode.Edit;
        //   // e.View = createdView;



        //  }

        [Association("Customer-CustomerItemPricing")]
        public XPCollection<CustomerItemPricing> CustomerItemPricing
        {
            get
            {
                return GetCollection<CustomerItemPricing>("CustomerItemPricing");
            }
        }


        [Association("Customer-CustomerWebUsers")]
        public XPCollection<CustomerWebUsers> CustomerWebUsers
        {
            get
            {
                return GetCollection<CustomerWebUsers>("CustomerWebUsers");
            }
        }

        [Association("Customer-CustomerCustomUDRequests")]
        public XPCollection<CustomerCustomUDRequest> CustomerCustomUDRequest
        {
            get
            {
                return GetCollection<CustomerCustomUDRequest>("CustomerCustomUDRequest");
            }
        }

        [Association("Customer-Customer222Forms")]
        public XPCollection<Customer222Forms> Customer222Forms
        {
            get
            {
                return GetCollection<Customer222Forms>(nameof(Customer222Forms));
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


        //[Action(Caption = "Sales Order", ImageName = "order-add", TargetObjectsCriteria = "[CustomerNo] Is Not Null")]
        //public void Complete()
        //{
        //    IsCompleted = true;
        //}





        public void Activate()
        {

            // throw new NotImplementedException();
        }

        public void DeActivate()
        {
            //throw new NotImplementedException();
        }


        public class MyNavigationItemsUpdater : ModelNodesGeneratorUpdater<NavigationItemNodeGenerator>
        {
            public override void UpdateNode(ModelNode node)
            {
            }

        }
        public void UpdateMaximumOrder(bool forceChangeEvents)
        {
            //decimal? oldMaximumOrder = fMaximumOrder;
            //decimal tempMaximum = 0m;
            //foreach (Order detail in Orders)
            //    if (detail.Total > tempMaximum)
            //        tempMaximum = detail.Total;
            //fMaximumOrder = tempMaximum;
            //if (forceChangeEvents)
            //    OnChanged("MaximumOrder", oldMaximumOrder, fMaximumOrder);
        }

        public string GetNextCustomerNumber()
        {
            ApplicationOptions AO = Session.FindObject<ApplicationOptions>(CriteriaOperator.Parse("[Oid] = ?", 1));
            if (AO != null)
            {
                int newid = AO.NextCustomerNumber++;
               AO.Save();

                return newid.ToString("0000000000");
            }

            return 0.ToString("000000000");

        }

       

        public decimal GetCustomerItemPrice(int CustomerOID, string ItemNumber)
        {
            //... 
            // If Customer Has Custom Price get that first
            Customer cust = Session.FindObject<Customer>(CriteriaOperator.Parse("[Oid] = ?", CustomerOID));
            if (cust != null)
            {
                CustomerItemPricing CustItemPricing = Session.FindObject<CustomerItemPricing>(CriteriaOperator.Parse("[Customer] = ? && [Item] = ?", cust.Oid, ItemNumber));

                if (CustItemPricing != null)
                {

                    return CustItemPricing.CustomerPrice;
                }

                // No Customer pricing found Check out if customer is in a pricing group
                if (cust.CustomerPricingGroup != null)
                {
                    ItemPricingGroupList CustItemGroupPricing = Session.FindObject<ItemPricingGroupList>(CriteriaOperator.Parse("[ItemPricingGroup] = ? && [Item] = ?", cust.CustomerPricingGroup, ItemNumber));

                    if (CustItemPricing != null)
                    {
                        return CustItemPricing.CustomerPrice;
                    }
                }
            }
            // Check for  Std price

            Items item = Session.FindObject<Items>(CriteriaOperator.Parse("[Itemnumber] = ? ", ItemNumber));
            if (item != null)
            {
                return item.StdPrice;
            }

            // no pricing set send 0
            return 0;
        }

    }


}
