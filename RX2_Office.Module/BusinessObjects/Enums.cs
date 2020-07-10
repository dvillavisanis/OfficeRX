 using DevExpress.Persistent.Base;

namespace RX2_Office.Module.BusinessObjects
{
    public enum InvoiceType
    {
        [ImageName("Mail")]
        Postal,
        [ImageName("Email")]
        Email,
        [ImageName("Fax")]
        Fax
    }


    public enum eDeaType
    { Detoxification=10,Distributor=20,CentralFillPharmacy=30,HospitalClinic=40,Manufacturer=50,MlpNursePractitioner=60,MlpPhysicianAssistant=70,Practitioner=80,RetailPharmacy=90}

    public enum eLabelType
    { InnerCarton, Shipping, Pallet }
    public enum Gender { Male, Female }
    public enum SalesOrderStatus
    { New = 0 , Submitted = 20, ComplianceCheck = 30 , PickingTicketPrinted = 40 , Picking = 50, Picked = 60 ,ShippingLabel = 70 ,Invoiced = 80, Deleted = 99}
    public enum ItemTypes
    { Inventory, NonInventory, Service }
    public enum InventoryTransactionTypes
    { Adj, Trf, PO, SO, WO, QU }
    public enum ItemValuation
    { Standard, Average, FIFO, LIFO, LOT }

    public enum eCommissionMethod
    { None, PercentOfSales, PercentOfCost, PercentOfGrossProfit, PercentageOfPrice, FlatRatePerUnit }

    public enum PoStatus
    { New, Open, BackOrdered, Close }

    public enum ItemRequestStatus
    { All = 0, New = 1, Searching = 5, OnPurchaseOrder = 6, SalesActionRequired = 7, Closed = 9, Expired = 10, Cancelled = 12, SalesOrderGenerated = 14 }

    public enum ItemRequestType
    { Search = 1, SearchUntil = 2, SoldAt = 3, MktOrder = 4 }

   // public enum ContactType
   // { PrimaryContact, Sales, AccountPayable, Other }

    public enum CustomerLicsenseType
    { Dea, State, Other }

    public enum RepackStatusCodes
    { New = 10, Intake = 20, IntakeQC = 35, Packaging = 40, QC = 50, PharmCheck = 60, Shipping = 70, Invoicing = 80, Completed = 99 }

    public enum RepackLabelStatus
    { New=0,WaitingForApproval=25,Locked=99}


    public enum PedBackToType
    { AuthorizedDistributor, Manufacturer }



    public enum DrugRequestSwitchReson
    { OrgItemDiscontinued = 1, OrigItemBackordered = 6, LowerCostItemAvail = 11 }

    public enum DrugFormCode
    { Unknown, Each, Milliliters, Grams }

    public enum CustomUDRequestStatus
    { New = 0, Purchasing = 10, PCompleted = 20, Ordered = 30, LabelRequested = 40, NDCRegistering = 50, InProduction = 60, Deleted = 99 }

    public enum PackagingStyle
    { LiquidCup, PillPack, PowderPouch, Syringe }

    public enum RepackSoldIn
    { Cases, Each}

    public enum WorkOrderStatus
    { New = 10, Submitted = 20, Shipping = 30, OnRtouteToRpk = 35, Processing = 40, Invoicing = 50, QuatityCheck = 55, Receiving = 60, Completed = 70, Deleted = 99 }


    public enum ShortMonthName
    { Jan = 1, Feb = 2, Mar = 3, May = 4, Apr = 5, Jun = 6, Jul = 7, Aug = 8, Sep = 9, Oct = 10, Nov = 11, Dec = 12 }

    public enum DeaClassEnum
    {
        [ImageName("UD")]
        None = 8,
        [ImageName("OTC")]
        OTC = 9,
        [ImageName("RX")]
        RX = 0,
        [ImageName("RX")]
        RX0 = 7,
        [ImageName("cV")]
        CV = 5,
        [ImageName("CIV")]
        CIV = 4,
        [ImageName("CIII")]
        CIII = 3,
        [ImageName("CII")]
        CII = 2,
        [ImageName("C-I")]
        CI = 1
    }
    public enum eNDCFormatCode { FourFourTwo = 1, FiveThreeTwo = 2,  FiveFourOne=3}


    public enum eItemInventoryBatchStatus { Scanning, Close, Deleted}
    public enum eInventoryBatchType { Full ,Partial}

    public enum eReceiverPackageType { PO,RMA,WO,Trans,Unknown}

    public enum eRepackPackageType
    {Undefined = 0, LiquidCups=10, SolidPouch=20, Syringe=30,Powder=40, OverWrap=50, Tube=60, UnitOfUse=60 }
    public enum eSerialTypes { sequential, Random, RFXcel }

    public enum ArPaymentType
    { Check, CreditCard, Wire, CreditMemo, DebitMemo }

    public enum eRecieptOfGoodStatus
    { CheckIn = 10, WaitingForInv = 20, WaitingForPed = 30, PutAway = 40,  Completed = 99 }

    public enum eEDLItemStatus
    { AlternateAvailable = 10, Available =20, BackOrdered = 30, Discontinued = 40, OnWorkOrder= 50, Purchased= 60 , NotAvailable = 70}
}