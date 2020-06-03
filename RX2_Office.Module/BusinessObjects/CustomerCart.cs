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
    [ImageName("")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CustomerCart : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerCart(Session session)
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

        Customer customers;
        [Association("Customer-CustomerCarts")]
        public Customer Customers
        {
            get
            {
                return customers;
            }
            set
            {
                SetPropertyValue(nameof(Customers), ref customers, value);
            }
        }

        Items cartItem;
        [Association("Items-CustomerCarts")]
        public Items CartItem
        {
            get
            {
                return cartItem;
            }
            set
            {
                SetPropertyValue(nameof(CartItem), ref cartItem, value);
            }
        }
        double itemPrice;
        public double ItemPrice
        {
            get
            {
                return itemPrice;
            }
            set
            {
                SetPropertyValue(nameof(ItemPrice), ref itemPrice, value);
            }
        }


        DateTime dateEntered;
        public DateTime DateEntered
        {
            get
            {
                return dateEntered;
            }
            set
            {
                SetPropertyValue(nameof(DateEntered), ref dateEntered, value);
            }
        }

        string enteredBy;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EnteredBy
        {
            get
            {
                return enteredBy;
            }
            set
            {
                SetPropertyValue(nameof(EnteredBy), ref enteredBy, value);
            }
        }


    }
}