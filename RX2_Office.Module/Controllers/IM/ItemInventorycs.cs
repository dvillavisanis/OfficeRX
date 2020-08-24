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
using RX2_Office.Module.BusinessObjects;

namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ItemInventorycs : ViewController
    {
        public ItemInventorycs()
        {
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

        private void imInventoryTransfer_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

            ItemInventoryTransfer so = (ItemInventoryTransfer)e.PopupWindowViewCurrentObject;




        }

        private void imInventoryTransfer_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ItemInventoryTransferNew_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemInventoryTransfer IITrans = objectSpace.CreateObject<ItemInventoryTransfer>();

            IITrans.InventoryItem = objectSpace.GetObject<ItemInventory>((ItemInventory)View.CurrentObject);
            IITrans.TransferStatus = ItemInventoryTransfer.eTransferStatus.New;
            IITrans.CreatedDate = DateTime.Now;
            IITrans.TransferCreatedBy = Application.Security.UserName;
            IITrans.OriginalCost = IITrans.InventoryItem.UnitCost;
            IITrans.FromWhse = IITrans.InventoryItem.Warehouse;

            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, IITrans);
            e.View.Caption = e.View.Caption + " - " + IITrans.InventoryItem.ItemNumber;

        }
    }
}
