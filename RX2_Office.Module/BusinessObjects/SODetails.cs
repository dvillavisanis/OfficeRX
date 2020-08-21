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
    [ImageName("order")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SODetails : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        private decimal? fOnSalesOrder = null;
        public SODetails(Session session)
            : base(session)

        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).

            this.UnitOfMeasure = Session.FindObject<ItemUnitOfMeasure>(CriteriaOperator.Parse("UnitOfMeasureCode = 'EA'"));

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

        string itemDescription;
        string scan;
        int qtyInvoiced;
        private int _QtyPicked;
        private ItemWarehouse _Item;
        private SOHeader _SalesOrder;
        private ItemUnitOfMeasure _UnitOfMeasure;
        private int _QtyOrdered;
        private decimal _UnitPrice;

        [VisibleInListView(false)]
        [Association("SOHeader-SODetails")]

        public SOHeader SalesOrder
        {
            get
            {
                return _SalesOrder;
            }
            set
            {
                SetPropertyValue("SalesOrder", ref _SalesOrder, value);
            }
        }

        [Indexed]
        [Association("ItemWarehouse-SODetails")]
        [DataSourceCriteria("Warehouse = '@This.SalesOrder.DistributionCenterWhse' ")]
        public ItemWarehouse ItemNumber
        {

            get
            {

                return _Item;
            }
            set
            {
                if (!IsLoading && value != ItemNumber)

                {
                    SetPropertyValue("Item", ref _Item, value);
                    if (this.SalesOrder != null)
                    {
                        this.UnitPrice = SalesOrder.CustomerNumber.GetCustomerItemPrice(SalesOrder.CustomerNumber, ItemNumber.ItemNumber);
                    }
                }

                SetPropertyValue("Item", ref _Item, value);
            }
        }


        [VisibleInListView(false)]
        // [ModelDefault("EditMask", "#,##.##")]
        // [ModelDefault("DisplayFormat", "{0:0}")]
        public decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                SetPropertyValue("UnitPrice", ref _UnitPrice, value);
            }
        }

        [RuleValueComparison("less than qtyonhand", DefaultContexts.Save, ValueComparisonType.LessThanOrEqual, "ItemNumber.ItemNumber.QtyOnHand", ParametersMode.Expression, CustomMessageTemplate = "A value Less than or Equal to Qty On Hand is required", SkipNullOrEmptyValues = false)]
        [RuleValueComparison("Greater than 0", DefaultContexts.Save, ValueComparisonType.GreaterThan, "0", ParametersMode.Expression, CustomMessageTemplate = "A value Greater than 0 is required")]

        [ModelDefault("EditMask", "#,##.##")]
        [ModelDefault("DisplayFormat", "{0:0}")]
        public int QtyOrdered
        {
            get
            {
                return _QtyOrdered;
            }
            set
            {
                SetPropertyValue("QtyOrdered", ref _QtyOrdered, value);
            }
        }


        public int QtyPicked
        {
            get
            {
                return _QtyPicked;
            }
            set
            {
                SetPropertyValue("QtyPicked", ref _QtyPicked, value);
            }
        }

        public int QtyInvoiced
        {
            get => qtyInvoiced;
            set => SetPropertyValue(nameof(QtyInvoiced), ref qtyInvoiced, value);
        }



        [NonPersistentAttribute]
        public decimal ExtendedPrice
        {
            get
            {
                decimal ExtPrice = _QtyOrdered * _UnitPrice;
                return ExtPrice;
            }
        }

        [NonPersistent]

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemDescription
        {
            get
            {
                return ItemNumber?.ItemNumber?.ItemNumberDescription;
            }

        }


        [NonPersistentAttribute]
        [Size(1024)]
        public string Scan
        {
            get => scan;
            set => SetPropertyValue(nameof(Scan), ref scan, value);
        }

        [VisibleInListView(false)]
        [Association("ItemUnitOfMeasure-SODetails")]
        public ItemUnitOfMeasure UnitOfMeasure
        {
            get
            {
                return _UnitOfMeasure;
            }
            set
            {
                SetPropertyValue("UnitOfMeasure", ref _UnitOfMeasure, value);
            }
        }

        [ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        public byte[] Form222Img
        {
            get
            {
                return GetPropertyValue<byte[]>("Form222Img");
            }
            set
            {
                SetPropertyValue<byte[]>("Form222Img", value);
            }
        }

        [Association("SODetails-SOItemDistributions")]
        public XPCollection<SOItemDistibution> SOItemDistributions
        {
            get
            {
                return GetCollection<SOItemDistibution>("SOItemDistributions");
            }
        }


    }
}