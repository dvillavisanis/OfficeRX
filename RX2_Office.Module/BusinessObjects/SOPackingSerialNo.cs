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
    [NavigationItem("Shipping")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
   
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SOPackingSerialNo : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SOPackingSerialNo(Session session)
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


        string scan;
        string serialNumber;
        DateTime dateEntered;
        string userName;
        DateTime expirationDate;
        double shipQty;
        string lot;
        string itemNumber;

        SOHeader salesOrder;
      


        //[Association("SOPacking-SoPackingSerialNumber")]
        //public SOPacking SoPackingId
        //{
        //    get => soPackingId;
        //    set => SetPropertyValue(nameof(SoPackingId), ref soPackingId, value);
        //}


        [Association("SOHeader-SoPackingSerailNumbers")]
        public SOHeader SalesOrder
        {
            get => salesOrder;
            set => SetPropertyValue(nameof(SalesOrder), ref salesOrder, value);
        }


        [Size(2044)]
        public string Scan
        {
            get => scan;
            set => SetPropertyValue(nameof(Scan), ref scan, value);
        }
        [Required]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemNumber
        {
            get => itemNumber;
            set => SetPropertyValue(nameof(ItemNumber), ref itemNumber, value);
        }

        [Required]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Lot
        {
            get => lot;
            set => SetPropertyValue(nameof(Lot), ref lot, value);
        }

        [Required]
        public double ShipQty
        {
            get => shipQty;
            set => SetPropertyValue(nameof(ShipQty), ref shipQty, value);
        }

        [Required]
        public DateTime ExpirationDate
        {
            get => expirationDate;
            set => SetPropertyValue(nameof(ExpirationDate), ref expirationDate, value);
        }


        [Size(64)]
        public string SerialNumber
        {
            get => serialNumber;
            set => SetPropertyValue(nameof(SerialNumber), ref serialNumber, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string UserName
        {
            get => userName;
            set => SetPropertyValue(nameof(UserName), ref userName, value);
        }


        public DateTime DateEntered
        {
            get => dateEntered;
            set => SetPropertyValue(nameof(DateEntered), ref dateEntered, value);
        }

       
    }
}