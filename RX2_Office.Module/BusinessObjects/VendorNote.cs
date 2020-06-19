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
using DevExpress.Xpo.Metadata;

namespace RX2_Office.Module.BusinessObjects
{
    [NavigationItem("Purchasing")]
    [DefaultClassOptions]
    [ImageName("note-vendor")]
    [Indices("Vendors;NoteDate")]
    public class VendorNote : XPObject
    {

        public VendorNote(Session session)
            : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            this.Author = SecuritySystem.CurrentUserName;
            this.NoteDate = DateTime.Today;


        }
        // Fields...

        // Fields...
        private Vendor _Vendors;
      private string _Author;
        private DateTime _NoteDate;
        private string _Text;

        
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

        [VisibleInListView(true)]
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

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Association("Vendor-VendorNotes")]
        public Vendor Vendors
        {
            get
            {
                return _Vendors;
            }
            set
            {
                SetPropertyValue("Vendors", ref _Vendors, value);
            }
        }
    }
}
