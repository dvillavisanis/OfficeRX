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
//using RX2_Office.Module.Win.BusinessLogic.GS1DataConvert;
using DevExpress.ExpressApp.SystemModule;

using RX2_Office.Module.BusinessObjects.BusinessLogic;
using RX2_Office.Module.BusinessObjects;
using DevExpress.ExpressApp.Editors;
using System.Globalization;

namespace RX2_Office.Module


{
    [DefaultClassOptions]
    [NavigationItem("Shipping")]
    [ListViewAutoFilterRowAttribute(true)]
    [ImageName("Receiver")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ReceiverPackage : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ReceiverPackage(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            ReceivedBy = SecuritySystem.CurrentUserName;
            ReceiverPackageDT = DateTime.Now;


        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            if (IsLoading) return;
            //    if (classInfo == null) return;
            if (propertyName == "LastBarcodescan" && newValue.ToString().Length > 15)
            {
                BarcodeUtil2 gs1 = new BarcodeUtil2();
                Dictionary<String, String> DGS1;

                DGS1 = gs1.decodeBarcodeGS1Pharma(newValue.ToString());
                
                string gtin = DGS1["01"];
                string expirationdt = DGS1["17"];
                string lot = "";
                    DGS1.TryGetValue("10" , out lot);
                string SerialNumber = "";
                    DGS1.TryGetValue("21",out SerialNumber);
                
                ReceiverPackageItems Ritem = new ReceiverPackageItems(Session);
                Ritem.BarCode = newValue.ToString();
                Ritem.Lot = lot;
               // Ritem.SerialNumber = SerialNumber;
                Ritem.ItemNumber = gtin.Substring(3, 10);
                //the day could be 00
                if (expirationdt.Substring(4,2)== "00")
                {
                    expirationdt = expirationdt.Substring(0, 4) + "28";
                }

               Ritem.ReceiverPackageId = this;

                Ritem.ExpireDate = DateTime.ParseExact(expirationdt, "yyMMdd", CultureInfo.InvariantCulture);
                Ritem.Save();



                int x = 1;
                

            }
       
            base.OnChanged(propertyName, oldValue, newValue);
            
        }
       
     

        string lastBarcodescan;
        string receivedBy;
        string documentRefNo;
        eReceiverPackageType recPackageType;
        DateTime receiverPackageDT;

        public DateTime ReceiverPackageDT
        {
            get => receiverPackageDT;
            set => SetPropertyValue(nameof(ReceiverPackageDT), ref receiverPackageDT, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ReceivedBy
        {
            get => receivedBy;
            set => SetPropertyValue(nameof(ReceivedBy), ref receivedBy, value);
        }



        public eReceiverPackageType RecPackageType
        {
            get => recPackageType;
            set => SetPropertyValue(nameof(RecPackageType), ref recPackageType, value);
        }


        [Size(15)]
        public string DocumentRefNo
        {
            get => documentRefNo;
            set => SetPropertyValue(nameof(DocumentRefNo), ref documentRefNo, value);
        }


        [Size(255)]
        public string LastBarcodescan
        {
            get => lastBarcodescan;

            set
            {


                SetPropertyValue(nameof(LastBarcodescan), ref lastBarcodescan, value);
            }
        }

        //[Association("ReceiverPackage-ItemReceiver")]
        //public XPCollection<ItemReceiver> ItemReceivers
        //{
        //    get
        //    {
        //        return GetCollection<ItemReceiver>(nameof(ItemReceivers));
        //    }
        //}

        [Association("ReceiverPackage-ReceiverPackageItems")]
        public XPCollection<ReceiverPackageItems> ReceiverPackageItems
        {
            get
            {
                return GetCollection<ReceiverPackageItems>(nameof(ReceiverPackageItems));
            }
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
    }
}