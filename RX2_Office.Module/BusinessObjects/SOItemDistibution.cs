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
    
   // [NavigationItem("Distribution")]
    [ImageName("Distribution")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SOItemDistibution : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SOItemDistibution(Session session)
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
      
        private SODetails _SOLineDetail;

      private DateTime _DistributionDate;
     
        private int _QtyShipped;
            private decimal _UnitPrice;
        private decimal _UnitCost;
        private string _ItemLot;
        private ItemInventory _ItemNumber;



        [Association("SODetails-SOItemDistributions")]
        public SODetails SOLineDetail
        {
            get
            {
                return _SOLineDetail;
            }
            set
            {
                SetPropertyValue("SOLineDetail", ref _SOLineDetail, value);
            }
        }
        [Association("ItemInventory-SOItemDistribution")]
       // [DataSourceCriteria("SoHeader. = 'Manager' AND Oid != '@This.Oid'")]
        public ItemInventory ItemInventory
        {
            get
            {
                return _ItemNumber;
            }
            set
            {
                SetPropertyValue("ItemNumber", ref _ItemNumber, value);
            }
        }

        public DateTime DistributionDate
        {
            get
            {
                return _DistributionDate;
            }
            set
            {
                SetPropertyValue("DistributionDate", ref _DistributionDate, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemLot
        {
            get
            {
                return _ItemLot;
            }
            set
            {
                SetPropertyValue("ItemLot", ref _ItemLot, value);
            }
        }

        public decimal UnitCost
        {
            get
            {
                return _UnitCost;
            }
            set
            {
                SetPropertyValue("UnitCost", ref _UnitCost, value);
            }
        }

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

        public int QtyShipped
        {
            get
            {
                return _QtyShipped;
            }
            set
            {
                SetPropertyValue("QtyShipped", ref _QtyShipped, value);
            }
        }


      


    }
}