using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.SystemModule;


namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("classification")]
    [NavigationItem("Sales")]
    [ListViewAutoFilterRowAttribute(true)]
    [DefaultProperty("Classification")] 
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class CustomerClassification : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CustomerClassification(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
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
        private string _Classification;

        [Size(32)]
        public string Classification 
        {
            get
            {
                return _Classification;
            }
            set
            {
                SetPropertyValue("Classification", ref _Classification, value);
            }
        }
        [Association("CustomerClassification-Customers")]
        public XPCollection<Customer> Customers 
        {
            get
            {
                return GetCollection<Customer>("Customers");
            }
        }
    }
}
