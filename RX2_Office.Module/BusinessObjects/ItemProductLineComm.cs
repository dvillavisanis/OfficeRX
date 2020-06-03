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
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [ListViewFilter(" Current ", "[EndDate] =NULL ", " Current ", "Current Product line Commission", false, Index = 0)]
    [ListViewFilter("All", "")]


    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ItemProductLineComm : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemProductLineComm(Session session)
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


        DateTime endDate;
        eCommissionMethod eCommissionMethod;
        DateTime startdate;
        decimal commissionPct;
        ItemProductLine itemProductLine;

        [Association("ItemProductLine-ItemProductLineComm")]
        public ItemProductLine ItemProductLine
        {
            get => itemProductLine;
            set => SetPropertyValue(nameof(ItemProductLine), ref itemProductLine, value);
        }


        public decimal CommissionPct
        {
            get => commissionPct;
            set => SetPropertyValue(nameof(CommissionPct), ref commissionPct, value);
        }

        public DateTime StartDate
        {
            get => startdate;
            set => SetPropertyValue(nameof(StartDate), ref startdate, value);
        }


        public DateTime EndDate
        {
            get => endDate;
            set => SetPropertyValue(nameof(EndDate), ref endDate, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eCommissionMethod CommissionMethod
        {
            get => eCommissionMethod;
            set => SetPropertyValue(nameof(eCommissionMethod), ref eCommissionMethod, value);
        }
    }
}
