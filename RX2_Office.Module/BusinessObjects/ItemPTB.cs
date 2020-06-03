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
    [ImageName("PriceToBeat")]
    [NavigationItem("Purchasing")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemPTB : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemPTB(Session session)
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
        [Association("Items-ItemPTBs")]
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
        DateTime startDate;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                SetPropertyValue(nameof(StartDate), ref startDate, value);
            }
        }
        DateTime endDate;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                SetPropertyValue(nameof(EndDate), ref endDate, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        DateTime enterDate;
        public DateTime EnterDate
        {
            get
            {
                return enterDate;
            }
            set
            {
                SetPropertyValue(nameof(EnterDate), ref enterDate, value);
            }
        }

        Decimal _PTB;
        public Decimal PTB
        {
            get
            {
                return _PTB;
            }
            set
            {
                SetPropertyValue(nameof(PTB), ref _PTB, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        Employee employee;
        [Association("Employee-ItemPTBs")]
        public Employee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                SetPropertyValue(nameof(Employee), ref employee, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        DateTime createdDate;
        public DateTime CreatedDate
        {
            get
            {
                return createdDate;
            }
            set
            {
                SetPropertyValue(nameof(CreatedDate), ref createdDate, value);
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