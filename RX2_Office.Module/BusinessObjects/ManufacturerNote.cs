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
    [ImageName("BO_Note")]
    [NavigationItem("Purchasing")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ManufacturerNote : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ManufacturerNote(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            Author = SecuritySystem.CurrentUserName;
            NoteDate = DateTime.Today;
              
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

        private Manufacturer _Manufacturer;
     private string _Text;
        private DateTime _NoteDate;
        private string _Author;

        [Required]
        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {
                SetPropertyValue("Author", ref _Author, value);
            }
        }

        public DateTime NoteDate
        {
            get
            {
                return _NoteDate;
            }
            set
            {
                SetPropertyValue("NoteDate", ref _NoteDate, value);
            }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                SetPropertyValue("Text", ref _Text, value);
            }
        }


        [Association("Manufacturer-ManufacturerNotes")]
        public Manufacturer Manufacturer
        {
            get
            {
                return _Manufacturer;
            }
            set
            {
                SetPropertyValue("Manufacturer", ref _Manufacturer, value);
            }
        }
    }
}
