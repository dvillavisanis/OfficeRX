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
    [ImageName("CustomerRequest")]
    [NavigationItem("Purchasing")]
    [DefaultProperty("Request")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CustomerCustomUDRequest : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CustomerCustomUDRequest(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            CreatedDate = DateTime.Now;
            CreatedBy = SecuritySystem.CurrentUserName;
            SubsOkay = true;
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
        private bool _SubsOkay;
        private Customer _Customer;
        private string _DoseSize;
        private Items _MasterOriginal;
        private DeaClassEnum _DEAClass;
        private DateTime _FDARegisteredDate;
        private DateTime _DateSubmittedtoFDA;
        private string _NewNDC;
        private string _ProductionNotes;
        private string _PurchasingNote;
        private string _CustomerNote;
        private int _OrderIncrements;
        private decimal _StdPrice;
        private decimal _MinPrice;
        private RepackSoldIn _UOM;
        private int _MinCaseOrder;
        private int _CaseCount;
        private PackagingStyle _PackagingType;
        private CustomUDRequestStatus _Status;
        private string _CreatedBy;
        private DateTime _CreatedDate;
        private Items _OriginalItem;
        private string _Request;


        [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Request
        {
            get
            {
                return _Request;
            }
            set
            {
                SetPropertyValue("Request", ref _Request, value);
            }
        }


            [RuleRequiredField]
        [Association("Customer-CustomerCustomUDRequests")]
        public Customer Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                SetPropertyValue("Customer", ref _Customer, value);
            }
        }

        public CustomUDRequestStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                SetPropertyValue("CreatedDate", ref _CreatedDate, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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


            [RuleRequiredField]
        [Association("Items-CustomerCustomUDRequests")]
        public Items OriginalItem
        {
            get
            {
                return _OriginalItem;
            }
            set
            {

                if (Equals(OriginalItem, value)) return;
                SetPropertyValue("OriginalItem", ref _OriginalItem, value);
                if (SetPropertyValue<Items>("OriginalItem", ref _MasterOriginal, value))
                {
                    if (!IsLoading && OriginalItem != null)
                    {
                        this.DEAClass = OriginalItem.DeaClass;
                    }
                }
                SetPropertyValue("OriginalItem", ref _OriginalItem, value);
            }
        }

            [RuleRequiredField]
        public PackagingStyle PackagingType
        {
            get
            {
                return _PackagingType;
            }
            set
            {
                SetPropertyValue("PackagingType", ref _PackagingType, value);
            }
        }

            [RuleRequiredField]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(25)]
        public string DoseSize
        {
            get
            {
                return _DoseSize;
            }
            set
            {
                SetPropertyValue("DoseSize", ref _DoseSize, value);
            }
        }


        
        public bool SubsOkay
            {
                get
                {
                    return _SubsOkay;
                }
                set
                {
                    SetPropertyValue("SubsOkay", ref _SubsOkay, value);
                }
            }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public int CaseCount
        {
            get
            {
                return _CaseCount;
            }
            set
            {
                SetPropertyValue("CaseCount", ref _CaseCount, value);
            }
        }


        public int MinCaseOrder
        {
            get
            {
                return _MinCaseOrder;
            }
            set
            {
                SetPropertyValue("MinCaseOrder", ref _MinCaseOrder, value);
            }
        }


        public int OrderIncrements
        {
            get
            {
                return _OrderIncrements;
            }
            set
            {
                SetPropertyValue("OrderIncrements", ref _OrderIncrements, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public RepackSoldIn SoldIn
        {
            get
            {
                return _UOM;
            }
            set
            {
                SetPropertyValue("UOM", ref _UOM, value);
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

        public decimal StdPrice
        {
            get
            {
                return _StdPrice;
            }
            set
            {
                SetPropertyValue("StdPrice", ref _StdPrice, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string CustomerNote
        {
            get
            {
                return _CustomerNote;
            }
            set
            {
                SetPropertyValue("CustomerNote", ref _CustomerNote, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string PurchasingNote
        {
            get
            {
                return _PurchasingNote;
            }
            set
            {
                SetPropertyValue("PurchasingNote", ref _PurchasingNote, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string ProductionNotes
        {
            get
            {
                return _ProductionNotes;
            }
            set
            {
                SetPropertyValue("ProductionNotes", ref _ProductionNotes, value);
            }
        }


        [Size(11)]
        public string NewNDC
        {
            get
            {
                return _NewNDC;
            }
            set
            {
                SetPropertyValue("NewNDC", ref _NewNDC, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime DateSubmittedtoFDA
        {
            get
            {
                return _DateSubmittedtoFDA;
            }
            set
            {
                SetPropertyValue("DateSubmittedtoFDA", ref _DateSubmittedtoFDA, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime FDARegisteredDate
        {
            get
            {
                return _FDARegisteredDate;
            }
            set
            {
                SetPropertyValue("FDARegisteredDate", ref _FDARegisteredDate, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DeaClassEnum DEAClass
        {
            get
            {
                return _DEAClass;
            }
            set
            {
                SetPropertyValue("DEAClass", ref _DEAClass, value);
            }
        }

    }
}