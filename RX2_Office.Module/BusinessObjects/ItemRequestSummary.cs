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
    [NavigationItem("Purchasing")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemRequestSummary : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemRequestSummary(Session session)
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


        eEDLItemStatus itemStatus;
        string itemNumber;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ItemNumber
        {
            get => itemNumber;
            set => SetPropertyValue(nameof(ItemNumber), ref itemNumber, value);
        }
        private int? openRequestQty = null;
        //public int? OpenRequestQty
        //{
        //    get
        //    {
        //        if (!IsLoading && !IsSaving && openRequestQty == null)
        //            //UpdateOpenRequestQty(false);
        //        return openRequestQty;
        //    }
        //}


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eEDLItemStatus ItemStatus
        {
            get => itemStatus;
            set => SetPropertyValue(nameof(ItemStatus), ref itemStatus, value);
        }

        public void UpdateItemRequestTotal(bool forceChangeEvents)
        {

            //decimal? oldOrdersTotal = fOrdersTotal;
            //decimal tempTotal = 0m;
            //foreach (Order detail in Orders)
            //    tempTotal += detail.Total;
            //fOrdersTotal = tempTotal;
            //if (forceChangeEvents)
            //    OnChanged(nameof(OrdersTotal), oldOrdersTotal, fOrdersTotal);
        }


    }
}