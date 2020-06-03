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
    //[ImageName("BO_Contact")]
    [DefaultProperty("ShippingTypeCode")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class ShippingType : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ShippingType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        private string _ShippingDescription;
        private string _WebSite;
        [XafDisplayName("ShippingType"), ToolTip("My hint message")]
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
        private string _ShippingType;
        [Key]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ShippingTypeCode  
        {
            get
            {
                return _ShippingType;
            }
            set
            {
                SetPropertyValue("ShippingTypeCode", ref _ShippingType, value);
            }
        }


        [Size(128)]
        public string ShippingDescription
        {
            get
            {
                return _ShippingDescription;
            }
            set
            {
                SetPropertyValue("ShippingDescription", ref _ShippingDescription, value);
            }
        }

        [Size(254)]
        public string WebSite
        {
            get
            {
                return _WebSite;
            }
            set
            {
                SetPropertyValue("WebSite", ref _WebSite, value);
            }
        }

        [Association("ShippingType-Customers")]
        public XPCollection<Customer> Customer
        {
            get
            {
                return GetCollection<Customer>("Customer");
            }
        }
        [Association("ShippingType-ApplicationOptions")]
        public XPCollection<ApplicationOptions > ApplicationOptions
        {
            get
            {
                return GetCollection<ApplicationOptions >(nameof(ApplicationOptions));
            }
        }

        [Association("ShippingType-SOHeader")]
        public XPCollection<SOHeader> SOHeader
        {
            get
            {
                return GetCollection<SOHeader>("SOHeader");
            }
        }
    }
}
