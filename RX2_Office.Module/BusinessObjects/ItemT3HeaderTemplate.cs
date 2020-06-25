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
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [NavigationItem("Compliance")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemT3HeaderTemplate : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemT3HeaderTemplate(Session session)
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
        private ItemReceiver _ItemReceiver;
        private DistributionCenter _Whse;
        private string _Itemdescription;
        private string _ItemLot;
        private Items _Itemnumber;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private double _QtyRecieved;




        [Association("Items-ItemT3HeaderTemplates")]
        public Items Itemnumber
        {
            get
            {
                return _Itemnumber;
            }
            set
            {
                SetPropertyValue("Itemnumber", ref _Itemnumber, value);
            }
        }


        [Size(20)]
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


        [Size(128)]
        public string itemdescription
        {
            get
            {
                return _Itemdescription;
            }
            set
            {
                SetPropertyValue("itemdescription", ref _Itemdescription, value);
            }
        }


        [Association("DistributionCenter-ItemT3HeaderTemplate")]
        public DistributionCenter DistributionCenter
        {
            get
            {
                return _Whse;
            }
            set
            {
                SetPropertyValue("Whse", ref _Whse, value);
            }
        }

        [Association("ItemReceiver-ItemT3HeaderTemplates")]
        public ItemReceiver ItemReceiverId
        {
            get
            {
                return _ItemReceiver;
            }
            set
            {
                SetPropertyValue("ItemReceiver", ref _ItemReceiver, value);
            }
        }

        public double QtyRecieved
        {
            get
            {
                return _QtyRecieved;
            }
            set
            {
                SetPropertyValue("QtyRecieved", ref _QtyRecieved, value);
            }
        }

        [Size(50)]
        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                SetPropertyValue("CreatedBy", ref _CreatedBy, value);
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                SetPropertyValue("CreatedOn", ref _CreatedDate, value);
            }



        }
    }
}
