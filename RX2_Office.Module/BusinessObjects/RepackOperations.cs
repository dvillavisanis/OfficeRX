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
       //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
   
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class RepackOperations : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackOperations(Session session)
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
        private decimal _OldId;
        private int _SortId;
        private bool _ChargeLotFee;
        private bool _ContainsLabel;
        private bool _IsMachineProcess;
        private decimal _MinPrice;
        private  decimal _StandardPrice;
        private  decimal _OperationUnitCost;
        private bool _ShownOnPackingSheet;
        private bool _IsActive;
        private string _OperationDescription;
        private string _AccountingItemNumber;

        [Size(18)]
        public string AccountingItemNumber
        {
            get
            {
                return _AccountingItemNumber;
            }
            set
            {
                SetPropertyValue("AccountingItemNumber", ref _AccountingItemNumber, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string OperationDescription
        {
            get
            {
                return _OperationDescription;
            }
            set
            {
                SetPropertyValue("OperationDescription", ref _OperationDescription, value);
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

        public bool shownOnPackingSheet
        {
            get
            {
                return _ShownOnPackingSheet;
            }
            set
            {
                SetPropertyValue("shownOnPackingSheet", ref _ShownOnPackingSheet, value);
            }
        }

        public decimal OperationUnitCost
        {
            get
            {
                return _OperationUnitCost;
            }
            set
            {
                SetPropertyValue("OperationUnitCost", ref _OperationUnitCost, value);
            }
        }

        public decimal StandardPrice
        {
            get
            {
                return _StandardPrice;
            }
            set
            {
                SetPropertyValue("StandardPrice", ref _StandardPrice, value);
            }
        }


        public decimal MinPrice
        {
            get
            {
                return _MinPrice;
            }
            set
            {
                SetPropertyValue("MinPrice", ref _MinPrice, value);
            }
        }

        public bool isMachineProcess
        {
            get
            {
                return _IsMachineProcess;
            }
            set
            {
                SetPropertyValue("isMachineProcess", ref _IsMachineProcess, value);
            }
        }

        public bool ContainsLabel
        {
            get
            {
                return _ContainsLabel;
            }
            set
            {
                SetPropertyValue("ContainsLabel", ref _ContainsLabel, value);
            }
        }

        public bool ChargeLotFee
        {
            get
            {
                return _ChargeLotFee;
            }
            set
            {
                SetPropertyValue("ChargeLotFee", ref _ChargeLotFee, value);
            }
        }

        public int SortId
        {
            get
            {
                return _SortId;
            }
            set
            {
                SetPropertyValue("SortId", ref _SortId, value);
            }
        }

        [Indexed]
        // the value for legacy software
        public decimal OldId
        {
            get
            {
                return _OldId;
            }
           set
           {
               SetPropertyValue("OldId", ref _OldId, value);
           }
        }


        [Association("RepackOperations-RepackLotOperations")]
        public XPCollection<RepackLotOperations> RepackLotOperations
        {
            get
            {
                return GetCollection<RepackLotOperations>("RepackLotOperations");
            }
        }
    }
}
