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
    [NavigationItem("Accounting")]

    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [ListViewFilter("Balance > 0", "Balance > 0 ", "Open Invoices", "Open Invoices", true)]
    [ListViewFilter("All", "", "All Invoices", "All Invoices",false)]


    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class VendorInvoice : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public VendorInvoice(Session session)
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

        string pONumber;
        Vendor vendor;
        DateTime sAPDateEntered;
        string sapRef;
        decimal balance;
        decimal paidAmount;
        decimal freightAmount;
        string accountingVendorNumber;
        decimal discountAmount;
        decimal invoiceAmount;
        string comment;
        DateTime invoiceDiscountDate;
        DateTime invoiceDueDate;
        DateTime invoiceDate;
        string invoiceNumber;


        [Association("Vendor-VendorInvoices")]
        public Vendor Vendor
        {
            get => vendor;
            set => SetPropertyValue(nameof(Vendor), ref vendor, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AccountingVendorNumber
        {
            get => accountingVendorNumber;
            set => SetPropertyValue(nameof(AccountingVendorNumber), ref accountingVendorNumber, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string InvoiceNumber
        {
            get => invoiceNumber;
            set => SetPropertyValue(nameof(InvoiceNumber), ref invoiceNumber, value);
        }

        
        [Size(25)]
        public string PONumber
        {
            get => pONumber;
            set => SetPropertyValue(nameof(PONumber), ref pONumber, value);
        }


        public DateTime InvoiceDate
        {
            get => invoiceDate;
            set => SetPropertyValue(nameof(InvoiceDate), ref invoiceDate, value);
        }



        public DateTime InvoiceDueDate
        {
            get => invoiceDueDate;
            set => SetPropertyValue(nameof(InvoiceDueDate), ref invoiceDueDate, value);
        }


        public DateTime InvoiceDiscountDate
        {
            get => invoiceDiscountDate;
            set => SetPropertyValue(nameof(InvoiceDiscountDate), ref invoiceDiscountDate, value);
        }

        // terms code


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Comment
        {
            get => comment;
            set => SetPropertyValue(nameof(Comment), ref comment, value);
        }


        public decimal InvoiceAmount
        {
            get => invoiceAmount;
            set => SetPropertyValue(nameof(InvoiceAmount), ref invoiceAmount, value);
        }


        public decimal DiscountAmount
        {
            get => discountAmount;
            set => SetPropertyValue(nameof(DiscountAmount), ref discountAmount, value);
        }



        public decimal FreightAmount
        {
            get => freightAmount;
            set => SetPropertyValue(nameof(FreightAmount), ref freightAmount, value);
        }


        public decimal PaidAmount
        {
            get => paidAmount;
            set => SetPropertyValue(nameof(PaidAmount), ref paidAmount, value);
        }


        public decimal Balance
        {
            get => balance;
            set => SetPropertyValue(nameof(Balance), ref balance, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SapRef
        {
            get => sapRef;
            set => SetPropertyValue(nameof(SapRef), ref sapRef, value);
        }

        
        public DateTime SAPDateEntered
        {
            get => sAPDateEntered;
            set => SetPropertyValue(nameof(SAPDateEntered), ref sAPDateEntered, value);
        }








    }
}