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
    [ImageName("Receiver.ico")]
    [NavigationItem("Shipping")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class InventoryScan : XPObject    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public InventoryScan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).

            this.scannedBy = SecuritySystem.CurrentUserName;
            this.ScannedDt = DateTime.Today;
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            if (propertyName == "BarcodeRead")
            {
               // int x = 1;
            }

            base.OnChanged(propertyName, oldValue, newValue);



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


        string barcodeRead;
        DateTime scannedDt;

        string scannedBy;
        string nDC;
        string serialNumber;
        DateTime expirationDt;
        string lot;
        string gtin;
        int batchId;

        public int BatchId
        {
            get => batchId;
            set => SetPropertyValue(nameof(BatchId), ref batchId, value);
        }
        
        [Size(255)]
        public string BarcodeRead
        {
            get => barcodeRead;
            set => SetPropertyValue(nameof(BarcodeRead), ref barcodeRead, value);
        }

        [Size(14)]
        public string Gtin        {
            get => gtin;
            set => SetPropertyValue(nameof(Gtin), ref gtin, value);
        }

        [Size(10)]
        public string NDC
        {
            get => nDC;
            set => SetPropertyValue(nameof(NDC), ref nDC, value);
        }

        [Size(10)]
        public string Lot
        {
            get => lot;
            set => SetPropertyValue(nameof(Lot), ref lot, value);
        }


        public DateTime ExpirationDt
        {
            get => expirationDt;
            set => SetPropertyValue(nameof(ExpirationDt), ref expirationDt, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SerialNumber
        {
            get => serialNumber;
            set => SetPropertyValue(nameof(SerialNumber), ref serialNumber, value);
        }


        [Size(50)]
        public string ScannedBy
        {
            get => scannedBy;
            set => SetPropertyValue(nameof(ScannedBy), ref scannedBy, value);
        }
        
        public DateTime ScannedDt
        {
            get => scannedDt;
            set => SetPropertyValue(nameof(ScannedDt), ref scannedDt, value);
        }
                     
    }
}