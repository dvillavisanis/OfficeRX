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
    [ImageName("Salesrepgoal")]
    [NavigationItem("Sales")]
    [ListViewFilter("This Months Goals", "[GoalMonth] = GetMonth(Now()) and [GoalYear] = GetYear(Now())  ", "This Months Goals", "This Months Goals", true)]
   
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SalesRepGoals : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SalesRepGoals(Session session)
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
       [Indexed("SalesRep;GoalYear;GoalMonth", Unique = true)]
        private int _UdUntdDollars;
        private int _UDCiiDollars;
        private int _UdOintmentDollars;
        private int _UdNarcDollars;
        private int _UdSyringDollars;
        private int _UdPowderDollars;
        private int _UdLiquidDollars;
        private int _UdSolidDollars;
        private int _UdUntdUnits;
        private int _UDCiiUnits;
        private int _UdOintmentUnits;
        private int _UdNarcUnits;
        private int _UdSyringUnits;
        private int _UdPowderUnits;
        private int _UdLiquidUnits;
        private int _UdSolidUnits;
        private decimal _UdSaleTotalGoalDollars;
        private decimal _GoalAmt;
        private String _GoalYear;
        private SalesRep _SalesRep;
        private ShortMonthName _GoalMonth;


        [Association("SalesRep-SalesRepGoals")]
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


        public String GoalYear
        {
            get
            {
                return _GoalYear;
            }
            set
            {
                SetPropertyValue("GoalYear", ref _GoalYear, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public ShortMonthName GoalMonth
        {
            get
            {
                return _GoalMonth;
            }
            set
            {
                SetPropertyValue("GoalMonth", ref _GoalMonth, value);
            }
        }


        public decimal GoalAmt
        {
            get
            {
                return _GoalAmt;
            }
            set
            {
                SetPropertyValue("GoalAmt", ref _GoalAmt, value);
            }
        }



        public decimal UdSaleTotalGoalDollars
        {
            get
            {
                return _UdSaleTotalGoalDollars;
            }
            set
            {
                SetPropertyValue("UdSaleTotalGoalDollars", ref _UdSaleTotalGoalDollars, value);
            }
        }


        [VisibleInListView(false)]
        public int UdSolidUnits
        {
            get
            {
                return _UdSolidUnits;
            }
            set
            {
                SetPropertyValue("UdSolidUnits", ref _UdSolidUnits, value);
            }
        }

        [VisibleInListView(false)]
        public int UdLiquidUnits
        {
            get
            {
                return _UdLiquidUnits;
            }
            set
            {
                SetPropertyValue("UdLiquidUnits", ref _UdLiquidUnits, value);
            }
        }

        [VisibleInListView(false)]
        public int UdPowderUnits
        {
            get
            {
                return _UdPowderUnits;
            }
            set
            {
                SetPropertyValue("UdPowderUnits", ref _UdPowderUnits, value);
            }
        }

        [VisibleInListView(false)]
        public int UdSyringUnits
        {
            get
            {
                return _UdSyringUnits;
            }
            set
            {
                SetPropertyValue("UdSyringUnits", ref _UdSyringUnits, value);
            }
        }
    [VisibleInListView(false)]
        public int UdNarcUnits
        {
            get
            {
                return _UdNarcUnits;
            }
            set
            {
                SetPropertyValue("UdNarcUnits", ref _UdNarcUnits, value);
            }
        }
    [VisibleInListView(false)]
        public int UdOintmentUnits
        {
            get
            {
                return _UdOintmentUnits;
            }
            set
            {
                SetPropertyValue("UdOintmentUnits", ref _UdOintmentUnits, value);
            }
        }
    [VisibleInListView(false)]
        public int UDCiiUnits
        {
            get
            {
                return _UDCiiUnits;
            }
            set
            {
                SetPropertyValue("UDCiiUnits", ref _UDCiiUnits, value);
            }
        }
    [VisibleInListView(false)]
        public int UdUntdUnits
        {
            get
            {
                return _UdUntdUnits;
            }
            set
            {
                SetPropertyValue("UdUntdUnits", ref _UdUntdUnits, value);
            }
        }
    [VisibleInListView(false)]
        public int UdSolidDollars
        {
            get
            {
                return _UdSolidDollars;
            }
            set
            {
                SetPropertyValue("UdSolidDollars", ref _UdSolidDollars, value);
            }
        }
    [VisibleInListView(false)]
        public int UdLiquidDollars
        {
            get
            {
                return _UdLiquidDollars;
            }
            set
            {
                SetPropertyValue("UdLiquidDollars", ref _UdLiquidDollars, value);
            }
        }
    [VisibleInListView(false)]
        public int UdPowderDollars
        {
            get
            {
                return _UdPowderDollars;
            }
            set
            {
                SetPropertyValue("UdPowderDollars", ref _UdPowderDollars, value);
            }
        }
    [VisibleInListView(false)]
        public int UdSyringDollars
        {
            get
            {
                return _UdSyringDollars;
            }
            set
            {
                SetPropertyValue("UdSyringDollars", ref _UdSyringDollars, value);
            }
        }
    [VisibleInListView(false)]
        public int UdNarcDollars
        {
            get
            {
                return _UdNarcDollars;
            }
            set
            {
                SetPropertyValue("UdNarcDollars", ref _UdNarcDollars, value);
            }
        }
    [VisibleInListView(false)]
        public int UdOintmentDollars
        {
            get
            {
                return _UdOintmentDollars;
            }
            set
            {
                SetPropertyValue("UdOintmentDollars", ref _UdOintmentDollars, value);
            }
        }
    [VisibleInListView(false)]
        public int UDCiiDollars
        {
            get
            {
                return _UDCiiDollars;
            }
            set
            {
                SetPropertyValue("UDCiiDollars", ref _UDCiiDollars, value);
            }
        }
            [VisibleInListView(false)]
        public int UdUntdDollars
        {
            get
            {
                return _UdUntdDollars;
            }
            set
            {
                SetPropertyValue("UdUntdDollars", ref _UdUntdDollars, value);
            }
        }



    }
}