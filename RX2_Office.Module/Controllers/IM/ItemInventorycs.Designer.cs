namespace RX2_Office.Module.Controllers
{
    partial class ItemInventorycs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Quanatine = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.imInventoryTransfer = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.imInventoryAdjustment = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // Quanatine
            // 
            this.Quanatine.AcceptButtonCaption = null;
            this.Quanatine.CancelButtonCaption = null;
            this.Quanatine.Caption = "Quarantine";
            this.Quanatine.Category = "RecordEdit";
            this.Quanatine.ConfirmationMessage = null;
            this.Quanatine.Id = "ItemQuarentine";
            this.Quanatine.ImageName = "Quarantine";
            this.Quanatine.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.Quanatine.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.Quanatine.TargetObjectsCriteria = "QtyOnHand > 0 ";
            this.Quanatine.ToolTip = "Quarantine this item";
            // 
            // imInventoryTransfer
            // 
            this.imInventoryTransfer.AcceptButtonCaption = null;
            this.imInventoryTransfer.CancelButtonCaption = null;
            this.imInventoryTransfer.Caption = "Inv Transfer";
            this.imInventoryTransfer.Category = "Edit";
            this.imInventoryTransfer.ConfirmationMessage = null;
            this.imInventoryTransfer.Id = "imInventoryTransfer";
            this.imInventoryTransfer.ImageName = "IM/InventoryTransfer";
            this.imInventoryTransfer.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.imInventoryTransfer.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.imInventoryTransfer.TargetObjectsCriteria = "QtyOnHand >0";
            this.imInventoryTransfer.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemInventory);
            this.imInventoryTransfer.ToolTip = null;
            this.imInventoryTransfer.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.imInventoryTransfer_CustomizePopupWindowParams);
            this.imInventoryTransfer.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.imInventoryTransfer_Execute);
            // 
            // imInventoryAdjustment
            // 
            this.imInventoryAdjustment.AcceptButtonCaption = null;
            this.imInventoryAdjustment.CancelButtonCaption = null;
            this.imInventoryAdjustment.Caption = "Inv Adjustment";
            this.imInventoryAdjustment.Category = "Edit";
            this.imInventoryAdjustment.ConfirmationMessage = null;
            this.imInventoryAdjustment.Id = "imInventoryAdjustment";
            this.imInventoryAdjustment.ImageName = "im/InventoryAdjustment";
            this.imInventoryAdjustment.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.imInventoryAdjustment.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.imInventoryAdjustment.ToolTip = null;
            // 
            // ItemInventorycs
            // 
            this.Actions.Add(this.Quanatine);
            this.Actions.Add(this.imInventoryTransfer);
            this.Actions.Add(this.imInventoryAdjustment);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemInventory);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction Quanatine;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction imInventoryTransfer;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction imInventoryAdjustment;
    }
}
