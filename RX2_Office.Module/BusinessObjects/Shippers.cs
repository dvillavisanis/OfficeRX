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
    [NavigationItem("Shipping")]
    [ImageName("EmployeeShippers")]
    [DefaultProperty("ShipperId")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Shippers : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Shippers(Session session)
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
        private string _ShipperId;

private DistributionCenterWhse _DefaultWhse;
        private DistributionCenter _DefaultDC;
        private string _LastName;
        private string _FirstName;

        [Key]
        [Size(100)]
        public string ShipperId
        {
            get
            {
                return _ShipperId;
            }
            set
            {
                SetPropertyValue("ShipperId", ref _ShipperId, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                SetPropertyValue("FirstName", ref _FirstName, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                SetPropertyValue("LastName", ref _LastName, value);
            }
        }


        [Association("DistributionCenter-Shippers")]
        public DistributionCenter DefaultDC
        {
            get
            {
                return _DefaultDC;
            }
            set
            {
                SetPropertyValue("DefaultDC", ref _DefaultDC, value);
            }
        }


        [Association("DistributionCenterWhse-ShippersdefaultWhse")]
        public DistributionCenterWhse DefaultWhse
        {
            get
            {
                return _DefaultWhse;
            }
            set
            {
                SetPropertyValue("DefaultWhse", ref _DefaultWhse, value);
            }
        }





    }
}