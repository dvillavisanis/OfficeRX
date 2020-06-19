using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ListViewAutoFilterRowAttribute(true)]
    [ImageName("BO_Contact")]
    [NavigationItem("Sales")]
    [ListViewFilter("Primary Contact", "ContactType = 'PRIMA'", "Primary Contact", "Primary sales Contacts", false)]
    [ListViewFilter("Account Payable", "ContactType = 'AP'", "AP Sales ", "ACcount Payable Contacts", false)]
    //[ListViewFilter("My Customers (fake)", "[SalesRep] = 'Dvillavisanis'", "My Customers (fake)", "Customers that are mine", true)]
    [ListViewFilter(" All", "", true)]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class CustomerContact : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CustomerContact(Session session)
            : base(session)
        {
        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();
            FirstName = "NONE";
            

        }
        [Action(Caption = "Lock", ConfirmationMessage = "Are you sureYou want to lock?", ImageName = "lock", AutoCommit = true, TargetObjectsCriteria = "IsCurrentUserInRole('CustomContactLock') && locked = 0")]
        public void ContactLock()
        {
            // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
            Locked = true;
            this.Save();
        }


        [Action(Caption = "UnLock", ConfirmationMessage = "Are you sureYou want to Unlock?", ImageName = "lock_off", AutoCommit = true, TargetObjectsCriteria = "IsCurrentUserInRole('CustomContactLock') && locked = 1")]
        public void ContactUnLock()
        {
            // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
            Locked = false;
            this.Save();
        }




        //private string _PersistentProperty;
        // Fields...
        CustomerContactType contactType;
        bool locked;
        private bool isAppUser;

        //private ContactType _ContactType;
        private Customer _MasterCustomer;
        private State _State;
        private Customer _Customers;
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


        [Association("CustomerContactType-CustomerContact")]
        [Appearance("DisablePropertyContactType", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        public CustomerContactType ContactType
        {
            get => contactType;
            set => SetPropertyValue(nameof(ContactType), ref contactType, value);
        }

        [Appearance("DisablePropertyFirstName", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
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

        [Appearance("DisablePropertyLastName", Criteria = "Locked", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
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

        [Appearance("DisablePropertyMiddleName", Criteria = "Locked = true", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
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

        [PersistentAlias("[FirstName] + ' ' + [MiddleName] + ' ' + [LastName]")]
        public string FullName
        {
            get { return String.Format("{0} {1} {2}", FirstName ?? "", MiddleName ?? "", LastName ?? ""); }
        }

        [Appearance("DisablePropertyAddress", Criteria = "Locked", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
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


        [Appearance("DisablePropertyAddress2", Criteria = "Locked = true", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
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


        [Appearance("DisablePropertyCity", Criteria = "Locked = true", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
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
        [Appearance("DisablePropertyState", Criteria = "Locked", Enabled = false, Context = "DetailView")]
        [VisibleInListView(false)]
        [Association("State-CustomerContacts")]
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

        [Appearance("DisablePropertyZipCode", Criteria = "Locked", Enabled = false, Context = "DetailView")]
        [SizeAttribute(10)]
        [ModelDefault("DisplayFormat", "0:00000-0000")]
        [VisibleInListView(false)]
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
                [ModelDefault("DisplayFormat", "{0:(###)###-#### Ext. 0000}")]
        [ModelDefault("DisplayFormat", "0: (000)000-0000 Ext. 0000")]
        [Appearance("DisablePropertyPhone", Criteria = "Locked", Enabled = false, Context = "DetailView")]

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


        [Appearance("DisablePropertyMobile", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
        [Size(10)]
        [ModelDefault("EditMask", "(000)000-0000")]
        [ModelDefault("DisplayFormat", "{0:(###)###-####}")]

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

        [Appearance("DisablePropertyFax", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
        [Size(10)]
        [ModelDefault("EditMask", "(000)000-0000")]
        [ModelDefault("DisplayFormat", "{0:(###)###-####}")]

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
        [Size(255)]
        [RuleRegularExpression(DefaultContexts.Save, EmailRegularExpression, CustomMessageTemplate = "The Field must contain a vaild email address.")]
        [VisibleInListView(false)]
        [Appearance("DisablePropertyEmail", Criteria = "Locked", Enabled = false, Context = "DetailView")]

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
        [Appearance("DisablePropertyBirthDate", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
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
        [Appearance("DisablePropertyFaceBook", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
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
        [Appearance("DisablePropertyPhoto", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [Delayed]
        //[ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public System.Drawing.Image Photo
        {

            get { return GetDelayedPropertyValue<System.Drawing.Image>("Photo"); }
            set { SetDelayedPropertyValue("Photo", value); }

        }


        [VisibleInListView(false)]
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

        [Appearance("DisablePropertyIsAppUser", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
        public bool IsAppUser
        {
            get => isAppUser;
            set => SetPropertyValue(nameof(isAppUser), ref isAppUser, value);
        }

        [Appearance("DisablePropertySendMarketing", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(false)]
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

        [Appearance("DisablePropertyLocked", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [VisibleInListView(true)]
        public bool Locked
        {
            get => locked;
            set => SetPropertyValue(nameof(Locked), ref locked, value);
        }

        [Appearance("DisablePropertyCustomers", Criteria = "Locked", Enabled = false, Context = "DetailView")]

        [Association("Customer-CustomerContacts")]
        public Customer Customers
        {
            get
            {
                return _Customers;
            }
            set
            {
                if (Equals(Customers, value)) return;
                SetPropertyValue("Customers", ref _Customers, value);
                if (SetPropertyValue<Customer>("Customers", ref _MasterCustomer, value))
                {
                    if (!IsLoading && Customers != null)
                    {
                        this.Address = Customers.BillingAddress;
                        this.Address2 = Customers.BillingAddress2;
                        this.City = Customers.BillingCity;
                        this.State = Customers.BillingState;
                        this.ZipCode = Customers.BillingZip;
                        this.Phone = Customers.Phone;
                        this.Fax = Customers.Fax;
                    }
                }
            }
        }
        private XPCollection<AuditDataItemPersistent> changeHistory;
        public XPCollection<AuditDataItemPersistent> ChangeHistory
        {
            get
            {
                if (changeHistory == null)
                {
                    changeHistory = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return changeHistory;
            }
        }
    }
}
