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
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class RepackLotGenerate : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackLotGenerate(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            QtyOfPartial = 2;
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

        public enum RepackLotSerialNoType { Sequence, File, RFEX }
        int qtyOfPartial;
        bool sequential;
        RepackLotSerialNoType serialType;
        int qtyToGenerate;
        RepackLots _LotId;


        [Association("RepackLots-RepackLotGenerates")]
        public RepackLots LotId
        {
            get => _LotId;
            set => SetPropertyValue(nameof(LotId), ref _LotId, value);
        }


        public int QtyToGenerate
        {
            get => qtyToGenerate;
            set => SetPropertyValue(nameof(QtyToGenerate), ref qtyToGenerate, value);
        }
        
        public int QtyOfPartial
        {
            get => qtyOfPartial;
            set => SetPropertyValue(nameof(QtyOfPartial), ref qtyOfPartial, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public RepackLotSerialNoType SerialType
        {
            get => serialType;
            set => SetPropertyValue(nameof(SerialType), ref serialType, value);
        }


        
        public bool Sequential
        {
            get => sequential;
            set => SetPropertyValue(nameof(Sequential), ref sequential, value);
        }



    }
}