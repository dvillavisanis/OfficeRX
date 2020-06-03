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
    public class ReceiverPackageItemSerialNo : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ReceiverPackageItemSerialNo(Session session)
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


       
        decimal unitCost;
        double quantity;
        DateTime expirationDt;
        string serialNumber;
        string lot;
        string itemNumber;
        string barCode;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BarCode
        {
            get => barCode;
            set => SetPropertyValue(nameof(BarCode), ref barCode, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemNumber
        {
            get => itemNumber;
            set => SetPropertyValue(nameof(ItemNumber), ref itemNumber, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Lot
        {
            get => lot;
            set => SetPropertyValue(nameof(Lot), ref lot, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SerialNumber
        {
            get => serialNumber;
            set => SetPropertyValue(nameof(SerialNumber), ref serialNumber, value);
        }


        public DateTime ExpirationDt
        {
            get => expirationDt;
            set => SetPropertyValue(nameof(ExpirationDt), ref expirationDt, value);
        }


        public double Quantity
        {
            get => quantity;
            set => SetPropertyValue(nameof(Quantity), ref quantity, value);
        }


        public decimal UnitCost
        {
            get => unitCost;
            set => SetPropertyValue(nameof(UnitCost), ref unitCost, value);
        }

        
        //[Association("ReceiverPackageItems-ReceiverPackageItemSerialNo")]
        //public ReceiverPackageItemSerialNo ReceiverPackageItem
        //{
        //    get => receiverPackageItem;
        //    set => SetPropertyValue(nameof(ReceiverPackageItem), ref receiverPackageItem, value);
        //}

    }


}