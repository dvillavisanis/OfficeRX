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
    [NavigationItem("Inventory")]
    [ListViewAutoFilterRowAttribute(true)]
    
    //[ImageName("BO_Contact")]
    [DefaultProperty("BinBarcode")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DistributionCenterWhseBins : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DistributionCenterWhseBins(Session session)
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
        private DistributionCenterWhse _Warehouse;
private string _BinLevel;
        private string _BinRack;
        private string _BinBarcode;


        [Association("DistributionCenterWhse-DistributionCenterWhseBins")]
        public DistributionCenterWhse Warehouse
        {
            get
            {
                return _Warehouse;
            }
            set
            {
                SetPropertyValue("Whse", ref _Warehouse, value);
            }
        }

        [Size(15)]
        public string BinBarcode
        {
            get
            {
                return _BinBarcode;
            }
            set
            {
                SetPropertyValue("BinBarcode", ref _BinBarcode, value);
            }
        }


        [Size(15)]
        public string BinRack
        {
            get
            {
                return _BinRack;
            }
            set
            {
                SetPropertyValue("BinRack", ref _BinRack, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BinLevel
        {
            get
            {
                return _BinLevel;
            }
            set
            {
                SetPropertyValue("BinLevel", ref _BinLevel, value);
            }
        }

        [Association("DistributionCenterWhseBin-ItemReceivers")]
        public XPCollection<ItemReceiver> ItemReciever
        {
            get
            {
                return GetCollection<ItemReceiver>("ItemReciever");
            }
        }

        [Association("DistributionCenterWhseBins-ItemInventorys")]
        public XPCollection<ItemInventory> Inventory
        {
            get
            {
                return GetCollection<ItemInventory>("Inventory");
            }
        }
        
    }
}
