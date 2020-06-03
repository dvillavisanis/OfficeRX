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
    [NavigationItem("Sales")]

    [ListViewAutoFilterRowAttribute(true)]
    [ImageName("CustomerItemPricing")]
    [ListViewFilter(" My Customer Pricing", " [Customer.SalesRep] = CurrentUserName()", " My Customer Pricing ", "My Customer Pricing. ", true)]
    [ListViewFilter(" All ", "")]

    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]


    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CustomerItemPricing : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerItemPricing(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsContractPricing = false;
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
        private bool _IsContractPricing;
        private DateTime _LastUpdated;
        private string _LastUpdatedBy;
        private decimal _CustomerPrice;
        private Items _Item;
        private Customer _Customer;

        [Association("Customer-CustomerItemPricing")]
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


        [Association("Items-CustomerItemPricing")]
        public Items Item
        {
            get
            {
                return _Item;
            }
            set
            {
                SetPropertyValue("Item", ref _Item, value);
            }
        }


        public decimal CustomerPrice
        {
            get
            {
                return _CustomerPrice;
            }
            set
            {
                SetPropertyValue("CustomerPrice", ref _CustomerPrice, value);
            }
        }


        public bool IsContractPricing
        {
            get
            {
                return _IsContractPricing;
            }
            set
            {
                SetPropertyValue("IsContractPricing", ref _IsContractPricing, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastUpdatedBy
        {
            get
            {
                return _LastUpdatedBy;
            }
            set
            {
                SetPropertyValue("LastUpdatedBy", ref _LastUpdatedBy, value);
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return _LastUpdated;
            }
            set
            {
                SetPropertyValue("LastUpdated", ref _LastUpdated, value);
            }
        }


    }
}