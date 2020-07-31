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
    [ImageName("whseinv")]
    [NavigationItem("Inventory")]
    [DefaultProperty("ItemNumber")]
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemWarehouse :XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemWarehouse(Session session)
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

        Items itemNumber;
        [Association("Items-ItemWarehouseInv")]
        [RuleRequiredField]
        public Items ItemNumber
        {
            get
            {
                return itemNumber;
            }
            set
            {
                SetPropertyValue(nameof(ItemNumber), ref itemNumber, value);
            }
        }

     
        DistributionCenterWhse whsehouse;
        [Association("DistributionCenterWhse-ItemWarehouses")]
        public DistributionCenterWhse Warehouse
        {
            get
            {
                return whsehouse;
            }
            set
            {
                SetPropertyValue(nameof(Warehouse), ref whsehouse, value);
            }
        }
        double qtyOnHand;
        public double QtyOnHand
        {
            get
            {
                return qtyOnHand;
            }
            set
            {
                SetPropertyValue(nameof(QtyOnHand), ref qtyOnHand, value);
            }
        }

        decimal whseUnitCost;
        public decimal WhseUnitCost
        {
            get
            {
                return whseUnitCost;
            }
            set
            {
                SetPropertyValue(nameof(WhseUnitCost), ref whseUnitCost, value);
            }
        }
        double qtyOnSO;
        public double QtyOnSO
        {
            get
            {
                return qtyOnSO;
            }
            set
            {
                SetPropertyValue(nameof(QtyOnSO), ref qtyOnSO, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public double QtyAvailable=> (QtyOnHand - QtyOnSO);

        DateTime lastReceiveDate;
        public DateTime LastReceiveDate
        {
            get
            {
                return lastReceiveDate;
            }
            set
            {
                SetPropertyValue(nameof(LastReceiveDate), ref lastReceiveDate, value);
            }
        }
        [Association("ItemWarehouse-SODetails")]
        public XPCollection<SODetails> SODetails
        {
            get
            {
                return GetCollection<SODetails>(nameof(SODetails));
            }
        }

        // Created/Updated: ABC\VillavisanisD on SOLIDTSI-03 at 7/31/2020 2:06 PM
        public new class FieldsClass : XPObject.FieldsClass
        {
            public FieldsClass()
            {

            }

            public FieldsClass(string propertyName) : base(propertyName)
            {

            }

            public PersistentBase.FieldsClass ItemNumber => new PersistentBase.FieldsClass(GetNestedName("ItemNumber"));

            public PersistentBase.FieldsClass Warehouse => new PersistentBase.FieldsClass(GetNestedName("Warehouse"));

            public OperandProperty QtyOnHand => new OperandProperty(GetNestedName("QtyOnHand"));

            public OperandProperty WhseUnitCost => new OperandProperty(GetNestedName("WhseUnitCost"));

            public OperandProperty QtyOnSO => new OperandProperty(GetNestedName("QtyOnSO"));

            public OperandProperty QtyAvailable => new OperandProperty(GetNestedName("QtyAvailable"));

            public OperandProperty LastReceiveDate => new OperandProperty(GetNestedName("LastReceiveDate"));

            public OperandProperty SODetails => new OperandProperty(GetNestedName("SODetails"));
        }

        public new static FieldsClass Fields
        {
            get
            {
                if (ReferenceEquals(_Fields, null))
                {
                    _Fields = new FieldsClass();
                }

                return _Fields;
            }
        }

        static FieldsClass _Fields;
    }
}