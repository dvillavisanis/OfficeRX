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
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions]
    [ImageName("PricingGroup")]
    [NavigationItem("Inventory")]
    [DefaultProperty("ItemGroupCd")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemPricingGroup : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemPricingGroup(Session session)
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

        private string _ItemGroupDescription;
        private string _ItemGroupCd;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemGroupCd
        {
            get
            {
                return _ItemGroupCd;
            }
            set
            {
                SetPropertyValue("ItemGroupCd", ref _ItemGroupCd, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemGroupDescription
        {
            get
            {
                return _ItemGroupDescription;
            }
            set
            {
                SetPropertyValue("ItemGroupDescription", ref _ItemGroupDescription, value);
            }
        }


        [Association("ItemPricingGroup-Customers")]
        public XPCollection<Customer> Customers
        {
            get
            {
                return GetCollection<Customer>("Customers");
            }
        }


        [Association("ItemPricingGroup-ItemPricingGroupLists")]
        public XPCollection<ItemPricingGroupList> ItemGroupPriceList
        {
            get
            {
                return GetCollection<ItemPricingGroupList>("ItemGroupPriceList");
            }
        }
    }
}