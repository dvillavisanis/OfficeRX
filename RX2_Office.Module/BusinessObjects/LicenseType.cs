﻿using System;
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
    [ImageName("LicenseType1")]
    [NavigationItem("Compliance")]
    [DefaultProperty("LicenseTypeCode")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class LicenseType : XPBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public LicenseType(Session session)
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
        private string _LicenseDescription;
        private string _LicenseTypeCode;
        [Key]
        [Size(5)]
        public string LicenseTypeCode
        {
            get
            {
                return _LicenseTypeCode;
            }
            set
            {
                SetPropertyValue("LicenseType", ref _LicenseTypeCode, value);
            }
        }

        [Size(64)]
        public string LicenseDescription
        {
            get
            {
                return _LicenseDescription;
            }
            set
            {
                SetPropertyValue("LicenseDescription", ref _LicenseDescription, value);
            }
        }
        [Association("LicenseType-DistributionCenterLicenses")]
        public XPCollection<DistributionCenterLicenses> DistributionCenterLicense
        {
            get
            {
                return GetCollection<DistributionCenterLicenses>("DistributionCenterLicense");
            }
        }


    }
}
