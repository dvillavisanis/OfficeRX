using System;
using System.Collections.Generic;
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
using RX2_Office.Module.Win.Windows.Shipping;

namespace RX2_Office.Module.Win.Controllers.Shipping
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ReceiptPackageItems : ViewController
    {
        public ReceiptPackageItems()
        {
            SimpleAction showWindowAction = new SimpleAction(this, "ShowWindow",
DevExpress.Persistent.Base.PredefinedCategory.View);
            showWindowAction.ImageName = "ModelEditor_Views";
            showWindowAction.Execute +=   new SimpleActionExecuteEventHandler(ReceiptPackageItem_Execute);

            InitializeComponent();
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

        private void ReceiptPackageItem_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ReceiverPackage IR = (ReceiverPackage)e.CurrentObject;
            int iOID = IR.Oid;
            ReceiptPackageItemsScanForm form = new ReceiptPackageItemsScanForm(IR);
            form.Text = IR.RecPackageType.ToString() + ": " + IR.DocumentRefNo.ToString();
            form.ShowDialog();

        }

        private void ReceiptOfGoodsScan_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();
          


           // ReceiptOfGoodsScans RoGScan = (ReceiptOfGoodsScans)e.PopupWindowView.CurrentObject;
           // RoGScan lsg = lotGenSerial.LotId;

            //RepackLots RL = (RepackLots)objectSpace.GetObjectByKey(typeof(RepackLots), lsg.Oid);
            //eSerialTypes stype;
            //int snumber = 1965;
            //if (lsg == null)
            //{
            //    stype = eSerialTypes.sequential;
            //}
            //stype = RL.RepackItem.SerialType;

            
            //objectSpace.CommitChanges();
            //ObjectSpace.Refresh();
            //MessageOptions options = new MessageOptions();
            //options.Duration = 20000;
            //options.Message = string.Format("{0} Serial Number for Lot {1} has been entered", lotGenSerial.QtyToGenerate, lotGenSerial.LotId.LotId.ToString());
            //options.Type = InformationType.Success;
            //options.Web.Position = InformationPosition.Right;
            //options.Win.Caption = "Success";
            //options.Win.Type = WinMessageType.Alert;
            
            //Application.ShowViewStrategy.ShowMessage(options);
        }
    }
}
