using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.SystemModule;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Sales")]

    [ImageName("note-Customer")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    
   // [ListViewFilter(" My This Week", "[NoteDate] >= LocalDateTimeThisWeek() and [NoteDate] <= LocalDateTimeNextWeek() and [Customers.SalesRep] = CurrentUserName()", " My This Week", "This Weeks Notes. ", false)]

    [ListViewFilter(" My This Month", "[Author] = CurrentUserName() && [NoteDate] >= LocalDateTimeThisMonth() and [NoteDate] <= LocalDateTimeNextMonth() ", "My This Month", "My This Month Notes. ", true , Index = 1 )]
    [ListViewFilter(" My This Week", "[Author] = CurrentUserName() && [NoteDate] >= LocalDateTimeThisWeek() and [NoteDate] <= LocalDateTimeNextWeek() ", "My This Week", "My This Weeks Notes. ", false, Index = 2)]
    [ListViewFilter(" My Yesterday's's Notes", "[Author] = CurrentUserName() && [NoteDate] >=  LocalDateTimeYesterday() and [NoteDate] <= LocalDateTimeToday() ", " My Yesterday and Today", "  My Notes from yesterday and Today.", false, Index = 3)]
    [ListViewFilter(" My Last Week", "[Author] = CurrentUserName() && [NoteDate] >= LocalDateTimeLastWeek() and [NoteDate] <= LocalDateTimeThisWeek() ", "Last Week", "Last Weeks Notes. ", false, Index = 4)]
    [ListViewFilter(" My Last Month", "[Author] = CurrentUserName() && [NoteDate] >= LocalDateTimeLastMonth() and [NoteDate] <= LocalDateTimeThisMonth() ", "My Last Month ", "My Last Month Notes. ", false, Index = 5)]
    [ListViewFilter(" My All Past Year", "[Author] = CurrentUserName() && [NoteDate] >  ADDDAYS(LocalDateTimeToday(), -365) ", "My Past Year Notes", "My notes for past 365 days. ", false, Index = 6)]
    [ListViewFilter(" My All ", "[Author] = CurrentUserName() ", "My All Notes", "My All Notes", false,Index = 0 )]


    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class CustomerNote : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CustomerNote(Session session)
            : base(session)
        {
          
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            if (SecuritySystem.CurrentUserId != null)
            {

                Author = SecuritySystem.CurrentUserName;
                NoteDate = DateTime.Today;
            }

        }
        public void atest()
        {
            int i = 1;
            i = i + i;


        
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
        //    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
        //    this.PersistentProperty = "Paid";
        //}
        // Fields...
        private Customer _Customers;
        private string _Text;
        private DateTime _NoteDate;
        private string _Author;

        [Required]
        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {
                SetPropertyValue("Author", ref _Author, value);
            }
        }
        [VisibleInListView(true)]
        [Index(0)]
        [Indexed(Unique = false)]
        public DateTime NoteDate
        {
            get
            {
                return _NoteDate;
            }
            set
            {
                SetPropertyValue("NoteDate", ref _NoteDate, value);
            }
        }

        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(true)]
        [Index(0)]
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                SetPropertyValue("Text", ref _Text, value);
            }
        }

        
        [Association("Customer-CustomerNotes")]
        public Customer Customers
        {
            get
            {
                return _Customers;
            }
            set
            {
                SetPropertyValue("Customers", ref _Customers, value);
            }
        }


        public void AddNote(Customer cust, String Note)
        {

            CustomerNote cn = new CustomerNote(Session);
            cn.Author = SecuritySystem.CurrentUserName;
            cn.Customers = cust;
            cn.NoteDate = DateTime.Now;
            cn.Text = Note;
            cn.Save();


        }


    }


}
