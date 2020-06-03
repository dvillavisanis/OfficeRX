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
using DevExpress.ExpressApp.SystemModule;
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.BusinessObjects.BusinessLogic;
using System.Windows.Forms;
using DevExpress.Xpo;

namespace RX2_Office.Module.Controllers.Shipping
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.

    public partial class EditInventoryItemBatch : ViewController
    {
        private DetailView createdView;
       // private DetailView view;
      
        private PopupWindowShowAction editInventoryItemBatchAction;
        private ItemInventoryBatch IIB;
        private CustomizePopupWindowParamsEventArgs E;
        private ItemInventoryBatch objectToShow;
        //private ListViewProcessCurrentObjectController processCurrentObjectController;
        public EditInventoryItemBatch()
        {
            InitializeComponent();

            TargetObjectType = typeof(ItemInventoryBatch);
            editInventoryItemBatchAction =
                new PopupWindowShowAction(this, "EditInventoryItemBatchRecord", PredefinedCategory.Edit);
            editInventoryItemBatchAction.ToolTip = "Edit Inventory Batch Record";
            editInventoryItemBatchAction.Caption = "Item Scan";

            editInventoryItemBatchAction.ImageName = "Action_Edit";

            editInventoryItemBatchAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            editInventoryItemBatchAction.Execute += EditInventoryItemBatchAction_Execute;
            editInventoryItemBatchAction.CustomizePopupWindowParams += EditInventoryItemBatchPopup_CustomizePopupWindowParams
                ;
            ////InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

        private void EditInventoryItemBatchAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            // IObjectSpace newObjectSpace = e.View.ObjectSpace;
            // IObjectSpace newObjectSpace = Application.CreateObjectSpace();
            IObjectSpace newObjectSpace = Application.CreateObjectSpace(View.ObjectTypeInfo.Type);
            objectToShow = (ItemInventoryBatch)newObjectSpace.GetObject(View.CurrentObject);
            //objectToShow = newObjectSpace.GetObject(View.CurrentObject);
            if (objectToShow != null)
            {
                IIB = (ItemInventoryBatch)View.CurrentObject;
                createdView = Application.CreateDetailView(newObjectSpace, IIB);
                createdView.ViewEditMode = ViewEditMode.Edit;
                e.View = createdView;
                IIB.LastScan = "";
                E = e;
             //   IIB.LastScanChangedEvent += IIB_LastScanChangedEvent;
            }
        }

        private void EditInventoryItemBatchAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ////   IENavigationHistorySequenceStrategy;
            //TargetViewId = "ItemInventoryBatch_DetailView";

            //IIB = (ItemInventoryBatch)e.CurrentObject;
            //IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ItemInventoryBatch));
            ////IObjectSpace objectSpace =; 

            //IIB.LastScanChangedEvent += IIB_LastScanChangedEvent;
            //view = Application.CreateDetailView(objectSpace, IIB, true);



            //view.Caption = "Batch: " + IIB.BatchDiscription;

        }


        //private void IIB_LastScanChangedEvent(object sender, string e)
        //{
        //    scancount++;
        //    string scan = e;


        //}

        protected override void OnActivated()
        {
            //processCurrentObjectController = Frame.GetController<ListViewProcessCurrentObjectController>();
            //if (processCurrentObjectController != null)
            //{
            //    processCurrentObjectController.CustomProcessSelectedItem += ProcessCurrentObjectController_CustomProcessSelectedItem;

            //}


            base.OnActivated();
            // View.CurrentObjectChanged += View_CurrentObjectChanged;

            // IIB.LastScanChangedEvent += IIB_LastScanChangedEvent;


            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            //if (processCurrentObjectController != null)
            //{
            //    processCurrentObjectController.CustomProcessSelectedItem -= ProcessCurrentObjectController_CustomProcessSelectedItem
            //        ;

            //}
            base.OnDeactivated();

            // Unsubscribe from previously subscribed events and release other references and resources.
        }


       


        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        private void EditInventoryItemBatchPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {


        }

        private void EditInventoryItemBatchPopup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ItemInventoryBatch_DetailView";
            {
                IObjectSpace newObjectSpace = Application.CreateObjectSpace(View.ObjectTypeInfo.Type);
                objectToShow = (ItemInventoryBatch)newObjectSpace.GetObject(View.CurrentObject);
              
                if (objectToShow != null)
                {
                    createdView = Application.CreateDetailView(newObjectSpace, objectToShow);
                    createdView.ViewEditMode = ViewEditMode.Edit;

                    e.View = createdView;


                    objectToShow.LastScanChangedEvent += ObjectToShow_LastScanChangedEvent;

                }
            }
        }

        private void View_ControlsCreated(object sender, EventArgs e)
        {
            PropertyEditor editor = ((DetailView)createdView).FindItem("LastScan") as PropertyEditor;
            if (editor != null)
            {
                // IIB.LastScan = string.Empty;
                (editor.Control as Control).Focus();
                (editor.Control as Control).Select();
                (editor.Control as Control).ResetText();
            }

        }

        private void ObjectToShow_LastScanChangedEvent(object sender, string Scan)
        {
            string itemnumber;
            string lot;
            string expdate;
            string serialnumber;
            string scan = Scan;
            BarcodeUtil2 gdu = new BarcodeUtil2();
            if (scan.ToString() == string.Empty)
            {
                return;
            }
            if (scan.Length < 30)
            {
                string message = "You did not scan a GS1 2d barcode.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);



                //  txtBarcode.Text = string.Empty;
                //  txtBarcode.Focus();

                //  txtBarcode.Clear();
                return;
            }
            Dictionary<string, string> BarcodeDecodeDictionary;
            BarcodeDecodeDictionary = gdu.decodeBarcodeGS1Pharma(scan);


            string pstring;

            BarcodeDecodeDictionary.TryGetValue("01", out pstring);

            itemnumber = pstring;


            BarcodeDecodeDictionary.TryGetValue("17", out pstring);
            expdate = pstring;

            BarcodeDecodeDictionary.TryGetValue("10", out pstring);
            lot = pstring;

            BarcodeDecodeDictionary.TryGetValue("21", out pstring);
            serialnumber = pstring;
            int ret = 1;

            if (serialnumber != null)
            {
                ret = AddToSerialNumber(itemnumber, lot, serialnumber, expdate, scan);
            }


            if (ret > 0)
            {
                ret = AddToItems(sender, itemnumber, lot, expdate, scan);
            }

            this.View.Refresh();
            this.View.ObjectSpace.ReloadObject(sender);


            PropertyEditor editor = ((DetailView)createdView).FindItem("LastScan") as PropertyEditor;
            if (editor != null)
            {
                // IIB.LastScan = string.Empty;
                (editor.Control as Control).Focus();
                (editor.Control as Control).Select();
                (editor.Control as Control).ResetText();
            }



            // ret = AddToSerialNumber(itemnumber, lot, serialnumber, expdate, scan);

            //  txtBarcode.Focus();
            //  txtBarcode.Clear();

        }


        private int AddToItems(object sender, string itemnumber, string lot, string expdate, string scan)
        {
            // this counts for non serialized numbers


            // editor1 = ((DetailView)View).FindItem("Items") as ListPropertyEditor;
            IObjectSpace objectspace = this.ObjectSpace.CreateNestedObjectSpace();

            // InventoryItemBatchItems iiBi = this.ObjectSpace.GetObject<InventoryItemBatchItems>();

            ItemInventoryBatch iib = objectToShow;

            // Find the item in the item list
            bool found = false;
            Session session;
            session = objectToShow.Session;
            CriteriaOperator op = GroupOperator.Combine(GroupOperatorType.And,
                new BinaryOperator("InventoryBatch", iib.Oid),
              new BinaryOperator("NDC", itemnumber),
              new BinaryOperator("Lot", lot));

            InventoryItemBatchItems itemToUpdate = (InventoryItemBatchItems)session.FindObject(typeof(InventoryItemBatchItems),
                op, true);


            if (itemToUpdate != null)
            {
                itemToUpdate.Qty++;
                itemToUpdate.Save();
                session.CommitTransaction();

            }
            else
            {
                InventoryItemBatchItems iibi;

                iibi = objectspace.CreateObject<InventoryItemBatchItems>();


                iibi.InventoryBatch = objectspace.GetObject<ItemInventoryBatch>((ItemInventoryBatch)this.View.CurrentObject);
                //iibi.InventoryBatch.Oid = iib.Oid;

                iibi.NDC = itemnumber;
                iibi.Lot = lot;
                iibi.Qty = 1;
                DateTime result;
                if (DateTime.TryParse(expdate, out result))
                {
                    iibi.ExpirationDate = result;
                }
                iibi.Save();
                objectspace.CommitChanges();
                // objectspace.Refresh();
            }

            objectToShow.Save();
            this.View.ObjectSpace.CommitChanges();
            objectToShow.ItemInventoryBatchS.Reload();
            objectToShow.Item.Reload();
            //jectSpace.ReloadObject();
            
            this.View.ObjectSpace.Refresh();
            return 1;

        }
        private int AddToSerialNumber(string itemnumber, string lot, string serialnumber, string expdate, string scan)
        {
            IObjectSpace objectspace = this.ObjectSpace.CreateNestedObjectSpace();

            // InventoryItemBatchItems iiBi = this.ObjectSpace.GetObject<InventoryItemBatchItems>();

            ItemInventoryBatch iib = objectToShow;

            // Find the item in the item list
            bool found = false;
            Session session;
            session = objectToShow.Session;
            CriteriaOperator op = GroupOperator.Combine(GroupOperatorType.And,
                new BinaryOperator("ItemInventoryBatch", iib.Oid),
              new BinaryOperator("NDC", itemnumber),
              new BinaryOperator("Lot", lot),
              new BinaryOperator("SerialNumber", serialnumber));

            ItemInventoryBatchSerialNo itemToUpdate = (ItemInventoryBatchSerialNo)session.FindObject(typeof(ItemInventoryBatchSerialNo),
                op, true);


            if (itemToUpdate != null)
            {
                return -1;

            }
            else
            {
                ItemInventoryBatchSerialNo iibi;

                iibi = objectspace.CreateObject<ItemInventoryBatchSerialNo>();


                iibi.ItemInventoryBatch = objectspace.GetObject<ItemInventoryBatch>((ItemInventoryBatch)this.View.CurrentObject);


                iibi.NDC = itemnumber;
                iibi.Lot = lot;
                iibi.Barcode = scan;
                iibi.SerialNumber = serialnumber;
                DateTime result;
                if (DateTime.TryParse(expdate, out result))
                {
                    iibi.ExpDate = result;
                }
                iibi.Save();
                objectspace.CommitChanges();
                //  objectspace.Refresh();
            }
            objectToShow.Item.Reload();
            //jectSpace.ReloadObject();
           
            this.View.ObjectSpace.CommitChanges();
            this.View.ObjectSpace.Refresh();
            
            
            return 1;
        }
    }
}
