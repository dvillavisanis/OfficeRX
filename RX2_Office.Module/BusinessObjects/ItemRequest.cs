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
    [ListViewFilter(" My Open Last 30 Day Request ", "[RequestBy] = CurrentUserName() && [RequestStatus] < 9  && [RequestDt] >=  ADDDAYS(LocalDateTimeToday(), -30)  ", " My Open last 30 days Request ", "Request I created In the last 30 days", true, Index = 0)]
    [ListViewFilter(" My Open Last 90 Day Request ", "[RequestBy] = CurrentUserName() && [RequestStatus] < 9  && [RequestDt] >=  ADDDAYS(LocalDateTimeToday(), -90)  ", " My Open last 90 days Request ", "Request I created In the last 90 days", true, Index = 2)]
    [ListViewFilter(" My ALL Open Request ", "[RequestBy] = CurrentUserName() && [RequestStatus] < 9  ", " My All Open Request ", "All Open Request I created", false, Index = 5)]
 
    [NavigationItem("Purchasing")]
    [ImageName("Request")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class ItemRequest : BaseObject
    {
        public ItemRequest(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            this.RequestBy = SecuritySystem.CurrentUserName;
            this.RequestDt = DateTime.Now;
            this.GoodUntilDt = DateTime.Now.AddDays(5);

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

        // Fields...
        private long _OldID;
        private bool _AllOrNothing;
        private DrugRequestSwitchReson _DrugRequestSwitchReson;
        private int _TotalAllocated;
        private string _RequestSOEnteredBy;
        private DateTime _RequestSalesOrderDate;
        private DateTime _CompletedDate;
        private string _Completedby;
        private bool _Completed;
        private PedBackToType _PedBackToType;
        private DateTime _SearchUntil;
        private decimal _BuyPrice;
        private bool _OnEDL;
        private bool _SubsOkay;
        private ItemRequestType _ItemRequestType;
        private ItemRequestStatus _RequestStatus;
        private Customer _Customer;
        private decimal _UnitPrice;
        private string _CustomerPO;
        private long _RequestQty;
        private DateTime _GoodUntilDt;
        private DateTime _RequestDt;
        private string _RequestBy;
        private Items _ItemNumber;
        private string _Comment;

        [RuleRequiredField]
        [Association("Items-Request")]
        public Items ItemNumber
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

        [RuleRequiredField]
        public ItemRequestType ItemRequestType
        {
            get
            {
                return _ItemRequestType;
            }
            set
            {
                SetPropertyValue("ItemRequestType", ref _ItemRequestType, value);
            }
        }
   
        public ItemRequestStatus RequestStatus
        {
            get
            {
                return _RequestStatus;
            }
            set
            {
                SetPropertyValue("RequestStatus", ref _RequestStatus, value);
            }
        }
        [VisibleInListView(true)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RequestBy
        {
            get
            {
                return _RequestBy;
            }
            set
            {
                SetPropertyValue("RequestBy", ref _RequestBy, value);
            }
        }

        [VisibleInListView(true)]
        
        public DateTime RequestDt
        {
            get
            {
                return _RequestDt;
            }
            set
            {
                SetPropertyValue("RequestDt", ref _RequestDt, value);
            }
        }
        [RuleRequiredField]
        [VisibleInListView(true)]
        public DateTime GoodUntilDt
        {
            get
            {
                return _GoodUntilDt;
            }
            set
            {
                SetPropertyValue("GoodUntilDt", ref _GoodUntilDt, value);
            }
        }
        [RuleRequiredField]
        public long   RequestQty
        {
            get
            {
                return _RequestQty;
            }
            set
            {
                //bool modified = SetPropertyValue("RequestQty", ref _RequestQty, value);
                //if (!IsLoading && !IsSaving && ItemRequestSummary != null && modified)
                //{
                // //  ItemRequestSummary.UpdateItemRequestTotal(true);
                    
                //}
            }
        }

        [VisibleInListView(false)]
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


        [RuleRequiredField]
        [Association("Customer-Requests")]
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

        [RuleRequiredField("SoldatOrMarketOrder ", DefaultContexts.Save,
      SkipNullOrEmptyValues = false, TargetCriteria = "ItemRequestType >= 2")]
        [VisibleInListView(false)]
        [Size(35)]
        public string CustomerPO
        {
            get
            {
                return _CustomerPO;
            }
            set
            {
                SetPropertyValue("CustomerPO", ref _CustomerPO, value);
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


        public bool OnEDL
        {
            get
            {
                return _OnEDL;
            }
            set
            {
                SetPropertyValue("OnEDL", ref _OnEDL, value);
            }
        }

    
        public decimal BuyPrice
        {
            get
            {
                return _BuyPrice;
            }
            set
            {
                SetPropertyValue("BuyPrice", ref _BuyPrice, value);
            }
        }

        [RuleRequiredField]
        public DateTime SearchUntil
        {
            get
            {
                return _SearchUntil;
            }
            set
            {
                SetPropertyValue("SearchUntil", ref _SearchUntil, value);
            }
        }

        [VisibleInListView(false)]
        public PedBackToType PedBackToType
        {
            get
            {
                return _PedBackToType;
            }
            set
            {
                SetPropertyValue("PedBackToType", ref _PedBackToType, value);
            }
        }



        [VisibleInListView(false)]
        public bool Completed
        {
            get
            {
                return _Completed;
            }
            set
            {
                SetPropertyValue("Completed", ref _Completed, value);
            }
        }

        [VisibleInListView(false)]
        [Size(25)]
        public string Completedby
        {
            get
            {
                return _Completedby;
            }
            set
            {
                SetPropertyValue("Completedby", ref _Completedby, value);
            }
        }
        [VisibleInListView(false)]
        public DateTime CompletedDate
        {
            get
            {
                return _CompletedDate;
            }
            set
            {
                SetPropertyValue("CompletedDate", ref _CompletedDate, value);
            }
        }




        [VisibleInListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public String Comment
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


        public DateTime RequestSalesOrderDate
        {
            get
            {
                return _RequestSalesOrderDate;
            }
            set
            {
                SetPropertyValue("RequestSalesOrderDate", ref _RequestSalesOrderDate, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RequestSOEnteredBy
        {
            get
            {
                return _RequestSOEnteredBy;
            }
            set
            {
                SetPropertyValue("RequestSOEnteredBy", ref _RequestSOEnteredBy, value);
            }
        }


        public bool AllOrNothing
        {
            get
            {
                return _AllOrNothing;
            }
            set
            {
                SetPropertyValue("AllOrNothing", ref _AllOrNothing, value);
            }
        }



        public int TotalAllocated
        {
            get
            {
                return _TotalAllocated;
            }
            set
            {
                SetPropertyValue("TotalAllocated", ref _TotalAllocated, value);
            }
        }

        public DrugRequestSwitchReson DrugRequestSwitchReson
        {
            get
            {
                return _DrugRequestSwitchReson;
            }
            set
            {
                SetPropertyValue("DrugRequestSwitchReson", ref _DrugRequestSwitchReson, value);
            }
        }
        
        [Indexed]
        [VisibleInListView(false)]
        public long OldID
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

        

    }
}