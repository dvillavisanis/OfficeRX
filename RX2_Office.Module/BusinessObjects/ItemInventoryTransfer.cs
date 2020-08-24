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
    [NavigationItem("Inventory")]
    [DefaultClassOptions]
    [ImageName("IM/InventoryTransfer")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [ListViewFilter("Awaiting Shipping", "[TransferStatus] = 0", "Awaiting Shipping", "New Transfer waiting to be Shipped", false)]
    [ListViewFilter("Awaiting Receiving","[TransferStatus] = 1", "Awaiting Receiving", "Transfer shipped and waiting to be received", false)]
    [ListViewFilter("Received Transfers","[TransferStatus] = 2", "Received (closed) transfers Transfer", "Received Transfer ", false)]
    [ListViewFilter("All Open Transfer", "[TransferStatus] in (0,1)", "All Open Transfer", "All open transfers ", true)]
    [ListViewFilter("All", "", "All", "All", false)]


    public class ItemInventoryTransfer : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public enum eTransferStatus
        { New, Shipped, Received }

        public ItemInventoryTransfer(Session session)
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
        //    get { return _PersdistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}


        double originalCost;
        string transferComment;
        string trackingNumber;
        DateTime receivedDate;
        string receivedBy;
        DateTime shipDate;
        string shippedBy;
        DateTime createdDate;
        string transferCreatedBy;
        decimal shippingCost;
        decimal shipWeight;
        eTransferStatus transferStatus;
        double unitCost;
        double qtyTransfer;
        ItemInventory inventoryItem;
        DistributionCenterWhse toWhse;
        DistributionCenterWhse fromWhse;

        [Association("DistributionCenterWhse-TransferFrom")]
        public DistributionCenterWhse FromWhse
        {
            get => fromWhse;
            set => SetPropertyValue(nameof(FromWhse), ref fromWhse, value);
        }


        [Association("DistributionCenterWhse-TransferTo")]
        public DistributionCenterWhse ToWhse
        {
            get => toWhse;
            set => SetPropertyValue(nameof(ToWhse), ref toWhse, value);
        }


        [Association("ItemInventory-ItemInventoryTransfers")]
        public ItemInventory InventoryItem
        {
            get => inventoryItem;
            set => SetPropertyValue(nameof(InventoryItem), ref inventoryItem, value);
        }


        public double QtyTransfer
        {
            get => qtyTransfer;
            set => SetPropertyValue(nameof(QtyTransfer), ref qtyTransfer, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TransferComment
        {
            get => transferComment;
            set => SetPropertyValue(nameof(TransferComment), ref transferComment, value);
        }



        public double UnitCost
        {
            get => unitCost;
            set => SetPropertyValue(nameof(UnitCost), ref unitCost, value);
        }



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eTransferStatus TransferStatus
        {
            get => transferStatus;
            set => SetPropertyValue(nameof(TransferStatus), ref transferStatus, value);
        }


        public decimal ShipWeight
        {
            get => shipWeight;
            set => SetPropertyValue(nameof(ShipWeight), ref shipWeight, value);
        }


        public decimal ShippingCost
        {
            get => shippingCost;
            set => SetPropertyValue(nameof(ShippingCost), ref shippingCost, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TrackingNumber
        {
            get => trackingNumber;
            set => SetPropertyValue(nameof(TrackingNumber), ref trackingNumber, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TransferCreatedBy
        {
            get => transferCreatedBy;
            set => SetPropertyValue(nameof(TransferCreatedBy), ref transferCreatedBy, value);
        }


        public DateTime CreatedDate
        {
            get => createdDate;
            set => SetPropertyValue(nameof(CreatedDate), ref createdDate, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ShippedBy
        {
            get => shippedBy;
            set => SetPropertyValue(nameof(ShippedBy), ref shippedBy, value);
        }


        public DateTime ShipDate
        {
            get => shipDate;
            set => SetPropertyValue(nameof(ShipDate), ref shipDate, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ReceivedBy
        {
            get => receivedBy;
            set => SetPropertyValue(nameof(ReceivedBy), ref receivedBy, value);
        }


        public DateTime ReceivedDate
        {
            get => receivedDate;
            set => SetPropertyValue(nameof(ReceivedDate), ref receivedDate, value);
        }

        
        public double OriginalCost
        {
            get => originalCost;
            set => SetPropertyValue(nameof(OriginalCost), ref originalCost, value);
        }



    }







}