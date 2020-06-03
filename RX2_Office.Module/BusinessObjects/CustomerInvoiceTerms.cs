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

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("Payment Terms")]
    [NavigationItem("Sales")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CustomerInvoiceTerms : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
      /// <summary>
      /// Author Daniel Villavisanis
      /// </summary>
      /// <param name="session"></param>
        public CustomerInvoiceTerms(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            this.DaysBeforeDue = 0;
            this.DaysBeforeDiscountDue = 0;
            this.DiscountPercent = 0;

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


        private decimal _DiscountPercent;

        private int _DaysBeforeDiscountDue;
        private int _DaysBeforDue;
        private string _InvoiceTermDescription;
        private string _InvoiceTermCode;
        
        // Fields...

        [Key]
        [Size(10)]
        public string InvoiceTermCode
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


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string InvoiceTermDescription
        {
            get
            {
                return _InvoiceTermDescription;
            }
            set
            {
                SetPropertyValue("InvoiceTermDescription", ref _InvoiceTermDescription, value);
            }
        }


        public int DaysBeforeDue
        {
            get
            {
                return _DaysBeforDue;
            }
            set
            {
                SetPropertyValue("DaysBeforeDue", ref _DaysBeforDue, value);
            }
        }


        public int DaysBeforeDiscountDue
        {
            get
            {
                return _DaysBeforeDiscountDue;
            }
            set
            {
                SetPropertyValue("DaysBeforeDiscountDue", ref _DaysBeforeDiscountDue, value);
            }
        }



        public decimal DiscountPercent
        {
            get
            {
                return _DiscountPercent;
            }
            set
            {
                SetPropertyValue("DiscountPercent", ref _DiscountPercent, value);
            }
        }



        [Association("CustomerInvoiceTerms-CustomerInvoiceHistorys")]
        public XPCollection<CustomerInvoiceHistory> CustomerInvoiceHistory
        {
            get
            {
                return GetCollection<CustomerInvoiceHistory>("CustomerInvoiceHistory");
            }
        }
    }
}