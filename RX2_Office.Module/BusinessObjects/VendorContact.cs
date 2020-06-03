using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Validation;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Purchasing")]
    
    [ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class VendorContact : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public VendorContact(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        
        }

        private Vendor _VendorsContact;
        private State _State;
        private Vendor _Vendors;
        private bool _SendMarketing;
        private string _Notes;
        private string _Mobile;
        private string _MiddleName;
        private string _FaceBook;
        private DateTime _BirthDate;
        private string _Email;
        private string _Fax;
        private string _Phone;
        private string _ZipCode;
        private string _City;
        private string _Address2;
        private string _Address;
        private string _LastName;
        private string _FirstName;


        
    [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
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
    [VisibleInListView(false)]
    [VisibleInLookupListView(false)]
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
    [VisibleInListView(false)]
    [VisibleInLookupListView(false)]
        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                SetPropertyValue("MiddleName", ref _MiddleName, value);
            }
        }
        [NonPersistent]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1} {2}", FirstName ?? "", MiddleName ?? "", LastName ?? "");
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                SetPropertyValue("address2", ref _Address2, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
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

        [Association("State-VendorContact")]
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
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
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
        [Size(15)]
        [ModelDefault("DisplayFormat", "0: (000)000-0000 Ext. 9999")]
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        }
        [Size(10)]
        [ModelDefault("DisplayFormat", "(000)000-0000")]
        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                SetPropertyValue("Mobile", ref _Mobile, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(10)]
        [ModelDefault("DisplayFormat", "(000)000-0000")]
        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                SetPropertyValue("Fax", ref _Fax, value);
            }
        }

        public const string EmailRegularExpression = "^[A-Za-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$";

        [RuleRegularExpression(DefaultContexts.Save, EmailRegularExpression, CustomMessageTemplate = "The Field must contain a vaild email address.")]

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy}")]
        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                SetPropertyValue("BirthDate", ref _BirthDate, value);
            }
        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string FaceBook
        {
            get
            {
                return _FaceBook;
            }
            set
            {
                SetPropertyValue("FaceBook", ref _FaceBook, value);
            }
        }

        [Delayed]
        //[ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public System.Drawing.Image Photo
        {
            // get
            // {
            //return GetPropertyValue<byte[]>("Photo"); 
            // }
            // set
            // {
            //     SetPropertyValue<byte[]>("Photo", value);
            // }
            get { return GetDelayedPropertyValue<System.Drawing.Image>("Photo"); }
            set { SetDelayedPropertyValue("Photo", value); }

        }
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                SetPropertyValue("Notes", ref _Notes, value);
            }
        }

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool SendMarketing
        {
            get
            {
                return _SendMarketing;
            }
            set
            {
                SetPropertyValue("SendMarketing", ref _SendMarketing, value);
            }
        }

        [Association("Vendor-VendorContacts")]
        public Vendor Vendors
        {
            get
            {
                return _Vendors;
            }
            set
            {
                if (Equals(Vendors, value)) return;
                SetPropertyValue("Vendors", ref _Vendors, value);
                if (SetPropertyValue<Vendor>("Vendors", ref _VendorsContact, value))
                {
                    if (!IsLoading && Vendors != null)
                    {
                        this.Address = Vendors.Address;
                        this.Address2 = Vendors.Address2 ;
                        this.City = Vendors.City;
                        this.State = Vendors.State;
                        this.ZipCode = Vendors.ZipCode;
                        this.Phone = Vendors.Phone;
                        this.Fax = Vendors.Fax;
                    }
                }
            }
        }
    }
}
