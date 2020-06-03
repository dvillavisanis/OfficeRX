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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CustomerGPOItemPricing : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerGPOItemPricing(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            LastUpdated = DateTime.Now;
            UpdatedBy = SecuritySystem.CurrentUserName;
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
        CustomerGPO customerGPO;
        [Association("CustomerGPO-CustomerGpoItemPricing")]
        public CustomerGPO CustomerGPO
        {
            get
            {
                return customerGPO;
            }
            set
            {
                SetPropertyValue(nameof(CustomerGPO), ref customerGPO, value);
            }
        }

        Items itemNumber;
        [Association("Items-CustomerGPOItemPricing")]
        public Items ItemNumber
        {
            get
            {
                return itemNumber;
            }
            set
            {
                SetPropertyValue(nameof(ItemNumber), ref itemNumber, value);
            }
        }

        decimal itemGPOPrice;
        public decimal ItemGPOPrice
        {
            get
            {
                return itemGPOPrice;
            }
            set
            {
                SetPropertyValue(nameof(ItemGPOPrice), ref itemGPOPrice, value);
            }
        }
        DateTime lastUpdated;
        public DateTime LastUpdated
        {
            get
            {
                return lastUpdated;
            }
            set
            {
                SetPropertyValue(nameof(LastUpdated), ref lastUpdated, value);
            }
        }
        string updatedBy;
        [Size(35)]
        public string UpdatedBy
        {
            get
            {
                return updatedBy;
            }
            set
            {
                SetPropertyValue(nameof(UpdatedBy), ref updatedBy, value);
            }
        }

    }
}