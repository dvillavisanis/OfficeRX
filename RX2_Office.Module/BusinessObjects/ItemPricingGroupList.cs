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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace RX2_Office.Module.BusinessObjects
{
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions ]
    [ImageName("GroupPricing")]
    [NavigationItem(  "Inventory")]
    [ListViewFilter("Web Pricing ", "[ItemPricingGroup.ItemGroupCd] = 'WEB'", "Web Pricing ", "Web Pricing", false)]

    [Appearance("Below Min", AppearanceItemType = "ViewItem", TargetItems = "*",
    Criteria = " [GroupPrice] < [Item.MinPrice] ", Context = "ListView", FontColor = "Maroon", Priority = 2)]
    [ListViewFilter("All", "",true)]
    //[DefaultProperty("DisplayMember

    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemPricingGroupList : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemPricingGroupList(Session session)
            : base(session)
        {
        
        }


        public override void AfterConstruction()
        {
            
        
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).

            LastModifiedDt = DateTime.Now;
                       
            
        }
        //private string _PersistentProperty;
        //[XafDisplayName("Group Pricing"), ToolTip("Group Item Pricing")]
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
        private ItemPricingGroup _ItemPricingGroup;
        private decimal _ContractAcquisitionCost;
  
        private decimal _GroupPrice;
        private Items _Item;


        [Association("ItemPricingGroup-ItemPricingGroupLists")]
        public ItemPricingGroup ItemPricingGroup
        {
            get
            {
                return _ItemPricingGroup;
            }
            set
            {
                SetPropertyValue("ItemPricingGroup", ref _ItemPricingGroup, value);
            }
        }
       


        [Association("Items-ItemPricingGroupLists")]
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


        public decimal GroupPrice
        {
            get
            {
                return _GroupPrice;
            }
            set
            {
                SetPropertyValue("GroupPrice", ref _GroupPrice, value);
                LastModifiedDt = DateTime.Now;
            }
        }


                
        public decimal ContractAcquisitionCost
        {
            get
            {
                return _ContractAcquisitionCost;
            }
            set
            {
                SetPropertyValue("ContractAcquisitionCost", ref _ContractAcquisitionCost, value);
            }
        }


        DateTime lastModifiedDt;
        public DateTime LastModifiedDt
        {
            get
            {
                return lastModifiedDt;
            }
            set
            {
                SetPropertyValue("LastModifiedDt", ref lastModifiedDt, value);
            }
        }


    }
}