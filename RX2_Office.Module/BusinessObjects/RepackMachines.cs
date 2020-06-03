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
    [NavigationItem("Repack")]
   [ImageName("setup1")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class RepackMachines : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackMachines(Session session)
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
        private bool _IsProcessMachine;
        private bool _IsActive;
        private string _Comment;
        private DateTime _DateInservice;
        private string _Location;
        private string _Ctr;
        private static string _Owner;
        private string _InventoryId;
        private string _SerialNumber;
        private string _Model;
        private string _EquipmentDescription;
        private string _EquipmentId;

        [Size(25)]
        public string EquipmentId
        {
            get
            {
                return _EquipmentId;
            }
            set
            {
                SetPropertyValue("EquipmentId", ref _EquipmentId, value);
            }
        }


        [Size(50)]
        public string EquipmentDescription
        {
            get
            {
                return _EquipmentDescription;
            }
            set
            {
                SetPropertyValue("EquipmentDescription", ref _EquipmentDescription, value);
            }
        }

        [Size(25)]
        public string Model
        {
            get
            {
                return _Model;
            }
            set
            {
                SetPropertyValue("Model", ref _Model, value);
            }
        }

        [Size(25)]
        public string SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                SetPropertyValue("SerialNumber", ref _SerialNumber, value);
            }
        }

        [Size(25)]
        public string InventoryId
        {
            get
            {
                return _InventoryId;
            }
            set
            {
                SetPropertyValue("InventoryId", ref _InventoryId, value);
            }
        }

        [Size(25)]
        public string Owner
        {
            get
            {
                return _Owner;
            }
            set
            {
                SetPropertyValue("Owner", ref _Owner, value);
            }
        }

        [Size(25)]
        public string Ctr
        {
            get
            {
                return _Ctr;
            }
            set
            {
                SetPropertyValue("Ctr", ref _Ctr, value);
            }
        }

        [Size(50)]
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                SetPropertyValue("Location", ref _Location, value);
            }
        }

        public DateTime DateInservice
        {
            get
            {
                return _DateInservice;
            }
            set
            {
                SetPropertyValue("DateInservice", ref _DateInservice, value);
            }
        }


        [Size(254)]
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                SetPropertyValue("Comment", ref _Comment, value);
            }
        }


        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetPropertyValue("IsActive", ref _IsActive, value);
            }
        }

        public bool IsProcessMachine
        {
            get
            {
                return _IsProcessMachine;
            }
            set
            {
                SetPropertyValue("IsProcessMachine", ref _IsProcessMachine, value);
            }
        }
    }
}
