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

using System.Windows.Forms;
namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]

    [NavigationItem("Sales")]

    [ImageName("Invoice")]
    [ListViewFilter("All Past Year", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -365)", "Past Year Invoice", "Only invoices in the past year. ", false)]
    [ListViewFilter("Past 10 years ", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -3650)")]
    [ListViewFilter("Past 5 years ", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -1825)")]
    [ListViewFilter("Past 2 years ", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -730)")]
    [ListViewFilter("Last 90 days ", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -90)")]
    [ListViewFilter("Last 60 days ", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -60)")]
    [ListViewFilter("Last 30 days", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -30)")]


    //[ListViewFilter("Last Week", "[InvoiceDate] > LocalDateTimeLastWeek() and [InvoiceDate] < LocalDateTimeThisWeek()", "Last Week", "Last Weeks Invoices. ", false)]
    //[ListViewFilter("Last Month", "[InvoiceDate] > LocalDateTimeLastMonth() and [InvoiceDate] < LocalDateTimeThisMonth()", "Last Month", "Last month Invoices. ", false)]
    //[ListViewFilter("This Week", "[InvoiceDate] > LocalDateTimeThisWeek() and [InvoiceDate] <= LocalDateTimeToday()", "This Week", "This Weeks Invoices. ", false)]
    //[ListViewFilter("This Month", "[InvoiceDate] > LocalDateTimeThisMonth() and [InvoiceDate] < LocalDateTimeNextMonth()", "This Month", "Thisd month Invoices. ", false)]
    //[ListViewFilter(" My This Week", "[InvoiceDate] >= LocalDateTimeThisWeek() and [InvoiceDate] <= LocalDateTimeNextWeek() and [SalesRep] = CurrentUserName()", " My This Week", "This Weeks Invoices. ", false)]
    //[ListViewFilter(" My This Month", "[InvoiceDate] >= LocalDateTimeThisMonth() and [InvoiceDate] < LocalDateTimeNextMonth() and [SalesRep] = CurrentUserName()", " My This Month", "Thisd month Invoices. ", true)]
    //[ListViewFilter(" My Yeasterday's Invoices", "[InvoiceDate] >=  LocalDateTimeYesterday() and [InvoiceDate] < LocalDateTimeToday() and [SalesRep] = CurrentUserName()", " My Yesterday and Today", " My Only invoices from yesterday and Today.", true)]
    //[ListViewFilter(" My Last Week", "[InvoiceDate] >= LocalDateTimeLastWeek() and [InvoiceDate] <= LocalDateTimeThisWeek() and [SalesRep] = CurrentUserName()", " My Last Week", "Last Weeks Invoices. ", false)]
    //[ListViewFilter(" My Last Month", "[InvoiceDate] >= LocalDateTimeLastMonth() and [InvoiceDate] <= LocalDateTimeThisMonth()and [SalesRep] = CurrentUserName()", " My Last Month ", "My Last month Invoices. ", false)]
    //[ListViewFilter(" All Last Month", "[InvoiceDate] >= LocalDateTimeLastMonth() and [InvoiceDate] <= LocalDateTimeThisMonth()", " All Last Month ", "My Last month Invoices. ", false)]
    //[ListViewFilter(" All Last Week", "[InvoiceDate] >= LocalDateTimeLastWeek() and [InvoiceDate] >= LocalDateTimeThisWeek() ", " All Last Week", "Last Weeks Invoices. ", false)]
    //[ListViewFilter(" All Last Week", "[InvoiceDate] >= LocalDateTimeLastWeek() and [InvoiceDate] >= LocalDateTimeThisWeek() ", " All Last Week", "Last Weeks Invoices. ", false)]


    [ListViewFilter(" All ", " ", "")]
    [Indices("InvoiceNumber", "InvoiceDate", "CustomerID;InvoiceDate", "InvoiceDate;SalesRep")]

    [DefaultProperty("InvoiceNumber")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class CustomerInvoiceHistory : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerInvoiceHistory(Session session)
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


        DateTime sapEntered;
        private FileData file;
        private string _TrackingNumber;
        private CustomerInvoiceTerms _InvoiceTermCode;
        private bool _IsPrinted;
        private DistributionCenterWhse _WhseCode;
        private decimal _InvoiceTotal;
        private string _ShipToZip;
        private string _OldInvoiceNumber;
        private SalesRep _SalesRep;
        private DateTime _ShipDate;
        private string _ShipToState;
        private string _ShipToCity;
        private string _ShipToAddress3;
        private string _ShipToAddress2;
        private string _ShipToAddress1;
        private string _BillToZip;
        private string _BillToState;
        private string _BillToCity;
        private string _BillToAdress3;
        private string _BillToAdress2;
        private string _BillToAddress1;
        private string _BillToName;
        private decimal _FrieghtAmount;
        private DateTime _TransactionDate;
        private string _SalesOrderNumber;
        private DateTime _DiscountDueDate;
        private DateTime _InvoiceDueDate;
        private string _Comment;
        private string _CustomerPoNumber;
        private string _CustomerName;
        private Customer _CustomerId;
        private DateTime _InvoiceDate;
        private string _InvoiceNumber;
        [Indexed("CustomerID;InvoiceDate", Unique = false)]
        [Size(10)]
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

        [Indexed]
        public DateTime InvoiceDate
        {
            get
            {
                return _InvoiceDate;
            }
            set
            {
                SetPropertyValue("InvoiceDate", ref _InvoiceDate, value);
            }
        }


        [VisibleInListView(false)]
        [Association("Customer-CustomerInvoiceHistorys")]
        public Customer CustomerID
        {
            get
            {
                return _CustomerId;
            }
            set
            {
                SetPropertyValue("Customer", ref _CustomerId, value);
            }
        }

        [VisibleInListView(true)]
        [Size(128)]
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                SetPropertyValue("SoldToName", ref _CustomerName, value);
            }
        }
        [Indexed]
        [Association("SalesReps-CustomerInvoiceHistorys")]
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

        // termscode
        //taxschedule


        //ShipingMethod

        [VisibleInListView(false)]
        [Size(15)]
        public string CustomerPoNumber
        {
            get
            {
                return _CustomerPoNumber;
            }
            set
            {
                SetPropertyValue("CustomerPoNumber", ref _CustomerPoNumber, value);
            }
        }

        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
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
        public DateTime InvoiceDueDate
        {
            get
            {
                return _InvoiceDueDate;
            }
            set
            {
                SetPropertyValue("InvoiceDueDate", ref _InvoiceDueDate, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime DiscountDueDate
        {
            get
            {
                return _DiscountDueDate;
            }
            set
            {
                SetPropertyValue("DiscountDueDate", ref _DiscountDueDate, value);
            }
        }

        [VisibleInListView(false)]
        [Indexed]
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
        public DateTime TransactionDate
        {
            get
            {
                return _TransactionDate;
            }
            set
            {
                SetPropertyValue("TransactionDate", ref _TransactionDate, value);
            }
        }
        [VisibleInListView(false)]
        [Size(10)]
        public string SalesOrderNumber
        {
            get
            {
                return _SalesOrderNumber;
            }
            set
            {
                SetPropertyValue("SalesOrderNumber", ref _SalesOrderNumber, value);
            }
        }


        [VisibleInListView(false)]
        public decimal FrieghtAmount
        {
            get
            {
                return _FrieghtAmount;
            }
            set
            {
                SetPropertyValue("FrieghtAmount", ref _FrieghtAmount, value);
            }
        }

        [VisibleInListView(false)]
        [Size(50)]
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
        [Size(50)]
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
        [Size(50)]
        public string BillToAdress2
        {
            get
            {
                return _BillToAdress2;
            }
            set
            {
                SetPropertyValue("BillToAdress2", ref _BillToAdress2, value);
            }
        }


        [VisibleInListView(false)]
        [Size(50)]
        public string BillToAdress3
        {
            get
            {
                return _BillToAdress3;
            }
            set
            {
                SetPropertyValue("BillToAdress3", ref _BillToAdress3, value);
            }
        }
        [VisibleInListView(false)]
        [Size(50)]
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
        [Size(2)]
        public string BillToState
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
        [Size(10)]
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

        [VisibleInListView(false)]
        [Size(50)]
        public string ShipToAddress1
        {
            get
            {
                return _ShipToAddress1;
            }
            set
            {
                SetPropertyValue("ShipToAddress1", ref _ShipToAddress1, value);
            }
        }
        [VisibleInListView(false)]
        [Size(50)]
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
        [Size(50)]
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
        [Size(50)]
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
        [Size(2)]
        public string ShipToState
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

        [VisibleInListView(false)]
        [Size(15)]
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

        //[Persistent("InvoiceTotal")]
        //public decimal InvoiceTotal
        //{
        //    get
        //    {
        //        //if (!IsLoading && !IsSaving )
        //        //    UpdateInvoiceTotal(true);
        //        return _InvoiceTotal;
        //    }
        //    set
        //    {
        //        SetPropertyValue("InvoiceTotal", ref _InvoiceTotal, value);
        //    }
        //}

        [VisibleInListView(false)]
        [Association("CustomerInvoiceTerms-CustomerInvoiceHistorys")]
        public CustomerInvoiceTerms InvoiceTermCode
        {
            get
            {
                return _InvoiceTermCode;
            }
            set
            {
                SetPropertyValue("InvoiceTermCode", ref _InvoiceTermCode, value);
            }
        }
        string deliveryEmail;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DeliveryEmail
        {
            get
            {
                return deliveryEmail;
            }
            set
            {
                SetPropertyValue(nameof(DeliveryEmail), ref deliveryEmail, value);
            }
        }

        DateTime lastDeliveryDate;
        public DateTime LastDeliveryDate
        {
            get
            {
                return lastDeliveryDate;
            }
            set
            {
                SetPropertyValue(nameof(LastDeliveryDate), ref lastDeliveryDate, value);
            }
        }

        InvoiceType invoiceType;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public InvoiceType InvoiceType
        {
            get
            {
                return invoiceType;
            }
            set
            {
                SetPropertyValue(nameof(InvoiceType), ref invoiceType, value);
            }
        }


        [VisibleInListView(false)]
        [Size(8)]
        public string OldInvoiceNumber
        {
            get
            {
                return _OldInvoiceNumber;
            }
            set
            {
                SetPropertyValue("OldInvoiceNumber", ref _OldInvoiceNumber, value);
            }
        }

        // shipVia Rate

        [VisibleInListView(false)]
        [PersistentAlias("[InvoiceDate]")]
        public System.DayOfWeek InvoiceDayOfWeek
        {
            get { return (InvoiceDate.DayOfWeek); }
        }

        [PersistentAlias("[<CustomerInvoiceHistoryDetails>][InvoiceNumber == ^.Oid].Sum(QtyShipped * UnitPrice )")]
        public decimal LineTotal
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDecimal(EvaluateAlias("LineTotal"));
                }
                return 0;

            }
        }


        [PersistentAlias("[<CustomerInvoicePayments>][InvoiceNumber == ^.Oid].Sum( TransactionAmount )")]
        public decimal AmountPaid
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDecimal(EvaluateAlias("AmountPaid"));
                }
                return 0;
            }
        }

        [PersistentAlias("(LineTotal + FrieghtAmount )")]
        public decimal InvoiceTotal
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDecimal(EvaluateAlias("InvoiceTotal"));
                }
                return 0;

            }
        }
        [PersistentAlias("(InvoiceTotal - AmountPaid)")]
        public decimal BalanceDue
        {
            get
            {
                if (!IsLoading)
                {
                    return Convert.ToDecimal(EvaluateAlias("BalanceDue"));
                }
                return 0;
            }
        }


        
        public DateTime SapEntered
        {
            get => sapEntered;
            set => SetPropertyValue(nameof(SapEntered), ref sapEntered, value);
        }

        [Association(" DistributionCenterWhse-CustomerInvoiceHistorys")]
        public DistributionCenterWhse WhseCode
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


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TrackingNumber
        {
            get
            {
                return _TrackingNumber;
            }
            set
            {
                SetPropertyValue("TrackingNumber", ref _TrackingNumber, value);
            }
        }
        [DevExpress.Xpo.Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData InvoicePdfFile
        {
            get { return file; }
            set
            {
                SetPropertyValue(nameof(InvoicePdfFile), ref file, value);
            }
        }

        //person
        [Association("CustomerInvoiceHistoryDetails")]
        public XPCollection<CustomerInvoiceHistoryDetails> InvoicenumberDetails
        {
            get
            {
                return GetCollection<CustomerInvoiceHistoryDetails>("InvoicenumberDetails");
            }
        }

        [Association("CustomerInvoiceHistory-CustomerInvoicePayments")]
        public XPCollection<CustomerInvoicePayments> InvoicePayments
        {
            get
            {
                return GetCollection<CustomerInvoicePayments>("InvoicePayments");
            }
        }

        public void UpdateInvoiceTotal(bool ForceChangeEvents)
        {
            Decimal? OldInvoiceTotal = _InvoiceTotal;
            decimal tempTotal = 0;
            foreach (CustomerInvoiceHistoryDetails detail in InvoicenumberDetails)
                tempTotal += (detail.ExtendedAmt);
            _InvoiceTotal = tempTotal;
            if (ForceChangeEvents && OldInvoiceTotal != _InvoiceTotal)
                OnChanged("InvoiceTotal", OldInvoiceTotal, _InvoiceTotal);


        }

        [Delayed]
        //[ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public System.Drawing.Image InvoicePDF
        {

            get { return GetDelayedPropertyValue<System.Drawing.Image>("InvoicePDF"); }
            set { SetDelayedPropertyValue("InvoicePDF", value); }

        }




        [Action(Caption = "Recalculate Invoice Totals", ToolTip = "Recalculate Invoice Totals", ImageName = "order-add")]
        public void RecalcTotals()
        {


            UpdateInvoiceTotal(true);
            //UnitOfWork.ExecuteNonQuery(sql: sqlUpdateTotals);
            //DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("Invoice number:{0} recalculated. Total = {1:c}.", this.InvoiceNumber, this.InvoiceTotal));


        }
    }

}
