using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraReports.UI;
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.BusinessObjects.BusinessLogic;
using RX2_Office.Module.Reports;

namespace RX2_Office.Module.Controllers.Shipping
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ShippingController : ViewController
    {
        public BarcodeUtil2 gdu;
        public ShippingController()
        {

            InitializeComponent();
            gdu = new BarcodeUtil2();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void PickingSheetPrint_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            ArrayList SelectedSo = new ArrayList();
            if ((e.SelectedObjects.Count > 0) &&
                ((e.SelectedObjects[0] is XafDataViewRecord) ||
                 (e.SelectedObjects[0] is XafInstantFeedbackRecord)))
            {
                foreach (var selectedObject in e.SelectedObjects)
                {
                    SelectedSo.Add((SOHeader)ObjectSpace.GetObject(selectedObject));
                }
            }
            else
            {
                SelectedSo = (ArrayList)e.SelectedObjects;
            }
            foreach (SOHeader selectedContact in SelectedSo)
            {
                XtraReport myReport = new rptShippingPickSht();
                myReport.DataSource = SelectedSo;


                //selectedContact.Street1 
            }
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }

        private void PickSht2_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            XtraReport myReport = new rptShippingPickSht();

            ArrayList SelectedSo = new ArrayList();
            if ((e.SelectedObjects.Count > 0) &&
                ((e.SelectedObjects[0] is XafDataViewRecord) ||
                 (e.SelectedObjects[0] is XafInstantFeedbackRecord)))
            {
                foreach (var selectedObject in e.SelectedObjects)
                {
                    SelectedSo.Add((SOHeader)ObjectSpace.GetObject(selectedObject));
                }
            }
            else
            {
                SelectedSo = (ArrayList)e.SelectedObjects;
            }

            myReport.DataSource = SelectedSo;
            foreach (SOHeader selectedSOi in SelectedSo)
            {

                selectedSOi.PickingsheetPrinted = true;
                selectedSOi.SOStatus = SalesOrderStatus.Picking;
                selectedSOi.Save();
                //selectedContact.Street1 
            }
            myReport.PrintDialog();
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }

        private void SOPack_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.PopupWindow.View.ObjectSpace.CommitChanges();
            //  ((ListView)View).CollectionSource.Reload();
            //MessageOptions options = new MessageOptions();
            //options.Duration = 3000;
            //options.Message = "Note Entered ";
            //options.Type = InformationType.Success;
            //options.Web.Position = InformationPosition.Right;
            //options.Win.Caption = "Success";
            //options.Win.Type = WinMessageType.Alert;
            //Application.ShowViewStrategy.ShowMessage(options);

            View.ObjectSpace.Refresh();
            View.Refresh();
        }

        private void SOPack_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "SOHeader_DetailView_Packing";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            SOHeader SOH = objectSpace.CreateObject<SOHeader>();
            SOH = objectSpace.GetObject<SOHeader>((SOHeader)View.CurrentObject);
            SOH.Scan = "";
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, SOH);
            e.View.Caption = e.View.Caption + " - " + SOH.CustomerNumber.CustomerName;
            e.View.ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (e.PropertyName.ToUpper() == "SCAN")
            {
                if (e.NewValue.ToString().Length > 12)
                {
                    // Might be a valid 2d barcode
                    string scan = e.NewValue.ToString();
                    //BarcodeUtil2 gdu = new BarcodeUtil2();
                    if (scan.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (scan.Length < 30)
                    {
                        string message = "You did not scan a GS1 2d barcode.";
                        string caption = "Error Detected in Input";


                    }

                    Dictionary<string, string> ScanDecodeDictionary;
                    ScanDecodeDictionary = gdu.decodeBarcodeGS1Pharma(scan);
                    int rtn = LoadScan(ScanDecodeDictionary, e);



                }
                else
                {
                }

            }

        }


        private int LoadScan(Dictionary<string, string> ScanDecodeDictionary, ObjectChangedEventArgs e)
        {
            bool addCount = false;
            string pstring;

            ScanDecodeDictionary.TryGetValue("01", out pstring);

            string pItemnumber = pstring;


            ScanDecodeDictionary.TryGetValue("17", out pstring);
            string pExpDt = pstring;

            ScanDecodeDictionary.TryGetValue("10", out pstring);
            string pLot = pstring;

            ScanDecodeDictionary.TryGetValue("21", out pstring);
            string pSerialNumber = pstring;
            int cc = 0;
            cc = cc++;
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            SOHeader SOH = objectSpace.CreateObject<SOHeader>();
            SOH = objectSpace.GetObject<SOHeader>((SOHeader)View.CurrentObject);
            SOItemDistibution SID = new SOItemDistibution(SOH.Session);

            // lets see if the serial number exists in so
            CriteriaOperator SerialCriteria = CriteriaOperator.Parse("[ItemNumber] = ? and [SerialNumber] = ?", pItemnumber, pSerialNumber);
            SOPackingSerialNo SOPSN = (SOPackingSerialNo)objectSpace.FindObject(typeof(SOPackingSerialNo), SerialCriteria);
            if (SOPSN != null)
            {
                return -1;
            }

            else // Lets add the serial number in the serial packing list

            {
                SOPSN = new SOPackingSerialNo(SOH.Session);
                SOPSN.SalesOrder = SOH;
                SOPSN.ItemNumber = pItemnumber.Substring(3);
                SOPSN.ShipQty = 1;
                SOPSN.Lot = pLot;
                SOPSN.ShipQty = 1;
                SOPSN.SerialNumber = pSerialNumber;
                SOPSN.Lot = pLot;
                SOPSN.DateEntered = System.DateTime.Today;
                SOPSN.UserName = SecuritySystem.CurrentUserName;
                SOPSN.ExpirationDate = DateTime.ParseExact(pExpDt, "yyMMdd", CultureInfo.CurrentCulture);
                SOPSN.Save();
                SOH.Session.CommitTransaction();
                addCount = true;
            }
            // lets see if item exists on the  SO Packing table

            CriteriaOperator ItemCriteria = CriteriaOperator.Parse("[ItemNumber] = ? ", pItemnumber);
            SOPacking SOP = (SOPacking)objectSpace.FindObject(typeof(SOPacking), ItemCriteria);
            if (addCount)
            {
                if (SOP != null)
                {

                    SOP.ItemQty = SOP.ItemQty++;
                }
                else
                {
                    SOP = new SOPacking(SOH.Session);
                    SOP.ItemNumber = pItemnumber;
                    SOP.SalesOrder = SOH;
                    SOP.ItemQty = 1;
                }
                SOP.Save();
            }
            SOH.Save();
            SOH.Session.CommitTransaction();
            SOH.Reload();
            SOH.SOPacking.Reload();
            SOH.SoPackingSerialNumbers.Reload();
            SOH.Scan = null;
            return 0;
        }




        private void SOPack_CustomizeTemplate(object sender, CustomizeTemplateEventArgs e)
        {

        }
    }
}
