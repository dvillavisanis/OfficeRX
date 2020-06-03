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
{  [DefaultClassOptions]
    [NavigationItem("Options")]
  
    [ImageName("setup1")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ZipCodes : XPBaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ZipCodes(Session session)
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
        private string _Territory;
        private string _DayLightSavings;
        private string _CountyFIPS;
        private int _Elevation;
        private string _TimeZone;
        private decimal _Longitude;
        private decimal _Latitude;
        private string _AreaCode;
        private string _County;
        private string _State;
        private string _City;
        private string _ZipCode;

        [Size(5)]
        [Key]
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                SetPropertyValue("ZipCode", ref _ZipCode, value);
            }
        }

        [Size(35)]
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                SetPropertyValue("City", ref _City, value);
            }
        }

        [Size(2)]
        public string State
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

        [Size(45)]
        [VisibleInListView(false)]
        public string County
        {
            get
            {
                return _County;
            }
            set
            {
                SetPropertyValue("County", ref _County, value);
            }
        }

        [Size(8)]
        public string AreaCode
        {
            get
            {
                return _AreaCode;
            }
            set
            {
                SetPropertyValue("AreaCode", ref _AreaCode, value);
            }
        }
         [DbType("decimal(18,8)")]
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat","{0:D}")]
        public decimal Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                SetPropertyValue("Latitude", ref _Latitude, value);
            }
        }
         [DbType("decimal(18,8)")]
        [ModelDefault("EditMask", "##.#####")]
        [ModelDefault("DisplayFormat", "{0:D}")]
        public decimal Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                SetPropertyValue("Longitude", ref _Longitude, value);
            }
        }

        [Size(2)]
        [VisibleInListView(false) ]
        public string TimeZone
        {
            get
            {
                return _TimeZone;
            }
            set
            {
                SetPropertyValue("TimeZone", ref _TimeZone, value);
            }
        }

        [VisibleInListView(false)]
        public int Elevation
        {
            get
            {
                return _Elevation;
            }
            set
            {
                SetPropertyValue("Elevation", ref _Elevation, value);
            }
        }

        [Size(5)]
        [VisibleInListView(false)]
        public string CountyFIPS
        {
            get
            {
                return _CountyFIPS;
            }
            set
            {
                SetPropertyValue("CountyFIPS", ref _CountyFIPS, value);
            }
        }

        [Size(1)]
        [VisibleInListView(false)]
        public string DayLightSavings
        {
            get
            {
                return _DayLightSavings;
            }
            set
            {
                SetPropertyValue("DayLightSavings", ref _DayLightSavings, value);
            }
        }

        [Size(50)]
        [VisibleInListView(false)]
        public string Territory
        {
            get
            {
                return _Territory;
            }
            set
            {
                SetPropertyValue("Territory", ref _Territory, value);
            }
        }
    }
}
