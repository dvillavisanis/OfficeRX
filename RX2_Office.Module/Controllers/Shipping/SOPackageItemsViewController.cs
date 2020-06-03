using System;
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
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.BusinessObjects.BusinessLogic;

namespace RX2_Office.Module.Controllers.Shipping
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SOPackageItemsViewController : ViewController
    {
        ReceiverPackageItems RPI;
        public SOPackageItemsViewController()
        {
            InitializeComponent();
            RegisterActions(components);
        }
        // Target required Views (via the TargetXXX properties) and create their Actions.
    
        private void propertyEditor_ControlCreated(Object sender, EventArgs e)
        {
            InitNullText((PropertyEditor)sender);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            ((CompositeView)View).ItemsChanged += ScanRecieveItems_ItemChanged;
          //  TryInitializeBarCodeItem();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        //private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        //{
        //    if (ViewCurrentObject != null)
        //    {
        //        if (e.PropertyName == "BarCode")
        //        {
        //            ViewCurrentObject.RetroDate = ViewCurrentObject.EffectiveDate;
        //        }
        //    }
        //}
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ((CompositeView)View).ItemsChanged -= ScanRecieveItems_ItemChanged;
        }
    
        private void InitNullText(PropertyEditor propertyEditor)
        {
            ((DevExpress.XtraEditors.BaseEdit)propertyEditor.Control).Properties.NullText = CaptionHelper.NullValueText;
        }

        private void ScanRecieveItems_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            ReceiverPackage RP = (ReceiverPackage)e.PopupWindowViewCurrentObject;
            //string erromsg;

            MessageOptions options = new MessageOptions();
            //if (CBL.SoComplianceCheck(so, out erromsg) == 0)
            //{

            //    options.Duration = 20000;
            //    options.Message = string.Format("Sales Order for {0} has been entered", so.CustomerNumber.CustomerName);
            //    options.Type = InformationType.Success;
            //    options.Web.Position = InformationPosition.Right;
            //    options.Win.Caption = "Success";
            //    options.Win.Type = WinMessageType.Alert;
            //}
            //else
            //{

            //    options.Duration = 20000;
            //    options.Message = string.Format("Sales Order for {0} has been entered is in Compliance due to the following {1}", so.CustomerNumber.CustomerName, erromsg);
            //    options.Type = InformationType.Warning;
            //    options.Web.Position = InformationPosition.Right;
            //    options.Win.Caption = "Success Need Compliance";
            //    options.Win.Type = WinMessageType.Alert;
            //}
            //options.OkDelegate = () => {
            //    IObjectSpace os = Application.CreateObjectSpace(typeof(Customer));
            // DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ItemRequest>());
            // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
            //};
            //Application.ShowViewStrategy.ShowMessage(options);

        }


        private void ScanRecieveItems_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ReceiverPackageItems_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            RPI = objectSpace.CreateObject<ReceiverPackageItems>();
            RPI.ReceiverPackageId = objectSpace.GetObject<ReceiverPackage>((ReceiverPackage)View.CurrentObject);
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, RPI);
            e.View.Caption = e.View.Caption + " - " + RPI.ReceiverPackageId.Oid.ToString();
            //e.Size = new Size(1000, 1000);
          
        }
        public void TryInitializeBarCodeItem()
        {
            //PropertyEditor propertyEditor = ((DetailView)View).FindItem("BarCode") as PropertyEditor;
            //if (propertyEditor != null)
            //{
            //    if (propertyEditor.Control != null)
            //    {
            //        InitNullText(propertyEditor);
            //    }
            //    else
            //    {
            //        propertyEditor.ControlCreated += new EventHandler<EventArgs>(propertyEditor_ControlCreated);
            //    }
            //}
        }
        private void ScanRecieveItems_ItemChanged(object sender, ViewItemsChangedEventArgs e)
        {
            if (e.ChangedType == ViewItemsChangedType.Added && e.Item.Id == "BarCode")
            {
                ParseBarcode(e.Item.ObjectTypeInfo.ToString());
            }
        }


        private void ParseBarcode(string pBarCode)
        {
           // pBarCode = RPI.BarCode;
            if (pBarCode.Length > 21)
            // Assume it is a 2d barcode
            {
                BarcodeUtil2 gs1 = new BarcodeUtil2();
                Dictionary<String, String> DGS1;
                DGS1 = gs1.decodeBarcodeGS1Pharma(pBarCode);
                string gtin = DGS1["01"];
                string expirationdt = DGS1["17"];
                string lot = "";
                DGS1.TryGetValue("10", out lot);
                string SerialNumber = "";
                DGS1.TryGetValue("21", out SerialNumber);
               RPI.Lot = lot;
               // RPI.SerialNumber = SerialNumber;
                RPI.ItemNumber = gtin.Substring(3, 10);
                //the day could be 00
                if (expirationdt.Substring(4, 2) == "00")
                {
                    expirationdt = expirationdt.Substring(0, 4) + "28";
                }
                RPI.ExpireDate = DateTime.ParseExact(expirationdt, "yyMMdd", CultureInfo.InvariantCulture);
                RPI.Save();
            }
        }
    }
}


