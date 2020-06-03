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
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class RepackLotOperations : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackLotOperations(Session session)
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
        private decimal _OldID;
        private bool _OpCompleted;
        private decimal _QtyShipped;
        private bool _ShowOnInvoice;
        private int _OperationOrder;
        private decimal _RetentionQty;
        private decimal _QtyLost;
        private decimal _QtyProcessed;
        private decimal _EstimatedQty;
        private string _UnitDoseUnitOfMeasure;
        private decimal _UnitDoseQty;
        private RepackOperations _RepackOperation;
        private RepackLots _RepackLotOid;
        private string _OperationDesc;

        [Association("RepackLots-RepackLotOperations")]
        public RepackLots RepackLotOid
        {
            get
            {
                return _RepackLotOid;
            }
            set
            {
                SetPropertyValue("RepackLotOid", ref _RepackLotOid, value);
            }
        }


        [Association("RepackOperations-RepackLotOperations")]
        public RepackOperations RepackOperation
        {
            get
            {
                return _RepackOperation;
            }
            set
            {
                SetPropertyValue("RepackOperation", ref _RepackOperation, value);
            }
        }


        [Size(254)]
        public string OperationDesc
        {
            get
            {
                return _OperationDesc;
            }
            set
            {
                SetPropertyValue("OperationDesc", ref _OperationDesc, value);
            }
        }


        public decimal UnitDoseQty
        {
            get
            {
                return _UnitDoseQty;
            }
            set
            {
                SetPropertyValue("UnitDoseQty", ref _UnitDoseQty, value);
            }
        }


        [Size(15)]
        public string UnitDoseUnitOfMeasure
        {
            get
            {
                return _UnitDoseUnitOfMeasure;
            }
            set
            {
                SetPropertyValue("UnitDoseUnitOfMeasure", ref _UnitDoseUnitOfMeasure, value);
            }
        }

        [VisibleInListView(false)]
        public decimal EstimatedQty
        {
            get
            {
                return _EstimatedQty;
            }
            set
            {
                SetPropertyValue("EstimatedQty", ref _EstimatedQty, value);
            }
        }

        [VisibleInListView(false)]
        public decimal QtyProcessed
        {
            get
            {
                return _QtyProcessed;
            }
            set
            {
                SetPropertyValue("QtyProcessed", ref _QtyProcessed, value);
            }
        }
        [VisibleInListView(false)]
        public decimal QtyLost
        {
            get
            {
                return _QtyLost;
            }
            set
            {
                SetPropertyValue("QtyLost", ref _QtyLost, value);
            }
        }

        [VisibleInListView(false)]
        public decimal RetentionQty
        {
            get
            {
                return _RetentionQty;
            }
            set
            {
                SetPropertyValue("RetentionQty", ref _RetentionQty, value);
            }
        }
        [VisibleInListView(false)]
        public decimal QtyShipped
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


        public int OperationOrder
        {
            get
            {
                return _OperationOrder;
            }
            set
            {
                SetPropertyValue("OperationOrder", ref _OperationOrder, value);
            }
        }

        [VisibleInListView(false)]
        public bool ShowOnInvoice
        {
            get
            {
                return _ShowOnInvoice;
            }
            set
            {
                SetPropertyValue("ShowOnInvoice", ref _ShowOnInvoice, value);
            }
        }


        public bool OpCompleted
        {
            get
            {
                return _OpCompleted;
            }
            set
            {
                SetPropertyValue("OpCompleted", ref _OpCompleted, value);
            }
        }


        public decimal OldID
        {
            get
            {
                return _OldID;
            }
            set
            {
                SetPropertyValue("OldID", ref _OldID, value);
            }
        }



        private XPCollection<AuditDataItemPersistent> changeHistory;
        public XPCollection<AuditDataItemPersistent> ChangeHistory
        {
            get
            {
                if (changeHistory == null)
                {
                    changeHistory = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return changeHistory;
            }
        }
    }
}
