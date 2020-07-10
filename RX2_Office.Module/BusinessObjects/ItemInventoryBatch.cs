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
using DevExpress.ExpressApp.Editors;

namespace RX2_Office.Module.BusinessObjects
{
    [ListViewAutoFilterRowAttribute(true)]
    [NavigationItem("Shipping")]

    [DefaultClassOptions]
    [ListViewFilter(" All", "")]
    [ListViewFilter(" Close Batches", "[Status] = 1", "Closed Batches", "Closed Inventory Batches", false)]

    [ListViewFilter(" Open Batches", "[Status] = 0", "Open Batches", "Open Inventory Batches", true)]

    [ImageName("Inventory")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemInventoryBatch : XPObject, INotifyPropertyChanged
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

        public event EventHandler<string> LastScanChangedEvent;
        public ItemInventoryBatch(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            CreatedDate = DateTime.Now;
            CreatedBy = SecuritySystem.CurrentUserName;

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
       // string fullDescription;
        string lastScan;
        eInventoryBatchType inventoryType;
        eItemInventoryBatchStatus status;
        DistributionCenterWhse dCWarehouse;
        string createdBy;
     //   DistributionCenterWhse distributionCenter;
        DateTime createdDate;
        string batchDiscription;
        [Required]
        [Size(64)]
        public string BatchDiscription
        {
            get => batchDiscription;
            set => SetPropertyValue(nameof(BatchDiscription), ref batchDiscription, value);
        }
        [Required]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eInventoryBatchType InventoryType
        {
            get => inventoryType;
            set => SetPropertyValue(nameof(InventoryType), ref inventoryType, value);
        }

        public DateTime CreatedDate
        {
            get => createdDate;
            set => SetPropertyValue(nameof(CreatedDate), ref createdDate, value);
        }

        [Size(25)]
        public string CreatedBy
        {
            get => createdBy;
            set => SetPropertyValue(nameof(CreatedBy), ref createdBy, value);
        }

        [Required]
        [Association("DistributionCenterWhse-ItemInventoryBatchs")]
        public DistributionCenterWhse DCWarehouse
        {
            get => dCWarehouse;
            set => SetPropertyValue(nameof(DCWarehouse), ref dCWarehouse, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eItemInventoryBatchStatus Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
        [Appearance("LasScanDisabled", Context = "DetailView", Visibility = ViewItemVisibility.Hide, Enabled = false, Criteria = "IsNullOrEmpty(DCWarehouse)")]

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastScan
        {
            get => lastScan;
            set
            {
                SetPropertyValue(nameof(LastScan), ref lastScan, value);
                LastScanChangedEvent?.Invoke(this, lastScan);

            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FullDescription
        {
            get => String.Format("{0} For:{1}", BatchDiscription, DCWarehouse.Name);
        }

        [Association("ItemInventoryBatch-ItemInventoryBatchS")]
        public XPCollection<ItemInventoryBatchSerialNo> ItemInventoryBatchS
        {
            get
            {
                return GetCollection<ItemInventoryBatchSerialNo>(nameof(ItemInventoryBatchS));
            }
        }


        [Association("ItemInventoryBatch-InventoryItemBatchItemss")]
        public XPCollection<InventoryItemBatchItems> Item
        {
            get
            {
                return GetCollection<InventoryItemBatchItems>(nameof(Item));
            }
        }
    }
}