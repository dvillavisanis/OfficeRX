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
    [ImageName("CustomerCDR")]
    [ListViewAutoFilterRowAttribute(true)]
    [NavigationItem("Sales")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [ListViewFilter("My Today's Calls", "[SalesRep] = CurrentUserName() && [CallDate] >= LocalDateTimeToday() ", "My Today's Calls ", "Calls I made today", true)]
    [ListViewFilter("My This Weeks Calls", "[SalesRep] = CurrentUserName() && [CallDate] >= LocalDateTimeThisWeek() ", "My This Weeks Calls ", "Calls I made this week", false)]
    [ListViewFilter("My This Month Calls", "[SalesRep] = CurrentUserName() && [CallDate] >= LocalDateTimeThisMonth() ", "My This Month Calls ", "Calls I made this month", false)]
    
    public class CustomerCDR : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerCDR(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        

        // Fields...
      
        private SalesRep _SalesRep;
        private Customer _Customer;
        private int _Mssql_trans;
        private string _UserField;
        private string _uniqueid;
        private string _AccountCode;
        private string _Disposition;
        private int _BillSeconds;
        private int _Duration;
        private string _LastData;
        private string _LastApp;
        private string _DstChannel;
        private string _Channel;
        private string _Dcontext;
        private string _Dst;
        private string _Src;
        private string _Clid;
        private DateTime _CallDate;


        [Indexed(Unique = false)]
        public DateTime CallDate
        {
            get
            {
                return _CallDate;
            }
            set
            {
                SetPropertyValue("CallDate", ref _CallDate, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Clid
        {
            get
            {
                return _Clid;
            }
            set
            {
                SetPropertyValue("Clid", ref _Clid, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Src
        {
            get
            {
                return _Src;
            }
            set
            {
                SetPropertyValue("Src", ref _Src, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string dst
        {
            get
            {
                return _Dst;
            }
            set
            {
                SetPropertyValue("dst", ref _Dst, value);
            }
        }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string dcontext
        {
            get
            {
                return _Dcontext;
            }
            set
            {
                SetPropertyValue("dcontext", ref _Dcontext, value);
            }
        }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Channel
        {
            get
            {
                return _Channel;
            }
            set
            {
                SetPropertyValue("Channel", ref _Channel, value);
            }
        }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string dstChannel
        {
            get
            {
                return _DstChannel;
            }
            set
            {
                SetPropertyValue("dstChannel", ref _DstChannel, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastApp
        {
            get
            {
                return _LastApp;
            }
            set
            {
                SetPropertyValue("LastApp", ref _LastApp, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastData
        {
            get
            {
                return _LastData;
            }
            set
            {
                SetPropertyValue("LastData", ref _LastData, value);
            }
        }
        [VisibleInListView(false)]
        public int Duration
        {
            get
            {
                return _Duration;
            }
            set
            {
                SetPropertyValue("Duration", ref _Duration, value);
            }
        }


        

        public int BillSeconds
        {
            get
            {
                return _BillSeconds;
            }
            set
            {
                SetPropertyValue("BillSeconds", ref _BillSeconds, value);
            }
        }

        [VisibleInListView(false)]
        [Size(45)]
        public string Disposition
        {
            get
            {
                return _Disposition;
            }
            set
            {
                SetPropertyValue("Disposition", ref _Disposition, value);
            }
        }
        [Indexed(Unique = false)]
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AccountCode
        {
            get
            {
                return _AccountCode;
            }
            set
            {
                SetPropertyValue("AccountCode", ref _AccountCode, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Uniqueid
        {
            get
            {
                return _uniqueid;
            }
            set
            {
                SetPropertyValue("Uniqueid", ref _uniqueid, value);
            }
        }

        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string UserField
        {
            get
            {
                return _UserField;
            }
            set
            {
                SetPropertyValue("UserField", ref _UserField, value);
            }
        }

        [VisibleInListView(false)]
        public int Mssql_trans
        {
            get
            {
                return _Mssql_trans;
            }
            set
            {
                SetPropertyValue("Mssql_trans", ref _Mssql_trans, value);
            }
        }

        [NonPersistent]
        public double BillMinutes
        {
            get
            {
                return _BillSeconds / 60;
            }

        }
        [Association("Customer-CustomerCDR")]
        public Customer Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                SetPropertyValue("Customer", ref _Customer, value);
            }
        }


        [Association("SalesRep-CustomerCDR")]
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
    }
}