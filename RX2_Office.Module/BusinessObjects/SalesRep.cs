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
using RX2_Office.Module.BusinessObjects.BusinessLogic;

namespace RX2_Office.Module.BusinessObjects
{
    [NavigationItem("Sales")]
    [DefaultClassOptions]
    [ImageName("SalesReps")]
    [DefaultProperty("SalesRepCode")]
    [ListViewFilter("Active", "[IsActive] = true ", "Active", "Active", true)]
    [ListViewFilter("All", "")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class SalesRep : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SalesRep(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            IsActive = true;
            RepStartDate = DateTime.Now;


        }

        // Fields...


        
        Gender gender;
        private decimal _RepCurrentGPGoal;
        private bool _IsActive;
        private DateTime _RepEndDate;
        private DateTime _RepStartDate;
        private string _PhoneAccountingCode;
        private SalesTeams _Team;
        private string _PhoneExtension;
        private string _SalesRepCode;
        private string _LastName;
        private string _GLCostofGoodsSold;
        private string _SalesrepAccountingCode;
        private string _MiddleName;
        private string _FirstName;

        [Key]
        [Size(20)]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]


        public string SalesRepCode
        {
            get
            {
                return _SalesRepCode;
            }
            set
            {
                SetPropertyValue("SalesRepCode", ref _SalesRepCode, value);
            }
        }

        [Size(100)]
        [VisibleInListView(false)]
        [RuleRequiredField]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                SetPropertyValue("FirstName", ref _FirstName, value);
            }
        }

        [VisibleInListView(false)]
        [Size(100)]
        [RuleRequiredField]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                SetPropertyValue("LastName", ref _LastName, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(100)]
        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                SetPropertyValue("MiddleName", ref _MiddleName, value);
            }
        }

        [PersistentAlias("[FirstName] + ' ' + [MiddleName] + ' ' + [LastName]")]
        public string SalesRepFullName
        {
            get { return String.Format("{0} {1} {2}", FirstName ?? "", MiddleName ?? "", LastName ?? ""); }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string SalesrepAccountingCode
        {
            get
            {
                return _SalesrepAccountingCode;
            }
            set
            {
                SetPropertyValue("SalesrepAccountingCode", ref _SalesrepAccountingCode, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string GLDivisionAccount
        {
            get
            {
                return _GLCostofGoodsSold;
            }
            set
            {
                SetPropertyValue("GLCostofGoodsSold", ref _GLCostofGoodsSold, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime RepStartDate
        {
            get
            {
                return _RepStartDate;
            }
            set
            {
                SetPropertyValue("RepStartDate", ref _RepStartDate, value);
            }
        }
        [VisibleInListView(false)]
        public DateTime RepEndDate
        {
            get
            {
                return _RepEndDate;
            }
            set
            {
                SetPropertyValue("RepEndDate", ref _RepEndDate, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetPropertyValue("IsActive", ref _IsActive, value);
            }
        }



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Gender Lot
        {
            get => gender;
            set => SetPropertyValue(nameof(Lot), ref gender, value);
        }

        [VisibleInListView(false)]
        public decimal RepCurrentGPGoal
        {
            get
            {
                return _RepCurrentGPGoal;
            }
            set
            {
                SetPropertyValue("RepCurrentGPGoal", ref _RepCurrentGPGoal, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(5)]
        public string PhoneAccountingCode
        {
            get
            {
                return _PhoneAccountingCode;
            }
            set
            {
                SetPropertyValue("PhoneAccountingCode", ref _PhoneAccountingCode, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(5)]
        public string PhoneExtension
        {
            get
            {
                return _PhoneExtension;
            }
            set
            {
                SetPropertyValue("PhoneExtension", ref _PhoneExtension, value);
            }
        }


        [PersistentAlias("[<CustomerInvoiceHistoryDetails>][IsThisMonth(InvoiceNumber.InvoiceDate) and InvoiceNumber.SalesRep =^.SalesRepCode].Sum(QtyShipped * UnitPrice)")]
        public decimal ThisMonthSales
        {
            get
            {
                if (SalesRepCode != null)
                {
                    return Convert.ToDecimal(EvaluateAlias("ThisMonthSales"));
                }
                return 0;

            }
        }
        [PersistentAlias("[<CustomerInvoiceHistoryDetails>][IsThisMonth(InvoiceNumber.InvoiceDate) and InvoiceNumber.SalesRep =^.SalesRepCode].Sum(QtyShipped * UnitPrice- UnitCost)")]
        public decimal ThisMonthGP
        {
            get
            {
                if (SalesRepCode != null)
                {
                    return Convert.ToDecimal(EvaluateAlias("ThisMonthGP"));
                }
                return 0;

            }
        }

        [PersistentAlias("[<CustomerInvoiceHistoryDetails>][IsLastMonth(InvoiceNumber.InvoiceDate) and InvoiceNumber.SalesRep =^.SalesRepCode].Sum(QtyShipped * UnitPrice)")]
        public decimal LastMonthSales
        {
            get
            {
                if (SalesRepCode != null)
                {
                    return Convert.ToDecimal(EvaluateAlias("LastMonthSales"));
                }
                return 0;

            }
        }

        [PersistentAlias("[<CustomerInvoiceHistoryDetails>][IsLastMonth(InvoiceNumber.InvoiceDate) and InvoiceNumber.SalesRep =^.SalesRepCode].Sum(QtyShipped * UnitPrice- UnitCost)")]
        public decimal LastMonthGP
        {
            get
            {
                if (SalesRepCode != null)
                {
                    return Convert.ToDecimal(EvaluateAlias("LastMonthGP"));
                }
                return 0;

            }
        }




        [Association("SalesRep-SalesRepGoals")]
        public XPCollection<SalesRepGoals> SaleRepGoals
        {
            get
            {
                return GetCollection<SalesRepGoals>("SaleRepGoals");
            }
        }


        [Association("SalesRep-Customers")]
        public XPCollection<Customer> Customers
        {
            get
            {
                return GetCollection<Customer>("Customers");
            }
        }
        [Association("SalesReps-CustomerInvoiceHistorys")]
        public XPCollection<CustomerInvoiceHistory> InvoicehistorySalesrep
        {
            get
            {
                return GetCollection<CustomerInvoiceHistory>("InvoicehistorySalesrep");
            }
        }

        [Association("SalesTeams-SalesRep")]
        public SalesTeams Team
        {
            get
            {
                return _Team;
            }
            set
            {
                SetPropertyValue("Team", ref _Team, value);
            }
        }
        [Association("SalesRep-SOHeader")]
        public XPCollection<SOHeader> SoHeader
        {
            get
            {
                return GetCollection<SOHeader>("SoHeader");
            }
        }

        [Association("SalesRep-CustomerCDR")]
        public XPCollection<CustomerCDR> CustomerCDR
        {
            get
            {
                return GetCollection<CustomerCDR>("CustomerCDR");
            }
        }


        [Association("SalesRep-SalesRepGroupings")]
        public XPCollection<SalesRepGrouping> SalesRepGroupings
        {
            get
            {
                return GetCollection<SalesRepGrouping>("SalesRepGroupings");
            }
        }

        //[Association("SalesRep-CustomersSRSplit")]
        
        //public XPCollection<SalesRep> SalesReps

        //{
        //    get
        //    {
        //        return GetCollection<SalesRep>("SalesReps");
        //    }
        //}
        


        [Association("SalesRep-SaleRepProductLineComPct")]
        public XPCollection<SaleRepProductLineComPct> SaleRepProductLineComPct
        {
            get
            {
                return GetCollection<SaleRepProductLineComPct>(nameof(SaleRepProductLineComPct));
            }
        }
    }
}
