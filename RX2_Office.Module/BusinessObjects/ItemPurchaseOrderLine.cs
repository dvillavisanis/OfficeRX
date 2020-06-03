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
    [ImageName("PurchaseOrder")]
    [NavigationItem("Purchasing")]
    [ListViewFilter("All Lines PO", "[PurchaseOrder.PoStatus] = 1 ", "All Lines Items", "All line items", false)]

    [ListViewFilter("Open PO", "[PurchaseOrder.PoStatus] = 1 && QtyOrdered > QtyReceived ", "Open POs Items", "Items on Po That are marked open", true)]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ItemPurchaseOrderLine : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ItemPurchaseOrderLine(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        protected override void OnSaved()
        {
            base.OnSaved();

        }

        // Fields...

        private string _ItemDescription;
        private int _QtyReceived;
        private int _QtyReturned;
        private ItemUnitOfMeasure _UnitofMeasure;
        private Items _ItemNumber;
        private DateTime _LastDateReceived;
        private int _QtyBackOrdered;
        private decimal _UnitCost;
        private int _QtyOrdered;
        private RX2_Office.Module.BusinessObjects.ItemPurchaseOrder _PurchaseOrder;
        private Items _MasterItems;

        [Association("PurchaseOrder-PurchaseOrderLines")]
        public RX2_Office.Module.BusinessObjects.ItemPurchaseOrder PurchaseOrder
        {
            get
            {
                return _PurchaseOrder;
            }
            set
            {
                SetPropertyValue("PurchaseOrder", ref _PurchaseOrder, value);
            }
        }


        [VisibleInListView(true)]
        [RuleRequiredField]
        [Association("Items-PoLines")]
        [VisibleInDetailView(true)]
        public Items ItemNumber
        {
            get
            {
                return _ItemNumber;
            }
            set
            {
                if (Equals(ItemNumber, value)) return;
                SetPropertyValue("ItemNumber", ref _ItemNumber, value);
                if (SetPropertyValue<Items>("ItemNumber", ref _MasterItems, value))
                {
                    if (!IsLoading && ItemNumber != null)
                    {
                        this.ItemDescription = _MasterItems.ItemDescription;



                    }
                }
                SetPropertyValue("ItemNumber", ref _ItemNumber, value);


            }


        }

        [Size(255)]
        public string ItemDescription
        {
            get
            {
                return _ItemDescription;
                ;
            }
            set
            {
                SetPropertyValue("ItemDescription", ref _ItemDescription, value);
            }
        }


        [VisibleInListView(true)]
        [RuleRequiredField]
        public decimal UnitCost
        {
            get
            {
                return _UnitCost;
            }
            set
            {
                SetPropertyValue("UnitCost", ref _UnitCost, value);
                OnChanged("LineTotal");
            }
        }



        [VisibleInListView(true)]
        [RuleRequiredField]
        public int QtyOrdered
        {
            get
            {
                return _QtyOrdered;
            }
            set
            {
                SetPropertyValue("QtyOrdered", ref _QtyOrdered, value);
                OnChanged("LineTotal");
            }
        }




        public int QtyReceived
        {
            get
            {
                return _QtyReceived;
            }
            set
            {
                SetPropertyValue("QtyReceived", ref _QtyReceived, value);
            }
        }

        [VisibleInListView(false)]
        public int QtyBackOrdered
        {
            get
            {
                return _QtyBackOrdered;
            }
            set
            {
                SetPropertyValue("QtyBackOrdered", ref _QtyBackOrdered, value);
            }
        }


        public double QtyRemaining
        {
            get
            {
                return _QtyOrdered - _QtyReceived;
            }

        }


        [VisibleInListView(false)]
        public int QtyReturned
        {
            get
            {
                return _QtyReturned;
            }
            set
            {
                SetPropertyValue("QtyReturned", ref _QtyReturned, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime LastDateReceived
        {
            get
            {
                return _LastDateReceived;
            }
            set
            {
                SetPropertyValue("LastDateReceived", ref _LastDateReceived, value);
            }
        }



        [VisibleInListView(false)]
        [Association("ItemUnitOfMeasure-ItemPurchaseOrderLines")]
        public ItemUnitOfMeasure UnitofMeasure
        {
            get
            {
                return _UnitofMeasure;
            }
            set
            {
                SetPropertyValue("UnitofMeasure", ref _UnitofMeasure, value);
            }
        }



        [VisibleInListView(true)]
        [PersistentAlias("QtyOrdered * UnitCost")]
        public decimal LineTotal
        {
            get
            {
                return Convert.ToDecimal(EvaluateAlias("LineTotal"));

                //    object tempObject = EvaluateAlias("LineTotal");
                //if (tempObject != null)
                //{
                //    return (decimal)tempObject;
                //}
                //else
                //{
                //  return 0;
                //}
            }

        }
        [VisibleInListView(true)]
        [PersistentAlias("QtyRemaining * UnitCost")]
        public decimal OutstandingTotal
        {
            get
            {
                return Convert.ToDecimal(EvaluateAlias("OutstandingTotal"));


            }

        }


    }
}
