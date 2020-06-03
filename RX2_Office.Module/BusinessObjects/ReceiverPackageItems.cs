using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using System.Data;
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
    public class ReceiverPackageItems : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ReceiverPackageItems(Session session)
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


       // ReceiverPackageItemSerialNo propertyName;
        decimal unitCost;
        double qty;
       // string serialNumber;
        DateTime expireDate;

        string lot;
        string itemNumber;
        string barCode;
        ReceiverPackage receiverPackageId;

        [Association("ReceiverPackage-ReceiverPackageItems")]
        public ReceiverPackage ReceiverPackageId
        {
            get => receiverPackageId;
            set => SetPropertyValue(nameof(ReceiverPackageId), ref receiverPackageId, value);
        }


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

        public DateTime ExpireDate
        {
            get => expireDate;
            set => SetPropertyValue(nameof(ExpireDate), ref expireDate, value);
        }

        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //public string SerialNumber
        //{
        //    get => serialNumber;
        //    set => SetPropertyValue(nameof(SerialNumber), ref serialNumber, value);
        //}


        public double Qty
        {
            get => qty;
            set => SetPropertyValue(nameof(Qty), ref qty, value);
        }


        public decimal UnitCost
        {
            get => unitCost;
            set => SetPropertyValue(nameof(UnitCost), ref unitCost, value);
        }

        //[Association("ReceiverPackageItems-ReceiverPackageItemSerialNo")]
        //public XPCollection<ReceiverPackageItemSerialNo> SerialNumbers
        //{
        //    get
        //    {
        //        return GetCollection<ReceiverPackageItemSerialNo>(nameof(SerialNumbers));
        //    }
        //}

    }
}