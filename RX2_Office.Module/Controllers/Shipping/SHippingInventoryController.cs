using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.XtraEditors;
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.BusinessObjects.BusinessLogic;

namespace RX2_Office.Module.Controllers.Shipping
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SHippingInventoryController : ViewController
    {
      //  private ListViewProcessCurrentObjectController processCurrentObjectController;
        private ItemInventoryBatch IIB;
        private int scancount = 0;
        public SHippingInventoryController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            //TargetObjectType = typeof(ItemInventoryBatch);
            //SimpleAction editItemInventoryBatchRecordAction =
            //    new SimpleAction(this, "EditInventoryItemBatch", PredefinedCategory.Edit);
            //editItemInventoryBatchRecordAction.ImageName = "Action_Edit";
            //editItemInventoryBatchRecordAction.SelectionDependencyType =
            //    SelectionDependencyType.RequireSingleObject;
            //editItemInventoryBatchRecordAction.Execute += EditItemInventoryBatchRecordAction_Execute;

        }

        

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //  ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        
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






        private void ShInventoryController_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

            e.PopupWindow.View.ObjectSpace.CommitChanges();

            View.ObjectSpace.Refresh();
            View.Refresh();
            
            MessageOptions options = new MessageOptions();
            if (1 == 1)
            {

                options.Duration = 20000;
                options.Message = string.Format("Inventory Batch for {0} has been entered", "dan test");
                options.Type = InformationType.Success;
                options.Web.Position = InformationPosition.Right;
                options.Win.Caption = "Success";
                options.Win.Type = WinMessageType.Alert;
            }
            else
            {

                options.Duration = 20000;
                options.Message = string.Format("Inventory Batch for {0} has been entered is in Compliance due to the following ", "Dan Test");
                options.Type = InformationType.Warning;
                options.Web.Position = InformationPosition.Right;
                options.Win.Caption = "Success Need Compliance";
                options.Win.Type = WinMessageType.Alert;
            }

            Application.ShowViewStrategy.ShowMessage(options);

        }

        private void ShInventoryController_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
           ;
            TargetViewId = "ItemInventoryBatch_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();

            IIB = objectSpace.CreateObject<ItemInventoryBatch>();
            // subscribe to the LastScanChanged event to capture the scans
            IIB.LastScanChangedEvent += IIB_LastScanChangedEvent;

            //objectSpace.ObjectEndEdit 
            IIB.CreatedDate = DateTime.Now;
            IIB.InventoryType = eInventoryBatchType.Partial;
            IIB.CreatedBy = SecuritySystem.CurrentUserName;
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, IIB);
            e.View.Caption = e.View.Caption + " - " + IIB?.Oid.ToString();
            IIB.Save();

        }

        private void IIB_LastScanChangedEvent(object sender, string e)
        {
              ItemInventoryBatch iib = (ItemInventoryBatch)sender;
            if (e == string.Empty)
            {
                return;
            }

            scancount++;
            string scan = e;
            PropertyEditor editor;
            BarcodeUtil2 gdu = new BarcodeUtil2();
            
            if (scan.Length < 30)
            {
                string message = "You did not scan a GS1 2d barcode.";
                //string caption = "Error Detected in Input";
                // MessageBoxButtons buttons = MessageBoxButtons.OK;
                //DialogResult result;
                Application.ShowViewStrategy.ShowMessage(message);
               
                editor = ((DetailView)View).FindItem("LastScan") as PropertyEditor;
                if (editor != null)
                {
                    (editor.Control as Control).Focus();
                }


                return;
            }
            if (iib.Oid == -1)
            {
                iib.Save();
                
            }

            

            AddToItem(iib, e);
            AddToItemSerial(iib, e);

            // now set the focus back to LastScan and empty out values
            editor = ((DetailView)View).FindItem("LastScan") as PropertyEditor;
            if (editor != null)
            {


                IIB.LastScan = string.Empty;


                (editor.Control as Control).Focus();
            }

        }

        private void AddToItemSerial(ItemInventoryBatch itemInventoryBatch, string e)
        {
            IObjectSpace objectSpace = View.ObjectSpace.CreateNestedObjectSpace();
            ItemInventoryBatchSerialNo itemSerials = objectSpace.CreateObject<ItemInventoryBatchSerialNo >();
            itemSerials.ItemInventoryBatch = itemInventoryBatch;
            itemSerials.NDC = "123456";
            itemSerials.SerialNumber = "ssn123456";
            itemSerials.Lot = "lot123";
            itemSerials.ExpDate = DateTime.Now;


        }

        private void AddToItem(ItemInventoryBatch itemInventoryBatch, string e)
        {
            IObjectSpace objectSpace = View.ObjectSpace.CreateNestedObjectSpace();
            InventoryItemBatchItems items = objectSpace.CreateObject<InventoryItemBatchItems>( );
            items.InventoryBatch = itemInventoryBatch;

            items.NDC = "123456";
            items.Qty = 1;
            items.Lot = "lot123";
            items.ExpirationDate = DateTime.Now;
            items.Save();
                                              
            objectSpace.CommitChanges();

        }
    }
}
