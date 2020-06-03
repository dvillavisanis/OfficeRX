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
    [ImageName("SalesRepTeam")]
    [NavigationItem("Sales") ]
    [DefaultProperty("TeamCode")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SalesTeams : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SalesTeams(Session session)
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
        private decimal _TeamGoal;
        private string _TeamDiscription;
        private string _TeamCode;

        [Size(10)]
        [RuleUniqueValue]
        [RulePropertiesRequired]
        public string TeamCode
        {
            get
            {
                return _TeamCode;
            }
            set
            {
                SetPropertyValue("TeamCode", ref _TeamCode, value);
            }
        }

        [RulePropertiesRequired]
        [Size(64)]
        public string TeamDiscription
        {
            get
            {
                return _TeamDiscription;
            }
            set
            {
                SetPropertyValue("TeamDiscription", ref _TeamDiscription, value);
            }
        }


        public decimal TeamGoal
        {
            get
            {
                return _TeamGoal;
            }
            set
            {
                SetPropertyValue("TeamGoal", ref _TeamGoal, value);
            }
        }
        [Association("SalesTeams-SalesRep")]
        public XPCollection<SalesRep> SalesReps

        {
            get
            {
                return GetCollection<SalesRep>("SalesReps");
            }
        }
    }
}