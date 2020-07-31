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
    [ImageName("Order")]
    [ListViewAutoFilterRowAttribute(true)]
    [NavigationItem("Shipping")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [ListViewFilter("Non Printed Picking Sheets ", "[PickingsheetPrinted] = False", "Non Printed Picking Sheets  ", "Non Printed Picking Sheets ", true)]
    [ListViewFilter("In Packing ", "[SOStatus] == 3 ", "In Packing", "In Packing", false)]
    [ListViewFilter("In Invoicing ", "[SOStatus] == 5 ", "In Invoicing", "In Invoicing", false)]
    [ListViewFilter("All", "")]

    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SOHeader : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SOHeader(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            SalesOrderDate = DateTime.Now;
            SOStatus = SalesOrderStatus.New;
            
            if (!(Session is NestedUnitOfWork)
                  && (Session.DataLayer != null)
                 && Session.IsNewObject(this)
                    && (Session.ObjectLayer is SimpleObjectLayer)
                   //OR
                   //&& !(Session.ObjectLayer is DevExpress.ExpressApp.Security.ClientServer.SecuredSessionObjectLayer)
                   && string.IsNullOrEmpty(SalesOrderNumber))
            {
                CustomerShippingAccount = CustomerNumber?.CustomerShippingAccount;
                ShippingType = CustomerNumber?.ShippingType;
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "SalesOrder");
                accountingSONumber = string.Format("SO{0:D6}", nextSequence);
                salesOrderNumber = accountingSONumber;
            }
           
        }

        protected override void OnSaving()
        {

            base.OnSaving();
            if (SalesOrderNumber == null)
            {
                SalesOrderNumber = AccountingSONumber;
            }
        }


        // Fields...

    
        CustomerContact contact;
        string scan;
        string lastComplianceMsg;
        private DistributionCenterWhse _DistributionCenterWhse;

        private string _CustomerShippingAccount;
        private ShippingType _ShippingType;
        private SalesRep _SalesRep;
        private SalesOrderStatus _SOStatus;
        private bool _PickingsheetPrinted;
        private string _SalesOrderComments;
        private string _ShipToZip;
        private State _ShipToState;
        private string _ShipToCity;
        private string _ShipToAddress3;
        private string _ShipToAddress2;
        private string _ShipToAddress;
        private string _ShipToName;
        private string _BillToZip;
        private State _BillToState;
        private string _BillToCity;
        private string _BillToAddress3;
        private string _BillToAddress2;
        private string _BillToAddress1;
        private string _BillToName;
        private Customer _CustomerNumber;
        private string _PoNumber;
        private DateTime _SalesOrderDate;


        [VisibleInListView(false)]
        [Indexed(Unique = true)]
        string salesOrderNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SalesOrderNumber
        {
            get
            {
                return GetPropertyValue<string>("SalesOrderNumber");

            }
            set
            {
                SetPropertyValue(nameof(SalesOrderNumber), ref salesOrderNumber, value);
            }
        }

        [Indexed(Unique = true)]
        string accountingSONumber;
        [Size(25)]
        public string AccountingSONumber
        {
            get
            {
                return accountingSONumber;
            }
            set
            {
                SetPropertyValue(nameof(AccountingSONumber), ref accountingSONumber, value);
                if (SalesOrderNumber == null) SalesOrderNumber = accountingSONumber;


            }
        }
        
        
        public DateTime SalesOrderDate
        {
            get
            {
                return _SalesOrderDate;
            }
            set
            {
                SetPropertyValue("SalesOrderDate", ref _SalesOrderDate, value);
            }
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PoNumber
        {
            get
            {
                return _PoNumber;
            }
            set
            {
                SetPropertyValue("PoNumber", ref _PoNumber, value);
            }
        }

        [RuleRequiredField()]
        public SalesOrderStatus SOStatus
        {
            get
            {
                return _SOStatus;
            }
            set
            {
                SetPropertyValue("SOStatus", ref _SOStatus, value);
            }
        }


        [RuleRequiredField()]
        [VisibleInListView(true)]
        [Association("Customer-SOHeaders")]
        public Customer CustomerNumber
        {
            get
            {
                return _CustomerNumber;
            }
            set
            {
                if (Equals(CustomerNumber, value)) return;

                SetPropertyValue("CustomerNumber", ref _CustomerNumber, value);

                if (!IsLoading && CustomerNumber != null)
                {
                    this.BillToName = CustomerNumber.CustomerName;
                    this.BillToAddress1 = CustomerNumber.BillingAddress;
                    this.BillToAddress2 = CustomerNumber.BillingAddress2;
                    this._BillToAddress3 = CustomerNumber.BillingAddress3;
                    this.BillToCity = CustomerNumber.BillingCity;
                    this.BillToState = CustomerNumber.BillingState;
                    this.BillToZip = CustomerNumber.BillingZip;
                    this.ShipToName = CustomerNumber.CustomerName;
                    this.ShipToAddress = CustomerNumber.ShipAddress;
                    this.ShipToAddress2 = CustomerNumber.ShipAddress2;
                    this.ShipToAddress3 = CustomerNumber.ShipAddress3;
                    this.ShipToCity = CustomerNumber.ShipCity;
                    this.ShipToState = CustomerNumber.ShipState;
                    this.ShipToZip = CustomerNumber.ShipZip;
                    this.ShippingType = CustomerNumber.ShippingType;
                    this.CustomerShippingAccount = CustomerNumber.CustomerShippingAccount;

                }
            }

        }

        [DataSourceCriteria("Customers = '@This.CustomerNumber' ")]
        [Association("CustomerContact-SOHeaders")]
        public CustomerContact Contact

        {
            get => contact;
            set => SetPropertyValue(nameof(Contact), ref contact, value);
        }


        [RuleRequiredField()]
        [Association("DistributionCenterWhse-SOHeaders")]
        [DataSourceCriteria("Retail = true ")]

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

        #region BillingAddress

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BillToName
        {
            get
            {
                return _BillToName;
            }
            set
            {
                SetPropertyValue("BillToName", ref _BillToName, value);
            }
        }



        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BillToAddress1
        {
            get
            {
                return _BillToAddress1;
            }
            set
            {
                SetPropertyValue("BillToAddress1", ref _BillToAddress1, value);
            }
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BillToAddress2
        {
            get
            {
                return _BillToAddress2;
            }
            set
            {
                SetPropertyValue("BillToAddress2", ref _BillToAddress2, value);
            }
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BillToAddress3
        {
            get
            {
                return _BillToAddress3;
            }
            set
            {
                SetPropertyValue("BillToAddress3", ref _BillToAddress3, value);
            }
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BillToCity
        {
            get
            {
                return _BillToCity;
            }
            set
            {
                SetPropertyValue("BillToCity", ref _BillToCity, value);
            }
        }


        [VisibleInListView(false)]
        [Association("State-SOBillToState")]
        public State BillToState
        {
            get
            {
                return _BillToState;
            }
            set
            {
                SetPropertyValue("BillToState", ref _BillToState, value);
            }
        }



        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BillToZip
        {
            get
            {
                return _BillToZip;
            }
            set
            {
                SetPropertyValue("BillToZip", ref _BillToZip, value);
            }
        }

        #endregion

        #region Shippingaddress
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        [Association("State-SOShipToState")]
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

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ShipToZip
        {
            get
            {
                return _ShipToZip;
            }
            set
            {
                SetPropertyValue("ShipToZip", ref _ShipToZip, value);
            }
        }
        #endregion

        #region Calculated fields

        [VisibleInListView(false)]
        public string BillToCityStateZip
        {
            get
            {
                return String.Format("{0}, {1}  {2}", BillToCity, BillToState.StateCode, BillToZip);
            }

        }


        [VisibleInListView(false)]
        public string ShipToCityStateZip
        {
            get
            {
                return String.Format("{0}, {1}  {2}", ShipToCity, ShipToState.StateCode, ShipToZip);
            }

        }
        #endregion

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SalesOrderComments
        {
            get
            {
                return _SalesOrderComments;
            }
            set
            {
                SetPropertyValue("SalesOrderComments", ref _SalesOrderComments, value);
            }
        }

        public bool PickingsheetPrinted
        {
            get
            {
                return _PickingsheetPrinted;
            }
            set
            {
                SetPropertyValue("PickingsheetPrinted", ref _PickingsheetPrinted, value);
            }
        }

        [RuleRequiredField()]
        [Association("ShippingType-SOHeader")]
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

        [VisibleInListView(false)]
        string importID;
        [Size(64)]
        public string ImportID
        {
            get
            {
                return importID;
            }
            set
            {
                SetPropertyValue(nameof(ImportID), ref importID, value);
            }
        }

        [VisibleInListView(false)]
        [Size(256)]
        public string LastComplianceMsg
        {
            get => lastComplianceMsg;
            set => SetPropertyValue(nameof(LastComplianceMsg), ref lastComplianceMsg, value);
        }

        [Association("SalesRep-SOHeader")]
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

        [NonPersistent]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Scan
        {
            get => scan;
            set => SetPropertyValue(nameof(Scan), ref scan, value);
        }


        [Association("SOHeader-SODetails"), DevExpress.Xpo.Aggregated]
        public XPCollection<SODetails> SODetails
        {
            get
            {
                return GetCollection<SODetails>("SODetails");
            }
        }

        [Association("SOHeader-SOPacking")]
        public XPCollection<SOPacking> SOPacking
        {
            get
            {
                return GetCollection<SOPacking>(nameof(SOPacking));
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

        [Association("SOHeader-SoPackingSerailNumbers")]
        public XPCollection<SOPackingSerialNo> SoPackingSerialNumbers
        {
            get
            {
                return GetCollection<SOPackingSerialNo>(nameof(SoPackingSerialNumbers));
            }
        }

    }
}