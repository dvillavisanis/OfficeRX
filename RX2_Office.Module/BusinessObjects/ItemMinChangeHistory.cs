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
    [ImageName("CustomerItemPricingHistory")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemMinChangeHistory : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemMinChangeHistory(Session session)
            : base(session)
        {

           

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnSaved()
        {
            
        
            this.Item.MinPrice = this.ItemMin;
                   
            base.OnSaved();
            
        }
        


            //using (IObjectSpace os = Application.CreateObjectSpace(typeof(Items)))
            //{
            //    Items minItem = os.FindObject<Items>(CriteriaOperator.Parse("ItemNumber=?", Item.ItemNumber));
            //    minItem.MinPrice = this.ItemMin;
            //          //        sequence.NextSequence = 5;
            //            os.CommitChanges();

            //}


        
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
        private string _ChangedBy;
  private Decimal _OldMin;
        private Items  _Item;
         private Decimal _ItemMin;
        private DateTime _CHangeDate;

        [RuleRequiredField]
        public DateTime CHangeDate
        {
            get
            {
                return _CHangeDate;
            }
            set
            {
                SetPropertyValue("CHangeDate", ref _CHangeDate, value);
            }
        }

        [RuleRequiredField]
        public Decimal ItemMin
        {
            get
            {
                return _ItemMin;
            }
            set
            {
                SetPropertyValue("ItemMin", ref _ItemMin, value);
            }
        }

        [RuleRequiredField]
        [Association("Items-ItemMinChangeHistorys")]
        public Items  Item
        {
            get
            {
                return _Item;
            }
            set
            {
                SetPropertyValue("Item", ref _Item, value);
            }
        }

        [RuleRequiredField]
        public Decimal OldMin
        {
            get
            {
                return _OldMin;
            }
            set
            {
                SetPropertyValue("OldMin", ref _OldMin, value);
            }
        }


        [Size(50)]
        public string ChangedBy
        {
            get
            {
                return _ChangedBy;
            }
            set
            {
                SetPropertyValue("ChangedBy", ref _ChangedBy, value);
            }
        }

    }
}