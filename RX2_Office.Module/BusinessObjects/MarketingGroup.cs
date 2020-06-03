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
using RX2_Office.Module.BusinessObjects;

namespace RX2_Office.Module
{
    [NavigationItem("Marketing")]
    [DefaultClassOptions]

    [ImageName("Marketing")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class MarketingGroup : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public MarketingGroup(Session session)
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

        private string _PromoCode;
        private DateTime _EndDate;
        private DateTime _StartDate;
        private string _MarketingGroupName;

        [Size(25)]
        public string MarketingGroupName
        {
            get
            {
                return _MarketingGroupName;
            }
            set
            {
                SetPropertyValue("MarketingGroupName", ref _MarketingGroupName, value);
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                SetPropertyValue("StartDate", ref _StartDate, value);
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                SetPropertyValue("EndDate", ref _EndDate, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PromoCode
        {
            get
            {
                return _PromoCode;
            }
            set
            {
                SetPropertyValue("PromoCode", ref _PromoCode, value);
            }
        }

        [Association("MarketingGroup-Items")]
        public XPCollection<MarketingGroupItems> Items
        {
            get
            {
                return GetCollection<MarketingGroupItems>("Items");
            }
        }


        
        [Association("MarketingGroup-MarketingGroupCustomer")]
        public XPCollection<MarketingGroupCustomers> MarketingGroupCustomer
        {
            get
            {
                return GetCollection<MarketingGroupCustomers>("MarketingGroupCustomer");
            }
        }

    }
}
