using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]

    [NavigationItem("Options")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // [Persistent("xAppOptions")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class ApplicationOptions : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ApplicationOptions(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        #region getDefaultDistributionWH
        public static DistributionCenterWhse getDefaultDefaultDistributionWH(IObjectSpace os)
        {
            DistributionCenterWhse tempST;

            ApplicationOptions app = os.FindObject<ApplicationOptions>(CriteriaOperator.Parse("Ref", 1));
            if (app != null)
            {
                tempST = app.DefaultDistributionWH;
            }
            else
            {
                tempST = null;
            }
            return tempST;
        }
        #endregion


        #region getDefaultShippingType
        public static ShippingType getDefaultShippingType(IObjectSpace os)
        {
            ShippingType tempST;

            ApplicationOptions app = os.FindObject<ApplicationOptions>(CriteriaOperator.Parse("Ref", 1));
            if (app != null)
            {
                tempST = app.DefaultShippingCd;
            }
            else
            {
                tempST = null;
            }
            return tempST;
        }
        #endregion
        // Fields...
        #region Fields
        private string _InvoiceMessage;
        private string _WireInfo;
        private string _RemitTo;
        private string _CompanyLogoPath;
        private int _ThrityDayCustomerSnatchLimit;
        private int _Ref;
        private int _NextSoNumber;
        private string _Zip;
        private decimal _DefaultCommissionPct;
        private CommissionFormulas _DefualtCommissionFormula;
        private bool _IsQuickbooks;
        private bool _IsSAP;
        private bool _IsActive;
        private string _State;
        private string _City;
        private string _Address2;
        private string _Address1;
        private string _CompanyName;
        #endregion
        [Size(128)]
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                SetPropertyValue("CompanyName", ref _CompanyName, value);
            }
        }


        public int Ref
        {
            get
            {
                return _Ref;
            }
            set
            {
                SetPropertyValue("Ref", ref _Ref, value);
            }
        }

        [Size(128)]
        public string Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                SetPropertyValue("Address1", ref _Address1, value);
            }
        }

        [Size(128)]
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

        [Size(128)]
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                SetPropertyValue("city", ref _City, value);
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

        [Size(9)]
        public string Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                SetPropertyValue("Zip", ref _Zip, value);
            }
        }


        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetPropertyValue("IsActive", ref _IsActive, value);
            }
        }

        public bool IsSAP
        {
            get
            {
                return _IsSAP;
            }
            set
            {
                SetPropertyValue("IsSAP", ref _IsSAP, value);
            }
        }

        public bool IsQuickbooks
        {
            get
            {
                return _IsQuickbooks;
            }
            set
            {
                SetPropertyValue("IsQuickbooks", ref _IsQuickbooks, value);
            }
        }


        public int NextSoNumber
        {
            get
            {
                return _NextSoNumber;
            }
            set
            {
                SetPropertyValue("NextSoNumber", ref _NextSoNumber, value);
            }
        }

        [Size(254)]
        public string RemitTo
        {
            get
            {
                return _RemitTo;
            }
            set
            {
                SetPropertyValue("RemitTo", ref _RemitTo, value);
            }
        }

        [Size(255)]
        public string WireInfo
        {
            get
            {
                return _WireInfo;
            }
            set
            {
                SetPropertyValue("WireInfo", ref _WireInfo, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CompanyLogopath
        {
            get
            {
                return _CompanyLogoPath;
            }
            set
            {
                SetPropertyValue("CompanyLogo", ref _CompanyLogoPath, value);
            }
        }

        [Size(255)]
        public string InvoiceMessage
        {
            get
            {
                return _InvoiceMessage;
            }
            set
            {
                SetPropertyValue("InvoiceMessage", ref _InvoiceMessage, value);
            }
        }


        decimal defaultSalesCreditLimit;
        public decimal DefaultSalesCreditLimit
        {
            get
            {
                return defaultSalesCreditLimit;
            }
            set
            {
                SetPropertyValue(nameof(DefaultSalesCreditLimit), ref defaultSalesCreditLimit, value);
            }
        }


        [Delayed]
        //[ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public System.Drawing.Image Photo
        {

            get { return GetDelayedPropertyValue<System.Drawing.Image>("Photo"); }
            set { SetDelayedPropertyValue("Photo", value); }

        }
        public int ThrityDayCustomerSnatchLimit
        {
            get
            {
                return _ThrityDayCustomerSnatchLimit;
            }
            set
            {
                SetPropertyValue("ThrityDayCustomerSnatchLimit", ref _ThrityDayCustomerSnatchLimit, value);
            }
        }
        ShippingType defaultShippingCd;
        [Association("ShippingType-ApplicationOptions")]
        public ShippingType DefaultShippingCd
        {
            get
            {
                return defaultShippingCd;
            }
            set
            {
                SetPropertyValue(nameof(DefaultShippingCd), ref defaultShippingCd, value);
            }
        }
        DistributionCenterWhse defaultDistributionWH;
        [Association("DistributionCenterWhse-ApplicationOptions")]
        public DistributionCenterWhse DefaultDistributionWH
        {
            get
            {
                return defaultDistributionWH;
            }
            set
            {
                SetPropertyValue(nameof(DefaultDistributionWH), ref defaultDistributionWH, value);
            }
        }
        [Association("CommissionFormulas-DefualtCommissionFormula")]
        public CommissionFormulas DefualtCommissionFormula
        {
            get
            {
                return _DefualtCommissionFormula;
            }
            set
            {
                SetPropertyValue("DefualtCommissionFormula", ref _DefualtCommissionFormula, value);
            }
        }

        int nextCustomerNumber;
        public int NextCustomerNumber
        {
            get
            {
                return nextCustomerNumber;
            }
            set
            {
                SetPropertyValue(nameof(NextCustomerNumber), ref nextCustomerNumber, value);
            }
        }

        int nextPONumber;
        public int NextPONumber
        {
            get
            {
                return nextPONumber;
            }
            set
            {
                SetPropertyValue(nameof(NextPONumber), ref nextPONumber, value);
            }
        }


        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("EditMask", ".#####")]
        [ModelDefault("DisplayFormat", "{0:P}")]
        public decimal DefaultCommissionPct
        {
            get
            {
                return _DefaultCommissionPct;
            }
            set
            {
                SetPropertyValue("DefaultCommissionPct", ref _DefaultCommissionPct, value);
            }
        }
        string smtpServer;
        [Size(128)]
        public string SmtpServer
        {
            get
            {
                return smtpServer;
            }
            set
            {
                SetPropertyValue(nameof(SmtpServer), ref smtpServer, value);
            }
        }
        int smtpPort;
        public int SmtpPort
        {
            get
            {
                return smtpPort;
            }
            set
            {
                SetPropertyValue(nameof(SmtpPort), ref smtpPort, value);
            }
        }

    }


}
