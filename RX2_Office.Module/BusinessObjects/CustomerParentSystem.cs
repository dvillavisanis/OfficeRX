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
    [ImageName("CustomerParent")]
    [NavigationItem("Sales")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class CustomerParentSystem : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CustomerParentSystem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            decimal nextid = GetNextId();
            OID = nextid++;

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
        //    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
        //    this.PersistentProperty = "Paid";
        //}
        // Fields...

        private string _ParentSystemName;
        private Decimal _OID;

        [Key]
        [ModelDefault("EditMask", "###,###")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        public Decimal OID
        {
            get
            {
                return _OID;
            }
            set
            {
                SetPropertyValue("OID", ref _OID, value);
            }
        }

        public string ParentSystemName
        {
            get
            {
                return _ParentSystemName;
            }
            set
            {
                SetPropertyValue("ParentSystemName", ref _ParentSystemName, value);
            }
        }

        [Association("CustomerParentSystem-Customers")]
        public XPCollection<Customer> Customer
        {
            get
            {
                return GetCollection<Customer>("Customer");
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

        public decimal GetNextId()
        {
            decimal ret = 0;

            Object maxId = Session.Evaluate<CustomerParentSystem>(CriteriaOperator.Parse("Max(OID)"), null);

            if (maxId != null)
            {
                  ret = Convert.ToDecimal(maxId) + 1;
                return ret;
            }
            return ret;
        }

    }

    }
