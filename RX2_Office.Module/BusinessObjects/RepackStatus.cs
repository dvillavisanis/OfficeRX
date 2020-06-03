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
    //*******************************************************************************************
    //THIS HAS BEEN DISCONTINUEd use the enum instead
    //***********************************************************************************************



    [NavigationItem("Repack")]
    [DefaultClassOptions]
    [ImageName("setup1")]
    [DefaultProperty("StatusDescription")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]

    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class RepackStatus : XPCustomObject
    { // Inherit from a different class to XPBaseObjectprovide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackStatus(Session session)
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
        private string _StatusDescription;
        private Decimal _StatusOrder;
        private Decimal _RepackStatusId;


        [Key]
        public Decimal  RepackStatusId
        {
            get
            {
                return _RepackStatusId;
            }
            set
            {
                SetPropertyValue("RepackStatusId", ref _RepackStatusId, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string StatusDescription
        {
            get
            {
                return _StatusDescription;
            }
            set
            {
                SetPropertyValue("StatusDescription", ref _StatusDescription, value);
            }
        }

        public Decimal StatusOrder
        {
            get
            {
                return _StatusOrder;
            }
            set
            {
                SetPropertyValue("StatusOrder", ref _StatusOrder, value);
            }
        }

        //[Association("RepackStatus-RepackLots")]
        //public XPCollection<RepackLots> RepackLotStatus
        //{
        //    get
        //    {
        //        return GetCollection<RepackLots>("RepackLotStatus");
        //    }
        //}
    }
}
