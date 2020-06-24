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
    [ListViewAutoFilterRowAttribute(true)]
    [NavigationItem("Compliance")]
    [ImageName("DCLicense")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView,false , NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class DistributionCenterLicenses : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DistributionCenterLicenses(Session session)
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
        DateTime createdDate;
        private byte[] _LicenseFile;
        private DateTime _ExpirationDate;
        private string _LicenseNumber;
        private LicenseType _LicenseTypeCode;
        private State _State;
        private DistributionCenter _DistributionCenterId;

        [Association("DistributionCenter-DistributionCenterLicenses")]
        public DistributionCenter DistributionCenterId
        {
            get
            {
                return _DistributionCenterId;
            }
            set
            {
                SetPropertyValue("DistributionCenterId", ref _DistributionCenterId, value);
            }
        }



        [Association("LicenseType-DistributionCenterLicenses")]
        public LicenseType LicenseTypeCode
        {
            get
            {
                return _LicenseTypeCode;
            }
            set
            {
                SetPropertyValue("LicenseTypeCode", ref _LicenseTypeCode, value);
            }
        }
        [Association("State-DistributionCenterLicenses")]
        public State State
        {
            get
            {
                return _State;
            }
            set
            {
                SetPropertyValue("State", ref _State, value);
            }
        }


        [Size(25)]
        public string LicenseNumber
        {
            get
            {
                return _LicenseNumber;
            }
            set
            {
                SetPropertyValue("LicenseNumber", ref _LicenseNumber, value);
            }
        }
        
        public DateTime CreatedDate
        {
            get => createdDate;
            set => SetPropertyValue(nameof(CreatedDate), ref createdDate, value);
        }


        public DateTime ExpirationDate
        {
            get
            {
                return _ExpirationDate;
            }
            set
            {
                SetPropertyValue("ExpirationDate", ref _ExpirationDate, value);
            }
        }



        public byte[] LicenseFile
        {
            get
            {
                return _LicenseFile;
            }
            set
            {
                SetPropertyValue("LicenseFile", ref _LicenseFile, value);
            }
        }
    }
}
