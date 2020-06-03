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
using DevExpress.ExpressApp.SystemModule;

namespace RX2_Office.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ListViewFilter("All ", "", "All ", "All ", false)]
    [ListViewFilter("All Inner Labels", "[LabelType] = ##Enum#RX2_Office.Module.BusinessObjects.eLabelType,InnerCarton# ", "All Inner Cartoons labels", "All Inner Cartoons Labels", false)]
    [ListViewFilter("All Shipping Labels", "[LabelType] = ##Enum#RX2_Office.Module.BusinessObjects.eLabelType,Shipping# ", "All Shipping", "All Shipping Labels", false)]
    [ListViewFilter("All Pallet Labels", "[LabelType] = ##Enum#RX2_Office.Module.BusinessObjects.eLabelType,Pallet# ", "All Pallet Labels", "All Pallet Labels", false)]


    [ListViewFilter("All Inner Labels Not Printed", "[LabelType] = ##Enum#RX2_Office.Module.BusinessObjects.eLabelType,InnerCarton# And [Isprinted] = False ", "All Inner Labels Not Printed", "All Inner Labels Not Printed ", false)]
    [ListViewFilter("All Shipping Labels Not Printed", "[LabelType] = ##Enum#RX2_Office.Module.BusinessObjects.eLabelType,Shipping# And [Isprinted] = False ", "All Shipping Labels Not Printed", "All Shipping Labels Not Printed ", false)]
    [ListViewFilter("All Pallet Labels Not Printed", "[LabelType] = ##Enum#RX2_Office.Module.BusinessObjects.eLabelType,Pallet# And [Isprinted] = False ", "All Pallet label Not Printed", "All Pallet Not Printed ", false)]

    
    [ListViewFilter("Label to be Printed", "[Isprinted] = False ", "Label to be Printed", "Label to be Printed ", true)]
    [ListViewFilter("To Be Commission to Vendor", "[IsCommission] = True And [CommissionPostedToVendor] = False ", "To Be Commission to Vendor", "To Be Commission to Vendor ", true)]
    [ListViewFilter("To Be Aggregated to Vendor", "[IsCommission] = True And [CommissionPostedToVendor] = True And [AggPostedToVendor] = False", "To Be Aggregated to Vendor", "To Be Aggregated to Vendor ", true)]
  
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class RepackLotSerialNo : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RepackLotSerialNo(Session session)
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


        string ssccSerialNumber;
        string gTIN;
        bool shippmentPostedToVendor;
        bool aggPostedToVendor;
        bool commissionPostedToVendor;
        string parentSerialNo;
        eLabelType labelType;
        bool isprinted;
        int partialQty;
        bool ispartial;
        string sgTIN;
        RepackLots repackLot;
        string commissionBatchId;

        bool isCommission;
        string serialNo;



        [Association("RepackLots-RepackLotSerialNos")]
        public RepackLots RepackLot
        {
            get => repackLot;
            set => SetPropertyValue(nameof(RepackLot), ref repackLot, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SerialNo
        {
            get => serialNo;
            set => SetPropertyValue(nameof(SerialNo), ref serialNo, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public eLabelType LabelType
        {
            get => labelType;
            set => SetPropertyValue(nameof(LabelType), ref labelType, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string sGTIN
        {
            get => sgTIN;
            set => SetPropertyValue(nameof(sGTIN), ref sgTIN, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GTIN
        {
            get => gTIN;
            set => SetPropertyValue(nameof(GTIN), ref gTIN, value);
        }
        public bool isPartial
        {
            get => ispartial;
            set => SetPropertyValue(nameof(isPartial), ref ispartial, value);
        }


        public int PartialQty
        {
            get => partialQty;
            set => SetPropertyValue(nameof(PartialQty), ref partialQty, value);
        }


        public bool Isprinted
        {
            get => isprinted;
            set => SetPropertyValue(nameof(Isprinted), ref isprinted, value);
        }
        public bool IsCommission

        {
            get => isCommission;
            set => SetPropertyValue(nameof(IsCommission), ref isCommission, value);
        }

        public bool ShippmentPostedToVendor
        {
            get => shippmentPostedToVendor;
            set => SetPropertyValue(nameof(ShippmentPostedToVendor), ref shippmentPostedToVendor, value);
        }


        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ParentSerialNo
        {
            get => parentSerialNo;
            set => SetPropertyValue(nameof(ParentSerialNo), ref parentSerialNo, value);
        }

        public bool AggPostedToVendor
        {
            get => aggPostedToVendor;
            set => SetPropertyValue(nameof(AggPostedToVendor), ref aggPostedToVendor, value);
        }
        public bool CommissionPostedToVendor
        {
            get => commissionPostedToVendor;
            set => SetPropertyValue(nameof(CommissionPostedToVendor), ref commissionPostedToVendor, value);
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CommissionBatchId
        {
            get => commissionBatchId;
            set => SetPropertyValue(nameof(CommissionBatchId), ref commissionBatchId, value);
        }
        
        [Size(18)]
        public string SsccSerialNumber
        {
            get => ssccSerialNumber;
            set => SetPropertyValue(nameof(ssccSerialNumber), ref ssccSerialNumber, value);
        }
    }

}
