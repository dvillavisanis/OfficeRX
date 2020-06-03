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
    [ListViewFilter("This Week", "[TransactionDate] > LocalDateTimeThisWeek() and  [TransactionDate] <= ADDDAYS(LocalDateTimeThisWeek(),+7) ", "This weeks Payemnts", "This weeks Payemnts ", true)]
    [ListViewFilter("This Month", "[TransactionDate] = LocalDateTimeThisMonth()", "This Month Payemnts", "This Month Payemnts ", false)]
    [ListViewFilter("Past 90 day", "[TransactionDate] >  ADDDAYS(LocalDateTimeToday(), -90)", "Past 90 day Payments", "Only Paymentsin the last 90 days. ", false)]
    [ListViewFilter("Past Year", "[TransactionDate] >  ADDDAYS(LocalDateTimeToday(), -365)", "Past Year Payments", "Only Paymentsin the past year. ", false)]
    
    [ListViewFilter(" All ", "")]
    [NavigationItem("Accounting")]
    [DefaultClassOptions]
    [ImageName("customersPayments")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CustomerInvoicePayments : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerInvoicePayments(Session session)
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
        private string _AuthorizationCode;
        private Customer _CustomerOID;
        private decimal _TransactionAmount;
        private string _CreditCardTransactionId;
        private string _CCcvv2Number;
        private string _CcNumberLastfour;
        private string _EncryptedCardNumber;
        private int _CcExpYear;
        private int _CCExpMonth;
        private string _CardHoldername;
        private string _PaymentReferance;
        private CustomerInvoiceHistory _InvoiceNumber;
        private ArPaymentType _PyamentType;
        private string _CheckNumber;
        private DateTime _TransactionDate;

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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CheckNumber
        {
            get
            {
                return _CheckNumber;
            }
            set
            {
                SetPropertyValue("CheckNumber", ref _CheckNumber, value);
            }
        }


        [Association("Customer-CustomerInvoicePayments")]
        public Customer CustomerOID
        {
            get
            {
                return _CustomerOID;
            }
            set
            {
                SetPropertyValue("CustomerOID", ref _CustomerOID, value);
            }
        }

        public ArPaymentType PyamentType
        {
            get
            {
                return _PyamentType;
            }
            set
            {
                SetPropertyValue("PyamentType", ref _PyamentType, value);
            }
        }


        [Association("CustomerInvoiceHistory-CustomerInvoicePayments")]
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

        public decimal TransactionAmount
        {
            get
            {
                return _TransactionAmount;
            }
            set
            {
                SetPropertyValue("TransactionAmount", ref _TransactionAmount, value);
            }
        }
        [VisibleInListView(false)]
        [Size(64)]
        public string PaymentReferance
        {
            get
            {
                return _PaymentReferance;
            }
            set
            {
                SetPropertyValue("PaymentReferance", ref _PaymentReferance, value);
            }
        }

        [VisibleInListView(false)]
        [Size(64)]
        public string CardHoldername
        {
            get
            {
                return _CardHoldername;
            }
            set
            {
                SetPropertyValue("CardHoldername", ref _CardHoldername, value);
            }
        }

        [VisibleInListView(false)]
        public int CCExpMonth
        {
            get
            {
                return _CCExpMonth;
            }
            set
            {
                SetPropertyValue("CCExpMonth", ref _CCExpMonth, value);
            }
        }
        [VisibleInListView(false)]
        public int ccExpYear
        {
            get
            {
                return _CcExpYear;
            }
            set
            {
                SetPropertyValue("ccExpYear", ref _CcExpYear, value);
            }
        }

        [VisibleInListView(false)]
        [Size(32)]
        [PasswordPropertyText]
        public string EncryptedCardNumber
        {
            get
            {
                return _EncryptedCardNumber;
            }
            set
            {
                SetPropertyValue("EncryptedCardNumber", ref _EncryptedCardNumber, value);
            }
        }



        [VisibleInListView(false)]
        [Size(4)]
        public string ccNumberLastfour
        {
            get
            {
                return _CcNumberLastfour;
            }
            set
            {
                SetPropertyValue("ccNumberLastfour", ref _CcNumberLastfour, value);
            }
        }

        [VisibleInListView(false)]
        [Size(4)]
        public string CCcvv2Number
        {
            get
            {
                return _CCcvv2Number;
            }
            set
            {
                SetPropertyValue("CCcvv2Number", ref _CCcvv2Number, value);
            }
        }

        [VisibleInListView(false)]
        [Size(32)]
        public string CreditCardTransactionId
        {
            get
            {
                return _CreditCardTransactionId;
            }
            set
            {
                SetPropertyValue("CreditCardTransactionId", ref _CreditCardTransactionId, value);
            }
        }

        [VisibleInListView(false)]
        [Size(10)]
        public string AuthorizationCode
        {
            get
            {
                return _AuthorizationCode;
            }
            set
            {
                SetPropertyValue("AuthorizationCode", ref _AuthorizationCode, value);
            }
        }
    }
}