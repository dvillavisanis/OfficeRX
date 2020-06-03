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
using RX2_Office.Module.BusinessObjects;
using DevExpress.ExpressApp.SystemModule;





namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Sales")]

    [ImageName("InvoiceDetail")]
    [ListViewFilter(" All ", "", true)]
    [ListViewFilter(" All My", "[InvoiceNumber.SalesRep] = CurrentUserName()", " All My ", "All My items ", false)]
    [ListViewFilter(" My This Week", "[InvoiceNumber.InvoiceDate] >= LocalDateTimeThisWeek() and [InvoiceNumber.InvoiceDate] <= LocalDateTimeNextWeek() and [InvoiceNumber.SalesRep] = CurrentUserName()", " My This Week", "This Weeks Invoices. ", false)]
    [ListViewFilter(" My This Month", "InvoiceNumber.[InvoiceDate] >= LocalDateTimeThisMonth() and [InvoiceNumber.InvoiceDate] < LocalDateTimeNextMonth() and [InvoiceNumber.SalesRep] = CurrentUserName()", " My This Month", "Thisd month Invoices. ", false)]
    [ListViewFilter(" My Yeasterday's Invoices", "[InvoiceNumber.InvoiceDate] >=  LocalDateTimeYesterday() and [InvoiceNumber.InvoiceDate] < LocalDateTimeToday() and [InvoiceNumber.SalesRep] = CurrentUserName()", " My Yesterday and Today", " My Only invoices from yesterday and Today.", true)]
    [ListViewFilter(" My Last Week", "[InvoiceNumber.InvoiceDate] >= LocalDateTimeLastWeek() and [InvoiceNumber.InvoiceDate] <= LocalDateTimeThisWeek() and [InvoiceNumber.SalesRep] = CurrentUserName()", " My Last Week", "Last Weeks Invoices. ", false)]
    [ListViewFilter(" My Last Month", "[InvoiceNumber.InvoiceDate] >= LocalDateTimeLastMonth() and [InvoiceNumber.InvoiceDate] <= LocalDateTimeThisMonth()and [InvoiceNumber.SalesRep] = CurrentUserName()", " My Last Month ", "My Last month Invoices. ", false)]


    //    [Indices("InvoiceNumber", "InvoiceDate", "CustomerID;InvoiceDate", "InvoiceDate;SalesRep")]


    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class CustomerInvoiceHistoryDetails : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerInvoiceHistoryDetails(Session session)
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

        private DateTime _LotExpDate;

        private string _ItemLot;
        private ItemProductLine _ProductLine;
        private string _GlSalesAcct;
        private string _GlCogSoldAcct;
        private DistributionCenterWhse _WarehouseId;
        private ItemUnitOfMeasure _UnitOfMessure;
        private decimal _ExtendedAmt;
        private decimal _UnitCost;
        private decimal _UnitPrice;
        private decimal _QtyBackOrdered;
        private decimal _QtyShipped;
        private decimal _QtyOrdered;
        private string _ItemDescription;
        private Items _ItemNumber;
        private int _SortOrder;
        private CustomerInvoiceHistory _InvoiceNumber;

        [Association("CustomerInvoiceHistoryDetails")]
        public CustomerInvoiceHistory InvoiceNumber
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

        public int SortOrder
        {
            get
            {
                return _SortOrder;
            }
            set
            {
                SetPropertyValue("SortOrder", ref _SortOrder, value);
            }
        }


        [Association("Items-CustomerInvoiceHistoryDetails")]
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


        [Size(254)]
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


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemLot
        {
            get
            {
                return _ItemLot;
            }
            set
            {
                SetPropertyValue("ItemLot", ref _ItemLot, value);
            }
        }



        public DateTime LotExpDate
        {
            get
            {
                return _LotExpDate;
            }
            set
            {
                SetPropertyValue("LotExpDate", ref _LotExpDate, value);
            }
        }

        [Association("DistributionCenterWhse-CustomerInvoiceHistoryDetailss")]
        public DistributionCenterWhse WarehouseId
        {
            get
            {
                return _WarehouseId;
            }
            set
            {
                SetPropertyValue("WarehouseId", ref _WarehouseId, value);
            }
        }

          [VisibleInListView(false)]
        [Association("ItemUnitOfMeasure-CustomerInvoiceHistoryDetailss")]
        public ItemUnitOfMeasure UnitOfMessure
        {
            get
            {
                return _UnitOfMessure;
            }
            set
            {
                SetPropertyValue("UnitOfMessure", ref _UnitOfMessure, value);
            }
        }
          [VisibleInListView(false)]
        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal QtyOrdered
        {
            get
            {
                return _QtyOrdered;
            }
            set
            {
                SetPropertyValue("QtyOrdered", ref _QtyOrdered, value);
            }
        }

        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal QtyShipped
        {
            get
            {
                return _QtyShipped;
            }
            set
            {
                SetPropertyValue("QtyShippped", ref _QtyShipped, value);
            }
        }

          [VisibleInListView(false)]
        [ModelDefault("EditMask", "#,##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal QtyBackOrdered
        {
            get
            {
                return _QtyBackOrdered;
            }
            set
            {
                SetPropertyValue("QtyBackOrdered", ref _QtyBackOrdered, value);
            }
        }

        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:C}")]

        public decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                SetPropertyValue("UnitPrice", ref _UnitPrice, value);
            }
        }
          [VisibleInListView(false)]
        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:C}")]
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

        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:C}")]

        public decimal ExtendedAmt
        {
            set
            {
                if (!IsLoading && !IsSaving && _InvoiceNumber != null)
                {
                    _InvoiceNumber.UpdateInvoiceTotal(true);
                }
                SetPropertyValue("ExtendedAmt", ref _ExtendedAmt, value);

            }
            get
            {
                _ExtendedAmt = UnitPrice * QtyShipped;



                return _ExtendedAmt;
            }

        }

          [VisibleInListView(false)]
        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:C}")]
        [NonPersistent]
        public decimal ExtendedGrossProfit
        {
            get
            {

                return (UnitPrice - UnitCost) * QtyShipped;
            }

        }

          [VisibleInListView(false)]
        [Size(25)]
        public string GlCogSoldAcct
        {
            get
            {
                return _GlCogSoldAcct;
            }
            set
            {
                SetPropertyValue("GlCogSoldAcct", ref _GlCogSoldAcct, value);
            }
        }
          [VisibleInListView(false)]
        [Size(25)]
        public string GlSalesAcct
        {
            get
            {
                return _GlSalesAcct;
            }
            set
            {
                SetPropertyValue("GlSalesAcct", ref _GlSalesAcct, value);
            }
        }


        [Association("ItemProductLine-CustomerInvoiceHistoryDetailss")]
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



    }


}
