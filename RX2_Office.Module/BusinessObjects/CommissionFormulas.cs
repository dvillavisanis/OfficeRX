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
    [NavigationItem("Options")]
    [DefaultProperty("FormulaCode")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class CommissionFormulas : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CommissionFormulas(Session session)
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
      
        private int _OID;
        private string _Formula;
        private string _FormulaDescription;
        private string _FormulaCode;

        [Key]
        public int OID
        {
            get
            {
                return _OID;
            }
            set
            {
                SetPropertyValue("OID", ref _OID, value);
            }
        }

        [Size(15)]
        public string FormulaCode
        {
            get
            {
                return _FormulaCode;
            }
            set
            {
                SetPropertyValue("FormulaCode", ref _FormulaCode, value);
            }
        }

        [Size(128)]
        public string FormulaDescription
        {
            get
            {
                return _FormulaDescription;
            }
            set
            {
                SetPropertyValue("FormulaDescription", ref _FormulaDescription, value);
            }

        }
                       
        [Size(128)]
        public string Formula
        {
            get
            {
                return _Formula;
            }
            set
            {
                SetPropertyValue("Formula", ref _Formula, value);
            }
        }
        [Association("CommissionFormulas-DefualtCommissionFormula")]
        public XPCollection<ApplicationOptions> DefualtCommissionFormula
        {
            get
            {
                return GetCollection<ApplicationOptions>("DefualtCommissionFormula");
            }
        }
    }



}
