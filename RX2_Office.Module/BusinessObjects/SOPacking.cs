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
    public class SOPacking : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SOPacking(Session session)
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


        SOHeader salesOrder;
        string scan;
        double itemQty;
        string itemLot;
        string itemNumber;

        
        [Association("SOHeader-SOPacking")]
        public SOHeader SalesOrder
        {
            get => salesOrder;
            set => SetPropertyValue(nameof(SalesOrder), ref salesOrder, value);
        }



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemNumber
        {
            get => itemNumber;
            set => SetPropertyValue(nameof(ItemNumber), ref itemNumber, value);
        }


        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //public string ItemLot
        //{
        //    get => itemLot;
        //    set => SetPropertyValue(nameof(ItemLot), ref itemLot, value);
        //}


        public  double ItemQty
        {
            get => itemQty;
            set => SetPropertyValue(nameof(ItemQty), ref itemQty, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Scan
        {
            get => scan;
            set => SetPropertyValue(nameof(Scan), ref scan, value);
        }

        //[Association("SOPacking-SoPackingSerialNumber")]
        //public XPCollection<SOPackingSerialNo> SoPackingSerialNumber
        //{
        //    get
        //    {
        //        return GetCollection<SOPackingSerialNo>(nameof(SoPackingSerialNumber));
        //    }
        //}

    }
}